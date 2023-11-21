using DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfAIS
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private Student User = new Student();

        public SecondWindow(Student x)
        {
            InitializeComponent();
            User = x;
            this.Loaded += Window_Loaded;
        }

        public int DabarMetai()
        {
            return int.Parse(DateTime.Now.ToString("yyyy"));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = Properties.Settings.Default.WindowLeft;
            this.Top = Properties.Settings.Default.WindowTop;

            txtprisijungtas1.Content = $"{User.Premissions.ToUpper()}:{User.Login},{User.Surname} {User.Name}";


            if (User.Premissions == "student")
            {
                btnAdmin.Visibility = Visibility.Hidden;
                btnLecturer.Visibility = Visibility.Hidden;

                if (User.Kursas == "1")
                {
                    btnPirmiMetai1.Content = $"{DabarMetai()}/{DabarMetai() + 1} m.m {User.Fakultetas}";
                    btnAntriMetai1.Content = $"{DabarMetai() + 1}/{DabarMetai() + 2} m.m {User.Fakultetas}";
                    btnTretiMetai1.Content = $"{DabarMetai() + 2}/{DabarMetai() + 3} m.m {User.Fakultetas}";
                    btnKetverti1.Content = $"{DabarMetai() + 3}/{DabarMetai() + 4} m.m {User.Fakultetas}";
                    btnAntriMetai1.IsEnabled = false;
                    btnTretiMetai1.IsEnabled = false;
                    btnKetverti1.IsEnabled = false;
                    btnAntriMetai1.Background = new SolidColorBrush(Colors.Gray);
                    btnTretiMetai1.Background = new SolidColorBrush(Colors.Gray);
                    btnKetverti1.Background = new SolidColorBrush(Colors.Gray);
                }
                else if (User.Kursas == "2")
                {
                    btnPirmiMetai1.Content = $"{DabarMetai() - 1}/{DabarMetai()} m.m {User.Fakultetas}";
                    btnAntriMetai1.Content = $"{DabarMetai()}/{DabarMetai() + 1} m.m {User.Fakultetas}";
                    btnTretiMetai1.Content = $"{DabarMetai() + 1}/{DabarMetai() + 2} m.m {User.Fakultetas}";
                    btnKetverti1.Content = $"{DabarMetai() + 2}/{DabarMetai() + 3} m.m {User.Fakultetas}";
                    btnTretiMetai1.IsEnabled = false;
                    btnKetverti1.IsEnabled = false;
                    btnTretiMetai1.Background = new SolidColorBrush(Colors.Gray);
                    btnKetverti1.Background = new SolidColorBrush(Colors.Gray);
                }
                else if (User.Kursas == "3")
                {
                    btnPirmiMetai1.Content = $"{DabarMetai() - 2}/{DabarMetai() - 1} m.m {User.Fakultetas}";
                    btnAntriMetai1.Content = $"{DabarMetai() - 1}/{DabarMetai()} m.m {User.Fakultetas}";
                    btnTretiMetai1.Content = $"{DabarMetai()}/{DabarMetai() + 1} m.m {User.Fakultetas}";
                    btnKetverti1.Content = $"{DabarMetai() + 1}/{DabarMetai() + 2} m.m {User.Fakultetas}";
                    btnKetverti1.IsEnabled = false;
                    btnKetverti1.Background = new SolidColorBrush(Colors.Gray);
                }
                else if (User.Kursas == "4")
                {
                    btnPirmiMetai1.Content = $"{DabarMetai() - 3}/{DabarMetai() - 2} m.m {User.Fakultetas}";
                    btnAntriMetai1.Content = $"{DabarMetai() - 2}/{DabarMetai() - 1} m.m {User.Fakultetas}";
                    btnTretiMetai1.Content = $"{DabarMetai() - 1}/{DabarMetai()} m.m {User.Fakultetas}";
                    btnKetverti1.Content = $"{DabarMetai()}/{DabarMetai() + 1} m.m {User.Fakultetas}";
                }
            }
            else if (User.Premissions == "lecturer")
            {
                btnAdmin.Visibility = Visibility.Hidden;

                btnPirmiMetai1.IsEnabled= false;
                btnAntriMetai1.IsEnabled = false;
                btnTretiMetai1.IsEnabled = false;
                btnKetverti1.IsEnabled = false;
            }
            else if (User.Premissions == "admin")
            {

                btnPirmiMetai1.IsEnabled = false;
                btnAntriMetai1.IsEnabled = false;
                btnTretiMetai1.IsEnabled = false;
                btnKetverti1.IsEnabled = false;
            }
            
        }

        private void btnPirmiMetai1_Click(object sender, RoutedEventArgs e)
        {
            var x = new IndividualusPlanasWindow(1,User,btnPirmiMetai1.Content.ToString());
            x.Show();
            this.Close();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adm = new AdminWindow(User);
            adm.Show();
            this.Close();
        }

        private void btnAntriMetai1_Click(object sender, RoutedEventArgs e)
        {
            var x = new IndividualusPlanasWindow(2, User, btnAntriMetai1.Content.ToString());
            x.Show();
            this.Close();
        }

        private void btnTretiMetai1_Click(object sender, RoutedEventArgs e)
        {
            var x = new IndividualusPlanasWindow(3, User, btnTretiMetai1.Content.ToString());
            x.Show();
            this.Close();
        }

        private void btnKetverti1_Click(object sender, RoutedEventArgs e)
        {
            var x = new IndividualusPlanasWindow(4, User, btnKetverti1.Content.ToString());
            x.Show();
            this.Close();
        }

        private void btnLecturer_Click(object sender, RoutedEventArgs e)
        {
            var x = new LecturerWindow(User);
            x.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var x = new KontaktiniaiWindow(User);
            x.Show();
            this.Close();
        }
    }
}
