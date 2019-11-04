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

namespace Control_Lab_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String[] productIdList = { "PID0001", "PID0002", "PID0003" };
        String[] productNameList = { "Super Red Cup", "God Blue Cup", "Nice Purple Cup" };
        int[] productPriceList = { 200, 350, 160 };
        String[] productImageList = { "/image/red.jpg", "/image/blue.jpg", "/image/purple.jpg" };

        public MainWindow()
        {
            InitializeComponent();

            List<string> ItemList = new List<string>();
            ItemList.AddRange(productIdList);
            productCode.ItemsSource = ItemList;
            productCode.SelectedIndex = 0;
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
  
         
        }


        private void ProductCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = productCode.SelectedIndex;
            proudctName.Text = productNameList[index];
            unitPrice.Text = productPriceList[index].ToString();
            productImage.Source = new BitmapImage(new Uri(productImageList[index], UriKind.Relative));
            updatePrice();
        }

        private void updatePrice()
        {
            int result = Int32.Parse(unitPrice.Text) * Int32.Parse(orderQty.Text);
            totalPrice.Text = result.ToString();
        }

        private void OrderQty_KeyDown(object sender, KeyEventArgs e)
        {
            updatePrice();
        }

        private void OrderQty_KeyUp(object sender, KeyEventArgs e)
        {
            updatePrice();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String qty = orderQty.Text;
            String name = proudctName.Text;
            String price = totalPrice.Text;
            String payment = "VISA";
            if (cash.IsChecked == true)
            {
                payment = "Cash";
            }
           
            String delivery = "";

            if (free.IsChecked == true)
            {
                delivery = "with free delivery";
            }
            String result = String.Format("You have ordered {0} units of {1} with total cost equal to HK${2}. Payment is {3} {4}",qty,name,price,payment,delivery);
            MessageBox.Show(result);
        }

        private void OrderQty_KeyUp_1(object sender, KeyEventArgs e)
        {
            updatePrice();
        }

        private void OrderQty_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            updatePrice();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            productCode.SelectedIndex = 0;
            ////orderQty.Text = "1";
        }
    }
}
