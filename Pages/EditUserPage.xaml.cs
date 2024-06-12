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
    /// Логика взаимодействия для EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        private Users editUser;
        private Users user;
        public EditUserPage(Users editUser, Users user)
        {
            InitializeComponent();
            this.editUser = editUser;
            if (user.role_id == 1)
            {
                SpPassword.Visibility = Visibility.Visible;
            }

            TxtUser.Text = editUser.role;
            TbName.Text = editUser.name;
            TbEmail.Text = editUser.email;
            TbPassword.Text = editUser.password;
            TbSurname.Text = editUser.surname;
            TbTelephone.Text = editUser.telephone_number;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.Connection.Users.Remove(editUser);
            MessageBox.Show("Удалено");
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            editUser.name = TbName.Text;
            editUser.email = TbEmail.Text;
            editUser.surname= TbSurname.Text;
            editUser.telephone_number = TbTelephone.Text;
            if (editUser.role_id == 3) editUser.password = null;
            else if (editUser.role_id == 4) editUser.password = TbPassword.Text;
            DBConnection.Connection.SaveChanges();
            MessageBox.Show("Пользователь изменен!");
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
