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
        private int _currentProgress = 0;
        IProgress<int> _progress;

        public MainWindow()
        {
            InitializeComponent();
            myProgress.Value = _currentProgress;
            _progress = new Progress<int>(value => { myProgress.Value = value; });
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(async () => {
                while (_currentProgress < 100)
                {
                    _currentProgress += 10;
                    _progress?.Report(_currentProgress);
                    await Task.Delay(500);
                }
            });
        }
    }
}
