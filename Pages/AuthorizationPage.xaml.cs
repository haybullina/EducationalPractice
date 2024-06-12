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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void EventLogin_Click(object sender, RoutedEventArgs e)
        {
            var user = DBConnection.Connection.Users.Where(x => x.password == TxtPassword.Password).FirstOrDefault();
            if (user == null) MessageBox.Show("Пользователя не существует");
            else 
            {
                if (user.role_id == 1) NavigationService.Navigate(new MainPage(user));
                else if (user.role_id == 2) NavigationService.Navigate(new MainPage(user));
            }
        }
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var user = DBConnection.Connection.Users.Where(x => x.password == TxtPassword.Password).FirstOrDefault();

                if (user == null) MessageBox.Show("Пользователя не существует");
                else
                {
                    if (user.role_id == 1) NavigationService.Navigate(new MainPage(user));
                    else if (user.role_id == 2) NavigationService.Navigate(new MainPage(user));
                }
            }
            else return;
        }
    }
}
