using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Projeto_Coqui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public static async Task<string> Localizacao()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            string retorno = "Não foi possível pegar a localização";

            if (location != null)
            {
                retorno = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
            }

            return retorno;
        }

        private void btnGPS_Clicked(object sender, EventArgs e)
        {
            var location = Localizacao().Result;
            lblGPS.Text = location;
        }

        private void btnConexao_Clicked(object sender, EventArgs e)
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                lblConexao.Text = "Com acesso a internet";
            else
                lblConexao.Text = "Sem acesso a internet";
        }
    }
}
