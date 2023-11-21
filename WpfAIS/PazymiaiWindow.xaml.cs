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
    /// Interaction logic for PazymiaiWindow.xaml
    /// </summary>
    public partial class PazymiaiWindow : Window
    {
        Dalykas Dalykas = new Dalykas();
        List<Marks> Marks = new List<Marks>();
        MarksRepository marksRepository;
        Student Student = new Student();

        public PazymiaiWindow(Dalykas d,Student s)
        {
            InitializeComponent();
            marksRepository = new RepositoryFactory("Prod").CreateMarksRepository();
            Dalykas = d;
            Student = s;

            txtprisijungtas.Content = $"{Student.Premissions.ToUpper()}:{Student.Login},{Student.Surname} {Student.Name}";
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Marks = await marksRepository.GetAllMarksByDalykoId(Dalykas.Id);


            dtgPazymiai.ItemsSource = Marks;
        }

        private void btnIndPlanas_Click(object sender, RoutedEventArgs e)
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
    }
}
