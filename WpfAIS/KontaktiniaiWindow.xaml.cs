using DataAccess;
using DataAccess.Repository;
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
using System.Windows.Shapes;

namespace WpfAIS
{
    /// <summary>
    /// Interaction logic for KontaktiniaiWindow.xaml
    /// </summary>
    public partial class KontaktiniaiWindow : Window
    {
        Student Student = new Student();
        StudentRepository studentRepository;

        public KontaktiniaiWindow(Student s)
        {
            InitializeComponent();
            studentRepository = new RepositoryFactory("Prod").CreateStudentRepository();
            Student = s;
            txtPareigos.Content = $"{Student.Premissions.ToUpper()}:{Student.Surname} {Student.Name}";
            txtprisijungtas1.Content = $"{Student.Premissions.ToUpper()}:{Student.Login},{Student.Surname} {Student.Name}";

            txtValstybe.Text = $"{Student.Valstybe}";
            txtMiestas.Text = Student.Miestas;
            txtGatve.Text = Student.Gatve;
            txtTelefonas.Text = Student.Telefonas;

            txtElPastas.Text = Student.AsmPastas;

            if (Student.Premissions == "lecturer" || Student.Premissions == "student")
            {
                btnAdmin.Visibility = Visibility.Hidden;
            }

            if (Student.Premissions == "student")
            {
                btnDest.Visibility = Visibility.Hidden;
            }
        }

        private void btnPagrMeniu_Click(object sender, RoutedEventArgs e)
        {
            var x = new SecondWindow(Student);
            x.Show();
            this.Close();
        }

        private void btnAtsijungti_Click(object sender, RoutedEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();
        }

        private void btnKont_Click(object sender, RoutedEventArgs e)
        {
            var x = new KontaktiniaiWindow(Student);
            x.Show();
            this.Close();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Student.Valstybe = txtValstybe.Text;
            Student.Miestas = txtMiestas.Text;
            Student.Gatve = txtGatve.Text;
            Student.AsmPastas = txtElPastas.Text;
            Student.Telefonas = txtTelefonas.Text;

            bool c = await studentRepository.UpdateStudentAsync(Student);

            if (c)
            {
                MessageBox.Show("Duomenys buvo atnaujinti");
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            var x = new AdminWindow(Student);
            x.Show();
            this.Close();
        }

        private void btnDest_Click(object sender, RoutedEventArgs e)
        {
            var x = new LecturerWindow(Student);

            x.Show();
            this.Close();
        }
    }
}
