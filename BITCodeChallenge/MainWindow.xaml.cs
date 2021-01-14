using BITCodeChallenge.Models;
using System.IO;
using Microsoft.Win32;
using System.Windows;
using System.Xml.Serialization;
using BITCodeChallenge.ViewModels;
using BITCodeChallenge.Logic;
using System;

namespace BITCodeChallenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string filePath;
       
        //todo: handle window maximization properly
 

        public MainWindow()
        {
            InitializeComponent();

            Title = "Boyum IT Challenge";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Id.Content = string.Empty;
            Customer.Content = string.Empty;
            Date.Content = string.Empty;
            PriceAvg.Content = string.Empty;
            Total.Content = string.Empty;

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
            FilePath_TxtBox.Text = string.Empty;
            WebOrderModel webOrderModel = new WebOrderModel();
            try
            {
                webOrderModel = WebOrderHelpers.DeserializeToObject<WebOrderModel>(filePath);
            }
            catch (System.Exception exception)
            {
                MessageBox.Show($"There was an error in processing your file. Make sure it is the correct type and format. {Environment.NewLine}" +
                    $"Error message: {exception.Message}");
            }

            WebOrder webOrderView = new WebOrder();
            if (webOrderModel.Equals(new WebOrderModel()))
            {
                MessageBox.Show("There seems to be an error with your input file. Check its structure and try again.");
            }
            else
            {
                webOrderView = new WebOrder(webOrderModel);
                Id.Content = webOrderView.ID == 0 ? "Wrong order ID" : webOrderView.ID.ToString();
                Customer.Content = string.IsNullOrEmpty(webOrderView.Customer) ? "No customer name found." : webOrderView.Customer;
                Date.Content = webOrderView.Date.Equals(new System.DateTime(0001, 01, 01)) ? Date.Content = "Wrong date format" : webOrderView.Date;
                PriceAvg.Content = webOrderView.PriceAvg.Equals("000.000") ? "No items found" : webOrderView.PriceAvg;
                Total.Content = webOrderView.Total.Equals("000.000") ? "No items found" : webOrderView.Total;
            }
        }




    }
}
