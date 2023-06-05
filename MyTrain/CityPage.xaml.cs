using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyTrain
{
    /// <summary>
    /// Логика взаимодействия для CityPage.xaml
    /// </summary>
    public partial class CityPage : Page
    {
        int selectedCityId;
        public CityPage()
        {
            InitializeComponent();
            UpdateCitiesGridWithGettingDB();
            P1Cities();
        }

        private void P1Cities()
        {
            var db = new MyTrainEntities();
            CitiesDataGrid.ItemsSource = db.Cities.ToList();
            CitiesDataGrid.MouseDoubleClick += (s, e) =>
            {
                var cell = CitiesDataGrid.CurrentCell;
                var city = (Cities)cell.Item;

                selectedCityId = city.Id;
                CityName.Text = city.Name;
            };
            db.Dispose();
        }

        public void UpdateCitiesGridWithGettingDB()
        {
            var db = new MyTrainEntities();

            CitiesDataGrid.ItemsSource = db.Cities.ToList();

            db.Dispose();

        }

        private void ChangeCity(object sender, RoutedEventArgs e)
        {
            if (selectedCityId == 0)
                return;

            var db = new MyTrainEntities();

            Cities city = db.Cities.Find(selectedCityId);
            city.Name = CityName.Text;
            db.SaveChanges();

            MessageBox.Show("Название города изменено", "Успешно");
            db.Dispose();

            UpdateCitiesGridWithGettingDB();
            selectedCityId = 0;
        }

        private void DeleteCity(object sender, RoutedEventArgs e)
        {
            if (selectedCityId == 0)
                return;

            var db = new MyTrainEntities();

            db.Cities.Remove(db.Cities.Find(selectedCityId));
            db.SaveChanges();

            MessageBox.Show("Город удален", "Успешно");
            db.Dispose();

            UpdateCitiesGridWithGettingDB();
        }

        private void AddCity(object sender, RoutedEventArgs e)
        {
            var db = new MyTrainEntities();

            Cities city = new Cities();
            city.Name = CityName.Text;
            db.Cities.Add(city);
            db.SaveChanges();

            db.Dispose();

            UpdateCitiesGridWithGettingDB();
            CityName.Text = "";
        }
    }
}
