using System;
using Xamarin.Forms;

namespace ModelessAndModal
{
    public class ModelessPage : ContentPage
    {
        public ModelessPage()
        {
            Title = "Modeless Page";

			// NavigationPage.SetHasBackButton(this, false);
			// NavigationPage.SetHasNavigationBar(this, false);

			//obsolete
			if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
				NavigationPage.SetTitleIcon(this, "ic_action_flash_on.png");

			//if(Device.RuntimePlatform == "IOS" || Device.RuntimePlatform == "Android"){
			//	NavigationPage.SetiTitleIcon(this, "ic_action_flash_on.png");
			//}
            Button goBackButton = new Button
            {
                Text = "Back to Main",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            goBackButton.Clicked += async (sender, args) =>
            {
                await Navigation.PopAsync();
            };

            Content = goBackButton;
        }
    }
}
