using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JustNotes
{
    public partial class JustNotesPage : ContentPage
    {
        public JustNotesPage()
        {
            InitializeComponent();

            // Retrieve last saved Editor text.
            IDictionary<string, object> properties = Application.Current.Properties;

            if (properties.ContainsKey("text"))
            {
                editor.Text = (string)properties["text"];
            }
        }

        void OnEditorFocused(object sender, FocusEventArgs args)
        {
			var currentEditor = (Editor)sender;
			bool isEditorCurrent = currentEditor.Equals(editor);
			double currentEditorHeight = 0.1;
			double theOtherEditorHeight = 0.2 - currentEditorHeight;

			double editorHeight = isEditorCurrent ? currentEditorHeight : theOtherEditorHeight;
			double editor1Height = 0.2 - editorHeight;
            if (Device.RuntimePlatform == Device.iOS)
            {
                //AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 0.5));
				AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, editorHeight));
				AbsoluteLayout.SetLayoutBounds(editor1, new Rectangle(0, editorHeight, 1, editor1Height));
            }
        }

        void OnEditorUnfocused(object sender, FocusEventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                //AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 1));
				AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, .5));
				AbsoluteLayout.SetLayoutBounds(editor1, new Rectangle(0, .5, 1, .5));
            }
        }

        public void OnSleep()
        {
            // Save Editor text.
            Application.Current.Properties["text"] = editor.Text;
        }
    }
}
