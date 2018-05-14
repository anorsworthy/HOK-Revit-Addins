using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using HOK.Core.Utilities;

namespace HOK.MissionControl.Tools.DTMTool
{
    public static class DtmViewTemplateOverrides
    {
        /// <summary>
        /// Creates an idling task that will bind our own edit View Template command to existing one.
        /// </summary>
        public static void CreateViewTemplatesOverride()
        {
            AppCommand.EnqueueTask(app =>
            {
                try
                {
                    var commandId = RevitCommandId.LookupCommandId("ID_SETTINGS_VIEWTEMPLATES");
                    var commandId2 = RevitCommandId.LookupCommandId("ID_APPLY_VIEW_TEMPLATE");
                    if (commandId == null || commandId2 == null|| !commandId.CanHaveBinding) return;

                    var binding = app.CreateAddInCommandBinding(commandId);
                    var binding2 = app.CreateAddInCommandBinding(commandId2);
                    binding.Executed += OnEditViewTemplate;
                    binding2.Executed += OnApplyViewTemplate;
                }
                catch (Exception e)
                {
                    Log.AppendLog(LogMessageType.EXCEPTION, e.Message);
                }
            });
        }

        private static void OnApplyViewTemplate(object sender, ExecutedEventArgs e)
        {
            var some = "";
        }

        private static void OnEditViewTemplate(object sender, ExecutedEventArgs args)
        {
            AppCommand.EnqueueTask(app =>
            {
                try
                {
                    var doc = app.ActiveUIDocument.Document;
                    var info = new ReportingElementInfo(); //TODO: Might have to fill this out.
                    var dtmViewModel = new DTMViewModel(doc, info);
                    var dtmWindow = new DTMWindow
                    {
                        DataContext = dtmViewModel
                    };
                    var showDialog = dtmWindow.ShowDialog();
                    if (showDialog != null && (bool)showDialog)
                    {
                        //
                    }
                }
                catch (Exception e)
                {
                    Log.AppendLog(LogMessageType.EXCEPTION, e.Message);
                }
            });
        }
    }
}
