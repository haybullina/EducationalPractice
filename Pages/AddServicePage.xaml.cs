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
    /// Логика взаимодействия для AddServicePage.xaml
    /// </summary>
    public partial class AddServicePage : Page
    {
        public AddServicePage()
        {
            InitializeComponent();

            CbCategories.ItemsSource = DBConnection.Connection.Categories.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                var newService = new Services() 
                {
                    title = TbTitle.Text,
                    price = float.Parse(TbPrice.Text),
                    category_id = (CbCategories.SelectedItem as Categories).id
                };

                DBConnection.Connection.Services.Add(newService);   
                DBConnection.Connection.SaveChanges();

                MessageBox.Show("Добавлено!");

                NavigationService.GoBack();
            } 
            catch { MessageBox.Show("Неверный формат стоимости"); }
        }
    }
}
