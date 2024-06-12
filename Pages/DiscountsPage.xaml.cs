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
    /// Логика взаимодействия для DiscountsPage.xaml
    /// </summary>
    public partial class DiscountsPage : Page
    {
        public DiscountsPage(Users user)
        {
            InitializeComponent();

            if (user.role_id == 2)
            {
                BtnAdd.Visibility = Visibility.Collapsed;
            }

            var Discounts = DBConnection.Connection.Discounts.ToList();
            ListItemsDiscounts.ItemsSource = Discounts;
        }

        private void View_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new EditDiscountPage((Discounts)ListItemsDiscounts.SelectedItem));
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
                ListItemsDiscounts.ItemsSource = DBConnection.Connection.Discounts.ToList();
            }
            else if (text != "")
            {
                ListItemsDiscounts.ItemsSource = DBConnection.Connection.Discounts.Where(x => x.title.IndexOf(text) >= 0 ||
                                                                    x.size.ToString().IndexOf(text) >= 0)
                                                                    .ToList();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddDiscountPage());
        }
    }
}
