using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
using Cryptonit.Algoritms;

namespace Cryptonit
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

        private void CheckForSimple(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrWhiteSpace(FirstNumberBox.Text))
                return;
            if (String.IsNullOrWhiteSpace(SecondNumberBox.Text))
                return;



            long aNumber = long.Parse(FirstNumberBox.Text);
            long bNumber = long.Parse(SecondNumberBox.Text);
            long x=0, y=0;

           long res =  Euclid.gcd(aNumber, bNumber);
           long res2 = Euclid.egcd(aNumber, bNumber, ref x, ref y);

                if (aNumber % bNumber == 0 || x == 1 && y == 0)
                {
                    FirstNumberBox.Text = "No";
                    SecondNumberBox.Text = "";
                }
                else
                {
                    FirstNumberBox.Text = "YES";
                    SecondNumberBox.Text = x.ToString() + " and " + y.ToString();
                }
            
         

        }

        private void GoToAphineFrame(object sender, RoutedEventArgs e)
        {
         AphineWindow page = new AphineWindow();
         page.Show();
                  
        }

        private void GoToCessarFrame(object sender, RoutedEventArgs e)
        {
            CessarWindow page = new CessarWindow();
            page.Show();
        }
    }
}
