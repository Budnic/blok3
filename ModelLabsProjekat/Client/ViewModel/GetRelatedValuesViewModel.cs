using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FTN.ServiceContracts;
using FTN.Common;
using System.Collections.ObjectModel;
using Client.Model;

namespace Client.ViewModel
{
    public class GetRelatedValuesViewModel : AbstractViewModel
    {
        public GetRelatedValuesViewModel(INetworkModelGDAContract proxy) : base(proxy)
        {

        }

        public DMSType Type
        {
            get { return type; }
            set { this.type = value; OnPropertyChanged("Type"); OnPropertyChanged("Properties");  ; OnPropertyChanged("GIDs"); OnPropertyChanged("References"); }
        }


        public ObservableCollection<long> GIDs
        {
            get { return type == 0 ? new ObservableCollection<long>() : GetGIDs(type); }
            set { this.GIDs = value; OnPropertyChanged("GIDs"); }
        }

        public ObservableCollection<ModelCode> References
        {
            get
            {
                return type == 0 ? new ObservableCollection<ModelCode>() : GetReferences();
            }

            set { this.References = value; OnPropertyChanged("References"); }
        }

        private ObservableCollection<ModelCode> GetReferences()
        {
            ObservableCollection<ModelCode> references = new ObservableCollection<ModelCode>();
            foreach (var mc in Properties)
            {
                if (((int)mc.ModelCode & 0x0000000000000009) == 0x0000000000000009)
                {
                    references.Add(mc.ModelCode);
                }
            }
            return references;
        }

        //public ObservableCollection<PropertyView> ObjectValue
        //{
        //    get { return objectValue; }
        //    set { this.objectValue = value; OnPropertyChanged("ObjectValue"); }
        //}
    }
}
