using nanoFramework.Presentation;
using nanoFramework.UI.Input;
using nanoFramework.UI;
using nanoFramework.M5Stack;
using System.Threading;

namespace M5App
{
    public class PresentationWindow : Window
    {
        protected App App { get; set; }

        public PresentationWindow(App app)
        {
            App = app;

            Visibility = Visibility.Visible;
            Width = DisplayControl.ScreenWidth;
            Height = DisplayControl.ScreenHeight;
        }

        protected override void OnTouchUp(TouchEventArgs e)
        {
            base.OnTouchUp(e);
            M5Core2.Vibrate = true;
            Thread.Sleep(500);
            M5Core2.Vibrate = false;
        }

        protected override void OnButtonUp(ButtonEventArgs e)
        {
            base.OnButtonUp(e);
            M5Core2.Vibrate = true;
            Thread.Sleep(500);
            M5Core2.Vibrate = false;
        }
    }
}
