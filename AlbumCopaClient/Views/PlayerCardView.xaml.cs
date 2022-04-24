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
    }
}
