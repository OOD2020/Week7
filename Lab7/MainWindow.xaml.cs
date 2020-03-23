using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Expense> expenses;
        Random rng = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        //this method will run when the window loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create three expense objects
            Expense e1 = GetRandomExpense();

            Expense e2 = GetRandomExpense();

            Expense e3 = GetRandomExpense();

            //add those to a list
            expenses = new ObservableCollection<Expense>();//new list created on window load
            expenses.Add(e1);
            expenses.Add(e2);
            expenses.Add(e3);


            //display list in a listbox
            lbxExpenses.ItemsSource = expenses;

            tblkTotal1.Text = Expense.TotalExpenses.ToString();



        }
        //method to add expense item
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //create an expense
            //Expense e1 = new Expense()
            //{
            //    Category = "Travel",
            //    Amount = 55m,
            //    ExpenseDate = DateTime.Now
            //};

            //add that to the list
            expenses.Add(GetRandomExpense());

            tblkTotal1.Text = Expense.TotalExpenses.ToString("C");

            //refresh screen 
            //.ItemsSource = null;
            //.ItemsSource = expenses;
        }
        private Expense GetRandomExpense()
        {
            //get random category
            string[] categories = { "Office", "Travel", "Entertainment" };
            int randomNumber = rng.Next(0, 3); //0, 1, or 2
            string category = categories[randomNumber];

            //get random amount
            randomNumber = rng.Next(1, 10001);
            decimal randomAmount = (decimal)randomNumber / 100;

            //get random date - in the last 30 days 
            randomNumber = rng.Next(0, 31);//0-30
            DateTime randomDate = DateTime.Now.AddDays(-randomNumber); //give a date in the last 30 days

            //create an expense object with that information
            Expense e1 = new Expense(randomAmount, randomDate, category);

            //return random object 
            return e1;

        }

        private void lbxExpenses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
