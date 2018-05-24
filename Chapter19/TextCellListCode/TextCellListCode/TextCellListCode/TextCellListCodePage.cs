using System;
using Xamarin.Forms;
using Xamarin.FormsBook.Toolkit;

namespace TextCellListCode
{
    public class TextCellListCodePage : ContentPage
    {
        public TextCellListCodePage()
        {
			// Define the DataTemplate.
			//DataTemplate dataTemplate = new DataTemplate(typeof(TextCell)); 
			// Alternative to illustrate scorlling items into view and intantiating TextCells as 
			// they come into view
			int count = 0;
			DataTemplate dataTemplate = new DataTemplate(() => {
					System.Diagnostics.Debug.WriteLine($"Text Cell Number {++count}");
					return new TextCell();
				}
			);
            dataTemplate.SetBinding(TextCell.TextProperty, "FriendlyName");
            dataTemplate.SetBinding(TextCell.DetailProperty, 
                new Binding(path: "RgbDisplay", stringFormat: "RGB = {0}"));

            // Build the page.
            Padding = new Thickness(10, Device.RuntimePlatform == Device.iOS ? 20 : 0, 10, 0);

            Content = new ListView
            {
                ItemsSource = NamedColor.All,
                ItemTemplate = dataTemplate
            };
        }
    }
}
