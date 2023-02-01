using ExamenProAlberto.Models;
using Newtonsoft.Json;
using System.Net;

namespace ExamenProAlberto;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public async void Button_Clicked(object sender, EventArgs e)
    {
        string cadena = Buscador.Text;
        string apiKey = "76322bf3";
        var request = new HttpRequestMessage();
        //request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        request.RequestUri = new Uri("https://www.omdbapi.com/?t=" + cadena + "&apikey=" + apiKey);
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json");

        var client = new HttpClient();

        HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<AV_Rootobject>(content);
            ListaDemo.ItemsSource = new List<AV_Rootobject> { resultado };
        }
    }

    private void Button_Clicked_Historial(object sender, EventArgs e)
    {

    }
}

