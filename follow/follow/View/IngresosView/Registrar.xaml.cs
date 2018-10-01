using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.IngresosView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registrar : ContentPage
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void Registrarse(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Nombre.Text) || string.IsNullOrEmpty(this.Apellido.Text) ||
                    string.IsNullOrEmpty(this.Edad.Text) || string.IsNullOrEmpty(this.Id.Text) ||
                     string.IsNullOrEmpty(this.Email.Text) || string.IsNullOrEmpty(this.contraseña.Text) ||
                     string.IsNullOrEmpty(this.confirmacion.Text))

             {

                DisplayAlert("Error", "Todos los campos de resgistro deben ser llenados", "oky");
             }
            else
            {
                DisplayAlert("Felicidades", Nombre.Text+ " " + Apellido.Text + " fuiste agregado con exito", "Aceptar");
            }

        }
    }
}