using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace ChessboardDynamic
{
    public class ChessboardDynamicPage : ContentPage
    {
        AbsoluteLayout absoluteLayout;
		int countAbsLayoutSizeChanged = 0;
		int countContentViewSizeChanged = 0;
		int countPageSizeChanged = 0;

        public ChessboardDynamicPage()
        {
            absoluteLayout = new AbsoluteLayout
            {
                BackgroundColor = Color.FromRgb(240, 220, 130),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center                              
            };
			absoluteLayout.SizeChanged += OnAbsoluteLayoutSizeChanged;

            for (int i = 0; i < 32; i++)
            {
                BoxView boxView = new BoxView
                {
                    Color = Color.FromRgb(0, 64, 0)
                };
                absoluteLayout.Children.Add(boxView);
            }

            ContentView contentView = new ContentView
            {
                Content = absoluteLayout
            };
            contentView.SizeChanged += OnContentViewSizeChanged;

            Padding = new Thickness(5, Device.RuntimePlatform == Device.iOS ? 25 : 5, 5, 5);
            Content = contentView;
			SizeChanged += OnPageSizeChanged;
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
			System.Diagnostics.Debug.WriteLine($"In {nameof(OnContentViewSizeChanged)}: count={countContentViewSizeChanged++}, X={contentView.X}, Y={contentView.Y}," +
								   $" Width={contentView.Width}, Height={contentView.Height}");
            double squareSize = Math.Min(contentView.Width, contentView.Height) / 8;
            int index = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    // Skip every other square.
                    if (((row ^ col) & 1) == 0)
                        continue;

                    View view = absoluteLayout.Children[index];
                    Rectangle rect = new Rectangle(col * squareSize,
                                                   row * squareSize,
                                                   squareSize, squareSize);

                    AbsoluteLayout.SetLayoutBounds(view, rect);
                    index++;
                }
            }
        }

		void OnPageSizeChanged(object sender, EventArgs eventArgs) {
			var page = (ChessboardDynamicPage)sender;
			Debug.WriteLine($"In {nameof(OnPageSizeChanged)}: count={countPageSizeChanged++}, X={page.X}, Y={page.Y}," +
											   $" Width={page.Width}, Height={page.Height}");
			//var callStack = new System.Diagnostics.Debug.StackTrace();
			//System.Diagnostics.Debug.WriteLine($"StackTrace: {Environment.StackTrace}");
		}
    }
}
