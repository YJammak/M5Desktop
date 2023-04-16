using M5App;
using nanoFramework.M5Core2;
using nanoFramework.M5Stack;
using System.Threading;

M5Core2.InitializeScreen(1 * 1024 * 1024);

Vibrate(500);

M5Core2.TouchEvent += TouchEventCallback;

var app = new App();
app.Run(new MainWindow(app));
Thread.Sleep(Timeout.Infinite);

void Vibrate(int milliseconds)
{
    M5Core2.Vibrate = true;
    Thread.Sleep(milliseconds);
    M5Core2.Vibrate = false;
}

void TouchEventCallback(object sender, nanoFramework.M5Core2.TouchEventArgs e)
{
    if ((e.TouchEventCategory & TouchEventCategory.LeftButton) == TouchEventCategory.LeftButton)
    {
        var target = Screen.BrightnessPercentage - 10;
        if (target < 0)
        {
            target = 0;
            Screen.Enabled = false;
        }
        Screen.BrightnessPercentage = (byte)target;
        Vibrate(200);
    }

    if ((e.TouchEventCategory & TouchEventCategory.MiddleButton) == TouchEventCategory.MiddleButton)
    {
        Vibrate(500);
    }

    if ((e.TouchEventCategory & TouchEventCategory.RightButton) == TouchEventCategory.RightButton)
    {
        var target = Screen.BrightnessPercentage + 10;
        if (target > 100)
            target = 100;
        Screen.BrightnessPercentage = (byte)target;
        Screen.Enabled = true;
        Vibrate(200);
    }
}

