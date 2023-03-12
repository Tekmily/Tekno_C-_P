using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
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

namespace TKSP
{
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton==MouseButtonState.Pressed) 
            {
                DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState=WindowState.Minimized;
        }

        private void onefunctionality_Click(object sender, RoutedEventArgs e)
        {
            fibonnaciGird.Visibility=Visibility.Visible;
            matrisDizisiGrid.Visibility = Visibility.Hidden;
            dataMonitorGrid.Visibility=Visibility.Hidden;
            dataSortByGird.Visibility=Visibility.Hidden;
            multiplicationGird.Visibility=Visibility.Hidden;
            hiPanel.Visibility = Visibility.Hidden;
        }

        private void twofunctionality_Click(object sender, RoutedEventArgs e)
        {
            fibonnaciGird.Visibility = Visibility.Hidden;
            matrisDizisiGrid.Visibility = Visibility.Visible;
            dataMonitorGrid.Visibility = Visibility.Hidden;
            dataSortByGird.Visibility = Visibility.Hidden;
            multiplicationGird.Visibility = Visibility.Hidden;
            hiPanel.Visibility = Visibility.Hidden;
        }

        private void threefunctionality_Click(object sender, RoutedEventArgs e)
        {
            fibonnaciGird.Visibility = Visibility.Hidden;
            matrisDizisiGrid.Visibility = Visibility.Hidden;
            dataMonitorGrid.Visibility = Visibility.Visible;
            dataSortByGird.Visibility = Visibility.Hidden;
            multiplicationGird.Visibility = Visibility.Hidden;
            hiPanel.Visibility = Visibility.Hidden;
        }

        private void fourfunctionality_Click(object sender, RoutedEventArgs e)
        {
            fibonnaciGird.Visibility = Visibility.Hidden;
            matrisDizisiGrid.Visibility = Visibility.Hidden;
            dataMonitorGrid.Visibility = Visibility.Hidden;
            dataSortByGird.Visibility = Visibility.Visible;
            multiplicationGird.Visibility = Visibility.Hidden;
            hiPanel.Visibility = Visibility.Hidden;
        }

        private void fivefunctionality_Click(object sender, RoutedEventArgs e)
        {
            fibonnaciGird.Visibility = Visibility.Hidden;
            matrisDizisiGrid.Visibility = Visibility.Hidden;
            dataMonitorGrid.Visibility = Visibility.Hidden;
            dataSortByGird.Visibility = Visibility.Hidden;
            multiplicationGird.Visibility = Visibility.Visible;
            hiPanel.Visibility = Visibility.Hidden;
        }      

        //fibonacci hesaplaması Başlangıç
        /*
         Bir textbox’a kaç yazarsam, düğmeye basıldığında, ekranda,
        o sıradaki Fibonacci sayısını görmeliyim. Örneğin kutuya 12
        yazarsam, ekranda 89 göstermeli. Fibonacci serisinde, 
        birinci sıradaki sayı 0, ikinci sıradaki sayı 1’dir.
         */
        
        private void fibonnacibtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int n = int.Parse(txtfibonacci.Text);
                int fib = Fibonacci(n);
               fibonacciresultLabel.Content="Fibonacci number: " + fib;
                fibonacciLabel.Background = Brushes.Transparent;
                fibonacciLabel.Foreground = Brushes.Orange;
            }
            catch (FormatException)
            {
                fibonacciLabel.Content = "Lütfen bir sayı girin !";
                fibonacciLabel.Background = Brushes.Red;
                fibonacciLabel.Foreground = Brushes.Yellow;
            }
        }
        private void txtNumber_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsNumeric(e.Text);
        }
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private int Fibonacci(int n)
        {

            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                int a = 1;
                int b = 1;
                int fibonacciNumber = 0;

                for (int i = 4; i <= n; i++)
                {
                    fibonacciNumber = a + b;
                    a = b;
                    b = fibonacciNumber;
                }

                return fibonacciNumber;
            }
        }

       private void txtfibonacci_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtfibonacci.Text = "";
        }
        //fibonacci bitiş
        //Matris
        private void matrisbtn_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (int.TryParse(matrisTexbox.Text, out n) && n >= 1 && n <= 15)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i <= n; i++)
                {
                    for (int j = 0; j <= n; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            sb.Append("    ");
                        }
                        else if (i == 0)
                        {
                            sb.AppendFormat("{0,4}", j);
                        }
                        else if (j == 0)
                        {
                            sb.AppendFormat("{0,4}", i);
                        }
                        else
                        {
                            sb.AppendFormat("{0,4}", i * j);
                        }
                    }
                    sb.AppendLine();
                }

                txtmatris.Text = sb.ToString();
                matrisLabel.Background = Brushes.Transparent;
                matrisLabel.Foreground = Brushes.Black;

            }
            else
            {
                matrisLabel.Content = "Lütfen 1 ile 15 arasında bir tam sayı giriniz.";
                matrisLabel.Background = Brushes.Red;
                matrisLabel.Foreground = Brushes.Yellow;
           
            }
        }
        private void matrisClearbtn_Click(object sender, RoutedEventArgs e)
        {
            txtmatris.Text=string.Empty;
            matrisTexbox.Text = string.Empty;
            matrisLabel.Background = Brushes.Transparent;
            matrisLabel.Foreground = Brushes.Black;
        }
        //matris bitiş
        //zigzag yazdırma başlangıç

        private void dataMonitorbtn_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 1; i <= 200; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    if (i >= 100)
                    {
                        dataMonitorListbox.Items.Add("zagzig ");
                        Console.WriteLine("zagzig ");
                    }
                    else
                    {
                        dataMonitorListbox.Items.Add("zigzag ");
                        Console.WriteLine("zigzag ");
                    }
                }
                else if (i % 3 == 0)
                {

                    dataMonitorListbox.Items.Add("zig ");
                    Console.WriteLine("zig ");
                }
                else if (i % 5 == 0)
                {
                    dataMonitorListbox.Items.Add("zag ");
                    Console.WriteLine("zag ");
                }
                else
                {
                    dataMonitorListbox.Items.Add(i + " ");
                    Console.WriteLine(i + " ");
                }
            }
            Console.ReadLine();
        }
        private void dataMonitorSavebtn_Click(object sender, RoutedEventArgs e)
        {
           
            
                // Kaydedilecek dosya konumunu kullanıcıya seçtirin
                var saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Files (*.txt)|*.txt";
                if (saveDialog.ShowDialog() == true)
                {
                    // Seçilen konuma bir StreamWriter nesnesi oluşturun
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName))
                    {
                        // ListBox öğelerini dosyaya yazın
                        foreach (var item in dataMonitorListbox.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("Veriler metin dosyasına kaydedildi.");
                
            }

        }
        //zigzag yazdırma bitiş
        //Çağrılan Sayıları Sıralama başlangış
        private void dataSortBybtn_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            openFileDialog.Title = "Metin Dosyası Seçin";
            if (openFileDialog.ShowDialog() == true)
            {
                string temp = "";
                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
                List<double> numbers = new List<double>();
                
                foreach (string line in lines)
                {
                    string[] tokens = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string token in tokens)
                    {
                        double number;
                        if (double.TryParse(token, out number))
                        {
                           
                               
                           
                                numbers.Add(number);
                            
                           
                        }
                    }
                }
                
                numbers.Sort();
                foreach (double number in numbers)
                {
                   
                    
                  
                    dataSortBytexbox2.Text = number.ToString()+" " ;
                    temp += dataSortBytexbox2.Text;


                }
                txtdataSortBy.AppendText(temp  + Environment.NewLine);
            }

        }
        private void dataSortByClearbtn_Click(object sender, RoutedEventArgs e)
        {
            dataSortBytexbox2.Text = "";
            txtdataSortBy.Text = "";
        }
        //Çağrılan Sayıları Sıralama bitiş
        //3 textbox'a girilen sayıları hesaplama başlangıç
        private void multiplicationbtn_Click(object sender, RoutedEventArgs e)
        {
            int num1, num2, num3;

            if (int.TryParse(multiplicationtexbox1.Text, out num1) && int.TryParse(multiplicationtexbox2.Text, out num2) && int.TryParse(multiplicationtexbox3.Text, out num3))
            {
                int resultshow = (num1 + num2) * num3;
                multiplicationResult.Text = resultshow.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen sadece rakam giriniz!");
            }
        }
        private void multiplicationClearbtn_Click(object sender, RoutedEventArgs e)
        {
            multiplicationtexbox1.Text = string.Empty;
            multiplicationtexbox2.Text = string.Empty;
            multiplicationtexbox3.Text = string.Empty;
            multiplicationResult.Text= string.Empty;

        }//3 textbox'a girilen sayıları hesaplama bitiş

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://github.com/Tekmily");
        }
    }
}
