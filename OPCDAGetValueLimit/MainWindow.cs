using Softing.OPCToolbox;
using Softing.OPCToolbox.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DATest
{
    public partial class MainWindow : Form
    {
        Thread ReadFileContentThread = null;         // 读取字段
        bool isStopReadFileContentThread = true;

        Thread ReadFileContent_AttrThread = null;    // 读取属性
        bool isStopReadFileContent_AttrThread = true;

        Thread ReadFileContent_TagThread = null;    // 拼接
        bool isStopReadFileContent_TagThread = true;

        Thread ReadValueThread = null;              // 读值
        bool isStopReadValueThread = true;

        Thread WatchValueChangeThread = null;       //  监控
        public static bool isStopWatchValueChangeEvent = true;

        OpcClient watchValueChangeOPCClient = null;

        SynchronizationContext _syncContext = null; //子线程更改UI

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("./Config/LicenseAndURL.config"))
            {
                string[] configInfo = File.ReadAllText("./Config/LicenseAndURL.config").Split('@');
                LicenseAndOPCURL.licenseString = configInfo[0];
                LicenseAndOPCURL.opcUrlString = configInfo[1];
            }

            //获取UI线程同步上下文  
            _syncContext = SynchronizationContext.Current;

            openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
            openFileDialog.Title = "Select a File";

            if (!Directory.Exists("./Config"))
            {
                Directory.CreateDirectory("./Config");
            }
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {// Show the Dialog.
                SelectedFilePath.Text = openFileDialog.FileName;
                ReadFileContent_Click(null, null);
            }
        }

        private void ClearContent_Click(object sender, EventArgs e)
        {
            FileContentList.Items.Clear();
        }

        private void ReadFileContent_Click(object sender, EventArgs e)
        {
            isStopReadFileContentThread = false;
            if (SelectedFilePath.Text == string.Empty) MessageBox.Show("请选择要读取的文件!");
            else
            {
                if (ClearBeforeRead.Checked) FileContentList.Items.Clear();

                ReadFileContentThread = new Thread(ReadFileContentThreadFunction);
                ReadFileContentThread.IsBackground = true;
                ReadFileContentThread.Start();

                StatusMsg.Text = "正在读取文件，请稍等...";
            }
        }

        private void ReadFileContentThreadFunction()
        {
            string fileContent = File.ReadAllText(SelectedFilePath.Text, FileEncoding.Checked ? Encoding.UTF8 : Encoding.Default);
            string[] splittedString = fileContent.Split(SplitChoose.Checked ? '\n' : ';');
            foreach (string s in splittedString)
            {
                if (s.Trim() != string.Empty) _syncContext.Post(ReadFileToAddItems, s.Trim());//子线程中通过UI线程上下文更新UI  
                //Thread.Sleep(1);
                if (isStopReadFileContentThread) break;
            }
            if (!isStopReadFileContentThread) StatusMsg.Text = "读取文件完成.";
            SelectAll.CheckState = CheckState.Checked;
        }

        private void ReadFileToAddItems(object state)
        {
            FileContentList.Items.Add(state.ToString(), true);
        }

        private void StopRead_Click(object sender, EventArgs e)
        {
            isStopReadFileContentThread = true;

            while (ReadFileContentThread != null && ReadFileContentThread.ThreadState != ThreadState.Stopped)
            {
                ReadFileContentThread.Abort();
                Thread.Sleep(100);
            }
            ReadFileContentThread = null;

            StatusMsg.Text = "已停止文件读取.";
        }

        private void FileContentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileContentList.CheckedIndices.Count == FileContentList.Items.Count)
            {
                SelectAll.CheckState = CheckState.Checked;
            }

            if (FileContentList.CheckedIndices.Count < FileContentList.Items.Count)
            {
                SelectAll.CheckState = CheckState.Unchecked;
            }
        }

        private void FileEncoding_CheckedChanged(object sender, EventArgs e)
        {
            ReadFileContent_Click(null, null);
        }

        private void ReadValues_Click(object sender, EventArgs e)
        {
            isStopReadValueThread = false;

            ReadValueThread = new Thread(ReadValueThreadFunction);
            ReadValueThread.IsBackground = true;
            ReadValueThread.Start();

            StatusMsg.Text = "开始连接OPC...";
        }

        private void ReadValueThreadFunction()
        {
            List<string> items = CheckedItemCollection2ListString(TagsList.CheckedItems);

            //不需要处理多余注释就可以读取值？？？
            //List<string> items_copy = new List<string>();
            //foreach (string tempString in (List<string>)p_items)
            //{
            //    if (tempString.Contains<char>('('))
            //    {
            //        string ttt_s = tempString.Split('(')[0].Trim();
            //        if (ttt_s == string.Empty) continue;
            //        else
            //        {
            //            items_copy.Add(tempString);
            //        }
            //    }
            //    else
            //    {
            //        items_copy.Add(tempString);
            //    }
            //}
            //List<string> items = items_copy;

            OpcClient readValueOPCClient = null;
            int result = (int)EnumResultCode.S_OK;
            try
            {
                readValueOPCClient = new OpcClient();

                //	initialize the client instance
                if (!ResultCode.SUCCEEDED(readValueOPCClient.Initialize())) throw new Exception("readValueOPCClient.Initialize():Initialize the client instance error!");

                //	initialize the DA client simulation
                result |= readValueOPCClient.InitializeDaObjects(items);
                if (!ResultCode.SUCCEEDED(result)) throw new Exception("readValueOPCClient.InitializeDaObjects():Initialize the DA client simulation error!");
            }
            catch (Exception exc)
            {
                MessageBox.Show("ReadValueThreadFunction:" + exc.ToString());
            }
            finally
            {
                if (readValueOPCClient != null)
                {
                    readValueOPCClient.Terminate();
                    readValueOPCClient = null;
                }
            }

            if (!ResultCode.SUCCEEDED(result))
            {
                StatusMsg.Text = "操作异常.";
                return;
            }

            //m_opcClient.ActivateSession(false);   //异步激活
            readValueOPCClient.ActivateSession(true);   //同步激活
            StatusMsg.Text = "已激活Session，正在读取Value，请稍等...";

            Dictionary<string, string> valueList = readValueOPCClient.ReadItems();
            StatusMsg.Text = "Value读取完成, 正在显示（保存）Value，请稍等...";
            //--------------------------------------------------------------------------------

            if (SaveToFile.Checked)
            {
                File.Delete(@"./vlaueInfo.txt");
                foreach (KeyValuePair<string, string> kvp in valueList)
                {
                    File.AppendAllText(@"./vlaueInfo.txt", "Key = " + kvp.Key + ", Value = " + kvp.Value + "\r\n");

                    // 判断是否是第一次读取值，如果不是则判断value是否change.
                    if (GettedValueListView.Items.Count > 0)
                    {
                        ListViewItem findResult = GettedValueListView.FindItemWithText(kvp.Key, true, 0, false);
                        int index = GettedValueListView.Items.IndexOf(findResult);
                        if (index >= 0)
                        {
                            if (GettedValueListView.Items[index].SubItems[1].Text.Split('(')[0] != kvp.Value.Split('(')[0])
                            {
                                GettedValueListView.Items[index].SubItems[1].Text = kvp.Value;
                                GettedValueListView.Items[index].BackColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = kvp.Key;
                            lvi.SubItems.Add(kvp.Value);
                            GettedValueListView.Items.Add(lvi);
                        }
                    }
                    else
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = kvp.Key;
                        lvi.SubItems.Add(kvp.Value);
                        GettedValueListView.Items.Add(lvi);
                    }

                    if (isStopReadValueThread) break;
                }
            }
            else
            {
                foreach (KeyValuePair<string, string> kvp in valueList)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = kvp.Key;
                    lvi.SubItems.Add(kvp.Value);
                    GettedValueListView.Items.Add(lvi);

                    if (isStopReadValueThread) break;
                }
            }
            if (isStopReadValueThread) StatusMsg.Text = "已停止显示（保存）Value.";
            else StatusMsg.Text = "显示（/保存）Value完成.";

            GettedValueListView.Columns[0].Width = -1;
            GettedValueListView.Columns[1].Width = -2;
        }

        private void SelectAll_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectAll.Checked)
            {
                //全选
                for (int index = 0; index < FileContentList.Items.Count; index++)
                {
                    FileContentList.SetItemChecked(index, true);
                }
            }
            else
            {
                //取消全选
                foreach (int index in FileContentList.CheckedIndices)
                {
                    FileContentList.SetItemChecked(index, false);
                }
            }
        }

        private void OpenFile_Attr_Click(object sender, EventArgs e)
        {
            // Show the Dialog.
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectedFilePath_Attr.Text = openFileDialog.FileName;
                ReadFileContent_Attr_Click(null, null);
            }
        }

        private void ReadFileContent_Attr_Click(object sender, EventArgs e)
        {
            isStopReadFileContent_AttrThread = false;
            if (SelectedFilePath_Attr.Text == string.Empty) MessageBox.Show("请选择要读取的属性文件!");
            else
            {
                if (ClearBeforeRead_Attr.Checked) FileContentList_Attr.Items.Clear();

                ReadFileContent_AttrThread = new Thread(ReadFileContent_AttrThreadFunction);
                ReadFileContent_AttrThread.IsBackground = true;
                ReadFileContent_AttrThread.Start();

                StatusMsg.Text = "正在读取属性文件，请稍等...";
            }
        }

        private void ReadFileContent_AttrThreadFunction()
        {
            string file_AttrContent = File.ReadAllText(SelectedFilePath_Attr.Text, FileEncoding_Attr.Checked ? Encoding.UTF8 : Encoding.Default);
            string[] splittedString = file_AttrContent.Split(SplitChoose_Attr.Checked ? '\n' : ';');
            foreach (string s in splittedString)
            {
                if (s.Trim() != string.Empty) _syncContext.Post(ReadFile_AttrToAddItems, s.Trim());//子线程中通过UI线程上下文更新UI  
                //Thread.Sleep(1);
                if (isStopReadFileContent_AttrThread) break;
            }
            if (!isStopReadFileContent_AttrThread) StatusMsg.Text = "读取文件完成.";
            SelectAll_Attr.CheckState = CheckState.Checked;
        }

        private void ReadFile_AttrToAddItems(object state)
        {
            FileContentList_Attr.Items.Add(state.ToString(), true);
        }

        private void StopRead_Attr_Click(object sender, EventArgs e)
        {
            isStopReadFileContent_AttrThread = true;

            while (ReadFileContent_AttrThread != null && ReadFileContent_AttrThread.ThreadState != ThreadState.Stopped)
            {
                ReadFileContent_AttrThread.Abort();
                Thread.Sleep(100);
            }
            ReadFileContent_AttrThread = null;

            StatusMsg.Text = "已停止文件属性读取.";
        }

        private void ClearContent_Attr_Click(object sender, EventArgs e)
        {
            FileContentList_Attr.Items.Clear();
        }

        private void SelectAll_Attr_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectAll_Attr.Checked)
            {
                //全选
                for (int index = 0; index < FileContentList_Attr.Items.Count; index++)
                {
                    FileContentList_Attr.SetItemChecked(index, true);
                }
            }
            else
            {
                //取消全选
                foreach (int index in FileContentList_Attr.CheckedIndices)
                {
                    FileContentList_Attr.SetItemChecked(index, false);
                }
            }
        }

        private void FileContentList_Attr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FileContentList_Attr.CheckedIndices.Count == FileContentList_Attr.Items.Count)
            {
                SelectAll_Attr.CheckState = CheckState.Checked;
            }

            if (FileContentList_Attr.CheckedIndices.Count < FileContentList_Attr.Items.Count)
            {
                SelectAll_Attr.CheckState = CheckState.Unchecked;
            }
        }

        private void GetTags_Click(object sender, EventArgs e)
        {
            isStopReadFileContent_TagThread = false;
            if (ClearBeforeRead_Tag.Checked) TagsList.Items.Clear();

            File.Delete(@"./TestDA_Item.txt");

            ReadFileContent_TagThread = new Thread(ReadFileContent_TagThreadFunction);
            ReadFileContent_TagThread.IsBackground = true;
            ReadFileContent_TagThread.Start();

            StatusMsg.Text = "正在拼接，请稍等...";
        }

        public static List<string> CheckedItemCollection2ListString(CheckedListBox.CheckedItemCollection colletction)
        {
            List<string> result = new List<string>();
            foreach (string s in colletction)
            {
                result.Add(s);
            }
            return result;
        }

        private void ReadFileContent_TagThreadFunction()
        {
            ////net3.5
            //List<string> items = FileContentList.CheckedItems.Cast<string>().ToList();
            //List<string> items_Attr = FileContentList_Attr.CheckedItems.Cast<string>().ToList();

            // net2.0
            List<string> items = CheckedItemCollection2ListString(FileContentList.CheckedItems);
            List<string> items_Attr = CheckedItemCollection2ListString(FileContentList_Attr.CheckedItems);

            if (items.Count == 0 || items_Attr.Count == 0)
            {
                MessageBox.Show("PointSet or pointSet property is empty!");
                StatusMsg.Text = "操作异常.";
                return;
            }

            int result = (int)EnumResultCode.S_OK;
            OpcClient opcClient = null;
            try
            {
                opcClient = new OpcClient();

                //	initialize the client instance
                if (!ResultCode.SUCCEEDED(opcClient.Initialize())) throw new Exception("opcClient.Initialize():Initialize the client instance error!");

                //	initialize the DA client simulation
                result |= opcClient.InitializeDaObjects();
                if (!ResultCode.SUCCEEDED(result)) throw new Exception("opcClient.InitializeDaObjects():Initialize the DA client simulation error!");

                DaAddressSpaceElement testAddressSpaceElement = new DaAddressSpaceElement(EnumAddressSpaceElementType.BRANCH, String.Empty, string.Empty, string.Empty, 0, null);
                testAddressSpaceElement.Session = opcClient.GetSession(); ;
                MyTest(testAddressSpaceElement, items, items_Attr);
            }
            catch (Exception exc)
            {
                MessageBox.Show("ReadFileContent_TagThreadFunction:" + exc.ToString());
            }
            finally
            {
                items.Clear();
                items = null;

                items_Attr.Clear();
                items_Attr = null;

                if (opcClient != null)
                {
                    opcClient.Terminate();
                    opcClient = null;
                }
            }

            if (!ResultCode.SUCCEEDED(result))
            {
                StatusMsg.Text = "操作异常.";
            }
            else
            {
                StatusMsg.Text = "拼接操作结束.";
                SelectAll_Tag.CheckState = CheckState.Checked;
            }
        }

        private void MyTest(DaAddressSpaceElement element, List<string> items, List<string> items_Attr)
        {
            if (isStopReadFileContent_TagThread) throw new Exception("手动停止Tag拼接.");

            DaAddressSpaceElementBrowseOptions browseOptions = null;
            browseOptions.ElementTypeFilter = EnumAddressSpaceElementType.ALL;
            ExecutionOptions m_executionOptions = null;
            DaAddressSpaceElement[] testAddressSpaceElements = null;

            try
            {
                browseOptions = new DaAddressSpaceElementBrowseOptions();
                m_executionOptions = new ExecutionOptions();

                if (ResultCode.SUCCEEDED(element.Browse(
                        browseOptions,
                        out testAddressSpaceElements,
                        m_executionOptions
                        )))
                {
                    if (testAddressSpaceElements != null && testAddressSpaceElements.Length > 0)
                    {
                        for (int i = 0; i < testAddressSpaceElements.Length; i++)
                        {
                            if (!items.Contains(testAddressSpaceElements[i].QualifiedName.Split('.')[0])) continue;
                            MyTest(testAddressSpaceElements[i], items, items_Attr);
                        }//end for
                    }
                    else
                    {
                        if (items_Attr.Contains(element.Name))
                        {
                            File.AppendAllText(@"./TestDA_Item.txt", element.QualifiedName + "\r\n");
                            TagsList.Items.Add(element.QualifiedName, true);
                        }
                    }
                }
            }
            catch
            {
                browseOptions = null;
                testAddressSpaceElements = null;
                m_executionOptions = null;
                throw new Exception("手动停止Tag拼接.");
            }

            //GetDaProperties
            DaGetPropertiesOptions m_propertyGetOptions = new DaGetPropertiesOptions();
            DaProperty[] daProperties = null;
            m_propertyGetOptions.WhatPropertyData = EnumPropertyData.NONE;

            if (ResultCode.SUCCEEDED(element.GetDaProperties(
                m_propertyGetOptions,
                out daProperties,
                m_executionOptions)))
            {
                if (daProperties != null && daProperties.Length > 0)
                {
                    for (int i = 0; i < daProperties.Length; i++)
                    {
                        if (isStopReadFileContent_TagThread)
                        {
                            m_propertyGetOptions = null;
                            daProperties = null;
                            m_propertyGetOptions = null;
                            throw new Exception("手动停止Tag拼接.");
                        }
                        //add all properties except OPC-specific properties
                        if (daProperties[i].Id >= 100 && items_Attr.Contains(daProperties[i].Description))
                        {
                            File.AppendAllText(@"./TestDA_Item.txt", element.QualifiedName + "." + daProperties[i].Description + "\r\n");
                            TagsList.Items.Add(daProperties[i].ItemId + "(" + element.QualifiedName + "." + daProperties[i].Description + ")", true);
                            //TagsList.Items.Add(element.QualifiedName + "." + daProperties[i].Description, true);
                        }
                    }//end for
                }
            }   //  end if
        }

        private void Clear_Tag_Click(object sender, EventArgs e)
        {
            TagsList.Items.Clear();
        }

        private void SelectAll_Tag_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectAll_Tag.Checked)
            {
                //全选
                for (int index = 0; index < TagsList.Items.Count; index++)
                {
                    TagsList.SetItemChecked(index, true);
                }
            }
            else
            {
                //取消全选
                foreach (int index in TagsList.CheckedIndices)
                {
                    TagsList.SetItemChecked(index, false);
                }
            }
        }

        private void TagsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TagsList.CheckedIndices.Count == TagsList.Items.Count)
            {
                SelectAll_Tag.CheckState = CheckState.Checked;
            }

            if (TagsList.CheckedIndices.Count < TagsList.Items.Count)
            {
                SelectAll_Tag.CheckState = CheckState.Unchecked;
            }
        }

        private void Stop_Tag_Click(object sender, EventArgs e)
        {
            isStopReadFileContent_TagThread = true;

            while (ReadFileContent_TagThread != null && ReadFileContent_TagThread.ThreadState != ThreadState.Stopped)
            {
                ReadFileContent_TagThread.Abort();
                Thread.Sleep(100);
            }
            ReadFileContent_TagThread = null;

            StatusMsg.Text = "已停止拼接操作.";
        }

        private void FileContentList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FileContentList_Attr_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TagsList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FileContentList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (Directory.Exists(files[0]))
            {
                //如果选择是文件夹而不是文件则跳过
                MessageBox.Show("请拖拽单个文件(非文件夹)!");
                return;
            }
            SelectedFilePath.Text = files[0];
            ReadFileContent_Click(null, null);
        }

        private void FileContentList_Attr_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (Directory.Exists(files[0]))
            {
                //如果选择是文件夹而不是文件则跳过
                MessageBox.Show("请拖拽单个文件(非文件夹)!");
                return;
            }
            SelectedFilePath_Attr.Text = files[0];
            ReadFileContent_Attr_Click(null, null);
        }

        private void TagsList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (Directory.Exists(files[0]))
            {
                //如果选择是文件夹而不是文件则跳过
                MessageBox.Show("请拖拽单个文件(非文件夹)!");
                return;
            }

            if (ClearBeforeRead_Tag.Checked) TagsList.Items.Clear();

            string tagsContent = File.ReadAllText(files[0], FileEncoding_Tag.Checked ? Encoding.UTF8 : Encoding.Default);
            string[] splittedString = tagsContent.Split(SplitChoose_Tag.Checked ? '\n' : ';');
            foreach (string s in splittedString)
            {
                if (s.Trim() != string.Empty) TagsList.Items.Add(s.Trim(), true);
            }
            SelectAll_Tag.CheckState = CheckState.Checked;
            StatusMsg.Text = "Tags读取完成.";
            //MessageBox.Show("Tags读取完成.");
        }

        private void LicenseHelp_Click(object sender, EventArgs e)
        {
            new LicenseAndOPCURL().ShowDialog(this);
        }

        private void Clear_Value_Click(object sender, EventArgs e)
        {
            GettedValueListView.Items.Clear();
        }

        private void Stop_Value_Click(object sender, EventArgs e)
        {
            isStopReadValueThread = true;
            isStopWatchValueChangeEvent = true;

            while (ReadValueThread != null && ReadValueThread.ThreadState != ThreadState.Stopped)
            {
                ReadValueThread.Abort();
                Thread.Sleep(1000);
            }
            ReadValueThread = null;
            StatusMsg.Text = "已停止Value读取操作.";

            while (WatchValueChangeThread != null && WatchValueChangeThread.ThreadState != ThreadState.Stopped)
            {
                WatchValueChangeThread.Abort();
                Thread.Sleep(1000);
            }
            WatchValueChangeThread = null;
            StatusMsg.Text = "已停止Value Change监控.";

            watchValueChangeOPCClient.Terminate();
            watchValueChangeOPCClient = null;
        }

        private void ListenChange_Click(object sender, EventArgs e)
        {
            isStopWatchValueChangeEvent = false;

            List<string> items = CheckedItemCollection2ListString(TagsList.CheckedItems);
            File.Delete(@"./change.txt");

            WatchValueChangeThread = new Thread(WatchValueChangeEvent);
            WatchValueChangeThread.IsBackground = true;
            WatchValueChangeThread.Start(items);
        }

        private void WatchValueChangeEvent(object p_items)
        {
            StatusMsg.Text = "监控服务:正在读取当前Tag值作为初始值,请稍等...";
            ReadValues_Click(null, null);
            ReadValueThread.Join();
            StatusMsg.Text = "监控服务:初始值读取完成.";

            List<string> items = (List<string>)p_items;
            watchValueChangeOPCClient = new OpcClient();
            StatusMsg.Text = "监控服务:开始连接OPC...";
            try
            {
                int result = (int)EnumResultCode.S_OK;
                //	initialize the client instance
                if (!ResultCode.SUCCEEDED(watchValueChangeOPCClient.Initialize()))
                {
                    watchValueChangeOPCClient = null;
                    return;
                }   //	end if

                //	initialize the DA client simulation
                result |= watchValueChangeOPCClient.InitializeDaObjects(items);
            }
            catch (Exception exc)
            {
                StatusMsg.Text = exc.ToString();
                return;
            }	//	end try...catch

            //m_opcClient.ActivateSession(false);   //异步激活
            watchValueChangeOPCClient.ActivateSession(true);   //同步激活

            StatusMsg.Text = "监控服务:已连接OPC，正在监听Value Change...";

            while (!isStopWatchValueChangeEvent)
            {
                string value = SendMsgToWindow.PopMessage();
                if (value == string.Empty)
                {
                    Thread.Sleep(500);
                    foreach (ListViewItem ls in GettedValueListView.Items)
                    {
                        if (ls.BackColor != System.Drawing.Color.White)
                        {
                            ls.BackColor = System.Drawing.Color.White;
                        }
                    }
                    Thread.Sleep(500);
                }
                else
                {
                    string key = value.Split('@')[0];
                    string val = value.Split('@')[1];

                    if (GettedValueListView.Items.Count <= 0)
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = key;
                        lvi.SubItems.Add(val);
                        GettedValueListView.Items.Add(lvi);
                        GettedValueListView.Items[GettedValueListView.Items.Count - 1].BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        ListViewItem ls = GettedValueListView.FindItemWithText(key, true, 0, false);
                        int index = GettedValueListView.Items.IndexOf(ls);

                        if (index >= 0)
                        {
                            if (GettedValueListView.Items[index].SubItems[1].Text != val)
                            {
                                GettedValueListView.Items[index].SubItems[1].Text = val;
                                GettedValueListView.Items[index].BackColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.Text = key;
                            lvi.SubItems.Add(val);
                            GettedValueListView.Items.Add(lvi);
                            GettedValueListView.Items[GettedValueListView.Items.Count - 1].BackColor = System.Drawing.Color.Red;
                        }

                    }
                }
            }
        }
    }
}
