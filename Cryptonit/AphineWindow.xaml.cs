using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Shapes;
using Cryptonit.Algoritms;

namespace Cryptonit
{
    /// <summary>
    /// Interaction logic for AphineWindow.xaml
    /// </summary>
    public partial class AphineWindow : Window
    {
        public AphineWindow()
        {
            InitializeComponent();
        }

        private void AphineStart(object sender, RoutedEventArgs e)
        {
            string buffer = "";

            if (String.IsNullOrWhiteSpace(AphineTextBox1.Text))
                return;
            if (String.IsNullOrWhiteSpace(AphineTextBox2.Text))
                return;
            if (String.IsNullOrWhiteSpace(AchipherBox.Text))
                return;
            if (String.IsNullOrWhiteSpace(BchipherBox.Text))
                return;



            using (FileStream fileStream = File.OpenRead(AphineTextBox1.Text))
            {


                byte[] array = new byte[fileStream.Length];

                fileStream.Read(array, 0, array.Length);

               string cipher = System.Text.Encoding.Default.GetString(array);

                int a = Int32.Parse(AchipherBox.Text);
                int b = Int32.Parse(BchipherBox.Text);

               buffer = Affine.AffineEncrypt(cipher, a, b);
            }


            using (FileStream fileStream = new FileStream(AphineTextBox2.Text, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(buffer);
                fileStream.Write(array, 0, array.Length);

            }


            AphineTextBox1.Text = "";
            AphineTextBox2.Text = "";

        }

        private void ChekFileExist(object sender, RoutedEventArgs e)
        {

            BitmapImage tick = new BitmapImage();
            tick.BeginInit();

            tick.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Content/tick.png");
            tick.EndInit();
            BitmapImage noTick = new BitmapImage();
            noTick.BeginInit();
            noTick.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Content/No_tick.png");
            noTick.EndInit();


            if (String.IsNullOrWhiteSpace(AphineTextBox1.Text))
            {
                Tick1.Source = noTick;
                return;
            }

           FileInfo file = new FileInfo(AphineTextBox1.Text);




            if (file.Exists)
            {
                Tick1.Source = tick;
            }
            else
            {
                Tick1.Source = noTick;
            }
        }

        private void ChekFileExist2(object sender, RoutedEventArgs e)
        {
            BitmapImage tick = new BitmapImage();
            tick.BeginInit();

            tick.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Content/tick.png");
            tick.EndInit();
            BitmapImage noTick = new BitmapImage();
            noTick.BeginInit();
            noTick.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + "/Content/No_tick.png");
            noTick.EndInit();

            if (String.IsNullOrWhiteSpace(AphineTextBox1.Text))
            {
                Tick2.Source = noTick;
                return;
            }

            FileInfo file = new FileInfo(AphineTextBox2.Text);


            if (file.Exists)
            {
                Tick2.Source = tick;
            }
            else
            {
                Tick2.Source = noTick;
            }
        }


        private void DecryptCipher(object sender, RoutedEventArgs e)
        {
            string buffer = "";

            if (String.IsNullOrWhiteSpace(AphineTextBox1.Text))
                return;
            if (String.IsNullOrWhiteSpace(AphineTextBox2.Text))
                return;
            if (String.IsNullOrWhiteSpace(AchipherBox.Text))
                return;
            if (String.IsNullOrWhiteSpace(BchipherBox.Text))
                return;

            FileInfo file = new FileInfo(AphineTextBox1.Text);

            if (file.Exists)
            {

                using (FileStream fileStream = File.OpenRead(AphineTextBox1.Text))
                {


                    byte[] array = new byte[fileStream.Length];

                    fileStream.Read(array, 0, array.Length);

                    string text = System.Text.Encoding.Default.GetString(array);

                    int a = Int32.Parse(AchipherBox.Text);
                    int b = Int32.Parse(BchipherBox.Text);


                    buffer = Affine.AffineDecrypt(text, a, b);
                }


                using (FileStream fileStream = new FileStream(AphineTextBox2.Text, FileMode.OpenOrCreate))
                {
                    byte[] array = Encoding.Default.GetBytes(buffer);
                    fileStream.Write(array, 0, array.Length);

                }


            }
            else
            {
                AphineTextBox1.Text = "File is not exist";
            }


            AphineTextBox1.Text = "";
            AphineTextBox2.Text = "";
        }
    }
}
