using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using follow.Infrastructure;


namespace follow.View.EducadoresView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AgregarGrupos : ContentPage

    {
        string MateriaSelected;
        string grupoclick;
        string cod;
        ObservableCollection<Grupo> grupo = new ObservableCollection<Grupo>();

        public AgregarGrupos(string Materiatomada){

            InitializeComponent();
            materiatitle.Text = ("Materia : " + Materiatomada);
                 

            string codigo = codigo_Grupo();
                     
            ListaGrupos.ItemsSource = AccesoDatosGrupo.ObtenerGrupos();
           
            var TapPlus = new TapGestureRecognizer();
            TapPlus.Tapped += TapPlus_Tapped;
            Plus.GestureRecognizers.Add(TapPlus);
        }

        public static string codigo_Grupo(){

                var longitud = 6;
                string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder res = new StringBuilder();
                Random rnd = new Random();
                while (0 < longitud--)
                {
                    res.Append(caracteres[rnd.Next(caracteres.Length)]);
                }
                return res.ToString();
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
                string codigo = codigo_Grupo();
                 cod = codigo;

                int resultado = AccesoDatosGrupo.IngresarGrupo(EnteredName.Text, materiatitle.Text, codigo);

                if (resultado > 0)
                {
                 DisplayAlert("Nuevo grupo Agregado", "Tu Grupo " + EnteredName.Text + " fue agregado con exito y su codigo es: " + codigo, "oky");
                }
                else
                {
                    DisplayAlert("Error", "Hubo un error en tu creacion de Grupo, intentalo otra vez", "Aceptar");
                }
            }
        }

            void OnCancelButtonClicked(object sender, EventArgs args)
        {
            overlay.IsVisible = false;
        }

        private void ListaGrupos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null) { return; }


            var grupo = e.SelectedItem as Grupo;

            grupoclick = grupo.Nombre;


            Application.Current.MainPage.Navigation.PushAsync(new VistaTareasEducador(grupoclick));
        }
    }
}