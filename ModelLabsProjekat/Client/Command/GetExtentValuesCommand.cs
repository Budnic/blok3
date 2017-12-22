using Client.Model;
using Client.ViewModel;
using FTN.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Client.Command
{
    public class GetExtentValuesCommand : Command
    {

        private GetExtentValuesViewModel viewModel;
        public GetExtentValuesCommand(GetExtentValuesViewModel vm)
        {
            viewModel = vm;
        }
        public override void Execute(object parameter)
        {
            if (parameter == null || !(parameter is Object[]))
            {
                return;
            }

            Object[] parameters = parameter as Object[];

            if (parameters == null || parameters[0] == null || parameters[1] == null)
            {
                return;
            }

            List<ModelCode> properties = new List<ModelCode>();
            System.Collections.IList i = (System.Collections.IList)parameters[1];
            var propertyModels = i.Cast<PropertyModel>();
            ModelCode modelCode;
           if(!ModelCodeHelper.GetModelCodeFromString(parameters[0].ToString(), out modelCode))
            {
                return;
            }

            foreach (var propertyModel in propertyModels)
            {
                properties.Add(propertyModel.ModelCode);
            }

            List<ResourceDescription> resourceDescritions = GetExtentValues(modelCode , properties);

            List<PropertyView> propertyViews = new List<PropertyView>();

            foreach (ResourceDescription rd in resourceDescritions)
            {
                string gidString = String.Format("GID: 0x{0:x16}", rd.Id);
                propertyViews.Add(new PropertyView(modelCode, gidString));
                foreach(Property p  in rd.Properties)
                {
                    propertyViews.Add(new PropertyView(p.Id, p.ToString()));
                }
            }
            viewModel.ObjectValue = new ObservableCollection<PropertyView>(propertyViews); //
        }

        public List<ResourceDescription> GetExtentValues(ModelCode modelCode , List<ModelCode> properties)
        {
          

           
            int iteratorId = 0;
            List<ResourceDescription>  resourceDescriptions = new List<ResourceDescription>();

            try
            {
                int numberOfResources = 2;
                int resourcesLeft = 0;
                

                iteratorId = Connection.Connection.Instance().Proxy.GetExtentValues(modelCode, properties);
                resourcesLeft = Connection.Connection.Instance().Proxy.IteratorResourcesLeft(iteratorId);
                             
                while (resourcesLeft > 0)
                {
                    List<ResourceDescription> rds = Connection.Connection.Instance().Proxy.IteratorNext(numberOfResources, iteratorId);

                    for (int i = 0; i < rds.Count; i++)
                    {
                        resourceDescriptions.Add(rds[i]);
                    }

                    resourcesLeft = Connection.Connection.Instance().Proxy.IteratorResourcesLeft(iteratorId);
                }

                Connection.Connection.Instance().Proxy.IteratorClose(iteratorId);

            }
            catch
            {
                return null;
            }
           

            return resourceDescriptions;
        }
    }
}
