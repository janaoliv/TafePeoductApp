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

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;
        decimal subtotalDelivery, subtotalWrap, subtotal, GSTTotal;
        decimal DELIVERY_FEE = 25;
        decimal WRAP_FEE = 5;
        decimal GST_FEE = 1.1M;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
            subtotal = cProduct.TotalPayment;
            subtotalDelivery = subtotal + DELIVERY_FEE;
            subtotalWrap = subtotalDelivery + WRAP_FEE;
            GSTTotal = subtotalWrap * GST_FEE;
            totalChargeTextBlock.Text = Convert.ToString(subtotalDelivery);
            totalChargeWrap.Text = Convert.ToString(subtotalWrap);
            totalChargeWithGST.Text = Convert.ToString(GSTTotal);
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBlock.Text = "";
            totalChargeWrap.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
