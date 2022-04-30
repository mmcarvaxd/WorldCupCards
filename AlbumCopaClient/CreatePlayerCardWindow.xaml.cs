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
using System.Windows.Shapes;

namespace AlbumCopaClient
{
    /// <summary>
    /// Lógica interna para CreatePlayerCardWindow.xaml
    /// </summary>
    public partial class CreatePlayerCardWindow : Window
    {
        public CreatePlayerCardViewModel Model;

        private PlayerCard _playerCardToUpdate;

        public CreatePlayerCardWindow(Window owner, PlayerCard playerCardToUpdate = null)
        {
            InitializeComponent();
            this.Owner = owner;
            this.DataContext = new CreatePlayerCardViewModel();
            Model = DataContext as CreatePlayerCardViewModel;
            _playerCardToUpdate = playerCardToUpdate;
            this.Loaded += CreatePlayerCardWindow_Loaded;
        }

        private void CreatePlayerCardWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(_playerCardToUpdate != null)
            {
                btnCreatePlayerCard.Visibility = Visibility.Collapsed;
                Model.InitUCToUpdate(_playerCardToUpdate);
            }
            else
            {
                btnUpdatePlayerCard.Visibility = Visibility.Collapsed;
            }
        }

        private async void btnCreatePlayerCard_Click(object sender, RoutedEventArgs e)
        {
            var result = await Model.CreateNewPlayerCard();
            if (result)
                DialogResult = true;
        }

        private async void btnUpdatePlayerCard_Click(object sender, RoutedEventArgs e)
        {
            var result = await Model.UpdatePlayerCard();
            if (result)
                DialogResult = true;
        }
    }
}
