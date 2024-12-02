using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject
{
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            AddButtons(application);
            return Result.Succeeded;
        }

        public void AddButtons(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "Example";
            try
            {
                application.CreateRibbonTab(tabName);
            }
            catch (Autodesk.Revit.Exceptions.ArgumentException)
            {
            }

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Test");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            // create push button for Assign Run Id
            PushButtonData testData = new PushButtonData(
                "Test",
                "Test",
                thisAssemblyPath,
                "ExampleProject.TestCommand");

            PushButton testB = ribbonPanel.AddItem(testData) as PushButton;
            testB.ToolTip = "";
        }
    }
}
