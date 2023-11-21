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
    /// Interaction logic for IndividualusPlanasWindow.xaml
    /// </summary>
    public partial class IndividualusPlanasWindow : Window
    {
        private Student User = new Student();
        private readonly ProgrammRepository programmRepository;
        private int Kursas { get; set; }
        public IndividualusPlanasWindow(int kursas, Student student, string metai)
        {
            InitializeComponent();
            Kursas=kursas;
            User = student;
            programmRepository = new RepositoryFactory("Prod").CreateProgrammRepository();

            txtprisijungtas.Content = $"{User.Premissions.ToUpper()}:{User.Login},{User.Surname} {User.Name}";

            txtBla.Content = $"{User.Id}, {User.Surname} {User.Name} \n{User.Fakultetas}\nStudijų programa:{User.Programa}\nAkademinė grupė: {User.Grupe}";
            txtMetai.Content = metai.Split(' ')[0];
        }


        private async void dtgRudens_Loaded(object sender, RoutedEventArgs e)
        {
            dtgRudens.ItemsSource = await programmRepository.GetAllProgramosDalykus(Kursas,1,User.Grupe);
        }

        private async void dtgPavasario_Loaded(object sender, RoutedEventArgs e)
        {
            dtgPavasario.ItemsSource = await programmRepository.GetAllProgramosDalykus(Kursas, 2, User.Grupe);
        }

        private void btnPagrind_Click(object sender, RoutedEventArgs e)
        {
            var x = new SecondWindow(User);
            x.Show();
            this.Close();
        }

        private void RudensButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            DataGridRow dataGridRow = DataGridRow.GetRowContainingElement(button);
            Dalykas dalykas = (Dalykas)dataGridRow.Item;

            if (dalykas != null)
            {
                PazymiaiWindow pazymiai = new PazymiaiWindow(dalykas,User);
                pazymiai.Show();
                this.Close();
            }
        }

        private void PavasarioButton(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            DataGridRow dataGridRow = DataGridRow.GetRowContainingElement(button);
            Dalykas dalykas = (Dalykas)dataGridRow.Item;

            if (dalykas != null)
            {
                PazymiaiWindow pazymiai = new PazymiaiWindow(dalykas, User);
                pazymiai.Show();
                this.Close();
            }
        }

        private void btnKont_Click(object sender, RoutedEventArgs e)
        {
            var x = new KontaktiniaiWindow(User);
            x.Show();
            this.Close();
        }
    }
}
