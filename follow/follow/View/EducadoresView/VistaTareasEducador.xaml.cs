using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using follow.View.EducadoresView;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View.EducadoresView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VistaTareasEducador : ContentPage
	{
        public VistaTareasEducador()
        {
            InitializeComponent();
            string codigo = codigo_Grupo();
            codigoprueba.Text = string.Format("codigo de grupo :" + codigo);
            
		}

        public string codigo_Grupo()
        {
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
    }
}