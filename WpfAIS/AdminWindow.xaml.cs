using DataAccess;
using DataAccess.Model;
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
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace WpfAIS
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private Student User = new Student();
        private readonly StudentRepository studentRepository;
        private readonly DalykasRepository dalykasRepository;
        private readonly ProgrammRepository programmRepository;
        public AdminWindow(Student adm)
        {
            InitializeComponent();
            User = adm;

            studentRepository = new RepositoryFactory("Prod").CreateStudentRepository();
            dalykasRepository = new RepositoryFactory("Prod").CreateDalykasRepository();
            programmRepository = new RepositoryFactory("Prod").CreateProgrammRepository();
        }

        private async void btnSukurtiVartotoja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newPerson = new Student()
                {
                    Id = 0,
                    Premissions = txtPrem.Text,
                    Telefonas = txtTelefonas.Text,
                    AsmPastas = txtAsmPastas.Text,
                    Fakultetas = txtFakultetas.Text,
                    Name = txtVardas.Text,
                    Surname = txtPavarde.Text,
                    Grupe = txtGruupe.Text,
                    Kursas = txtKursas.Text,
                    Semestras = int.Parse(txtSemestras.Text),
                    Programa = txtPrograma.Text,
                    Gatve = "Nenustatyta",
                    Miestas = "Nenustatytas",
                    Valstybe = "Lietuva",
                };

                if (newPerson.Premissions=="student")
                {
                  await studentRepository.CreateStudentAsync(newPerson);
                }
                else 
                {
                    await studentRepository.CreateLecturerAsync(newPerson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                var lecturers = await studentRepository.GetAllLecturers();

                comboBoxLec.DisplayMemberPath = "FullName";
                comboBoxLec.SelectedValuePath = "Id";
                comboBoxLec.ItemsSource = lecturers;
            }

        }

        private async void comboBoxLec_Loaded(object sender, RoutedEventArgs e)
        {
            var lecturers = await studentRepository.GetAllLecturers();

            comboBoxLec.DisplayMemberPath = "FullName";
            comboBoxLec.SelectedValuePath = "Id";
            comboBoxLec.ItemsSource = lecturers;
        }

        private async void btnSukurtiDalyka_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBoxLec.SelectedItem == null)
                {
                    MessageBox.Show("Lektorius nebuvo pasirinktas.");
                    return;
                }

                var selectedItem = comboBoxLec.SelectedItem as Person;
                if (selectedItem == null)
                {
                    MessageBox.Show("Netinkamas lektorius.");
                    return;
                }


                var newDalykas = new Dalykas()
                {
                    Name = txtNameofDalykas.Text,
                    Description = txtDesc.Text,
                    lecturerId = selectedItem.Id
                };

                await dalykasRepository.CreateNewDalykas(newDalykas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                var lecturers = await dalykasRepository.GetAllDalykus();

                comboBoxDalykai.DisplayMemberPath = "FullName";
                comboBoxDalykai.SelectedValuePath = "Id";
                comboBoxDalykai.ItemsSource = lecturers;
            }

        }

        private async void comboBoxDalykai_Loaded(object sender, RoutedEventArgs e)
        {
            var lecturers = await dalykasRepository.GetAllDalykus();

            comboBoxDalykai.DisplayMemberPath = "FullName";
            comboBoxDalykai.SelectedValuePath = "Id";
            comboBoxDalykai.ItemsSource = lecturers;
        }

        private async void btnPrideti_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (comboBoxDalykai.SelectedItem == null)
                {
                    MessageBox.Show("Lektorius nebuvo pasirinktas.");
                    return;
                }

                var selectedItem = comboBoxDalykai.SelectedItem as Dalykas;
                if (selectedItem == null)
                {
                    MessageBox.Show("Netinkamas lektorius.");
                    return;
                }


                var newDalykas = new Programm()
                {
                    ProgrammName = txtNameOfProgramm.Text,
                    Semestras = int.Parse(txtSemestras1.Text),
                    Kursas = int.Parse(txtKursas1.Text),
                    DalykoId = selectedItem.Id,
                };

                await programmRepository.CreateNewProgramm(newDalykas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            var x = new AdminWindow(User);
            x.Show();
            this.Close();
        }

        private void btnLecturer_Click(object sender, RoutedEventArgs e)
        {
            var x = new LecturerWindow(User);
            x.Show();
            this.Close();
        }

        private void btnKont_Click(object sender, RoutedEventArgs e)
        {
            var x = new KontaktiniaiWindow(User);
            x.Show();
            this.Close();
        }

        private void btnAtsijungti_Click(object sender, RoutedEventArgs e)
        {
            var x = new MainWindow();
            x.Show();
            this.Close();
        }
    }
}
