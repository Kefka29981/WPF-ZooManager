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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WPF_ZooManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["WPF_ZooManager.Properties.Settings.PanjutorialsDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);
            ShowZoos();
            ShowAnimals();
        }

        private void ShowZoos()
        {
                var Zoos = from Zoo in dataContext.Zoos select Zoo.Location;
                listZoos.ItemsSource = Zoos;
        }


        private void ShowAssociatedAnimals()
        {
                if (listZoos.SelectedValue != null)
                {
                var AnimalsInAZoo = from Zoo in dataContext.ZooAnimal
                                    where Zoo.Zoos.Location == (string)listZoos.SelectedValue
                                    select Zoo.Animal.Name;

                    listAssociatedAnimals.ItemsSource = AnimalsInAZoo;
                }
        }

        private void ShowAnimals()
        {
                var Animals = from animal in dataContext.Animals select animal.Name;
                listAnimals.ItemsSource = Animals;
        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssociatedAnimals();
            if (listZoos.SelectedValue != null)
            {
                Input.Text = listZoos.SelectedItem.ToString();
            }
        }

        private void listAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listAnimals.SelectedValue != null)
            {
                Input.Text = listAnimals.SelectedItem.ToString();
            }
        }

        private void listAssociatedAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listAssociatedAnimals.SelectedValue != null)
            {
                Input.Text = listAssociatedAnimals.SelectedItem.ToString() + " from " + listZoos.SelectedItem.ToString() + " Zoo";
            }
        }

        private void Button_AddAnimalToZoo(object sender, RoutedEventArgs e)
        {
            if(listZoos.SelectedValue != null && listAnimals.SelectedValue != null)
            {
                var SelectedZooId = from Zoo in dataContext.Zoos where Zoo.Location == (string)listZoos.SelectedValue select Zoo.Id;
                var SelectedAnimalId = from animal in dataContext.Animals where animal.Name == (string)listAnimals.SelectedValue select animal.Id;

                ZooAnimal AddAnimalToZoo = new ZooAnimal { AnimalId = SelectedAnimalId.FirstOrDefault(), ZooID = SelectedZooId.FirstOrDefault() };

                dataContext.ZooAnimal.InsertOnSubmit(AddAnimalToZoo);
                dataContext.SubmitChanges();
                ShowAssociatedAnimals();
            }
            else
            {
                MessageBox.Show("Pls choose Zoo and animal before pressing the button");
            }
        }

        private void Button_DeleteAnimalFromZoo(object sender, RoutedEventArgs e)
        {

                var SelectedZooId = from Zoo in dataContext.Zoos where Zoo.Location == (string)listZoos.SelectedValue select Zoo.Id;
                var SelectedAnimalId = from animal in dataContext.Animals where animal.Name == (string)listAssociatedAnimals.SelectedValue select animal.Id;

                ZooAnimal DeleteAnimalFromZoo = dataContext.ZooAnimal.FirstOrDefault(za => za.AnimalId == SelectedAnimalId.FirstOrDefault() && za.ZooID == SelectedZooId.FirstOrDefault());


                dataContext.ZooAnimal.DeleteOnSubmit(DeleteAnimalFromZoo);
                dataContext.SubmitChanges();
                ShowAssociatedAnimals();

        }

        private void Button_AddAnimal(object sender, RoutedEventArgs e)
        {
                Animal NewAnimal = new Animal { Name = Input.Text };
                dataContext.Animals.InsertOnSubmit(NewAnimal);
                dataContext.SubmitChanges();
                ShowAnimals();
        }

        private void Button_RemoveAnimal(object sender, RoutedEventArgs e)
        {
                Animal SelectedAnimal = dataContext.Animals.FirstOrDefault(anim => anim.Name == (string)listAnimals.SelectedValue);
                dataContext.Animals.DeleteOnSubmit(SelectedAnimal);
                dataContext.SubmitChanges();
                ShowAnimals();
                ShowAssociatedAnimals();
        }

        private void Button_AddZoo(object sender, RoutedEventArgs e)
        {
                Zoos NewZoo = new Zoos { Location = Input.Text };
                dataContext.Zoos.InsertOnSubmit(NewZoo);
                dataContext.SubmitChanges();
                ShowZoos();
        }

        private void Button_DeleteZoo(object sender, RoutedEventArgs e)
        {
            if (listZoos.SelectedValue != null)
            {
                Zoos SelectedZoo = dataContext.Zoos.FirstOrDefault(Zoo => Zoo.Location == (string)listZoos.SelectedValue);
                dataContext.Zoos.DeleteOnSubmit(SelectedZoo);
                dataContext.SubmitChanges();
                ShowZoos();
            }
            else
            {
                MessageBox.Show("Pls choose Zoo you want to delete before pressing delete button");
            }
        }

        private void Button_UpdateAnimal(object sender, RoutedEventArgs e)
        {
                Animal SelectedAnimal = dataContext.Animals.FirstOrDefault(st => st.Name == (string)listAnimals.SelectedValue);

                SelectedAnimal.Name = Input.Text;

                dataContext.SubmitChanges();
                ShowAnimals();
                ShowAssociatedAnimals();
        }

        private void Button_UpdateZoo(object sender, RoutedEventArgs e)
        {
                Zoos SelectedZoo = dataContext.Zoos.FirstOrDefault(st => st.Location == (string)listZoos.SelectedValue);

                SelectedZoo.Location = Input.Text;

                dataContext.SubmitChanges();
                ShowZoos();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Input.Focus();
            Input.SelectionStart = Input.Text.Length;
        }
    }
}
