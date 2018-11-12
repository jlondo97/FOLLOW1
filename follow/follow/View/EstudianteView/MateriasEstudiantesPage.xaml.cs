using follow.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EstudianteView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MateriasEstudiantesPage : ContentPage
	{
        string correo;
		public MateriasEstudiantesPage (string usuario)
		{
			InitializeComponent ();
            correo = usuario;
            ListaGrupos.ItemsSource = AccesoDatosGrupo.ObtenerGruposEst(correo);
        }

        void TapPlus_Tapped(object sender, EventArgs args)
        {

            EnteredName.Text = string.Empty;           
            overlay.IsVisible = true;
            EnteredName.Focus();

        }

          void OnOKButtonClicked(object sender, System.EventArgs args)
        {
            overlay.IsVisible = false;


            DataTable Datos = AccesoDatosGrupo.VerificarGrupo(EnteredCode.Text);
            if (Datos.Rows.Count > 0)
            {
                //  Application.Current.MainPage.Navigation.PushAsync(new SeleccionUsuarioPage(Usuario));
                // DisplayAlert("Holla", "Grupo si existe", "oky");

                int resultado = AccesoDatosGrupo.IngresarEstudiante(EnteredCode.Text, EnteredName.Text, correo);

                if (resultado > 0)
                {
                    DisplayAlert("Nuevo grupo Agregado", "Tu Grupo fue agregado con exito" , "oky");
                }
                else
                {
                    DisplayAlert("Error", "Hubo un error en tu creacion de Grupo, intentalo otra vez", "Aceptar");
                }

            }
            else
            {
                DisplayAlert("Error", "Grupo invalido", "oky");
            }

            // {
            // DisplayAlert("Error", "Debes Agregar Estudiante o Identificacion", "oky");

            //}

            //else
            //{
           // DisplayAlert("EN CONSTRUCCION","Estamos en proceso, gracias", "oky");

              //  estudiantes.Add(new Estudiante { Nombre = EnteredName.Text, Id = Identificacion.Text });
            //}   


        }
 
        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }

        private void ListaGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new TareaEstudiante());
        }
    }
}