using Ninject.Modules;

namespace Bot2048.Automating
{
    public class AutomatingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAutomatingControler>().To<AutomatingControler>();
            Bind<IWebDriverFactory>().To<WebDriverFactory>();
        }
    }
}