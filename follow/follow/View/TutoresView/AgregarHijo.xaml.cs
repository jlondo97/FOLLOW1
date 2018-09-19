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

namespace follow.View.TutoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarHijo : ContentPage 
        {


        #region contructor
        ObservableCollection<Estudiante> estudiantes = new ObservableCollection<Estudiante>();

               public AgregarHijo()
        {
            InitializeComponent();
            ListaHijos.ItemsSource = estudiantes;
            var TapPlus = new TapGestureRecognizer();
            TapPlus.Tapped += TapPlus_Tapped;
            Plus.GestureRecognizers.Add(TapPlus);       
        }

        
        #endregion

        #region Botones



        void TapPlus_Tapped(object sender, EventArgs args)
        {

            EnteredName.Text = string.Empty;
            Identificacion.Text = string.Empty;
            overlay.IsVisible = true;
            EnteredName.Focus();

        }

       

        void OnOKButtonClicked(object sender, System.EventArgs args)
        {
            overlay.IsVisible = false;
            if (string.IsNullOrEmpty(this.EnteredName.Text) || string.IsNullOrEmpty(this.Identificacion.Text))
            {
                DisplayAlert("Error", "Debes Agregar Estudiante o Identificacion", "oky");

            }

            else
            {
                DisplayAlert("Nuevo Estudiante Agregado", EnteredName.Text, "oky");

                estudiantes.Add(new Estudiante { Nombre = EnteredName.Text, Id = Identificacion.Text });
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
