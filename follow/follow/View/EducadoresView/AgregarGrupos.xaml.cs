using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AgregarGrupos : ContentPage

    {
        ObservableCollection<Grupo> grupo = new ObservableCollection<Grupo>();
        public AgregarGrupos()
        {
            InitializeComponent();
            ListaGrupos.ItemsSource = grupo;
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

            if (string.IsNullOrEmpty(this.EnteredName.Text))
            {
                DisplayAlert("Error", "No pusiste un nombre :( ", "oky");

            }

            else
            {
                DisplayAlert("Nuevo Materia Agregada", "Tu curso " + EnteredName.Text + " fue agregado con exito", "oky");

                grupo.Add(new Grupo { Nombre = EnteredName.Text });

            }

        }


        void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }
    }
}