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
    /// Логика взаимодействия для TrainPage.xaml
    /// </summary>
    public partial class TrainPage : Page
    {

        int selectedTrainId;

        public TrainPage()
        {
            InitializeComponent();
            UpdateTrainsGridWithGettingDB();
            P1Trains();
        }

        private void P1Trains()
        {
            var db = new MyTrainEntities();
            TrainsDataGrid.ItemsSource = db.Trains.ToList();
            TrainsDataGrid.MouseDoubleClick += (s, e) =>
            {
                var cell = TrainsDataGrid.CurrentCell;
                var train = (Trains)cell.Item;

                selectedTrainId = train.Id;
                TrainName.Text = train.Name;
            };
            db.Dispose();
        }

        public void UpdateTrainsGridWithGettingDB()
        {
            var db = new MyTrainEntities();

            TrainsDataGrid.ItemsSource = db.Trains.ToList();

            db.Dispose();

        }

        private void AddTrain(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TrainName.Text))
                return;
            var db = new MyTrainEntities();

            Trains train = new Trains();
            train.Name = TrainName.Text;
            db.Trains.Add(train);
            db.SaveChanges();

            db.Dispose();

            UpdateTrainsGridWithGettingDB();
            TrainName.Text = "";

        }

        private void ChangeTrain(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TrainName.Text))
                return;
            if (selectedTrainId == 0)
                return;

            var db = new MyTrainEntities();

            Trains city = db.Trains.Find(selectedTrainId);
            city.Name = TrainName.Text;
            db.SaveChanges();

            MessageBox.Show("Название поезда изменено", "Успешно");
            db.Dispose();

            UpdateTrainsGridWithGettingDB();
            selectedTrainId = 0;
        }

        private void DeleteTrain(object sender, RoutedEventArgs e)
        {
            if (selectedTrainId == 0)
                return;

            var db = new MyTrainEntities();

            db.Trains.Remove(db.Trains.Find(selectedTrainId));
            db.SaveChanges();

            MessageBox.Show("Поезд удален", "Успешно");
            db.Dispose();

            UpdateTrainsGridWithGettingDB();
        }

        private void CheckerTB(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
