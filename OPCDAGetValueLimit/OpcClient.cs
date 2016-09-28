using Softing.OPCToolbox;
using Softing.OPCToolbox.Client;
using System;
using System.Collections.Generic;

namespace DATest
{
    class OpcClient
    {
        public OpcClient() { }

        private MyDaSession m_daSession = null;
        private MyDaSubscription m_daSubscription = null;

        private MyDaItem[] m_itemList_test;
        private string[] m_itemIds_test;

        private ExecutionOptions m_executionOptions;

        public Application GetApplication()
        {
            return Application.Instance;
        }   //	end GetApplication

        public int Initialize()
        {
            int result = (int)EnumResultCode.S_OK;
            GetApplication().VersionOtb = 445;

            //	TODO - binary license activation
            if (LicenseAndOPCURL.licenseString != string.Empty) result = Application.Instance.Activate(EnumFeature.DA_CLIENT, LicenseAndOPCURL.licenseString);
            if (!ResultCode.SUCCEEDED(result))
            {
                return result;
            }
            //	END TODO - binary license activation

            //	proceed with the OPC Toolkit core initialization
            result = GetApplication().Initialize();

            if (ResultCode.SUCCEEDED(result))
            {
                //	enable toolkit internal initialization
                GetApplication().EnableTracing(
                    EnumTraceGroup.ALL,
                    EnumTraceGroup.ALL,
                    EnumTraceGroup.ALL,
                    EnumTraceGroup.ALL,
                    "Trace.txt",
                    1000000,
                    0);
            }   //	end if

            return result;
        }   //	end Initialize

        public void Terminate()
        {
            if (m_daSubscription != null && m_daSubscription.CurrentState != EnumObjectState.DISCONNECTED)
            {
                m_daSubscription.Disconnect(new ExecutionOptions());
                for (int i = 0; i < m_itemList_test.Length; i++)
                {
                    m_daSubscription.RemoveDaItem(m_itemList_test[i]);
                    m_itemList_test[i] = null;
                }
            }
            if (m_daSession != null && m_daSession.CurrentState != EnumObjectState.DISCONNECTED)
            {
                m_daSession.Disconnect(new ExecutionOptions());
                m_daSession.RemoveDaSubscription(m_daSubscription);
            }

            GetApplication().RemoveDaSession(m_daSession);

            GetApplication().Terminate();
            m_daSession = null;
            m_daSubscription = null;
        }   //	end Terminate

        public int InitializeDaObjects()
        {
            int connectResult = (int)EnumResultCode.E_FAIL;
            m_executionOptions = new ExecutionOptions();
            try
            {

                //	TODO add your server URL here
                string url = (LicenseAndOPCURL.opcUrlString == string.Empty) ? "opcda:///Softing.OPCToolboxDemo_ServerDA.1/{2E565242-B238-11D3-842D-0008C779D775}" : LicenseAndOPCURL.opcUrlString;

                //uncomment if you need an XML-DA access
                //	string url = "http://localhost:8079/OPC/DA";

                m_daSession = new MyDaSession(url);

                connectResult = m_daSession.Connect(true, false, m_executionOptions);
            }
            catch (Exception exc)
            {
                GetApplication().Trace(
                    EnumTraceLevel.ERR,
                    EnumTraceGroup.USER,
                    "OpcClient::InitializaDaObjects",
                    exc.ToString());
            }   //	end try...catch

            return connectResult;
        }	//	end InitializeDaObjects

        public int InitializeDaObjects(List<string> items)
        {
            int connectResult = (int)EnumResultCode.E_FAIL;

            m_executionOptions = new ExecutionOptions();
            m_executionOptions.ExecutionType = EnumExecutionType.ASYNCHRONOUS;
            m_executionOptions.ExecutionContext = 0;

            m_itemIds_test = items.ToArray();

            m_itemList_test = new MyDaItem[m_itemIds_test.Length];

            try
            {
                //	TODO add your server URL here
                string url = (LicenseAndOPCURL.opcUrlString == string.Empty) ? "opcda:///Softing.OPCToolboxDemo_ServerDA.1/{2E565242-B238-11D3-842D-0008C779D775}" : LicenseAndOPCURL.opcUrlString;

                m_daSession = new MyDaSession(url);
                if (!m_daSession.Valid)
                {
                    return connectResult;
                }

                m_daSubscription = new MyDaSubscription(1000, m_daSession);
                if (!m_daSubscription.Valid)
                {
                    return connectResult;
                }

                for (int i = 0; i < m_itemIds_test.Length; i++)
                {
                    MyDaItem temp = new MyDaItem(m_itemIds_test[i], m_daSubscription);
                    if (!temp.Valid)
                    {
                        return connectResult;
                    }
                    m_itemList_test[i] = temp;
                }

                connectResult = m_daSession.Connect(true, false, m_executionOptions);
            }
            catch (Exception exc)
            {
                GetApplication().Trace(
                    EnumTraceLevel.ERR,
                    EnumTraceGroup.USER,
                    "OpcClient::InitializaDaObjects",
                    exc.ToString());
            }   //	end try...catch

            return connectResult;
        }   //	end InitializeDaObjects

        public MyDaSession GetSession()
        {
            return m_daSession;
        }// end GetSession

        public void ActivateSession(bool sync)
        {
            System.Console.WriteLine();
            if (sync)
            {
                int result = this.m_daSession.Connect(true, true, new ExecutionOptions());
                if (ResultCode.FAILED(result))
                {
                    System.Console.WriteLine(" Session activate failed!");
                }
            }// end if
            else
            {
                m_daSession.Connect(true, true, m_executionOptions);
                m_executionOptions.ExecutionContext++;
            } // end else
        } // end ActivateSession

        public Dictionary<string, string> ReadItems()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            ValueQT itemValues;
            int itemResult;
            int readResult;
            for (int i = 0; i < m_itemList_test.Length; i++)
            {
                readResult = m_itemList_test[i].Read(100, out itemValues, out itemResult, new ExecutionOptions());
                if (ResultCode.SUCCEEDED(readResult))
                {
                    result.Add(m_itemList_test[i].Id, itemValues.ToString());
                }
                else
                {
                    result.Add(m_itemList_test[i].Id, "Synchronous item read failed! Result: " + readResult);
                }
            }
            return result;
        } //end ReadItems
    }
}
