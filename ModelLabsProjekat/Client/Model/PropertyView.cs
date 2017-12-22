using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.Model
{
    public class PropertyView 
    {
        ModelCode modelCode;
        string value;

        public PropertyView(ModelCode modelCode , string value)
        {
            this.modelCode = modelCode;
            this.value = value;

        }

        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
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
}
