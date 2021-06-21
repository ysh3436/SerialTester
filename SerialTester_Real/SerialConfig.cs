using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

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
        JavaScriptSerializer _jsonConvertor = new JavaScriptSerializer();

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
        
        public SerialConfig loadConfigData(string filepath)
        {
            SerialConfig data = _jsonhandler.loadConfig(filepath);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public void Save()
        {
            _jsonhandler.Save("d://test.json", this);
            var temp = _jsonConvertor.Serialize(responseData);
            return;
        }

        #endregion Methods
    }
}