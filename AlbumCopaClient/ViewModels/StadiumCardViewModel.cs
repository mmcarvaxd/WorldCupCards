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
    public class StadiumCardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private BindingList<StadiumCard> _stadiumCardList;

        public BindingList<StadiumCard> StadiumCardList
        {
            get { return _stadiumCardList; }
            set
            {
                _stadiumCardList = value;
                OnPropertyChanged();
            }
        }

        public Task InitUC()
        {
            GetStadiumCards();
            return Task.CompletedTask;
        }

        /// <summary>
        /// Busca as cartas de estadios na API utilizando GET e exibe no datagrid.
        /// </summary>
        public async void GetStadiumCards()
        {
            try
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(UriPaths.StadiumCard);
                RestResponse response = await client.ExecuteGetAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var pcl = JsonConvert.DeserializeObject<List<StadiumCard>>(response.Content);
                    StadiumCardList = new BindingList<StadiumCard>(pcl);
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

        /// <summary>
        /// Deleta a carta de estadio na API utilizando DELETE.
        /// </summary>
        /// <param name="stadiumCard"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStadiumCard(StadiumCard stadiumCard)
        {
            try
            {
                RestClient client = new RestClient();
                RestRequest request = new RestRequest(UriPaths.DeleteStadiumCard(stadiumCard.CardNumber));
                RestResponse response = await client.DeleteAsync(request);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception($"{response.StatusCode}");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao deletar o jogador.\nException: {ex.Message}", "Erro");
                return false;
            }
        }
    }
}
