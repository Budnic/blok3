using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Assets
{
    public class AssetModel : IdentifiedObject
    {

        private List<long> assetInfos = new List<long>();
        public AssetModel(long globalId) : base(globalId)
        {
        }

        public List<long> AssetInfos
        {
            get
            {
                return assetInfos;
            }

            set
            {
                assetInfos = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                AssetModel x = (AssetModel)obj;
                return (CompareHelper.CompareLists(x.assetInfos, this.assetInfos));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();

        }

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.ASSETMODEL_ASSETINFOS:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }
        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.ASSETMODEL_ASSETINFOS:
                    prop.SetValue(assetInfos);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return assetInfos.Count > 0 || base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (assetInfos != null && assetInfos.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.ASSETMODEL_ASSETINFOS] = assetInfos.GetRange(0, assetInfos.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.ASSETINFO_ASSETMODEL:
                    assetInfos.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.ASSETINFO_ASSETMODEL:

                    if (assetInfos.Contains(globalId))
                    {
                        assetInfos.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation	
    }

}

