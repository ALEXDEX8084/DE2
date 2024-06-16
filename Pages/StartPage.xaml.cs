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
using WpfApp1.Classes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
            ListOrders.ItemsSource = EkzamBDEntities.GetContext().Orders.ToList();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListOrders.ItemsSource = EkzamBDEntities.GetContext().Orders.Where(x => x.Mans.Name.Contains(Search.Text)).ToList();
        }

        private void a1_Checked(object sender, RoutedEventArgs e)
        {
            ListOrders.ItemsSource = EkzamBDEntities.GetContext().Orders.OrderBy(x => x.Mans.Name).ToList();
        }

        private void a2_Checked(object sender, RoutedEventArgs e)
        {
            ListOrders.ItemsSource = EkzamBDEntities.GetContext().Orders.OrderByDescending(x => x.Mans.Name).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.AddEditPage(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var personforremoving = ListOrders.SelectedItems.Cast<Orders>().ToList();
            var resMessage = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(resMessage == MessageBoxResult.Yes)
            {
                try { 
                EkzamBDEntities.GetContext().Orders.RemoveRange(personforremoving);
                EkzamBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Udaleno");
                ListOrders.ItemsSource = EkzamBDEntities.GetContext().Orders.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
           
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.AddEditPage((Orders)ListOrders.SelectedItem));
        }
    }
}
