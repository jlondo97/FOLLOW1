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
		public MateriasEstudiantesPage ()
		{
			InitializeComponent ();

        
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


            DataTable Datos = AccesoDatosGrupo.VerificarGrupo(EnteredName.Text);
            if (Datos.Rows.Count > 0)
            {
                //  Application.Current.MainPage.Navigation.PushAsync(new SeleccionUsuarioPage(Usuario));
                DisplayAlert("Holla", "Grupo si existe", "oky");

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
    }
}