using System.Collections.Generic;
using System.Linq;

namespace SerialTester_Real
{
    public class Main : MainWindow
    {
        #region Fields

        private SerialConfig _config = new SerialConfig();

        #endregion Fields

        #region Constructors

        public Main()
        {
            dgResponse.Items.Add("1");
            initialEvent();
        }

        #endregion Constructors

        #region Destructors

        ~Main()
        {
        }

        #endregion Destructors

        #region Methods

        private void cmdload(object sender, System.Windows.RoutedEventArgs e)
        {
            load();
        }

        private void cmdSave(object sender, System.Windows.RoutedEventArgs e)
        {
            save();
        }

        private void cmdUpdate(object sender, System.Windows.RoutedEventArgs e)
        {
            updateData();
        }

        private void Form_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            load();
        }

        private bool initialEvent()
        {
            this.btnSave.Click += cmdSave;
            this.btnUpdate.Click += cmdUpdate;
            this.Loaded += Form_Loaded;
            return true;
        }

        private bool load()
        {
            string[] comlist = System.IO.Ports.SerialPort.GetPortNames();
            //List<string> test= System.IO.Ports.SerialPort.GetPortNames().ToList;
            this.cbPort.ItemsSource = comlist.ToList<string>();
            _config.loadConfig();
            this.tbBoardrate.Text = _config.Boardrate;
            this.cbPort.SelectedItem = _config.Port;

            dgResponse.Items.Clear();
            dgResponse.ItemsSource = _config.responseData;
            return false;
        }

        private bool save()
        {
            _config.Boardrate = this.tbBoardrate.Text;
            _config.Port = this.cbPort.Text;
            _config.responseData = this.dgResponse.ItemsSource as List<ResponseData>;
            _config.Save();
            //this.dResponse.Items.Count
            //_config.ResponseData.Add(new Config.responseData())
            //Jsonhandler.Save("d://test_config.json", _config);
            return false;
        }

        private bool updateData()
        {
            List<ResponseData> changedData = dgResponse.ItemsSource as List<ResponseData>;

            if (changedData == null)
            {
                return false;
            }
            string rxText = tbReciveData.Text;
            string txText = tbSendData.Text;
            int _isindex = changedData.FindIndex(e => e.rxData == rxText);
            if (_isindex < 0)
            {
                changedData.Add(new ResponseData(rxText, txText));
            }
            else
            {
                changedData[_isindex].txData = txText;
            }
            dgResponse.ItemsSource = null;//없으면 itemSource가 변경이 안됨...
            dgResponse.ItemsSource = changedData;
            return true;
        }

        #endregion Methods
    }
}