using System;
using Xamarin.Forms;

namespace ModalEnforcement
{
    public partial class ModalEnforcementHomePage : ContentPage
    {
		ModalEnforcementModalPage modalPage = new ModalEnforcementModalPage();
        public ModalEnforcementHomePage()
        {
            InitializeComponent();
        }

        async void OnGoToButtonClicked(object sender, EventArgs args)
        {
            //await Navigation.PushModalAsync(new ModalEnforcementModalPage());
			await Navigation.PushModalAsync(modalPage);
		}
    }
}
