using AlbumCopaClient.Entities;
using AlbumCopaClient.ViewModels;
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

namespace AlbumCopaClient.Views
{
    /// <summary>
    /// Interação lógica para StadiumCardView.xam
    /// </summary>
    public partial class StadiumCardView : UserControl
    {
        public StadiumCardViewModel Model;

        public StadiumCardView()
        {
            InitializeComponent();
            this.DataContext = new StadiumCardViewModel();
            Model = DataContext as StadiumCardViewModel;
            this.Loaded += StadiumCardView_Loaded;
        }

        private void StadiumCardView_Loaded(object sender, RoutedEventArgs e)
        {
            Model.InitUC();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            Model.GetStadiumCards();
        }

        private void btnAddStadium_Click(object sender, RoutedEventArgs e)
        {
            CreateStadiumCardWindow createStadiumCardWindow = new CreateStadiumCardWindow(Application.Current.MainWindow);
            bool result = createStadiumCardWindow.ShowDialog().Value;

            if (result)
                Model.GetStadiumCards();
        }

        private void btnEditStadiumCard_Click(object sender, RoutedEventArgs e)
        {
            StadiumCard stadiumCard = (sender as Button).Tag as StadiumCard;

            CreateStadiumCardWindow createStadiumCardWindow = new CreateStadiumCardWindow(Application.Current.MainWindow, stadiumCard);
            bool result = createStadiumCardWindow.ShowDialog().Value;

            if (result)
                Model.GetStadiumCards();
        }

        private async void btnDeleteStadiumCard_Click(object sender, RoutedEventArgs e)
        {
            StadiumCard stadiumCard = (sender as Button).Tag as StadiumCard;

            var result = MessageBox.Show($"Deseja Deletar a carta do jogador {stadiumCard.Description} ?", "Alerta", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                var succeed = await Model.DeleteStadiumCard(stadiumCard);
                Model.GetStadiumCards();
            }
        }
    }
}
