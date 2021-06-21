using System.Windows;

namespace SerialTester_Real
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        #region Constructors

        private App()
        {
            Main main = new Main();
            main.ShowDialog();
        }

        #endregion Constructors

    }
}