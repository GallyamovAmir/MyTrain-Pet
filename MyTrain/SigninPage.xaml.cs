using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        private void TB(object sender, TextChangedEventArgs e)
        {
            ButtonAuth.IsEnabled = PhoneNumber.Text.Length >= 11 && Password.Text.Length >= 4;

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
                if(Worker != null)
                {
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
                        MessageBox.Show("Недостаточно прав", "Ошибка доступа!");
                }
                else
                    MessageBox.Show("Пользователя с такими данными не существует", "Ошибка доступа!");
            }
        }
    }
}
