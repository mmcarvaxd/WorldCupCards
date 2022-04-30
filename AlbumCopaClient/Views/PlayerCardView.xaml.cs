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
    /// Interação lógica para PlayerCardView.xam
    /// </summary>
    public partial class PlayerCardView : UserControl
    {
        public PlayerCardViewModel Model;
        public PlayerCardView()
        {
            InitializeComponent();
            this.DataContext = new PlayerCardViewModel();
            Model = DataContext as PlayerCardViewModel;
            Loaded += PlayerCardView_Loaded;
        }

        private void PlayerCardView_Loaded(object sender, RoutedEventArgs e)
        {
            Model.InitUC();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            Model.GetPlayerCards();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            CreatePlayerCardWindow createPlayerCardWindow = new CreatePlayerCardWindow(Application.Current.MainWindow);
            bool result = createPlayerCardWindow.ShowDialog().Value;

            if (result)
                Model.GetPlayerCards();
        }

        private async void btnDeletePlayerCard_Click(object sender, RoutedEventArgs e)
        {
            PlayerCard playerCard = (sender as Button).Tag as PlayerCard;

            var result = MessageBox.Show($"Deseja Deletar a carta do jogador {playerCard.Description} ?", "Alerta", MessageBoxButton.YesNo);

            if(result == MessageBoxResult.Yes)
            {
                var succeed = await Model.DeletePlayerCard(playerCard);
                Model.GetPlayerCards();
            }
        }

        private void btnEditPlayerCard_Click(object sender, RoutedEventArgs e)
        {
            PlayerCard playerCard = (sender as Button).Tag as PlayerCard;

            CreatePlayerCardWindow createPlayerCardWindow = new CreatePlayerCardWindow(Application.Current.MainWindow, playerCard);
            bool result = createPlayerCardWindow.ShowDialog().Value;

            if (result)
                Model.GetPlayerCards();
        }
    }
}
