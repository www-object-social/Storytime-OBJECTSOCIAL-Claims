using Foundation;
using UIKit;

namespace OBJECTSOCIALMAUIClient;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    public AppDelegate()
    {

    }
    public override void OnActivated(UIApplication application)
    {
        this.Window.WindowScene.Titlebar.TitleVisibility = UITitlebarTitleVisibility.Hidden;

        base.OnActivated(application);
    }
}