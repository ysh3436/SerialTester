namespace SerialTester_Real
{
    internal class ResponseData
    {
        #region Constructors

        public ResponseData(string _rx, string _tx)
        {
            this.rxData = _rx;
            this.txData = _tx;
        }

        public ResponseData()
        {
            this.rxData = default(string);
            this.txData = default(string);
        }

        #endregion Constructors

        #region Properties

        public string rxData { get; set; }
        public string txData { get; set; }

        #endregion Properties
    }
}