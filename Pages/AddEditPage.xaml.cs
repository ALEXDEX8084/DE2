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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Orders currentuser = new Orders();

        public AddEditPage(Orders SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null)
                currentuser = SelectedUser;
            DataContext = currentuser;
            cmbvoxname.ItemsSource = EkzamBDEntities.GetContext().Mans.ToList();
            cmbvoxname.SelectedValue = "ID_Man";
            cmbvoxname.DisplayMemberPath = "Name";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrWhiteSpace(currentuser.DateOrder.ToString()))
                error.AppendLine("Karapulka");
            if(error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (currentuser.ID_Order == 0)
                EkzamBDEntities.GetContext().Orders.Add(currentuser);
            try
            {
                EkzamBDEntities.GetContext().SaveChanges();
                MessageBox.Show("pobeda");
                this.NavigationService.Navigate(new Pages.StartPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
