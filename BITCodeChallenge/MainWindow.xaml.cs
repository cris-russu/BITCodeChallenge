using BITCodeChallenge.Models;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Xml.Serialization;
using BITCodeChallenge.ViewModels;

namespace BITCodeChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filePath;


        public MainWindow()
        {
            InitializeComponent();

            Title = "Boyum IT Challenge";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.DefaultExt = "xml";
                openFileDialog.Title = "Select your xml input file";
                openFileDialog.Filter = "XML files (*.xml) |*.xml";
                filePath = openFileDialog.FileName;
                FilePath_TxtBox.Text = filePath;
            }
        }

        private void btnProcessFile_Click(object sender, RoutedEventArgs e)
        {
            WebOrderModel webOrder = new WebOrderModel();
            webOrder = webOrder.DeserializeToObject<WebOrderModel>(filePath);
            WebOrder woVM = new WebOrder(webOrder);
            viewString.Content = woVM.ToString();
        }




    }
}
