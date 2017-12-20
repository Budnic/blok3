namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
    using System;
    using FTN.Common;

    /// <summary>
    /// PowerTransformerConverter has methods for populating
    /// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
    /// </summary>
    public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
				if (cimIdentifiedObject.NameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
				}
                if (cimIdentifiedObject.AliasNameHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IDOBJ_ALIASNAME, cimIdentifiedObject.Name));
                }
            }
		}

        public static void PopulateAssetFunctionProperties(FTN.AssetFunction cimAssetFunction, ResourceDescription rd)
        {
            if ((cimAssetFunction != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimAssetFunction, rd);

                if (cimAssetFunction.ConfigIDHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSETFUNCTION_CONFIGID, cimAssetFunction.ConfigID));
                }
                if (cimAssetFunction.FirmwareIDHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSETFUNCTION_FIRMWAREID, cimAssetFunction.FirmwareID));
                }
                if (cimAssetFunction.HardwareIDHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSETFUNCTION_HARDWAREID, cimAssetFunction.HardwareID));
                }
                if (cimAssetFunction.PasswordHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSETFUNCTION_PASSWORD, cimAssetFunction.Password));
                }
                if (cimAssetFunction.ProgramIDHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSETFUNCTION_PROGRAMID, cimAssetFunction.ProgramID));
                }
            }

        }

        public static void PopulateSealProperties(Seal cimSeal, ResourceDescription rd)
        {
            if ((cimSeal != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimSeal, rd);

                if (cimSeal.AppliedDateTimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SEAL_APPLIEDTIME, cimSeal.AppliedDateTime));
                }
                if (cimSeal.ConditionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SEAL_CONDITION, (short)cimSeal.Condition));
                }
                if (cimSeal.KindHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SEAL_KIND, (short)cimSeal.Kind));
                }
                if (cimSeal.SealNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SEAL_SEALNUMBER, cimSeal.SealNumber));
                }
            }
        }


        public static void PopulateManufacturerProperties(Manufacturer cimManufacturer, ResourceDescription rd)
        {
            if ((cimManufacturer != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateOrganisationRoleProperties(cimManufacturer, rd);
            }
        }

        public static void PopulateOrganisationRoleProperties(OrganisationRole cimOrganisationRole, ResourceDescription rd)
        {
            if ((cimOrganisationRole != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimOrganisationRole, rd);
            }
        }

        public static void PopulateProductAssetModelProperties(ProductAssetModel cimProductAssetModel, ResourceDescription rd)
        {
            if ((cimProductAssetModel != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateAssetModelProperties(cimProductAssetModel ,  rd);

                if (cimProductAssetModel.CorporateStandardKindHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PRODUCTASSETMODEL_CSTANDARDKIND, (short)cimProductAssetModel.CorporateStandardKind));
                }

                if (cimProductAssetModel.ModelNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PRODUCTASSETMODEL_MODELNUMBER, cimProductAssetModel.ModelNumber));
                }

                if (cimProductAssetModel.ModelVersionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PRODUCTASSETMODEL_MODELVERSION , cimProductAssetModel.ModelVersion));
                }
                if (cimProductAssetModel.UsageKindHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PRODUCTASSETMODEL_USAGEKIND, (short)cimProductAssetModel.UsageKind));
                }
                if (cimProductAssetModel.WeightTotalHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.PRODUCTASSETMODEL_WEIGHTTOTAL, cimProductAssetModel.WeightTotal));
                }
            }
        }

        public static void PopulateAssetProperties(Asset cimAssset, ResourceDescription rd)
        {
            if ((cimAssset != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimAssset, rd);

                if (cimAssset.CriticalHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_CRITICAL, cimAssset.Critical));
                }
                if (cimAssset.InitialConditionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_INITIALCONDITION, cimAssset.InitialCondition));
                }
                if (cimAssset.InitialLossOfLifeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_INITIALLOSSOFLIFE, cimAssset.InitialLossOfLife));
                }
                if (cimAssset.LotNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_LOTNUMBER, cimAssset.LotNumber));
                }
                if (cimAssset.PurchasePriceHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_PURCHASEPRICE, cimAssset.PurchasePrice));
                }
                if (cimAssset.SerialNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_SERIALNUMBER, cimAssset.SerialNumber));
                }
                if (cimAssset.TypeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_TYPE, cimAssset.Type));
                }
                if (cimAssset.UtcNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.ASSET_UTCNUMBER, cimAssset.UtcNumber));
                }
            }
        }

        public static void PopulateAssetOwnerProperties(AssetOwner cimAssetOwner, ResourceDescription rd)
        {
            if ((cimAssetOwner != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateAssetOrganisationRole(cimAssetOwner, rd);
            }
        }

        private static void PopulateAssetOrganisationRole(AssetOrganisationRole cimAssetOrganisationRole, ResourceDescription rd)
        {
            if ((cimAssetOrganisationRole != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimAssetOrganisationRole, rd);
            }
        }

        public static void PopulateAssetInfoProperties(AssetInfo cimAssetInfo, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimAssetInfo != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimAssetInfo, rd);
                
                if(cimAssetInfo.AssetModelHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimAssetInfo.AssetModel.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimAssetInfo.GetType().ToString()).Append(" rdfID = \"").Append(cimAssetInfo.ID);
                        report.Report.Append("\" - Failed to set reference to AssetModel: rdfID \"").Append(cimAssetInfo.AssetModel.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.ASSETINFO_ASSETMODEL, gid));
                }
            }
        }

        public static void PopulateAssetModelProperties(AssetModel cimAssetModel, ResourceDescription rd)
        {
            if ((cimAssetModel != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimAssetModel, rd);
            }
        }

        #endregion Populate ResourceDescription

        #region Enums convert

        public static SealConditionKind GetDMSSealConditionKind(FTN.SealConditionKind conditionKinds)
        {
            switch(conditionKinds)
            {
                case FTN.SealConditionKind.broken:
                    return SealConditionKind.Broken;
                case FTN.SealConditionKind.locked:
                    return SealConditionKind.Locked;
                case FTN.SealConditionKind.missing:
                    return SealConditionKind.Missing;
                case FTN.SealConditionKind.open:
                    return SealConditionKind.Open;
                default:
                    return SealConditionKind.Other;
            }
        }

        public static SealKind GetDMSSealKind(FTN.SealKind sealKinds)
        {
            switch(sealKinds)
            {
                case FTN.SealKind.lead:
                    return SealKind.Lead;
                case FTN.SealKind.@lock:
                    return SealKind.Lock;
                case FTN.SealKind.steel:
                    return SealKind.Steel;
                default:
                    return SealKind.Other;
            }
        }

        public static CorporateStandardKind GetDMSCorporateStandardKind(FTN.CorporateStandardKind standardKinds)
        {
            switch(standardKinds)
            {
                case FTN.CorporateStandardKind.experimental:
                    return CorporateStandardKind.Experimental;
                case FTN.CorporateStandardKind.standard:
                    return CorporateStandardKind.Standard;
                case FTN.CorporateStandardKind.underEvaluation:
                    return CorporateStandardKind.UnderEvaluation;
                default:
                    return CorporateStandardKind.Other;
            }
        }

        public static AssetModelUsageKind GetDMSAssetModelUsageKind(FTN.AssetModelUsageKind usageKinds)
        {
            switch(usageKinds)
            {
                case FTN.AssetModelUsageKind.customerSubstation:
                    return AssetModelUsageKind.CustomerSubstation;
                case FTN.AssetModelUsageKind.distributionOverhead:
                    return AssetModelUsageKind.DistributionOverhead;
                case FTN.AssetModelUsageKind.distributionUnderground:
                    return AssetModelUsageKind.DistributionUnderground;
                case FTN.AssetModelUsageKind.other:
                    return AssetModelUsageKind.Other;
                case FTN.AssetModelUsageKind.streetlight:
                    return AssetModelUsageKind.Streetlight;
                case FTN.AssetModelUsageKind.substation:
                    return AssetModelUsageKind.Substation;
                case FTN.AssetModelUsageKind.transmission:
                    return AssetModelUsageKind.Transmission;
                default:
                    return AssetModelUsageKind.Unknown;
            }
        }
  //      public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
		//{
		//	switch (phases)
		//	{
		//		case FTN.PhaseCode.A:
		//			return PhaseCode.A;
		//		case FTN.PhaseCode.AB:
		//			return PhaseCode.AB;
		//		case FTN.PhaseCode.ABC:
		//			return PhaseCode.ABC;
		//		case FTN.PhaseCode.ABCN:
		//			return PhaseCode.ABCN;
		//		case FTN.PhaseCode.ABN:
		//			return PhaseCode.ABN;
		//		case FTN.PhaseCode.AC:
		//			return PhaseCode.AC;
		//		case FTN.PhaseCode.ACN:
		//			return PhaseCode.ACN;
		//		case FTN.PhaseCode.AN:
		//			return PhaseCode.AN;
		//		case FTN.PhaseCode.B:
		//			return PhaseCode.B;
		//		case FTN.PhaseCode.BC:
		//			return PhaseCode.BC;
		//		case FTN.PhaseCode.BCN:
		//			return PhaseCode.BCN;
		//		case FTN.PhaseCode.BN:
		//			return PhaseCode.BN;
		//		case FTN.PhaseCode.C:
		//			return PhaseCode.C;
		//		case FTN.PhaseCode.CN:
		//			return PhaseCode.CN;
		//		case FTN.PhaseCode.N:
		//			return PhaseCode.N;
		//		case FTN.PhaseCode.s12N:
		//			return PhaseCode.ABN;
		//		case FTN.PhaseCode.s1N:
		//			return PhaseCode.AN;
		//		case FTN.PhaseCode.s2N:
		//			return PhaseCode.BN;
		//		default: return PhaseCode.Unknown;
		//	}
		//}


  //      public static TransformerFunction GetDMSTransformerFunctionKind(FTN.TransformerFunctionKind transformerFunction)
		//{
		//	switch (transformerFunction)
		//	{
		//		case FTN.TransformerFunctionKind.voltageRegulator:
		//			return TransformerFunction.Voltreg;
		//		default:
		//			return TransformerFunction.Consumer;
		//	}
		//}

		//public static WindingType GetDMSWindingType(FTN.WindingType windingType)
		//{
		//	switch (windingType)
		//	{
		//		case FTN.WindingType.primary:
		//			return WindingType.Primary;
		//		case FTN.WindingType.secondary:
		//			return WindingType.Secondary;
		//		case FTN.WindingType.tertiary:
		//			return WindingType.Tertiary;
		//		default:
		//			return WindingType.None;
		//	}
		//}

		//public static WindingConnection GetDMSWindingConnection(FTN.WindingConnection windingConnection)
		//{
		//	switch (windingConnection)
		//	{
		//		case FTN.WindingConnection.D:
		//			return WindingConnection.D;
		//		case FTN.WindingConnection.I:
		//			return WindingConnection.I;
		//		case FTN.WindingConnection.Z:
		//			return WindingConnection.Z;
		//		case FTN.WindingConnection.Y:
		//			return WindingConnection.Y;
		//		default:
		//			return WindingConnection.Y;
		//	}
		//}
		#endregion Enums convert
	}
}
