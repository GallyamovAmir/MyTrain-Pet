using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyTrain
{
    /// <summary>
    /// Логика взаимодействия для FormalizedTicketPage.xaml
    /// </summary>
    public partial class FormalizedTicketPage : Page
    {
        public FormalizedTicketPage()
        {
            InitializeComponent();
            UpdateTicktesGridWithGettingDB();
            P1Tickets();
        }
        int selectedTicketId;
        public void UpdateTicktesGridWithGettingDB()
        {
            var db = new MyTrainEntities();

            var tickets = db.Tickets.Include("Users").Include("Wagons").Include("Routes").Include("Places").Include("Routes.Cities").Include("Routes.Cities1").ToList();

            TicktesDataGrid.ItemsSource = tickets;

            db.Dispose();

        }

        private void P1Tickets()
        {
            var db = new MyTrainEntities();
            
            TicktesDataGrid.MouseDoubleClick += (s, e) =>
            {
                var cell = TicktesDataGrid.CurrentCell;
                var ticket = (Tickets)cell.Item;

                selectedTicketId = ticket.Id;
                TBId.Text = (selectedTicketId).ToString();
                TBUserId.Text = (ticket.UserId).ToString();
                TBUserName.Text = ticket.Users.Name;
            };
            db.Dispose();
        }

        private void DeleteTicket(object sender, RoutedEventArgs e)
        {
            if (selectedTicketId == 0)
                return;

            var db = new MyTrainEntities();

            db.Tickets.Remove(db.Tickets.Find(selectedTicketId));
            db.SaveChanges();

            MessageBox.Show("Билет удален", "Успешно");
            db.Dispose();

            UpdateTicktesGridWithGettingDB();
        }

        private void RevokeTicket(object sender, RoutedEventArgs e)
        {
            if (selectedTicketId == 0)
                return;

            if ( string.IsNullOrEmpty(TBUserId.Text) || int.Parse(TBUserId.Text) == 0)
                return;


            var db = new MyTrainEntities();

            Tickets ticket = db.Tickets.Find(selectedTicketId);
            ticket.UserId = int.Parse(TBUserId.Text);
            db.SaveChanges();

            MessageBox.Show("Билет изменен", "Успешно");
            db.Dispose();

            UpdateTicktesGridWithGettingDB();
        }

        private void CheckerTB(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}
