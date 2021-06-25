using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAsyncProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IProgress<int> _progress;
        BusinessLogic _logic = new BusinessLogic();

        public MainWindow()
        {
            InitializeComponent();
            _progress = new Progress<int>(value => { myProgress.Value = value; });
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(async() => {
                string result = await _logic.DoSomething(_progress);
            });
        }
    }
}
