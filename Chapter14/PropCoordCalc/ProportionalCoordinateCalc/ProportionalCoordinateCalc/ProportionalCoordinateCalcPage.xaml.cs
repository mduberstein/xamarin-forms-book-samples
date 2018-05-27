using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace ProportionalCoordinateCalc
{
    public partial class ProportionalCoordinateCalcPage : ContentPage
    { 
		int countAbsLayoutSizeChanged = 0;
        int countContentViewSizeChanged = 0;
        int countPageSizeChanged = 0;

        public ProportionalCoordinateCalcPage()
        {
            InitializeComponent();

            Rectangle[] fractionalRects = 
            {
                new Rectangle(0.05, 0.1, 0.90, 0.1),    // outer top
                new Rectangle(0.05, 0.8, 0.90, 0.1),    // outer bottom
                new Rectangle(0.05, 0.1, 0.05, 0.8),    // outer left
                new Rectangle(0.90, 0.1, 0.05, 0.8),    // outer right

                new Rectangle(0.15, 0.3, 0.70, 0.1),    // inner top
                new Rectangle(0.15, 0.6, 0.70, 0.1),    // inner bottom
                new Rectangle(0.15, 0.3, 0.05, 0.4),    // inner left
                new Rectangle(0.80, 0.3, 0.05, 0.4),    // inner right
            };

            foreach (Rectangle fractionalRect in fractionalRects)
            {
                Rectangle layoutBounds = new Rectangle
                {
                    // Proportional coordinate calculations.
                    X = fractionalRect.X / (1 - fractionalRect.Width),
                    Y = fractionalRect.Y / (1 - fractionalRect.Height),

                    Width = fractionalRect.Width,
                    Height = fractionalRect.Height
                };

                absoluteLayout.Children.Add(
                    new BoxView
                    {
                        Color = Color.Blue
                    },
                    layoutBounds,
                    AbsoluteLayoutFlags.All);
            }
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



            // Figure has an aspect ratio of 2:1
            double height = Math.Min(contentView.Width / 2, contentView.Height);
            absoluteLayout.WidthRequest = 2 * height;
            absoluteLayout.HeightRequest = height;
        }

		void OnPageSizeChanged(object sender, EventArgs eventArgs)
        {
            var page = (ProportionalCoordinateCalcPage)sender;
            Debug.WriteLine($"In {nameof(OnPageSizeChanged)}: count={countPageSizeChanged++}, X={page.X}, Y={page.Y}," +
                                               $" Width={page.Width}, Height={page.Height}");
            //var callStack = new System.Diagnostics.Debug.StackTrace();
            //System.Diagnostics.Debug.WriteLine($"StackTrace: {Environment.StackTrace}");
        }
    }
}