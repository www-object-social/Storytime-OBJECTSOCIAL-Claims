namespace OBJECTSOCIALMAUIClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
            {
#if WINDOWS
                OnlyForMAUIClient.Platforms.Frame.Settings(handler);
#endif

            });
        }
    }
}