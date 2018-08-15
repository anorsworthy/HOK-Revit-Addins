using System;
using System.Linq;
using System.Reflection;
using Autodesk.Revit.UI;
using HOK.Core.Utilities;

namespace HOK.MaterialGenerator
{
    [Name(nameof(Properties.Resources.MaterialGenerator_Name), typeof(Properties.Resources))]
    [Description(nameof(Properties.Resources.MaterialGenerator_Description), typeof(Properties.Resources))]
    [Image(nameof(Properties.Resources.MaterialGenerator_ImageName), typeof(Properties.Resources))]
    [PanelName(nameof(Properties.Resources.MaterialGenerator_PanelName), typeof(Properties.Resources))]
    [Namespace(nameof(Properties.Resources.MaterialGenerator_Namespace), typeof(Properties.Resources))]
    [AdditionalButtonNames(nameof(Properties.Resources.MaterialGenerator_AdditionalButtonNames), typeof(Properties.Resources))]
    public class AppCommand : IExternalApplication
    {
        private const string tabName = "  HOK - Beta";
        public static MaterialGeneratorRequestHandlers MaterialGeneratorHandler { get; set; }
        public static ExternalEvent GroupManagerEvent { get; set; }

        public Result OnStartup(UIControlledApplication application)
        {
            var assembly = Assembly.GetAssembly(GetType());
            var panel = application.GetRibbonPanels(tabName).FirstOrDefault(x => x.Name == "Materials")
                        ?? application.CreateRibbonPanel(tabName, "Materials");
            var unused = (PushButton)panel.AddItem(new PushButtonData("MaterialGenerator_Command", "  Material  " + Environment.NewLine + "Generator",
                assembly.Location, "HOK.MaterialGenerator.MaterialGeneratorCommand")
            {
                LargeImage = ButtonUtil.LoadBitmapImage(assembly, "HOK.MaterialGenerator", Properties.Resources.MaterialGenerator_ImageName),
                ToolTip = Properties.Resources.MaterialGenerator_Description
            });

            MaterialGeneratorHandler = new MaterialGeneratorRequestHandlers();
            GroupManagerEvent = ExternalEvent.Create(MaterialGeneratorHandler);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
