using System.IO;
using System.Web.Script.Serialization;

namespace SerialTester_Real
{
    public class Jsonhandler<T>
    {
        #region Constructors

        public Jsonhandler()
        {
            //
        }

        #endregion Constructors

        #region Methods

        public bool Load()
        {
            return true;
        }

        public T loadConfig(string filePath)
        {
            if (!File.Exists(filePath)) return default(T);
            T _data = default(T);
            var _jsonConvertor = new JavaScriptSerializer();

            var _filePath = filePath;

            string jsonString = File.ReadAllText(_filePath);
            _data = _jsonConvertor.Deserialize<T>(jsonString);
            return _data;
        }

        public bool Save(string path, T config)
        {
            try
            {
                JavaScriptSerializer jsonConvertor = new JavaScriptSerializer();

                string allText = jsonConvertor.Serialize(config);

                allText = allText.Replace(@"{", "{\r\n\t");
                allText = allText.Replace(@",", ",\r\n\t");

                File.WriteAllText(path, allText);

                return true;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
                return false;
            }
        }

        #endregion Methods
    }
}