using ExamenProAlberto.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExamenProAlberto.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AV_Rootobject> _movieList;
        public ObservableCollection<AV_Rootobject> MovieList
        {
            get => _movieList;
            set
            {
                _movieList = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            MovieList = new ObservableCollection<AV_Rootobject>();
        }

        public async Task GetMovieInformation(string movieTitle)
        {
            string apiKey = "76322bf3";
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://www.omdbapi.com/?t=" + movieTitle + "&apikey=" + apiKey);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                String content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AV_Rootobject>(content);
                MovieList.Add(result);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
