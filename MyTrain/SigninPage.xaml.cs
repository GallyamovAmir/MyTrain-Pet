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
using System.Windows.Shapes;

namespace MyTrain
{
    /// <summary>
    /// Логика взаимодействия для SigninPage.xaml
    /// </summary>
    public partial class SigninPage : Window
    {
        public SigninPage()
        {
            InitializeComponent();

        }

        private void TBPhoneNumber(object sender, TextChangedEventArgs e)
        {
            if (PhoneNumber.Text.Length < 11)
            {
                ButtonAuth.IsEnabled = false;
            }
            else
            {
                ButtonAuth.IsEnabled = true;
            }
        }

        private void TBPassword(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length < 4)
            {
                ButtonAuth.IsEnabled = false;
            }
            else
            {
                ButtonAuth.IsEnabled = true;
            }
        }


        private void Auth(object sender, RoutedEventArgs e)
        {
            Users Worker = null;
            if (PhoneNumber.Text != null && Password.Text != null)
            {
                
                using (MyTrainEntities db = new MyTrainEntities())
                {
                    Worker = (Users)db.Users.Where(x => x.NumberPhone == PhoneNumber.Text && x.Password == Password.Text).FirstOrDefault();
                }

                if (Worker.RoleID == 1)
                {
                    MessageBox.Show($"Добро пожаловать, {Worker.Name} {Worker.MiddleName}!", "Авторизация успешна");

                    ValidWorker.name = Worker.Name;
                    ValidWorker.middlename = Worker.MiddleName;
                    ValidWorker.password = Worker.Password;

                    WorkerPage workerPage = new WorkerPage();
                    workerPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Недостаточно прав", "Ошибка доступа!");
                }

            }
            else
            {
                MessageBox.Show("Пользователя с такими данными не существует", "Ошибка доступа!");
            }

        }
    }
}
