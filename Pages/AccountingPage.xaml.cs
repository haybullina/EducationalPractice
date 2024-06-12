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
    /// Логика взаимодействия для AccountingPage.xaml
    /// </summary>
    public partial class AccountingPage : Page
    {
        private Users user;
        public AccountingPage(Users user)
        {
            InitializeComponent();

            CbClients.ItemsSource = DBConnection.Connection.Users.ToList();
            CbDiscounts.ItemsSource = DBConnection.Connection.Discounts.ToList();
            CbServices.ItemsSource = DBConnection.Connection.Services.ToList();
            TbBonus.Text = "0";
            CbMasters.ItemsSource = DBConnection.Connection.Users.Where(x => x.role_id == 4 ).ToList();
            TbDatetime.Text = $"{DateTime.Now}";
            TxtReception.Text = $"{user.name} {user.surname} {DBConnection.Connection.Roles.Where(x => x.id == user.id).FirstOrDefault().title}";


            this.user = user;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (float.Parse(TxtBonus.Text) < 0)
                {
                    MessageBox.Show("Превышен баланс бонусов клиента");
                    return;
                }

                Users_Services accounting = new Users_Services()
                {
                    user_id = (CbClients.SelectedItem as Users).id,
                    service_id = (CbServices.SelectedItem as Services).id,
                    dicount_id = (CbDiscounts.SelectedItem as Discounts).id,
                    final_price = float.Parse(finalAmount.Text),
                    datetime = DateTime.Parse(TbDatetime.Text),
                    master_id = (CbMasters.SelectedItem as Users).id,
                    reception_id = this.user.id,
                    client_bonus = float.Parse(TbBonus.Text)
                };

                (CbClients.SelectedItem as Users).bonus = -float.Parse(TbBonus.Text);
                DBConnection.Connection.Users_Services.Add(accounting);

                if (float.Parse(TbBonus.Text) == 0)
                {
                    user.bonus += float.Parse(finalAmount.Text) * 0.05;
                }

                DBConnection.Connection.SaveChanges();
                MessageBox.Show("Сохранено!");
                NavigationService.GoBack();
            }
            catch { MessageBox.Show("Некорректное число бонусов"); }
        }

        private void CbDiscounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbServices.SelectedItem == null || CbDiscounts.SelectedItem == null) return;
                if (TbBonus.Text == "") return;

                finalAmount.Text = $"{(CbServices.SelectedItem as Services).price * (1 - (CbDiscounts.SelectedItem as Discounts).size) - float.Parse(TbBonus.Text)}";

            }
            catch { MessageBox.Show("Некорректное число бонусов"); }
        }

        private void CbServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CbServices.SelectedItem == null || CbDiscounts.SelectedItem == null) return;
                if (TbBonus.Text == "") return;

                finalAmount.Text = $"{(CbServices.SelectedItem as Services).price * (1 - (CbDiscounts.SelectedItem as Discounts).size) - float.Parse(TbBonus.Text)}";

                
            }
            catch { MessageBox.Show("Некорректное число бонусов"); }
        }

        private void CbClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtBonus.Text = $"{(CbClients.SelectedItem as Users).bonus}";
        }

        private void TbBonus_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TxtBonus.Text = "0";
                if (TbBonus.Text == null || TbBonus.Text == "")
                {
                    TbBonus.Text = "0";
                    TxtBonus.Text = $"{(CbClients.SelectedItem as Users).bonus}";
                }
                else
                {

                    TxtBonus.Text = $"{(CbClients.SelectedItem as Users).bonus - float.Parse(TbBonus.Text)}";
                    finalAmount.Text = $"{(CbServices.SelectedItem as Services).price * (1 - (CbDiscounts.SelectedItem as Discounts).size) - float.Parse(TbBonus.Text)}";

                }
            }
            catch { }
        }
    }
}
