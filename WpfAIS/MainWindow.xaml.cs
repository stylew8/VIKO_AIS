using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
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

namespace WpfAIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly StudentRepository studentRepository;
        public MainWindow()
        {
            InitializeComponent();

            studentRepository = new RepositoryFactory("Prod").CreateStudentRepository();
        }


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.WindowLeft = this.Left;
            Properties.Settings.Default.WindowTop = this.Top;
            Properties.Settings.Default.Save();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private async void btnPrisijungti_Click(object sender, RoutedEventArgs e)
        {
            var x = await studentRepository.GetPersonByLogin(txtVar.Text);

            try
            {
                if (x.Password == Encrypt.HashPassword(txtPassword1.Password))
                {
                    var window = new SecondWindow(x);
                    window.Show();
                    this.Close();
                }
                else
                {
                    txtForErrors.Content = "Įvedete neteisinga vartotojo vardą arba slaptažodį";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
