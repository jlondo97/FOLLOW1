using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace follow.View.TutoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarHijo : ContentPage 
        {


        #region contructor
        private List<Estudiante> estudiantes;

        public AgregarHijo()
        {
            InitializeComponent();
            this.loadEstudiante();
      
            var TapPlus = new TapGestureRecognizer();
            TapPlus.Tapped += TapPlus_Tapped;
            Plus.GestureRecognizers.Add(TapPlus);


        }

        private async void loadEstudiante()
        {
            String nombre = EnteredName.Text;
            String id = Identificacion.Text;
            
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
            DisplayAlert("Nuevo Estudiante Agregado", EnteredName.Text, "oky");
           
        }
 
        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }









        #endregion
    }
}
