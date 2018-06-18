using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace ChessboardProportional
{
    public class ChessboardProportionalPage : ContentPage
    {
        AbsoluteLayout absoluteLayout;
		int countAbsLayoutSizeChanged = 0;
		int countContentViewSizeChanged = 0;
		int countPageSizeChanged = 0;

        public ChessboardProportionalPage()
        {
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.FromRgb(240, 220, 130),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Skip every other square.
                    if (((row ^ col) & 1) == 0)
                        continue;

                    BoxView boxView = new BoxView
                    {
                        Color = Color.FromRgb(0, 64, 0)
                    };

                    Rectangle rect = new Rectangle(col / 7.0,   // x
                                                   row / 7.0,   // y
                                                   1 / 8.0,     // width
                                                   1 / 8.0);    // height

                    absoluteLayout.Children.Add(boxView, rect, AbsoluteLayoutFlags.All);
                }
            }

            ContentView contentView = new ContentView
            {
                Content = absoluteLayout
            };
            contentView.SizeChanged += OnContentViewSizeChanged;

            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 25 : 5, 5, 5);
            Content = contentView;
        }

		void OnAbsoluteLayoutSizeChanged(object sender, EventArgs eventArgs)
        {
            var absLayout = (AbsoluteLayout)sender;
            System.Diagnostics.Debug.WriteLine($"In {nameof(OnAbsoluteLayoutSizeChanged)}: count={countAbsLayoutSizeChanged++}, X={absLayout.X}, Y={absLayout.Y}," +
                                               $" Width={absLayout.Width}, Height={absLayout.Height}");
        }


        void OnContentViewSizeChanged(object sender, EventArgs args)
        {
            ContentView contentView = (ContentView)sender;

			Debug.WriteLine($"In {nameof(OnContentViewSizeChanged)}: count={countContentViewSizeChanged++}, X={contentView.X}, Y={contentView.Y}," +
                       $" Width={contentView.Width}, Height={contentView.Height}");

            double boardSize = Math.Min(contentView.Width, contentView.Height);
            absoluteLayout.WidthRequest = boardSize;
            absoluteLayout.HeightRequest = boardSize;
        }

		void OnPageSizeChanged(object sender, EventArgs eventArgs) {
			var page = (ChessboardProportionalPage)sender;
			Debug.WriteLine($"In {nameof(OnPageSizeChanged)}: count={countPageSizeChanged++}, X={page.X}, Y={page.Y}," +
											   $" Width={page.Width}, Height={page.Height}");
			//var callStack = new System.Diagnostics.Debug.StackTrace();
			//System.Diagnostics.Debug.WriteLine($"StackTrace: {Environment.StackTrace}");
		}
    }
}
