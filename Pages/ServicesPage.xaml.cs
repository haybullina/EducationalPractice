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
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        private Users user;
        public ServicesPage(Users user)
        {
            InitializeComponent();

            this.user = user;

            if (user.role_id == 2)
                BtnAdd.Visibility = Visibility.Collapsed;

            var Services = DBConnection.Connection.Services.ToList().OrderBy(x => x.title);
            ListItemsServices.ItemsSource = Services;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null) return;

            var item = button.DataContext as Services;

            NavigationService.Navigate(new EditServicePage(item));
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
                ListItemsServices.ItemsSource = DBConnection.Connection.Services.ToList().OrderBy(x => x.title);
            }
            else if (text != "")
            {
                ListItemsServices.ItemsSource = DBConnection.Connection.Services.Where(x => x.title.IndexOf(text) >= 0 ||
                                                                    x.price.ToString().IndexOf(text) >= 0)
                                                                    .ToList().OrderBy(x => x.title);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServicePage());
        }
    }
}
