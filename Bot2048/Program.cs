using Bot2048.Automating;
using Bot2048.Logic;
using Bot2048.Model;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Bot2048
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                Print("2048 bot launched!");
                Print("Ready to beat high scores!");

                IKernel container = BuildContainer();

                IAutomatingControler controler = container.Get<IAutomatingControler>();
                await controler.OpenWebPage();

                IDecisionMaker decisionMaker = container.Get<IDecisionMaker>();
                IGridUpdater gridUpdater = container.Get<IGridUpdater>();

                while (true)
                {
                    Stopwatch watch = Stopwatch.StartNew();

                    LineBreak();
                    Print("Starting a new game");

                    Grid grid = new Grid();

                    while (!controler.DetectGameOver())
                    {
                        IEnumerable<GridUpdateInput> updateInputs = controler.ReadGridState();
                        gridUpdater.UpdateGrid(grid, updateInputs);

                        Direction nextDirection = decisionMaker.ChoseDirection(grid);
                        Print($"Moving {nextDirection}");
                        await controler.NextStep(nextDirection);

                        watch.Stop();
                    }

                    long duration = watch.ElapsedMilliseconds;
                    int score = controler.ReadScore();

                    Print($"Game finished in {duration}");
                    Print($"Score: {score}");

                    await controler.Replay();
                }
            }
            catch (Exception ex)
            {
                PrintError(ex);
                ExitOnClick();
            }
        }

        private static void Print(string message)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss} - {message}");
        }

        private static void PrintError(Exception ex)
        {
            LineBreak();
            Console.ForegroundColor = ConsoleColor.Red;
            Print(ex.Message);
            Print(ex.StackTrace);
            Console.ResetColor();
            LineBreak();
        }

        private static void LineBreak()
        {
            Console.WriteLine();
        }

        private static void ExitOnClick()
        {
            Print("Press any key to exit...");
            Console.Read();
            Environment.Exit(-1);
        }

        private static IKernel BuildContainer()
        {
            INinjectModule[] modules = new INinjectModule[]
            {
                new AutomatingModule(),
                new LogicModule(),
                new ConfigurationModule()
            };

            IKernel container = new StandardKernel(modules);

            return container;
        }
    }
}