using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using follow.Infrastructure;

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

            if (string.IsNullOrEmpty(NombreTarea.Text) || String.IsNullOrEmpty(DescripcionTarea.Text))               
             {
                DisplayAlert("Error", "Todos los campos de resgistro deben ser llenados", "oky");         
            }
            else
            {
                var Grupo = "";
                int resultado = AccesoDatosTarea.IngresarTarea(NombreTarea.Text, DescripcionTarea.Text, FechaInicio.Text, FechaFinal.Text,Grupo);
                 des = DescripcionTarea.Text;
                 
              
                    DisplayAlert("En hora buena ", "Validar con la base de datos y guardar ", "oky");
                
        }

        }
}