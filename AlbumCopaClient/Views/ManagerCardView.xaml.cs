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
    /// Interação lógica para ManagerCardView.xam
    /// </summary>
    public partial class ManagerCardView : UserControl
    {
        public ManagerCardViewModel Model;
        public ManagerCardView()
        {
            InitializeComponent();
            this.DataContext = new ManagerCardViewModel();
            Model = DataContext as ManagerCardViewModel;
            Loaded += ManagerCardView_Loaded; ;
        }

        private void ManagerCardView_Loaded(object sender, RoutedEventArgs e)
        {
            Model.InitUC();
        }

        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            Model.GetManagerCards();
        }
    }
}
