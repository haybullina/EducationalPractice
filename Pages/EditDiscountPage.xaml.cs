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
    /// Логика взаимодействия для EditDiscountPage.xaml
    /// </summary>
    public partial class EditDiscountPage : Page
    {
        private Discounts discount;
        public EditDiscountPage(Discounts discount)
        {
            InitializeComponent();
            this.discount = discount;

            TbTitle.Text = discount.title;
            TbSize.Text = discount.size.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                discount.title = TbTitle.Text;
                discount.size = float.Parse(TbSize.Text);

                DBConnection.Connection.SaveChanges();

                MessageBox.Show("Сохранено!");
            } catch { MessageBox.Show("Неверный формат размера"); }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.Connection.Discounts.Remove(discount);
        }
    }
}
