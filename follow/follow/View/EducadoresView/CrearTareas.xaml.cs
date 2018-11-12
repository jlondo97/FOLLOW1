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
        string GrupoTarea;

        public CrearTareas(string Grupo)
        {
            InitializeComponent();
            GrupoTarea = Grupo;
        }

        private void Guardar_Tarea(object sender, EventArgs e)
        {
           
            Coneccion6 conn = new Coneccion6();

            if (string.IsNullOrEmpty(NombreTarea.Text) || String.IsNullOrEmpty(DescripcionTarea.Text))
            {
                DisplayAlert("Error", "Todos los campos de resgistro deben ser llenados", "oky");
            }
            else
            {

                

              int resultado = AccesoDatosTarea.IngresarTarea(NombreTarea.Text, DescripcionTarea.Text, FechaInicio.Text, FechaFinal.Text, GrupoTarea);
              //  des = DescripcionTarea.Text;

                if (resultado > 0)
                {
                    DisplayAlert("En hora buena ", "Validar con la base de datos y guardar ", "oky");
                }
                else
                {

                    DisplayAlert("UPS ", "Parece que algo ha salido mal ", "oky");

                }
            }

        }
    }
}