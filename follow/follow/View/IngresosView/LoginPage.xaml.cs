using follow.View.IngresosView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace follow.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private void Registrar(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new Registrar());

        }
    }
}