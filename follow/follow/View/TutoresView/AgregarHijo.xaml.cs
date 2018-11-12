using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using follow.View.EducadoresView;
using follow.Infrastructure;
using System.Data;

namespace follow.View.TutoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarHijo : ContentPage 
        {
        String user;

        #region contructor
        ObservableCollection<Estudiante> estudiantes = new ObservableCollection<Estudiante>();
  
                     public AgregarHijo(String Usuario)
        {
            user=Usuario;
            InitializeComponent();
            ListaHijos.ItemsSource = AccesoDatosTutor.ObtenerHijo(Usuario);
            
            
              
        }

        
        #endregion

        #region Botones



        void TapPlus_Tapped(object sender, EventArgs args)
        {

            EnteredCorreo.Text = string.Empty;
           EnteredId.Text = string.Empty;
            overlay.IsVisible = true;
            EnteredCorreo.Focus();

        }


        void OnOKButtonClicked(object sender, System.EventArgs args)
        {
            DataTable Datos = AccesoDatosTutor.VerificarEstudiante(EnteredId.Text);
            if(Datos.Rows.Count>0)
            {

                AccesoDatosTutor.IngresarHijo(EnteredCorreo.Text,user);
                DisplayAlert("Correcto", "Estudiante Agregado", "oky");
                            }
            else
            {
                DisplayAlert("Error", "Estudiante no se encuentra", "oky");
            }

            overlay.IsVisible = false;
            if (string.IsNullOrEmpty(this.EnteredCorreo.Text) || string.IsNullOrEmpty(this.EnteredId.Text))
            {
                DisplayAlert("Error", "Debes Agregar Estudiante o Identificacion", "oky");

            }

            else
            {
               
                DisplayAlert("Nuevo Estudiante Agregado", EnteredCorreo.Text, "oky");

               // estudiantes.Add(new Estudiante { Nombre = EnteredName.Text, Id = Identificacion.Text });
            }   


        }
 
        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }




                                  #endregion

        private void ListaHijos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null) { return; }

           contact data = e.SelectedItem as contact;
            Application.Current.MainPage.Navigation.PushAsync(new ListaTareasTutorPage());

        }
    }
}
