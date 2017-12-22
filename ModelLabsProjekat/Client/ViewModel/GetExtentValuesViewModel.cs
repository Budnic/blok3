using Client.Command;
using Client.Model;
using FTN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Client.ViewModel
{
    public class GetExtentValuesViewModel : AbstractViewModel
    {

        public GetExtentValuesCommand LoadValues{get;set;}
        public GetExtentValuesViewModel()
        {
            this.LoadValues = new GetExtentValuesCommand(this);
        }


        public ObservableCollection<PropertyView> objectValue;
        public DMSType Type
        {
            get { return type; }
            set { this.type = value; OnPropertyChanged("Type"); OnPropertyChanged("Properties");}
        }


        public ObservableCollection<PropertyView> ObjectValue
        {
            get { return objectValue; }
            set { this.objectValue = value; OnPropertyChanged("ObjectValue"); }
        }

    }
}
