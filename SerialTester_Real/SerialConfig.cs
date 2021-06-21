using System;
using System.Collections.Generic;

namespace SerialTester_Real
{
    [Serializable]
    internal class SerialConfig
    {
        #region Fields

        public string Boardrate;
        public string Port;
        public List<ResponseData> responseData;
        private string _filePath;
        private Jsonhandler<SerialConfig> _jsonhandler;

        #endregion Fields

        #region Constructors

        public SerialConfig()
        {
            Port = string.Empty;
            Boardrate = string.Empty;
            responseData = new List<ResponseData>();
            _jsonhandler = new Jsonhandler<SerialConfig>();
        }

        #endregion Constructors

        #region Destructors

        ~SerialConfig()
        {
            //
        }

        #endregion Destructors

        #region Methods

        public void loadConfig()//string filePath)
        {
            SerialConfig data = _jsonhandler.loadConfig("d://test.json");
            if (data == null)
            {
                return;
            }
            this.Port = data.Port;
            this.Boardrate = data.Boardrate;
            this.responseData = data.responseData;
            return;
        }

        public void Save()
        {
            _jsonhandler.Save("d://test.json", this);
            return;
        }

        #endregion Methods
    }
}