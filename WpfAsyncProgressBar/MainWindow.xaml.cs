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

        public MainWindow()
        {
            InitializeComponent();
            myProgress.Value = _currentProgress;
        }

        private void IncreaseProgressButton_Click(object sender, RoutedEventArgs e)
        {
            IProgress<int> progress = new Progress<int>(value => { myProgress.Value = value; });
            _currentProgress += 10;
            progress?.Report(_currentProgress);
        }
    }
}
