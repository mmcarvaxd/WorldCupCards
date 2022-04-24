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
        public CreatePlayerCardWindow(Window owner)
        {
            InitializeComponent();
            this.Owner = owner;
            this.DataContext = new CreatePlayerCardViewModel();
            Model = DataContext as CreatePlayerCardViewModel;
        }

        private async void btnCreatePlayerCard_Click(object sender, RoutedEventArgs e)
        {
            var result = await Model.CreateNewPlayerCard();
            if (result)
                DialogResult = true;
        }
    }
}
