using FTN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Xml;

namespace Client.ViewModel
{

    public class PropertyModel
    {
        private bool isSelected = false;

        private string name;

        private ModelCode modelCode;
        private ModelCode m;

        public PropertyModel(ModelCode m)
        {
            this.modelCode = m;
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public ModelCode ModelCode
        {
            get
            {
                return modelCode;
            }

             set
            {
                modelCode = value;
            }
        }
    }

    public class GetValuesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ModelResourcesDesc modelResurcesDesc = null;
        private DMSType type;
        public GetValuesViewModel()
        {
            modelResurcesDesc = new ModelResourcesDesc();
        }


        public DMSType Type
        {
            get { return type; }
            set { this.type = value; OnPropertyChanged("Type"); OnPropertyChanged("Properties"); ; OnPropertyChanged("GIDs"); }
        }
        public ObservableCollection<PropertyModel> Properties
        {
            get { return type == 0 ? new ObservableCollection<PropertyModel>() : CreatePropertyModel(modelResurcesDesc.GetAllPropertyIds(type)); }
            set { this.Properties = value; OnPropertyChanged("Properties"); }
        }

        public ObservableCollection<long> GIDs
        {
            get { return type == 0 ? new ObservableCollection<long>() : GetGIDs(type); }
            set { this.GIDs = value; OnPropertyChanged("GIDs"); }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        ObservableCollection<PropertyModel> CreatePropertyModel(List<ModelCode> mc)
        {
            ObservableCollection<PropertyModel> retVal = new ObservableCollection<PropertyModel>();
            foreach(ModelCode m in mc)
            {
                retVal.Add(new PropertyModel(m));
            }
            return retVal;
        }

        ObservableCollection<long> GetGIDs(DMSType modelCode)
        {
            string message = "Getting extent values method started.";
            Console.WriteLine(message);
            CommonTrace.WriteTrace(CommonTrace.TraceError, message);

            int iteratorId = 0;
            List<long> ids = new List<long>();

            try
            {
                int numberOfResources = 2;
                int resourcesLeft = 0;

                List<ModelCode> properties = modelResurcesDesc.GetAllPropertyIds(modelCode);

                iteratorId = Connection.Connection.Instance().Proxy.GetExtentValues(modelResurcesDesc.GetModelCodeFromType(modelCode), properties);
                resourcesLeft = Connection.Connection.Instance().Proxy.IteratorResourcesLeft(iteratorId);

                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = Connection.Connection.Instance().Proxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        ids.Add(rds[i].Id);
                    }

                    resourcesLeft = Connection.Connection.Instance().Proxy.IteratorResourcesLeft(iteratorId);
                }

                Connection.Connection.Instance().Proxy.IteratorClose(iteratorId);

                message = "Getting extent values method successfully finished.";
                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);

            }
            catch (Exception e)
            {
                message = string.Format("Getting extent values method failed for {0}.\n\t{1}", modelCode, e.Message);
                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            }



           ObservableCollection<long> gids = new ObservableCollection<long>(ids);       
            
           return gids;
        }


    }
}
