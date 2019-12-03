using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revit_steel_connections
{
    public static class ConnectionsManager
    {
        public static void PlaceConnection(Document doc)
        {
            StructuralConnectionHandlerType connectionType = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructConnections)
                .WhereElementIsElementType()
                .Where(e => e.Name == "Base plate")
                .Cast<StructuralConnectionHandlerType>()
                .FirstOrDefault();

            FamilyInstance column = new FilteredElementCollector(doc)
               .OfCategory(BuiltInCategory.OST_StructuralColumns)
               .WhereElementIsNotElementType()
               .Cast<FamilyInstance>()
               .FirstOrDefault();

            if (column == null || connectionType == null) return;

            var connection = StructuralConnectionHandler.Create(doc, new List<ElementId>() { column.Id }, connectionType.Id);
        }

        public static void PlaceCustomConnection(Document doc)
        {
            StructuralConnectionHandlerType connectionType = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructConnections)
                .WhereElementIsElementType()
                .Where(e => e.Name == "Base Plate - Custom")
                .Cast<StructuralConnectionHandlerType>()
                .FirstOrDefault();

            FamilyInstance column = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns)
                .WhereElementIsNotElementType()
                .Cast<FamilyInstance>()
                .FirstOrDefault();

            if (column == null || connectionType == null) return;

            var connection = StructuralConnectionHandler.Create(doc, new List<ElementId>() { column.Id }, connectionType.Id);
        }
    }
}
