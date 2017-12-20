﻿using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Assets
{
    public class Asset : IdentifiedObject
    {
        public Asset(long globalId) : base(globalId)
        {
        }

        private bool cricital;
        private string initialCondition;
        private float initialLossOfLife;
        private string lotNumber;
        private float purchasePrice;
        private string serialNumber;
        private string type;
        private string utcNumber;
        private long assetOrganisationRole = 0;
        private long assetInfo = 0;
        public bool Cricital
        {
            get
            {
                return cricital;
            }

            set
            {
                cricital = value;
            }
        }

        public string InitialCondition
        {
            get
            {
                return initialCondition;
            }

            set
            {
                initialCondition = value;
            }
        }

        public float InitialLossOfLife
        {
            get
            {
                return initialLossOfLife;
            }

            set
            {
                initialLossOfLife = value;
            }
        }

        public string LotNumber
        {
            get
            {
                return lotNumber;
            }

            set
            {
                lotNumber = value;
            }
        }

        public float PurchasePrice
        {
            get
            {
                return purchasePrice;
            }

            set
            {
                purchasePrice = value;
            }
        }

        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }

            set
            {
                serialNumber = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string UtcNumber
        {
            get
            {
                return utcNumber;
            }

            set
            {
                utcNumber = value;
            }
        }

        public long AssetOrganisationRole
        {
            get
            {
                return assetOrganisationRole;
            }

            set
            {
                assetOrganisationRole = value;
            }
        }

        public long AssetInfo
        {
            get
            {
                return assetInfo;
            }

            set
            {
                assetInfo = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Asset x = (Asset)obj;
                return (
                    (x.cricital == this.cricital) && (x.initialCondition == this.initialCondition) && (x.initialLossOfLife == this.initialLossOfLife) && (x.lotNumber == this.lotNumber) && (x.purchasePrice == this.purchasePrice) && (x.serialNumber == this.serialNumber) && (x.type == this.type) && (x.utcNumber == this.utcNumber) && x.assetOrganisationRole== this.assetOrganisationRole) && (x.assetInfo == this.assetInfo);
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
                case ModelCode.ASSET_CRITICAL:
                    return true;
                case ModelCode.ASSET_INITIALCONDITION:
                    return true;
                case ModelCode.ASSET_INITIALLOSSOFLIFE:
                    return true;
                case ModelCode.ASSET_LOTNUMBER:
                    return true;
                case ModelCode.ASSET_ORGANISATIONROLE:
                    return true;
                case ModelCode.ASSET_PURCHASEPRICE:
                    return true;
                case ModelCode.ASSET_SERIALNUMBER:
                    return true;
                case ModelCode.ASSET_TYPE:
                    return true;
                case ModelCode.ASSET_UTCNUMBER:
                    return true;
                case ModelCode.ASSET_ASSETINFO:
                    return true;

                default:
                    return base.HasProperty(t);

            }
        }
        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.ASSET_CRITICAL:
                    prop.SetValue(cricital);
                    break;
                case ModelCode.ASSET_INITIALCONDITION:
                    prop.SetValue(initialCondition);
                    break;
                case ModelCode.ASSET_INITIALLOSSOFLIFE:
                    prop.SetValue(initialLossOfLife);
                    break;
                case ModelCode.ASSET_LOTNUMBER:
                    prop.SetValue(lotNumber);
                    break;
                case ModelCode.ASSET_ORGANISATIONROLE:
                    prop.SetValue(assetOrganisationRole);
                    break;
                case ModelCode.ASSET_PURCHASEPRICE:
                    prop.SetValue(purchasePrice);
                    break;
                case ModelCode.ASSET_SERIALNUMBER:
                    prop.SetValue(serialNumber);
                    break;
                case ModelCode.ASSET_TYPE:
                    prop.SetValue(type);
                    break;
                case ModelCode.ASSET_UTCNUMBER:
                    prop.SetValue(utcNumber);
                    break;
                case ModelCode.ASSET_ASSETINFO:
                    prop.SetValue(assetInfo);
                    break;

                default:
                    base.GetProperty(prop);
                    break;

            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.ASSET_CRITICAL:
                    cricital = property.AsBool();
                    break;
                case ModelCode.ASSET_INITIALCONDITION:
                    initialCondition = property.AsString();
                    break;
                case ModelCode.ASSET_INITIALLOSSOFLIFE:
                    initialLossOfLife = property.AsFloat();
                    break;
                case ModelCode.ASSET_LOTNUMBER:
                    lotNumber = property.AsString();
                    break;
                case ModelCode.ASSET_ORGANISATIONROLE:
                    assetOrganisationRole = property.AsReference();
                    break;
                case ModelCode.ASSET_PURCHASEPRICE:
                    purchasePrice = property.AsFloat();
                    break;
                case ModelCode.ASSET_SERIALNUMBER:
                    serialNumber = property.AsString();
                    break;
                case ModelCode.ASSET_TYPE:
                    type = property.AsString();
                    break;
                case ModelCode.ASSET_UTCNUMBER:
                    utcNumber = property.AsString();
                    break;
                case ModelCode.ASSET_ASSETINFO:
                    assetInfo = property.AsReference();
                    break;
                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {

            if (assetInfo != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.ASSETINFO_ASSETMODEL] = new List<long>();
                references[ModelCode.ASSETINFO_ASSETMODEL].Add(assetInfo);
            }
            if (assetOrganisationRole != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.ASSETINFO_ASSETMODEL] = new List<long>();
                references[ModelCode.ASSETINFO_ASSETMODEL].Add(assetOrganisationRole);
            }
            base.GetReferences(references, refType);
        }

        #endregion IReference implementation	

    }
}