using System;
using Xamarin.Forms;

namespace SizedBoxView
{
    public class SizedBoxViewPage : ContentPage
    {
        public SizedBoxViewPage()
        {
            //p. 77
            BackgroundColor = Color.Pink;

            Content = new BoxView
            {
                //p. 77
                //Color = Color.Accent,
                Color = Color.Navy,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                //WidthRequest = 200,
                //HeightRequest = 100
            };
        }
    }
}
