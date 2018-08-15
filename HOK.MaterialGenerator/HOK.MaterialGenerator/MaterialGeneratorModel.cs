using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Visual;

namespace HOK.MaterialGenerator
{
    public class MaterialGeneratorModel
    {
        private Document Doc { get; set; }

        public MaterialGeneratorModel(Document doc)
        {
            Doc = doc;
            GetAllMaterials();
        }

        private void GetAllMaterials()
        {
            var mats = Doc.Application.GetAssets(AssetType.Appearance);
        }
    }
}
