using Autodesk.Revit.DB;
using System.ComponentModel;

namespace HOK.MissionControl.Tools.DTMTool
{
    public class ReportingElementInfo : INotifyPropertyChanged
    {
        public ReportingElementInfo()
        {
        }

        public ReportingElementInfo(string cId, string uId, string path, string catName, string message, ElementId eId, string uniqueId)
        {
            _configId = cId;
            _updaterId = uId;
            _centralPath = path;
            _categoryName = catName;
            _description = message;
            _reportingElementId = eId;
            ReportingUniqueId = uniqueId;
        }

        private string _configId = string.Empty;
        public string ConfigId
        {
            get { return _configId; }
            set { _configId = value; NotifyPropertyChanged("ConfigId"); }
        }

        private string _updaterId = string.Empty;
        public string UpdaterId
        {
            get { return _updaterId; }
            set { _updaterId = value; NotifyPropertyChanged("UpdaterId"); }
        }

        private string _centralPath = string.Empty;
        public string CentralPath
        {
            get { return _centralPath; }
            set { _centralPath = value; NotifyPropertyChanged("CentralPath"); }
        }

        private string _categoryName = string.Empty;
        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; NotifyPropertyChanged("CategoryName"); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyPropertyChanged("Description"); }
        }

        private ElementId _reportingElementId = ElementId.InvalidElementId;
        public ElementId ReportingElementId
        {
            get { return _reportingElementId; }
            set { _reportingElementId = value; NotifyPropertyChanged("ReportingElementId"); }
        }

        private string _reportingUniqueId = string.Empty;
        public string ReportingUniqueId
        {
            get { return _reportingUniqueId; }
            set { _reportingUniqueId = value; NotifyPropertyChanged("ReportingUniqueId"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
