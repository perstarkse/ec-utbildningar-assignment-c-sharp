using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncAwaitWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBlockingCode_Click(object sender, RoutedEventArgs e)
        {
            tBlockStatus.Text = "";
            tBlockStatus.Text += "Downloading... \n";
            Thread.Sleep(3000);
            tBlockStatus.Text += "Installing... \n";
            Thread.Sleep(5000);
            tBlockStatus.Text += "Installing finished";
        }

        private async void btnNoneBlockingCode_Click(object sender, RoutedEventArgs e)
        {
            await DoWorkAsync();
        }

        private async Task DoWorkAsync()
        {
            tBlockStatus.Text = "";
            tBlockStatus.Text += "Downloading... \n";
            await Task.Run(() => Thread.Sleep(3000));
            tBlockStatus.Text += "Installing... \n";
            await Task.Run(() => Thread.Sleep(5000));
            tBlockStatus.Text += "Installing finished";
        }
    }
}
