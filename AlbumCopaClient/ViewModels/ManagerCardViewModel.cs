using AlbumCopaClient.Core;
using AlbumCopaClient.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AlbumCopaClient.ViewModels
{
    public class ManagerCardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BindingList<ManagerCard> _managerCardList;

        public BindingList<ManagerCard> ManagerCardList
        {
            get { return _managerCardList; }
            set
            {
                _managerCardList = value;
                OnPropertyChanged();
            }
        }

        public Task InitUC()
        {
            GetManagerCards();
            return Task.CompletedTask;
        }

        public async void GetManagerCards()
        {
            try
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(UriPaths.ManagerCard);
                RestResponse response = await client.ExecuteGetAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var managers = JsonConvert.DeserializeObject<List<ManagerCard>>(response.Content);
                    ManagerCardList = new BindingList<ManagerCard>(managers);
                }
                else
                {
                    throw new Exception($"{response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao buscar os jogadores.\nException: {ex.Message}", "Erro");
            }
        }
    }
}
