using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleProject
{
    [Transaction(TransactionMode.Manual)]
    public class TestCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                throw new Exception("This is a test error");
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error",ex.Message);
                TaskDialog.Show("Error",ex.StackTrace);
            }
            return Result.Succeeded;
        }
    }
}
