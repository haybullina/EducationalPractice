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
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private Users user;
        public ClientPage(Users user)
        {
            InitializeComponent();

            this.user = user;

            var Clients = DBConnection.Connection.Users.ToList().OrderBy(x => x.name);
            ListItemsClients.ItemsSource = Clients;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var item = button.DataContext as Users;

            NavigationService.Navigate(new EditUserPage(item, user));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbSearch.Text;

            if (text == "")
            {
                ListItemsClients.ItemsSource = DBConnection.Connection.Users.ToList().OrderBy(x => x.name);
            }
            else if (text != "")
            {
                ListItemsClients.ItemsSource = DBConnection.Connection.Users.Where(x => x.name.IndexOf(text) >= 0 ||
                                                                    x.surname.IndexOf(text) >= 0 ||
                                                                    x.telephone_number.IndexOf(text) >= 0)
                                                                    .ToList().OrderBy(x => x.name);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage(user));
        }
    }
}
