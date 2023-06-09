﻿using System;
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
    /// Логика взаимодействия для RoutesPage.xaml
    /// </summary>
    public partial class RoutesPage : Page
    {
        int selectedCityId;
        int selectedCity1Id;
        int selectedTrainId;
        int selectedRouteId;

        public RoutesPage()
        {
            InitializeComponent();

            var db = new MyTrainEntities();
            List<ComboBoxItem> departureCity = new List<ComboBoxItem>();
            foreach (Cities city in db.Cities.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = city.Name;
                cbi.Selected += (ss, ee) =>
                {
                    selectedCityId = city.Id;
                };
                departureCity.Add(cbi);//-------------------------------
            }
            RouteDepartureCityId.ItemsSource = departureCity;

            List<ComboBoxItem> arrivalCity = new List<ComboBoxItem>();
            foreach (Cities city1 in db.Cities.ToList())
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = city1.Name;
                cbi.Selected += (ss, ee) =>
                {
                    selectedCity1Id = city1.Id;
                };
                arrivalCity.Add(cbi);//-------------------------------
            }
            RouteArrivalCityId.ItemsSource = arrivalCity;

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
            RouteTrainsId.ItemsSource = trains;

            P1Route();
            UpdateRoutesGridWithGettingDB();
        }

        private void P1Route()
        {
            var db = new MyTrainEntities();
            RouteDataGrid.ItemsSource = db.Routes.Include("Cities").Include("Cities1").Include("Trains").ToList();
            RouteDataGrid.MouseDoubleClick += (s, e) =>
            {
                var cell = RouteDataGrid.CurrentCell;
                var route = (Routes)cell.Item;

                selectedRouteId = route.Id;
                selectedCityId = route.Cities.Id;
                selectedCity1Id = route.Cities1.Id;
                selectedTrainId = route.Trains.Id;
                RoutePriceCoupe.Text = (route.PriceCoupe).ToString();
                RoutePriceEconom.Text = (route.PriceEconom).ToString();
                RouteDepartureDate.Text = (route.DepartureDate).ToString();
                RouteArrivalDate.Text = (route.ArrivalDate).ToString();
            };
            db.Dispose();
        }

        public void UpdateRoutesGridWithGettingDB()
        {
            var db = new MyTrainEntities();

            RouteDataGrid.ItemsSource = db.Routes.Include("Cities").Include("Cities1").Include("Trains").ToList();

            db.Dispose();

        }

        private void AddRoute(object sender, RoutedEventArgs e)
        {
            if (RouteDepartureDate.Text == "")
                return;
            if (RouteArrivalDate.Text == "")
                return;
            if (selectedCityId == 0)
                return;
            if (selectedCity1Id == 0)
                return;
            if (selectedTrainId == 0)
                return;
            if (RoutePriceCoupe.Text == "")
                return;
            if (RoutePriceEconom.Text == "")
                return;

            var db = new MyTrainEntities();

            Routes route = new Routes();
            route.DepartureDate = Convert.ToDateTime(RouteDepartureDate.Text);
            route.DepartureCityId = selectedCityId;
            route.ArrivalCityId = selectedCity1Id;
            route.ArrivalDate = Convert.ToDateTime(RouteArrivalDate.Text);
            route.TrainsId = selectedTrainId;
            route.PriceCoupe = Convert.ToDecimal(RoutePriceCoupe.Text);
            route.PriceEconom = Convert.ToDecimal(RoutePriceEconom.Text);
            db.Routes.Add(route);
            db.SaveChanges();

            MessageBox.Show("Маршрут добавлен", "Успешно");
            db.Dispose();

            UpdateRoutesGridWithGettingDB();
        }

        private void ChangeRoute(object sender, RoutedEventArgs e)
        {

            var db = new MyTrainEntities();

            Routes route = db.Routes.Find(selectedRouteId);
            route.DepartureDate = Convert.ToDateTime(RouteDepartureDate.Text);
            route.DepartureCityId = selectedCityId;
            route.ArrivalCityId = selectedCity1Id;
            route.ArrivalDate = Convert.ToDateTime(RouteArrivalDate.Text);
            route.TrainsId = selectedTrainId;
            route.PriceCoupe = Convert.ToDecimal(RoutePriceCoupe.Text);
            route.PriceEconom = Convert.ToDecimal(RoutePriceEconom.Text);
            db.Routes.Add(route);
            db.SaveChanges();

            MessageBox.Show("Маршрут Изменен", "Успешно");
            db.Dispose();

            UpdateRoutesGridWithGettingDB();
        }

        private void DeleteRoute(object sender, RoutedEventArgs e)
        {
            if (selectedRouteId == 0)
                return;

            var db = new MyTrainEntities();

            db.Routes.Remove(db.Routes.Find(selectedRouteId));

            db.SaveChanges();

            MessageBox.Show("Маршрут удален", "Успешно");
            db.Dispose();

            UpdateRoutesGridWithGettingDB();
        }
    }
}
