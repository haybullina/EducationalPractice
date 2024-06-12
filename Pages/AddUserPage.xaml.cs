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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        private Users user;
        public AddUserPage(Users user)
        {
            InitializeComponent();

            this.user = user;

            CbRoles.ItemsSource = DBConnection.Connection.Roles.ToList();

            if (user.role_id == 2)
            {
                SpRoles.Visibility = Visibility.Collapsed;
                SpPassword.Visibility = Visibility.Collapsed;
            }
            TbPassword.Text = "";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new Users()
            {
                name = TbName.Text,
                surname = TbSurname.Text,
                email = TbEmail.Text,
                password = TbPassword.Text == "" ? null : TbPassword.Text,
                telephone_number = TbTelephone.Text,
                role_id = (CbRoles.SelectedItem as Roles).id,
                bonus = 0
            };

            DBConnection.Connection.Users.Add(newUser);
            DBConnection.Connection.SaveChanges();
            MessageBox.Show("Пользователь добавлен");
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CbRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((CbRoles.SelectedItem as Roles).id == 3)
            {
                SpPassword.Visibility = Visibility.Collapsed;
            }
            else SpPassword.Visibility = Visibility.Visible;
        }
    }
}
