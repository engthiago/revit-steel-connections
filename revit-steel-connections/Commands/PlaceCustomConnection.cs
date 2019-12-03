using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revit_steel_connections.Commands
{
    [Transaction(TransactionMode.Manual)]
    class PlaceCustomConnection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            using (Transaction t = new Transaction(doc, "Place connection"))
            {
                t.Start();

                ConnectionsManager.PlaceCustomConnection(doc);

                t.Commit();
            }

            return Result.Succeeded;
        }
    }
}
