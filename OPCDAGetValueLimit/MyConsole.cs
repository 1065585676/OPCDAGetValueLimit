namespace DATest
{
    class MyConsole
    {
        private static OpcClient m_opcClient = null;

        public OpcClient OpcClient
        {
            get
            {
                return m_opcClient;
            }   //	end get
        }   //	end OpcClient
        public void CreateOpcClient()
        {
            if (m_opcClient == null)
            {
                m_opcClient = new OpcClient();
            }   //	end if
        }   //	end CreateOpcClient
    }
}
