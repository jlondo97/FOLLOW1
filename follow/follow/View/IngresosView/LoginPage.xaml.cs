using follow.Infrastructure;
using follow.View.IngresosView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using follow.View.EducadoresView;

namespace follow.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            var Tapface = new TapGestureRecognizer();
            Tapface.Tapped += Tap_face;
            faceb.GestureRecognizers.Add(Tapface);
        }

        private void Registrar(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Registrar());

        }

        void Tap_face(object sender, EventArgs arg)
        {
            Application.Current.MainPage.Navigation.PushAsync(new VistaTareasEducador());
        }




        void OnEntrarButtonClicked(object sender, System.EventArgs args)
        {
            string Usuario;
            Usuario = Correo.Text;
          
            DataTable Datos = AccesoDatosUsuario.VerificarUsuario(Correo.Text,Contra.Text);
            if (Datos.Rows.Count > 0)
            {
                Application.Current.MainPage.Navigation.PushAsync(new SeleccionUsuarioPage(Usuario));

            }
            else
            {
                DisplayAlert("Error", "Usuario invalido", "oky");
            }

            

        }
    }
}