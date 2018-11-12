using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.View.EducadoresView;
using follow.Infrastructure;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaTareasEducador : ContentPage
    {
        string TareaClick;
        string Grup;
       
        public VistaTareasEducador(String Grupotomado)
        {

            InitializeComponent();

            grupotitle.Text = " Grupo : " + Grupotomado;
            Grup = Grupotomado;

            ListaTareas.ItemsSource = AccesoDatosTarea.ObtenerTareas(grupotitle.Text);
          
            
            
            


        }

        void Tap_Profile(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Estudiantes());
        }

        void NuevaTarea (object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushAsync(new CrearTareas(Grup));
        }

        private void ListaGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) { return; }


            var tarea = e.SelectedItem as Tarea;

            TareaClick = tarea.Nombre;


            Application.Current.MainPage.Navigation.PushAsync(new VistaTarea(TareaClick));
        }
    }

       

    }
