using EducationalPractice.Pages;
using System.Windows;

namespace EducationalPractice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrameNavigation.NavigationService.Navigate(new AuthorizationPage());
        }
    }
}
