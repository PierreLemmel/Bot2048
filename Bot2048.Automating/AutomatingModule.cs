using Ninject.Modules;

namespace Bot2048.Automating
{
    public class AutomatingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWebDriverFactory>().To<WebDriverFactory>();
        }
    }
}
