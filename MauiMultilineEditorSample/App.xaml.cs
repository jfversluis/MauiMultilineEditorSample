#if __IOS__
using Microsoft.Maui.Platform;
using UIKit;
#endif

namespace MauiMultilineEditorSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

#if __IOS__
        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("MultilineEditor", (handler, view) =>
        {
            if (view is MultilineEditor)
            {
                var Control = handler.PlatformView;
                handler.PlatformView.TextColor = UIColor.FromRGB(48, 48, 48);
                if (Control.Text == "")
                {
                    Control.Text = view.Placeholder;
                }
                Control.ShouldBeginEditing += (UITextView textView) =>
                {
                    if (textView.Text == view.Placeholder)
                    {
                        textView.Text = "";
                        textView.TextColor = UIColor.FromRGB(48, 48, 48); // Text Color
                    }

                    return true;
                };

                Control.ShouldEndEditing += (UITextView textView) =>
                {
                    if (textView.Text == "")
                    {
                        textView.Text = view.Placeholder;
                        textView.TextColor = UIColor.FromRGB(48, 48, 48); // Placeholder Color
                    }

                    return true;
                };

                Control.Layer.BorderColor = Color.FromArgb("#e5e5e5").ToCGColor();
                Control.Layer.MasksToBounds = true;
                Control.Layer.CornerRadius = 1;
                Control.Layer.BorderWidth = 1f;
                Control.Layer.BorderColor = Color.FromArgb("#999999").ToCGColor();
                Control.Layer.BackgroundColor = Colors.Transparent.ToCGColor();
                Control.SpellCheckingType = UITextSpellCheckingType.No;             // No Spellchecking
                Control.AutocorrectionType = UITextAutocorrectionType.No;           // No Autocorrection
                Control.AutocapitalizationType = UITextAutocapitalizationType.None; // No Autocapitalization
                Control.InputAccessoryView.Hidden = true;//For Removing Done button from editor keyboard.
                Control.KeyboardType = UIKeyboardType.ASCIICapable;//For Removing Emoticons from keyboard.
            }
        });
#endif

        MainPage = new MainPage();
	}
}
