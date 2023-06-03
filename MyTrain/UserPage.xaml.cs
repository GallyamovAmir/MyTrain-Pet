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

namespace MyTrain
{
    /// <summary>
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        int selectedUserId = 0;
        int selectedRoleId = 0;
        public UserPage()
        {
            InitializeComponent();

            var db = new MyTrainEntities();
            List<ComboBoxItem> roles = new List<ComboBoxItem>();
            foreach (Role role in db.Role.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = role.Name;
                cbi.Selected += (ss, ee) =>
                {
                    selectedRoleId = role.Id;
                };
                roles.Add(cbi);//-------------------------------
            }
            RoleSelector.ItemsSource = roles;
            UpdateUsersGridWithGettingDB();
            P1Clients();
        }

        private void P1Clients()
        {
            var db = new MyTrainEntities();
            UsersDataGrid.ItemsSource = db.Users.ToList();
            UsersDataGrid.MouseDoubleClick += (s, e) =>
            {
                var cell = UsersDataGrid.CurrentCell;
                var client = (Users)cell.Item;

                selectedUserId = client.Id;
                UserName.Text = client.Name;
            };
            db.Dispose();
        }

        public void UpdateUsersGridWithGettingDB()
        {
            var db = new MyTrainEntities();

            UsersDataGrid.ItemsSource = db.Users.ToList();
        
            db.Dispose();

        }

        private void ChangeRole(object sender, RoutedEventArgs e)
        {
            if (selectedUserId == 0)
                return;

            var db = new MyTrainEntities();

            Users user = db.Users.Find(selectedUserId);
          user.RoleID = selectedRoleId;
            db.SaveChanges();

            MessageBox.Show("Роль изменена", "Успешно");
            db.Dispose();

            UpdateUsersGridWithGettingDB();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (selectedUserId == 0)
                return;

            var db = new MyTrainEntities();

            db.Users.Remove(db.Users.Find(selectedUserId));
            db.SaveChanges();

            MessageBox.Show("Клиент удален", "Успешно");
            db.Dispose();

            UpdateUsersGridWithGettingDB();
        }
    }
}
