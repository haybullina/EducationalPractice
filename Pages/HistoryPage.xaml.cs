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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private Users user;
        public HistoryPage(Users user)
        {
            InitializeComponent();

            this.user = user;

            var History = DBConnection.Connection.Users_Services.ToList();
            ListItemsHistory.ItemsSource = History;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = TbSearch.Text;

            if (text == "")
            {
                ListItemsHistory.ItemsSource = DBConnection.Connection.Users_Services.ToList();
            }
            else if (text != "")
            {
                //ListItemsHistory.ItemsSource = DBConnection.Connection.Users_Services.Where(x => x.title.IndexOf(text) >= 0 ||
                                                                   // x.price.ToString().IndexOf(text) >= 0)
                                                                    //.ToList();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (user.role_id == 1)
            {
                var button = sender as Button;
                if (button != null) { return; }

                var item = button.DataContext as Users_Services;

                DBConnection.Connection.Users_Services.Remove(item);
                DBConnection.Connection.SaveChanges();
            }
        }
    }
}
