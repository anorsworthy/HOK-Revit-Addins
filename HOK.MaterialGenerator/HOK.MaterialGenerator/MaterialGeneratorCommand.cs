#region References

using System;
using System.Diagnostics;
using System.Windows.Interop;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using HOK.MissionControl.Core.Schemas;
using HOK.MissionControl.Core.Utils;

#endregion

namespace HOK.MaterialGenerator
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    public class MaterialGeneratorCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;

            try
            {
                // (Konrad) We are gathering information about the addin use. This allows us to
                // better maintain the most used plug-ins or discontiue the unused ones.
                var unused1 = AddinUtilities.PublishAddinLog(
                    new AddinLog("Material Generator", commandData.Application.Application.VersionNumber), LogPosted);

                var model = new MaterialGeneratorModel(doc);
                var viewModel = new MaterialGeneratorViewModel(model);
                var view = new MaterialGeneratorView
                {
                    DataContext = viewModel
                };

                var unused = new WindowInteropHelper(view)
                {
                    Owner = Process.GetCurrentProcess().MainWindowHandle
                };

                view.Show();
            }
            catch (Exception e)
            {
            }

            return Result.Succeeded;
        }

        /// <summary>
        /// Callback method for when Addin-info is published.
        /// </summary>
        /// <param name="data"></param>
        private static void LogPosted(AddinData data)
        {
        }
    }
}
