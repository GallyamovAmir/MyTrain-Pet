﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace MyTrain
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Window
    {
        bool SideBarFlag;
        bool TrainWagonFlag;
        public WorkerPage()
        {
            InitializeComponent();
            ValidWorkerName.Content = $"{ValidWorker.name} {ValidWorker.middlename}";
        }

        void SideBarOC()
        {
            ThicknessAnimation OpenMainBarAnimation = new ThicknessAnimation();
            OpenMainBarAnimation.From = MainBar.Margin;
            OpenMainBarAnimation.To = new Thickness(0, 0, 300, 0);
            OpenMainBarAnimation.Duration = TimeSpan.FromSeconds(0.3);
            MainBar.BeginAnimation(DockPanel.MarginProperty, OpenMainBarAnimation);

            ThicknessAnimation ButtonMainBarAnimation = new ThicknessAnimation();
            ButtonMainBarAnimation.From = ButtonSideBar.Margin;
            ButtonMainBarAnimation.To = new Thickness(0, 0, 0, 0);
            ButtonMainBarAnimation.Duration = TimeSpan.FromSeconds(0.3 / 300 * (ButtonSideBar.Margin.Left + ButtonSideBar.ActualWidth));
            ButtonSideBar.BeginAnimation(Button.MarginProperty, ButtonMainBarAnimation);

            SideBarFlag = false;
        }

        private void SideBar(object sender, RoutedEventArgs e)
        {
            if (!SideBarFlag)
            {

                ThicknessAnimation OpenMainBarAnimation = new ThicknessAnimation();
                OpenMainBarAnimation.From = MainBar.Margin;
                OpenMainBarAnimation.To = new Thickness(0, 0, 0, 0);
                OpenMainBarAnimation.Duration = TimeSpan.FromSeconds(0.3);
                MainBar.BeginAnimation(DockPanel.MarginProperty, OpenMainBarAnimation);

                ThicknessAnimation ButtonMainBarAnimation = new ThicknessAnimation();
                ButtonMainBarAnimation.From = ButtonSideBar.Margin;
                ButtonMainBarAnimation.To = new Thickness(gridd.ActualWidth - ButtonSideBar.ActualWidth, 0, 0, 0);
                ButtonMainBarAnimation.Duration = TimeSpan.FromSeconds(0.3 / 300 * (gridd.ActualWidth + ButtonSideBar.ActualWidth));
                ButtonSideBar.BeginAnimation(Button.MarginProperty, ButtonMainBarAnimation);

                SideBarFlag = true;
            }
            else
            {
                ThicknessAnimation OpenMainBarAnimation = new ThicknessAnimation();
                OpenMainBarAnimation.From = MainBar.Margin;
                OpenMainBarAnimation.To = new Thickness(0, 0, 300, 0);
                OpenMainBarAnimation.Duration = TimeSpan.FromSeconds(0.3);
                MainBar.BeginAnimation(DockPanel.MarginProperty, OpenMainBarAnimation);

                ThicknessAnimation ButtonMainBarAnimation = new ThicknessAnimation();
                ButtonMainBarAnimation.From = ButtonSideBar.Margin;
                ButtonMainBarAnimation.To = new Thickness(0, 0, 0, 0);
                ButtonMainBarAnimation.Duration = TimeSpan.FromSeconds(0.3 / 300 * (ButtonSideBar.Margin.Left + ButtonSideBar.ActualWidth));
                ButtonSideBar.BeginAnimation(Button.MarginProperty, ButtonMainBarAnimation);

                SideBarFlag = false;
            }
        }

        private void UserPage(object sender, RoutedEventArgs e)
        {
            SideBarOC();
            OutputFrame.Content = new UserPage();
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            ValidWorker.name = null;
            ValidWorker.middlename = null;
            ValidWorker.password = null;

            SigninPage signinPage = new SigninPage();
            signinPage.Show();
            this.Close();
            
        }

        private void ReturnToWorkerPage(object sender, MouseButtonEventArgs e)
        {
            OutputFrame.Content = null;
        }

        private void FormalizedTicketPage(object sender, RoutedEventArgs e)
        {
            SideBarOC();
            OutputFrame.Content = new FormalizedTicketPage();
        }

        private void CityPage(object sender, RoutedEventArgs e)
        {
            SideBarOC();
            OutputFrame.Content = new CityPage();
        }

        private void TrainWagonPage(object sender, RoutedEventArgs e)
        {
            SideBarOC();
             if(!TrainWagonFlag)
            {
                OutputFrame.Content = new TrainPage();
                TrainWagonFlag = true;
            }
             else
            {
                OutputFrame.Content = new WagonPage();
                TrainWagonFlag = false;
            }
           
        }

        private void RoutesPage(object sender, RoutedEventArgs e)
        {
            SideBarOC();
            OutputFrame.Content = new RoutesPage();
        }
    }
}
