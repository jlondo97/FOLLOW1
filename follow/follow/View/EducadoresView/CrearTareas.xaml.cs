using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrearTareas : ContentPage
    {
        string des;

        public CrearTareas()
        {
            InitializeComponent();
        }

        private void Guardar_Tarea (object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.NombreTarea.Text) )
            
            {
                DisplayAlert("Error", "Todos los campos de resgistro deben ser llenados", "oky");

         
            }
            else
            {

                 des = DescripcionTarea.Text;
                 
              
                    DisplayAlert("En hora buena ", "Validar con la base de datos y guardar ", "oky");
                /// Aqui va lo de acceso datos para tareas y guardar y validar en la base de datos 
            }
        }

        }
}