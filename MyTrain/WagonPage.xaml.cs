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
    /// Логика взаимодействия для WagonPage.xaml
    /// </summary>
    public partial class WagonPage : Page
    {
        int selectedWagonId;
        int selectedTrainId;
        int selectedTypeId;
        public WagonPage()
        {
            InitializeComponent();

            var db = new MyTrainEntities();
            List<ComboBoxItem> trains = new List<ComboBoxItem>();
            foreach (Trains train in db.Trains.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = train.Name;
                cbi.Selected += (ss, ee) =>
                {
                    selectedTrainId = train.Id;
                };
                trains.Add(cbi);//-------------------------------
            }
            TrainSelector.ItemsSource = trains;

            List<ComboBoxItem> typess = new List<ComboBoxItem>();
            foreach (Types typee in db.Types.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = typee.Name;
                cbi.Selected += (ss, ee) =>
                {
                    selectedTypeId = typee.Id;
                };
                typess.Add(cbi);//-------------------------------
            }
            TypeSelector.ItemsSource = typess;

            P1Wagon();
            UpdateWagonsGridWithGettingDB();
        }

        private void P1Wagon()
        {
            var db = new MyTrainEntities();
            WagonDataGrid.ItemsSource = db.Wagons.Include("Types").Include("Trains").ToList();
            WagonDataGrid.MouseDoubleClick += (s, e) =>
            {
                var cell = WagonDataGrid.CurrentCell;
                var wagon = (Wagons)cell.Item;

                selectedWagonId = wagon.Id;
                WagonName.Text = wagon.Name;
                WagonCountPlace.Text = wagon.Count;
            };
            db.Dispose();
        }

        public void UpdateWagonsGridWithGettingDB()
        {
            var db = new MyTrainEntities();

            WagonDataGrid.ItemsSource = db.Wagons.Include("Types").Include("Trains").ToList();

            db.Dispose();

        }

        private void DeleteWagon(object sender, RoutedEventArgs e)
        {
            if (selectedWagonId == 0)
                return;

            var db = new MyTrainEntities();

            for(int i = 0; i < int.Parse(WagonCountPlace.Text); i++)
            {
                db.Places.Remove(db.Places.Find(selectedWagonId));
            }
            db.Wagons.Remove(db.Wagons.Find(selectedWagonId));

            db.SaveChanges();

            MessageBox.Show("Вагон и его места удалены", "Успешно");
            db.Dispose();

            UpdateWagonsGridWithGettingDB();
        }

        private void ChangeWagon(object sender, RoutedEventArgs e)
        {
            if (selectedWagonId == 0)
                return;
            if (WagonCountPlace.Text != "")
            {
                MessageBox.Show("Количество мест в вагоне не может быть изменено", "Ошибка мест");
                WagonCountPlace.Text = "";
                return;
            }
            var db = new MyTrainEntities();



            Wagons wagon = db.Wagons.Find(selectedWagonId);
            wagon.Name = WagonName.Text;
            wagon.TrainsId = selectedTrainId;
            wagon.TypeId = selectedTypeId;

            db.SaveChanges();

            MessageBox.Show("Вагон изменен", "Успешно");
            db.Dispose();

            UpdateWagonsGridWithGettingDB();
        }

        private void AddWagon(object sender, RoutedEventArgs e)
        {
            if (WagonName.Text == "")
                return;
            if (string.IsNullOrEmpty(WagonCountPlace.Text) || int.Parse(WagonCountPlace.Text) == 0)
                return;
            if (selectedTrainId == 0)
                return;
            if (selectedTypeId == 0)
                return;

            var db = new MyTrainEntities();

            Wagons wagon = new Wagons();
            wagon.Name = WagonName.Text;
            wagon.Count = WagonCountPlace.Text;
            wagon.TrainsId = selectedTrainId;
            wagon.TypeId = selectedTypeId;
            db.Wagons.Add(wagon);
            db.SaveChanges();

            MessageBox.Show("Вагон добавлен", "Успешно");
            db.Dispose();

            UpdateWagonsGridWithGettingDB();
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
