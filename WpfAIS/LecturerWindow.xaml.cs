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
using Xceed.Wpf.Toolkit.Primitives;

namespace WpfAIS
{
    /// <summary>
    /// Interaction logic for LecturerWindow.xaml
    /// </summary>
    public partial class LecturerWindow : Window
    {
        Student User;
        DalykasRepository dalykasRepository;
        MarksRepository marksRepository;
        ProgrammRepository programmRepository;
        StudentRepository studentRepository;
        public LecturerWindow(Student x)
        {
            InitializeComponent();
            User = x;
            dalykasRepository = new RepositoryFactory("Prod").CreateDalykasRepository();
            marksRepository = new RepositoryFactory("Prod").CreateMarksRepository();
            programmRepository = new RepositoryFactory("Prod").CreateProgrammRepository();
            studentRepository = new RepositoryFactory("Prod").CreateStudentRepository();

            if (User.Premissions == "lecturer" || User.Premissions == "student")
            {
                btnAdmin.Visibility = Visibility.Hidden;
            }

            txtprisijungtas1.Content = $"{User.Premissions.ToUpper()}:{User.Login},{User.Surname} {User.Name}";
        }

        private void btnSukurti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbDalykas.SelectedItem == null)
                {
                    MessageBox.Show("Dalykas nebuvo pasirinktas.");
                    return;
                }

                var selectedItem = cbDalykas.SelectedItem as Dalykas;
                if (selectedItem == null)
                {
                    MessageBox.Show("Netinkamas dalykas.");
                    return;
                }

                var a = new Marks()
                {
                    DalykoId = selectedItem.Id,
                    Procentas = txtProcentas.Text,
                    Description = txtAprasymas.Text
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void cbDalykas_Loaded(object sender, RoutedEventArgs e)
        {
            var dalykai = await dalykasRepository.GetDalykaiByLecturerId(User.Id);

            cbDalykas.DisplayMemberPath = "FullName";
            cbDalykas.SelectedValuePath = "Id";

            cbDalykas.Items.Clear();

            cbDalykas.ItemsSource = dalykai;
        }

        private async void btnSukurti_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbDalykas.SelectedItem == null)
                {
                    MessageBox.Show("Dalykas nebuvo pasirinktas.");
                    return;
                }

                var selectedItem = cbDalykas.SelectedItem as Dalykas;
                if (selectedItem == null)
                {
                    MessageBox.Show("Netinkamas dalykas.");
                    return;
                }

                var programmName = await programmRepository.GetProgrammNameByDalykoId(selectedItem.Id);
                var students = await studentRepository.GetAllStudentsByProgrammName(programmName);

                var x = new Marks()
                {
                    DalykoId = selectedItem.Id,
                    Description = txtAprasymas.Text,
                    Procentas = txtProcentas.Text,
                };
                await marksRepository.CreateNewMark(x, students);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void cbDalykas_Copy_Loaded(object sender, RoutedEventArgs e)
        {
            var dalykai = await dalykasRepository.GetDalykaiByLecturerId(User.Id);

            cbDalykas_Copy.DisplayMemberPath = "FullName";
            cbDalykas_Copy.SelectedValuePath = "Name";

            cbDalykas_Copy.Items.Clear();

            cbDalykas_Copy.ItemsSource = dalykai;
        }


        private async void cbDalykas_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbDalykas_Copy.SelectedItem == null)
                {
                    MessageBox.Show("Dalykas nebuvo pasirinktas");
                    return;
                }

                var selectedItem = cbDalykas_Copy.SelectedItem as Dalykas;
                if (selectedItem == null)
                {
                    MessageBox.Show("Netinkamas dalykas");
                    return;
                }

                var uzKa = await marksRepository.GetAllUniqDescByDalykoId(selectedItem.Id);

                cbUzka.ItemsSource = uzKa;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void cbUzka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbDalykas_Copy.SelectedItem == null)
                {
                    MessageBox.Show("Dalykas nebuvo pasirinktas");
                    return;
                }

                var selectedItem = cbDalykas_Copy.SelectedItem as Dalykas;
                if (selectedItem == null)
                {
                    MessageBox.Show("Netinkamas dalykas");
                    return;
                }

                var programmName = await programmRepository.GetProgrammNameByDalykoId(selectedItem.Id);
                var students = await studentRepository.GetAllStudentsByProgrammName(programmName);

                cbStudentai.DisplayMemberPath = "FullName";
                cbStudentai.SelectedValuePath = "Id";

                cbStudentai.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbPazymis_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> pazymiai = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            cbPazymis.Items.Clear();

            cbPazymis.ItemsSource = pazymiai;
        }

        private async void btnIrasyti_Click(object sender, RoutedEventArgs e)
        {
            if (cbDalykas_Copy == null || cbUzka == null || cbStudentai == null || cbPazymis == null)
            {
                btnIrasyti.IsEnabled = false;
                return;
            }
            else
            {
                if (cbPazymis.SelectedItem is int x)
                {
                    await marksRepository.UpdateMarkByStudentByProcentasAndByDalykas(cbDalykas_Copy.SelectedItem as Dalykas,
                                                                                cbUzka.SelectedItem as string,
                                                                                cbStudentai.SelectedItem as Student,
                                                                                x);
                } 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();
        }

        private void btnKont_Click(object sender, RoutedEventArgs e)
        {
            var x = new KontaktiniaiWindow(User);
            x.Show();
            this.Close();
        }
    }
}
