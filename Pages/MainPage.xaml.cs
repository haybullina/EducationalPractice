using EducationalPractice.AdoModel;
using EducationalPractice.DBConnectionClass;
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

namespace EducationalPractice.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {

        private Users user;
        public MainPage(Users user)
        {
            InitializeComponent();

            this.user = user;

            TxtUser.Text = user.surname + " " + user.name + " " + DBConnection.Connection.Roles.Where(x => x.id == user.id).First().title;
        }

        private void ClientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage(user));
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicesPage(user));
        }

        private void DiscountsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DiscountsPage(user));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AccountingButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountingPage(user));
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HistoryPage(user));
        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EmployeesPage(user));
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HelpPage());
        }
    }
}
