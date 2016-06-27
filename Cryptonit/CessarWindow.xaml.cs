using System;
using System.Collections.Generic;
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
    /// Interaction logic for CessarWindow.xaml
    /// </summary>
    public partial class CessarWindow : Window
    {
        public CessarWindow()
        {
            InitializeComponent();
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


            if (String.IsNullOrWhiteSpace(CessarTextBox1.Text))
            {
                Tick1C.Source = noTick;
                return;
            }

            FileInfo file = new FileInfo(CessarTextBox1.Text);




            if (file.Exists)
            {
                Tick1C.Source = tick;
            }
            else
            {
                Tick1C.Source = noTick;
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


            if (String.IsNullOrWhiteSpace(CessarTextBox2.Text))
            {
                Tick2C.Source = noTick;
                return;
            }

            FileInfo file = new FileInfo(CessarTextBox2.Text);




            if (file.Exists)
            {
                Tick2C.Source = tick;
            }
            else
            {
                Tick2C.Source = noTick;
            }
        }

        private void CessarStart(object sender, RoutedEventArgs e)
        {

            string buffer = "";

            if (String.IsNullOrWhiteSpace(CessarTextBox1.Text))
                return;
            if (String.IsNullOrWhiteSpace(CessarTextBox2.Text))
                return;
            if (String.IsNullOrWhiteSpace(AchipherBox.Text))
                return;
            



            using (FileStream fileStream = File.OpenRead(CessarTextBox1.Text))
            {


                byte[] array = new byte[fileStream.Length];

                fileStream.Read(array, 0, array.Length);

                string cipher = System.Text.Encoding.Default.GetString(array);

                int key = Int32.Parse(AchipherBox.Text);


                buffer = Cessar.CessarEncrypt(cipher, key);
            }


            using (FileStream fileStream = new FileStream(CessarTextBox2.Text, FileMode.OpenOrCreate))
            {
                byte[] array = Encoding.Default.GetBytes(buffer);
                fileStream.Write(array, 0, array.Length);

            }


            CessarTextBox1.Text = "";
            CessarTextBox2.Text = "";
        }

        private void DecryptCipher(object sender, RoutedEventArgs e)
        {
            string buffer = "";

            if (String.IsNullOrWhiteSpace(CessarTextBox1.Text))
                return;
            if (String.IsNullOrWhiteSpace(CessarTextBox2.Text))
                return;
            if (String.IsNullOrWhiteSpace(AchipherBox.Text))
                return;
            

            FileInfo file = new FileInfo(CessarTextBox1.Text);

            if (file.Exists)
            {

                using (FileStream fileStream = File.OpenRead(CessarTextBox1.Text))
                {


                    byte[] array = new byte[fileStream.Length];

                    fileStream.Read(array, 0, array.Length);

                    string text = System.Text.Encoding.Default.GetString(array);

                    int key = Int32.Parse(AchipherBox.Text);



                    buffer = Cessar.CessarDecrypt(text, key);

                }


                using (FileStream fileStream = new FileStream(CessarTextBox2.Text, FileMode.OpenOrCreate))
                {
                    byte[] array = Encoding.Default.GetBytes(buffer);
                    fileStream.Write(array, 0, array.Length);

                }


            }
            else
            {
                CessarTextBox1.Text = "File is not exist";
            }


            CessarTextBox1.Text = "";
            CessarTextBox2.Text = "";
        }
    }
    }

