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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyTrain
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Window
    {
        bool SideBarFlag;
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
    }
}
