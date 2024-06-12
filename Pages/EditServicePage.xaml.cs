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
    /// Логика взаимодействия для EditServicePage.xaml
    /// </summary>
    public partial class EditServicePage : Page
    {
        private Services service;
        public EditServicePage(Services service)
        {
            InitializeComponent();
            this.service = service;

            CbCategories.ItemsSource = DBConnection.Connection.Categories.ToList();
            CbCategories.SelectedIndex = service.category_id-1;

            TbTitle.Text = service.title;
            TbPrice.Text = service.price.ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                service.title= TbTitle.Text;
                service.price = float.Parse(TbPrice.Text);
                service.category_id = (CbCategories.SelectedItem as Categories).id;

                DBConnection.Connection.SaveChanges();

                MessageBox.Show("Готово!");

                NavigationService.GoBack();
            } 
            catch { MessageBox.Show("Ошибка"); }   
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.Connection.Services.Remove(service);
            MessageBox.Show("Удалено!");
            NavigationService.GoBack();
        }
    }
}
