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
    /// Логика взаимодействия для AddDiscountPage.xaml
    /// </summary>
    public partial class AddDiscountPage : Page
    {
        public AddDiscountPage()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var newDiscount = new Discounts()
                {
                    title = TbTitle.Text,
                    size = float.Parse(TbSize.Text),
                };

                DBConnection.Connection.Discounts.Add(newDiscount);
                DBConnection.Connection.SaveChanges();

                MessageBox.Show("Готово");

                NavigationService.GoBack();
            }
            catch { MessageBox.Show("Некорректный формат скидки"); }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
