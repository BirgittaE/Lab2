using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Person
    {
        public int Age { get; set; }
        public int Candies { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Person(int age, string firstName, string lastName, int candies = 0)
        {
            this.Age = age;
            this.Firstname = firstName;
            this.Lastname = lastName;
            this.Candies = candies;
        }

        public override string ToString()
        {
            string view = this.Firstname + " " + this.Lastname + " " + "(" + this.Age + " år)";
            if (this.Candies >= 1)
            {
                view += ": " + this.Candies + " st";
            }

            return view;
        }
    }
    public class CandyCalculator
    {
        public List<Person> peoples = new List<Person>();
      
        public void DistributeCandies(int candiesAmount)
        {
            int candyPerPerson = candiesAmount / peoples.Count;

            if (peoples.Count >= 1)
            {
                peoples.ForEach(person =>
                {
                    person.Candies = candyPerPerson;
                });
            }
        }
    }

    public partial class MainWindow : Window
    {
        private CandyCalculator candyCalculator; 
        public MainWindow()
        {
            candyCalculator = new CandyCalculator(); 
            this.DataContext = candyCalculator.peoples;

            InitializeComponent(); 
        } 

        // Lägg till
        private void BtnEvent_Click(object sender, RoutedEventArgs e)
        {
            candyCalculator.peoples.Add(new Person(Convert.ToInt32(Age.Text), Firstname.Text, Lastname.Text)); 

            RefreshListView(); 
        }

        // Fördela 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            candyCalculator.DistributeCandies(Convert.ToInt32(Candies.Text));

            RefreshListView(); 
        } 

        private void RefreshListView()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(PeopleListView.ItemsSource);
            view.Refresh();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
