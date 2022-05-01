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
    /// Lógica interna para CreateStadiumCardWindow.xaml
    /// </summary>
    public partial class CreateStadiumCardWindow : Window
    {
        public CreateStadiumCardViewModel Model;

        private StadiumCard _stadiumCardToUpdate;
        public CreateStadiumCardWindow(Window owner, StadiumCard stadiumCardToUpdate = null)
        {
            InitializeComponent();
            this.Owner = owner;
            this.DataContext = new CreateStadiumCardViewModel();
            Model = DataContext as CreateStadiumCardViewModel;
            _stadiumCardToUpdate = stadiumCardToUpdate;
            this.Loaded += CreateStadiumCardWindow_Loaded;
        }

        private void CreateStadiumCardWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (_stadiumCardToUpdate != null)
            {
                btnCreateStadiumCard.Visibility = Visibility.Collapsed;
                Model.InitUCToUpdate(_stadiumCardToUpdate);
            }
            else
            {
                btnUpdateStadiumCard.Visibility = Visibility.Collapsed;
            }
        }

        private async void btnUpdateStadiumCard_Click(object sender, RoutedEventArgs e)
        {
            var result = await Model.UpdateStadiumCard();
            if (result)
                DialogResult = true;
        }

        private async void btnCreateStadiumCard_Click(object sender, RoutedEventArgs e)
        {
            var result = await Model.CreateNewStadiumCard();
            if (result)
                DialogResult = true;
        }
    }
}
