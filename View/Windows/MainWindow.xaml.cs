using Bookmaster.View.Pages;
using Bookmaster.View.Windows;
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

namespace Bookmaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            LogoutMi.Visibility=Visibility.Collapsed; LibraryMi.Visibility=Visibility.Collapsed;
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            //Для реализации оконной навигиции нужно;
            //1) Создать экземпляр окна, которое требуется открыть.
            LoginWindow loginWindow = new LoginWindow();

            //2) У экземпляра окна вызвать метод Show() или ShowDialog().
            loginWindow.Show();
        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            //Для реализации страничной навигации нужно:
            //1) Обратиться к элементу Frame по имени и называем метод Navigate()
            //2) В качестве аргумента передаем в метод экземпляр страницы, которую нужно открыть.
            MainFrm.Navigate(new BrowseCatalogPage());
        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new Manage_Customers_Page());
        }

        private void CalculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new CalculationPage());
        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrm.Navigate(new ReportsPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CirculationMi_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
