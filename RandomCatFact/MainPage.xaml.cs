using System.Text.Json;

namespace RandomCatFact
{
    public partial class MainPage : ContentPage
    {
        private JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
        

        public MainPage()
        {
            InitializeComponent();
            RandomCatFact(null,null);

        }

        private async void RandomCatFact(object sender, EventArgs e)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.None)
            {
                try
                {
                    HttpClient client = new HttpClient();

                    string response = await client.GetStringAsync("https://catfact.ninja/fact");
                    FactLabel.Text = JsonSerializer.Deserialize<CatFact>(response, _serializerOptions).Fact;
                }
                catch
                {
                    
                }
            }
        }

        
    }
}