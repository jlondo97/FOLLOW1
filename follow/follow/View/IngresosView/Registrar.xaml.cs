using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using follow.Infrastructure;


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
            Coneccion6 conn = new Coneccion6();
        
            if (string.IsNullOrEmpty(this.Nombre.Text) || string.IsNullOrEmpty(this.Apellido.Text) ||
                    string.IsNullOrEmpty(this.Edad.Text) || string.IsNullOrEmpty(this.Id.Text) ||
                     string.IsNullOrEmpty(this.Email.Text) || string.IsNullOrEmpty(this.contraseña.Text) ||
                     string.IsNullOrEmpty(this.confirmacion.Text))

            {

                DisplayAlert("Error", "Todos los campos de resgistro deben ser llenados", "oky");
            }
            else
            {
                string Mnombre = Nombre.Text;
                string MApellido = Apellido.Text;

                MApellido= MApellido.ToUpper();
                Mnombre= Mnombre.ToUpper();

                string str = "'"+ this.contraseña.Text +"','" + this.Email.Text + "','" + this.Nombre.Text + "','" + this.Apellido.Text +
                    "'," + this.Edad.Text + ",'" + this.Id.Text + "'";

                int res = conn.Insert(str, "UserLogin");

                if (res == 0)
                {
                    DisplayAlert("Felicidades", Mnombre + " " + MApellido + " fuiste agregado con exito", "Aceptar");
                    Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                    {
                    DisplayAlert("Error","Hubo un error en tu creacion de prefil, intentalo mas tarde", "Aceptar");

                }
                }

           

        }
    }
}