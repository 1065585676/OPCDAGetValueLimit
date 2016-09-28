namespace DATest
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SelectedFilePath = new System.Windows.Forms.TextBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.FileContentList = new System.Windows.Forms.CheckedListBox();
            this.ReadFileContent = new System.Windows.Forms.Button();
            this.StopRead = new System.Windows.Forms.Button();
            this.ClearContent = new System.Windows.Forms.Button();
            this.FileEncoding = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SplitChoose = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.ReadValues = new System.Windows.Forms.Button();
            this.SaveToFile = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.FileEncoding_Attr = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SplitChoose_Attr = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.ClearBeforeRead_Attr = new System.Windows.Forms.CheckBox();
            this.ClearContent_Attr = new System.Windows.Forms.Button();
            this.StopRead_Attr = new System.Windows.Forms.Button();
            this.ReadFileContent_Attr = new System.Windows.Forms.Button();
            this.SelectAll_Attr = new System.Windows.Forms.CheckBox();
            this.FileContentList_Attr = new System.Windows.Forms.CheckedListBox();
            this.OpenFile_Attr = new System.Windows.Forms.Button();
            this.SelectedFilePath_Attr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GetTags = new System.Windows.Forms.Button();
            this.TagsList = new System.Windows.Forms.CheckedListBox();
            this.SelectAll = new System.Windows.Forms.CheckBox();
            this.ClearBeforeRead = new System.Windows.Forms.CheckBox();
            this.ClearBeforeRead_Tag = new System.Windows.Forms.CheckBox();
            this.SelectAll_Tag = new System.Windows.Forms.CheckBox();
            this.Clear_Tag = new System.Windows.Forms.Button();
            this.Stop_Tag = new System.Windows.Forms.Button();
            this.GettedValueListView = new System.Windows.Forms.ListView();
            this.TagName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TagValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.SplitChoose_Tag = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.FileEncoding_Tag = new System.Windows.Forms.RadioButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LicenseHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.Stop_Value = new System.Windows.Forms.Button();
            this.Clear_Value = new System.Windows.Forms.Button();
            this.ListenChange = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(31, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "打开点位存储文件：";
            // 
            // SelectedFilePath
            // 
            this.SelectedFilePath.Location = new System.Drawing.Point(34, 62);
            this.SelectedFilePath.Name = "SelectedFilePath";
            this.SelectedFilePath.ReadOnly = true;
            this.SelectedFilePath.Size = new System.Drawing.Size(237, 20);
            this.SelectedFilePath.TabIndex = 1;
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(277, 60);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(75, 23);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "打开";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // FileContentList
            // 
            this.FileContentList.AllowDrop = true;
            this.FileContentList.CheckOnClick = true;
            this.FileContentList.FormattingEnabled = true;
            this.FileContentList.Location = new System.Drawing.Point(34, 184);
            this.FileContentList.Name = "FileContentList";
            this.FileContentList.Size = new System.Drawing.Size(318, 409);
            this.FileContentList.TabIndex = 3;
            this.FileContentList.SelectedIndexChanged += new System.EventHandler(this.FileContentList_SelectedIndexChanged);
            this.FileContentList.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileContentList_DragDrop);
            this.FileContentList.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileContentList_DragEnter);
            // 
            // ReadFileContent
            // 
            this.ReadFileContent.Location = new System.Drawing.Point(34, 103);
            this.ReadFileContent.Name = "ReadFileContent";
            this.ReadFileContent.Size = new System.Drawing.Size(75, 23);
            this.ReadFileContent.TabIndex = 6;
            this.ReadFileContent.Text = "读取";
            this.ReadFileContent.UseVisualStyleBackColor = true;
            this.ReadFileContent.Click += new System.EventHandler(this.ReadFileContent_Click);
            // 
            // StopRead
            // 
            this.StopRead.Location = new System.Drawing.Point(115, 103);
            this.StopRead.Name = "StopRead";
            this.StopRead.Size = new System.Drawing.Size(75, 23);
            this.StopRead.TabIndex = 7;
            this.StopRead.Text = "停止";
            this.StopRead.UseVisualStyleBackColor = true;
            this.StopRead.Click += new System.EventHandler(this.StopRead_Click);
            // 
            // ClearContent
            // 
            this.ClearContent.Location = new System.Drawing.Point(196, 103);
            this.ClearContent.Name = "ClearContent";
            this.ClearContent.Size = new System.Drawing.Size(75, 23);
            this.ClearContent.TabIndex = 8;
            this.ClearContent.Text = "清空";
            this.ClearContent.UseVisualStyleBackColor = true;
            this.ClearContent.Click += new System.EventHandler(this.ClearContent_Click);
            // 
            // FileEncoding
            // 
            this.FileEncoding.AutoSize = true;
            this.FileEncoding.Location = new System.Drawing.Point(84, 19);
            this.FileEncoding.Name = "FileEncoding";
            this.FileEncoding.Size = new System.Drawing.Size(52, 17);
            this.FileEncoding.TabIndex = 9;
            this.FileEncoding.Text = "UTF8";
            this.FileEncoding.UseVisualStyleBackColor = true;
            this.FileEncoding.CheckedChanged += new System.EventHandler(this.FileEncoding_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "GB2312";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // SplitChoose
            // 
            this.SplitChoose.AutoSize = true;
            this.SplitChoose.Checked = true;
            this.SplitChoose.Location = new System.Drawing.Point(6, 19);
            this.SplitChoose.Name = "SplitChoose";
            this.SplitChoose.Size = new System.Drawing.Size(66, 17);
            this.SplitChoose.TabIndex = 16;
            this.SplitChoose.TabStop = true;
            this.SplitChoose.Text = "换行(\\n)";
            this.SplitChoose.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(84, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.Text = "分号(;)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SplitChoose);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(34, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 46);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分隔符";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.FileEncoding);
            this.groupBox2.Location = new System.Drawing.Point(196, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 46);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件编码";
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8F);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMsg});
            this.statusStrip.Location = new System.Drawing.Point(0, 631);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1309, 22);
            this.statusStrip.TabIndex = 20;
            this.statusStrip.Text = "statusStrip";
            // 
            // StatusMsg
            // 
            this.StatusMsg.Name = "StatusMsg";
            this.StatusMsg.Size = new System.Drawing.Size(33, 17);
            this.StatusMsg.Text = "就绪.";
            // 
            // ReadValues
            // 
            this.ReadValues.Location = new System.Drawing.Point(1190, 330);
            this.ReadValues.Name = "ReadValues";
            this.ReadValues.Size = new System.Drawing.Size(75, 23);
            this.ReadValues.TabIndex = 22;
            this.ReadValues.Text = "读取值";
            this.ReadValues.UseVisualStyleBackColor = true;
            this.ReadValues.Click += new System.EventHandler(this.ReadValues_Click);
            // 
            // SaveToFile
            // 
            this.SaveToFile.AutoSize = true;
            this.SaveToFile.Checked = true;
            this.SaveToFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SaveToFile.Location = new System.Drawing.Point(1098, 599);
            this.SaveToFile.Name = "SaveToFile";
            this.SaveToFile.Size = new System.Drawing.Size(86, 17);
            this.SaveToFile.TabIndex = 23;
            this.SaveToFile.Text = "保存到文件";
            this.SaveToFile.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.FileEncoding_Attr);
            this.groupBox3.Location = new System.Drawing.Point(541, 132);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 46);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件编码";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "GB2312";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // FileEncoding_Attr
            // 
            this.FileEncoding_Attr.AutoSize = true;
            this.FileEncoding_Attr.Location = new System.Drawing.Point(84, 19);
            this.FileEncoding_Attr.Name = "FileEncoding_Attr";
            this.FileEncoding_Attr.Size = new System.Drawing.Size(52, 17);
            this.FileEncoding_Attr.TabIndex = 9;
            this.FileEncoding_Attr.Text = "UTF8";
            this.FileEncoding_Attr.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SplitChoose_Attr);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Location = new System.Drawing.Point(379, 132);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 46);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "分隔符";
            // 
            // SplitChoose_Attr
            // 
            this.SplitChoose_Attr.AutoSize = true;
            this.SplitChoose_Attr.Checked = true;
            this.SplitChoose_Attr.Location = new System.Drawing.Point(6, 19);
            this.SplitChoose_Attr.Name = "SplitChoose_Attr";
            this.SplitChoose_Attr.Size = new System.Drawing.Size(66, 17);
            this.SplitChoose_Attr.TabIndex = 16;
            this.SplitChoose_Attr.TabStop = true;
            this.SplitChoose_Attr.Text = "换行(\\n)";
            this.SplitChoose_Attr.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(84, 19);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(58, 17);
            this.radioButton6.TabIndex = 15;
            this.radioButton6.Text = "分号(;)";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // ClearBeforeRead_Attr
            // 
            this.ClearBeforeRead_Attr.AutoSize = true;
            this.ClearBeforeRead_Attr.Checked = true;
            this.ClearBeforeRead_Attr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ClearBeforeRead_Attr.Location = new System.Drawing.Point(587, 599);
            this.ClearBeforeRead_Attr.Name = "ClearBeforeRead_Attr";
            this.ClearBeforeRead_Attr.Size = new System.Drawing.Size(110, 17);
            this.ClearBeforeRead_Attr.TabIndex = 32;
            this.ClearBeforeRead_Attr.Text = "读取前清空列表";
            this.ClearBeforeRead_Attr.UseVisualStyleBackColor = true;
            // 
            // ClearContent_Attr
            // 
            this.ClearContent_Attr.Location = new System.Drawing.Point(541, 103);
            this.ClearContent_Attr.Name = "ClearContent_Attr";
            this.ClearContent_Attr.Size = new System.Drawing.Size(75, 23);
            this.ClearContent_Attr.TabIndex = 31;
            this.ClearContent_Attr.Text = "清空";
            this.ClearContent_Attr.UseVisualStyleBackColor = true;
            this.ClearContent_Attr.Click += new System.EventHandler(this.ClearContent_Attr_Click);
            // 
            // StopRead_Attr
            // 
            this.StopRead_Attr.Location = new System.Drawing.Point(460, 103);
            this.StopRead_Attr.Name = "StopRead_Attr";
            this.StopRead_Attr.Size = new System.Drawing.Size(75, 23);
            this.StopRead_Attr.TabIndex = 30;
            this.StopRead_Attr.Text = "停止";
            this.StopRead_Attr.UseVisualStyleBackColor = true;
            this.StopRead_Attr.Click += new System.EventHandler(this.StopRead_Attr_Click);
            // 
            // ReadFileContent_Attr
            // 
            this.ReadFileContent_Attr.Location = new System.Drawing.Point(379, 103);
            this.ReadFileContent_Attr.Name = "ReadFileContent_Attr";
            this.ReadFileContent_Attr.Size = new System.Drawing.Size(75, 23);
            this.ReadFileContent_Attr.TabIndex = 29;
            this.ReadFileContent_Attr.Text = "读取";
            this.ReadFileContent_Attr.UseVisualStyleBackColor = true;
            this.ReadFileContent_Attr.Click += new System.EventHandler(this.ReadFileContent_Attr_Click);
            // 
            // SelectAll_Attr
            // 
            this.SelectAll_Attr.AutoSize = true;
            this.SelectAll_Attr.Location = new System.Drawing.Point(379, 599);
            this.SelectAll_Attr.Name = "SelectAll_Attr";
            this.SelectAll_Attr.Size = new System.Drawing.Size(109, 17);
            this.SelectAll_Attr.TabIndex = 28;
            this.SelectAll_Attr.Text = "全选 / 取消全选";
            this.SelectAll_Attr.UseVisualStyleBackColor = true;
            this.SelectAll_Attr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectAll_Attr_MouseClick);
            // 
            // FileContentList_Attr
            // 
            this.FileContentList_Attr.AllowDrop = true;
            this.FileContentList_Attr.CheckOnClick = true;
            this.FileContentList_Attr.FormattingEnabled = true;
            this.FileContentList_Attr.Location = new System.Drawing.Point(379, 184);
            this.FileContentList_Attr.Name = "FileContentList_Attr";
            this.FileContentList_Attr.Size = new System.Drawing.Size(318, 409);
            this.FileContentList_Attr.TabIndex = 27;
            this.FileContentList_Attr.SelectedIndexChanged += new System.EventHandler(this.FileContentList_Attr_SelectedIndexChanged);
            this.FileContentList_Attr.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileContentList_Attr_DragDrop);
            this.FileContentList_Attr.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileContentList_Attr_DragEnter);
            // 
            // OpenFile_Attr
            // 
            this.OpenFile_Attr.Location = new System.Drawing.Point(622, 60);
            this.OpenFile_Attr.Name = "OpenFile_Attr";
            this.OpenFile_Attr.Size = new System.Drawing.Size(75, 23);
            this.OpenFile_Attr.TabIndex = 24;
            this.OpenFile_Attr.Text = "打开";
            this.OpenFile_Attr.UseVisualStyleBackColor = true;
            this.OpenFile_Attr.Click += new System.EventHandler(this.OpenFile_Attr_Click);
            // 
            // SelectedFilePath_Attr
            // 
            this.SelectedFilePath_Attr.Location = new System.Drawing.Point(379, 62);
            this.SelectedFilePath_Attr.Name = "SelectedFilePath_Attr";
            this.SelectedFilePath_Attr.ReadOnly = true;
            this.SelectedFilePath_Attr.Size = new System.Drawing.Size(237, 20);
            this.SelectedFilePath_Attr.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(376, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "打开点位属性存储文件：";
            // 
            // GetTags
            // 
            this.GetTags.Location = new System.Drawing.Point(1190, 57);
            this.GetTags.Name = "GetTags";
            this.GetTags.Size = new System.Drawing.Size(75, 23);
            this.GetTags.TabIndex = 36;
            this.GetTags.Text = "拼接Tag";
            this.GetTags.UseVisualStyleBackColor = true;
            this.GetTags.Click += new System.EventHandler(this.GetTags_Click);
            // 
            // TagsList
            // 
            this.TagsList.AllowDrop = true;
            this.TagsList.CheckOnClick = true;
            this.TagsList.FormattingEnabled = true;
            this.TagsList.Location = new System.Drawing.Point(724, 57);
            this.TagsList.Name = "TagsList";
            this.TagsList.Size = new System.Drawing.Size(460, 229);
            this.TagsList.TabIndex = 37;
            this.TagsList.SelectedIndexChanged += new System.EventHandler(this.TagsList_SelectedIndexChanged);
            this.TagsList.DragDrop += new System.Windows.Forms.DragEventHandler(this.TagsList_DragDrop);
            this.TagsList.DragEnter += new System.Windows.Forms.DragEventHandler(this.TagsList_DragEnter);
            // 
            // SelectAll
            // 
            this.SelectAll.AutoSize = true;
            this.SelectAll.Location = new System.Drawing.Point(34, 599);
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(109, 17);
            this.SelectAll.TabIndex = 4;
            this.SelectAll.Text = "全选 / 取消全选";
            this.SelectAll.UseVisualStyleBackColor = true;
            this.SelectAll.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectAll_MouseClick);
            // 
            // ClearBeforeRead
            // 
            this.ClearBeforeRead.AutoSize = true;
            this.ClearBeforeRead.Checked = true;
            this.ClearBeforeRead.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ClearBeforeRead.Location = new System.Drawing.Point(242, 599);
            this.ClearBeforeRead.Name = "ClearBeforeRead";
            this.ClearBeforeRead.Size = new System.Drawing.Size(110, 17);
            this.ClearBeforeRead.TabIndex = 11;
            this.ClearBeforeRead.Text = "读取前清空列表";
            this.ClearBeforeRead.UseVisualStyleBackColor = true;
            // 
            // ClearBeforeRead_Tag
            // 
            this.ClearBeforeRead_Tag.AutoSize = true;
            this.ClearBeforeRead_Tag.Checked = true;
            this.ClearBeforeRead_Tag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ClearBeforeRead_Tag.Location = new System.Drawing.Point(1074, 292);
            this.ClearBeforeRead_Tag.Name = "ClearBeforeRead_Tag";
            this.ClearBeforeRead_Tag.Size = new System.Drawing.Size(110, 17);
            this.ClearBeforeRead_Tag.TabIndex = 39;
            this.ClearBeforeRead_Tag.Text = "读取前清空列表";
            this.ClearBeforeRead_Tag.UseVisualStyleBackColor = true;
            // 
            // SelectAll_Tag
            // 
            this.SelectAll_Tag.AutoSize = true;
            this.SelectAll_Tag.Location = new System.Drawing.Point(724, 292);
            this.SelectAll_Tag.Name = "SelectAll_Tag";
            this.SelectAll_Tag.Size = new System.Drawing.Size(109, 17);
            this.SelectAll_Tag.TabIndex = 38;
            this.SelectAll_Tag.Text = "全选 / 取消全选";
            this.SelectAll_Tag.UseVisualStyleBackColor = true;
            this.SelectAll_Tag.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectAll_Tag_MouseClick);
            // 
            // Clear_Tag
            // 
            this.Clear_Tag.Location = new System.Drawing.Point(1190, 115);
            this.Clear_Tag.Name = "Clear_Tag";
            this.Clear_Tag.Size = new System.Drawing.Size(75, 23);
            this.Clear_Tag.TabIndex = 41;
            this.Clear_Tag.Text = "清空";
            this.Clear_Tag.UseVisualStyleBackColor = true;
            this.Clear_Tag.Click += new System.EventHandler(this.Clear_Tag_Click);
            // 
            // Stop_Tag
            // 
            this.Stop_Tag.Location = new System.Drawing.Point(1190, 86);
            this.Stop_Tag.Name = "Stop_Tag";
            this.Stop_Tag.Size = new System.Drawing.Size(75, 23);
            this.Stop_Tag.TabIndex = 42;
            this.Stop_Tag.Text = "停止";
            this.Stop_Tag.UseVisualStyleBackColor = true;
            this.Stop_Tag.Click += new System.EventHandler(this.Stop_Tag_Click);
            // 
            // GettedValueListView
            // 
            this.GettedValueListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TagName,
            this.TagValue});
            this.GettedValueListView.FullRowSelect = true;
            this.GettedValueListView.GridLines = true;
            this.GettedValueListView.Location = new System.Drawing.Point(724, 330);
            this.GettedValueListView.Name = "GettedValueListView";
            this.GettedValueListView.Size = new System.Drawing.Size(460, 263);
            this.GettedValueListView.TabIndex = 43;
            this.GettedValueListView.UseCompatibleStateImageBehavior = false;
            this.GettedValueListView.View = System.Windows.Forms.View.Details;
            // 
            // TagName
            // 
            this.TagName.Text = "Tag名称";
            // 
            // TagValue
            // 
            this.TagValue.Text = "Tag值";
            this.TagValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.SplitChoose_Tag);
            this.groupBox5.Controls.Add(this.radioButton5);
            this.groupBox5.Location = new System.Drawing.Point(1190, 144);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(86, 68);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "分隔符";
            // 
            // SplitChoose_Tag
            // 
            this.SplitChoose_Tag.AutoSize = true;
            this.SplitChoose_Tag.Checked = true;
            this.SplitChoose_Tag.Location = new System.Drawing.Point(6, 19);
            this.SplitChoose_Tag.Name = "SplitChoose_Tag";
            this.SplitChoose_Tag.Size = new System.Drawing.Size(66, 17);
            this.SplitChoose_Tag.TabIndex = 16;
            this.SplitChoose_Tag.TabStop = true;
            this.SplitChoose_Tag.Text = "换行(\\n)";
            this.SplitChoose_Tag.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 42);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(58, 17);
            this.radioButton5.TabIndex = 15;
            this.radioButton5.Text = "分号(;)";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton7);
            this.groupBox6.Controls.Add(this.FileEncoding_Tag);
            this.groupBox6.Location = new System.Drawing.Point(1190, 218);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(86, 68);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "文件编码";
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Checked = true;
            this.radioButton7.Location = new System.Drawing.Point(6, 19);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(64, 17);
            this.radioButton7.TabIndex = 10;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "GB2312";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // FileEncoding_Tag
            // 
            this.FileEncoding_Tag.AutoSize = true;
            this.FileEncoding_Tag.Location = new System.Drawing.Point(6, 42);
            this.FileEncoding_Tag.Name = "FileEncoding_Tag";
            this.FileEncoding_Tag.Size = new System.Drawing.Size(52, 17);
            this.FileEncoding_Tag.TabIndex = 9;
            this.FileEncoding_Tag.Text = "UTF8";
            this.FileEncoding_Tag.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1309, 24);
            this.menuStrip.TabIndex = 44;
            this.menuStrip.Text = "menuStrip";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LicenseHelp});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // LicenseHelp
            // 
            this.LicenseHelp.Name = "LicenseHelp";
            this.LicenseHelp.Size = new System.Drawing.Size(200, 22);
            this.LicenseHelp.Text = "License And OPC Server";
            this.LicenseHelp.Click += new System.EventHandler(this.LicenseHelp_Click);
            // 
            // Stop_Value
            // 
            this.Stop_Value.Location = new System.Drawing.Point(1190, 570);
            this.Stop_Value.Name = "Stop_Value";
            this.Stop_Value.Size = new System.Drawing.Size(75, 23);
            this.Stop_Value.TabIndex = 46;
            this.Stop_Value.Text = "停止";
            this.Stop_Value.UseVisualStyleBackColor = true;
            this.Stop_Value.Click += new System.EventHandler(this.Stop_Value_Click);
            // 
            // Clear_Value
            // 
            this.Clear_Value.Location = new System.Drawing.Point(1190, 359);
            this.Clear_Value.Name = "Clear_Value";
            this.Clear_Value.Size = new System.Drawing.Size(75, 23);
            this.Clear_Value.TabIndex = 45;
            this.Clear_Value.Text = "清空";
            this.Clear_Value.UseVisualStyleBackColor = true;
            this.Clear_Value.Click += new System.EventHandler(this.Clear_Value_Click);
            // 
            // ListenChange
            // 
            this.ListenChange.Location = new System.Drawing.Point(1190, 541);
            this.ListenChange.Name = "ListenChange";
            this.ListenChange.Size = new System.Drawing.Size(75, 23);
            this.ListenChange.TabIndex = 47;
            this.ListenChange.Text = "监控";
            this.ListenChange.UseVisualStyleBackColor = true;
            this.ListenChange.Click += new System.EventHandler(this.ListenChange_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 653);
            this.Controls.Add(this.ListenChange);
            this.Controls.Add(this.Stop_Value);
            this.Controls.Add(this.Clear_Value);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.GettedValueListView);
            this.Controls.Add(this.Stop_Tag);
            this.Controls.Add(this.Clear_Tag);
            this.Controls.Add(this.ClearBeforeRead_Tag);
            this.Controls.Add(this.SelectAll_Tag);
            this.Controls.Add(this.TagsList);
            this.Controls.Add(this.GetTags);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.ClearBeforeRead_Attr);
            this.Controls.Add(this.ClearContent_Attr);
            this.Controls.Add(this.StopRead_Attr);
            this.Controls.Add(this.ReadFileContent_Attr);
            this.Controls.Add(this.SelectAll_Attr);
            this.Controls.Add(this.FileContentList_Attr);
            this.Controls.Add(this.OpenFile_Attr);
            this.Controls.Add(this.SelectedFilePath_Attr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SaveToFile);
            this.Controls.Add(this.ReadValues);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ClearBeforeRead);
            this.Controls.Add(this.ClearContent);
            this.Controls.Add(this.StopRead);
            this.Controls.Add(this.ReadFileContent);
            this.Controls.Add(this.SelectAll);
            this.Controls.Add(this.FileContentList);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.SelectedFilePath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox SelectedFilePath;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.CheckedListBox FileContentList;
        private System.Windows.Forms.Button ReadFileContent;
        private System.Windows.Forms.Button StopRead;
        private System.Windows.Forms.Button ClearContent;
        private System.Windows.Forms.RadioButton FileEncoding;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton SplitChoose;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusMsg;
        private System.Windows.Forms.Button ReadValues;
        private System.Windows.Forms.CheckBox SaveToFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton FileEncoding_Attr;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton SplitChoose_Attr;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.CheckBox ClearBeforeRead_Attr;
        private System.Windows.Forms.Button ClearContent_Attr;
        private System.Windows.Forms.Button StopRead_Attr;
        private System.Windows.Forms.Button ReadFileContent_Attr;
        private System.Windows.Forms.CheckBox SelectAll_Attr;
        private System.Windows.Forms.CheckedListBox FileContentList_Attr;
        private System.Windows.Forms.Button OpenFile_Attr;
        private System.Windows.Forms.TextBox SelectedFilePath_Attr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GetTags;
        private System.Windows.Forms.CheckedListBox TagsList;
        private System.Windows.Forms.CheckBox SelectAll;
        private System.Windows.Forms.CheckBox ClearBeforeRead;
        private System.Windows.Forms.CheckBox ClearBeforeRead_Tag;
        private System.Windows.Forms.CheckBox SelectAll_Tag;
        private System.Windows.Forms.Button Clear_Tag;
        private System.Windows.Forms.Button Stop_Tag;
        private System.Windows.Forms.ListView GettedValueListView;
        private System.Windows.Forms.ColumnHeader TagName;
        private System.Windows.Forms.ColumnHeader TagValue;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton SplitChoose_Tag;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton FileEncoding_Tag;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LicenseHelp;
        private System.Windows.Forms.Button Stop_Value;
        private System.Windows.Forms.Button Clear_Value;
        private System.Windows.Forms.Button ListenChange;
    }
}

