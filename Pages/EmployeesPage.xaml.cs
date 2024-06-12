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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private Users user;
        public EmployeesPage(Users user)
        {
            InitializeComponent();

            this.user = user;

            if (user.role_id == 2)
            {
                BtnAdd.Visibility = Visibility.Collapsed;
            }

            var Masters = DBConnection.Connection.Users.Where(x => x.role_id == 4 || x.role_id == 2 || x.role_id == 1).ToList().OrderBy(x => x.name);

            ListItemsMasters.ItemsSource = Masters;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbSearch.Text;

            if (text == "")
            {
                ListItemsMasters.ItemsSource = DBConnection.Connection.Users.Where(x => x.role_id == 4).ToList().OrderBy(x => x.name);
            }
            else if (text != "")
            {
                ListItemsMasters.ItemsSource = DBConnection.Connection.Users.Where(x => (x.name.IndexOf(text) >= 0 ||
                                                                    x.surname.IndexOf(text) >= 0 ||
                                                                    x.telephone_number.ToString().IndexOf(text) >= 0) &&
                                                                    x.role_id == 4)
                                                                    .ToList().OrderBy(x => x.name);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
                return;

            var item = button.DataContext as Users;

            NavigationService.Navigate(new EditUserPage(item, user));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserPage(user));
        }
    }
}
