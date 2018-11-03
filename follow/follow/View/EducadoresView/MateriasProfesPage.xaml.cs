using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using follow.Infrastructure;
using System.Data.SqlClient;
using System.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MateriasProfesPage : ContentPage
	{
        String usuario;
       
        ObservableCollection<Materia> materia = new ObservableCollection<Materia>();
		public MateriasProfesPage (String correo)
		{
            usuario = correo;
			InitializeComponent ();

            ListaMaterias.ItemsSource = AccesoDatosMateria.ObtenerMaterias(correo);

            var TapPlus = new TapGestureRecognizer();
            TapPlus.Tapped += TapPlus_Tapped;
            Plus.GestureRecognizers.Add(TapPlus);
        }

        void TapPlus_Tapped(object sender, EventArgs args)
        {

            EnteredName.Text = string.Empty;
            overlay.IsVisible = true;
            EnteredName.Focus();

        }

        void OnOKButtonClicked(object sender, EventArgs args)
        {
            
            overlay.IsVisible = false;
            Coneccion6 conn = new Coneccion6();

            if (string.IsNullOrEmpty(this.EnteredName.Text))
             {
            DisplayAlert("Error", "No pusiste un nombre :( ", "oky");

            }


           else
            {
                
              int resultado =  AccesoDatosMateria.IngresarMateria(EnteredName.Text, usuario,"");
               

                if (resultado > 0)
                {

                    DisplayAlert("Nuevo Curso Agregado", "Tu curso " + EnteredName.Text + " fue agregado con exito", "oky");
                    
                }
                else
                {
                    DisplayAlert("Error", "Hubo un error en tu creacion de Materia, intentalo otra vez", "Aceptar");
                }
                

                          

            }   


        }

        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }

        private void ListaMaterias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem ==null) { return; }
          
            
            contact data = e.SelectedItem as contact;
            Application.Current.MainPage.Navigation.PushAsync(new AgregarGrupos());
            
        }

        
       
    }
}