using GalaSoft.MvvmLight;

namespace HOK.MaterialGenerator
{
    public class MaterialGeneratorViewModel : ViewModelBase
    {
        public MaterialGeneratorModel Model { get; set; }

        public MaterialGeneratorViewModel(MaterialGeneratorModel model)
        {
            Model = model;
        }
    }
}
