﻿using System;
using Automatica.Core.Base.Templates;
using Automatica.Core.Driver;
using Automatica.Core.EF.Models;
using NodeDataType = Automatica.Core.Base.Templates.NodeDataType;

namespace P3.Driver.Constants
{
    public class ConstantsDriverFactory : DriverFactory
    {

        public static readonly Guid InterfaceId = new Guid("5926638a-e9f8-48cb-8401-c8042170ff1b");

        public static readonly Guid BusId = new Guid("2ba2fdfe-3df0-4986-80c1-d0f695d64fdc");
        public static readonly Guid ValueId = new Guid("d46b8d4d-29e6-45bd-ba62-9463692bcbd7");
        public static readonly Guid PropertyValueId = new Guid("5d5c0c1f-50e2-4946-94c0-842cfc51a478");

        public static readonly Guid PiId = new Guid("36a0da8a-2735-4f83-91ef-9af90262de32");
        public static readonly Guid HalfPiId = new Guid("bde14ed8-24b3-476b-9c8a-751da617a50b");
        public static readonly Guid DoublePiId = new Guid("82e579a7-935e-463b-9d26-c75b31113553");


        public static readonly Guid TrueId = new Guid("98e87e1d-d725-4314-bd6c-805e2d1c4ed9");
        public static readonly Guid FalseId = new Guid("e74e5ae5-8c54-4f3a-aee8-63000de6738f");


        public static readonly Guid StringValueId = new Guid("9d3f1898-288a-48a4-b8a5-8ae3b3876784");
        public static readonly Guid StringPropertyValueId = new Guid("eef0348b-9b68-4998-a126-7a99af1d5aa0");



        public override string DriverName => "consts";
        public override Guid DriverGuid => BusId;

        public override Version DriverVersion => new Version(1, 0, 0, 0);

        public override string ImageName => "automaticacore/plugin-p3.driver.constants";
        
        public override string Tag => "latest-develop";

        public override void InitNodeTemplates(INodeTemplateFactory factory)
        {
            factory.CreateInterfaceType(InterfaceId, "CONSTANTS.NAME", "CONSTANTS.DESCRIPTION", int.MaxValue, 1, true);

            factory.CreateNodeTemplate(BusId, "CONSTANTS.NAME", "CONSTANTS.DESCRIPTION", "consts", GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Virtual),
                InterfaceId, false, true, true, false, true, NodeDataType.NoAttribute, Int32.MaxValue, false);

            factory.CreateNodeTemplate(ValueId, "CONSTANTS.NODE.CONSTANT.NAME", "CONSTANTS.NODE.CONSTANT.DESCRIPTION", "const", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.Integer, Int32.MaxValue, false);
            factory.CreatePropertyTemplate(PropertyValueId, "CONSTANTS.PROPERTY.VALUE.NAME", "CONSTANTS.PROPERTY.VALUE.DESCRIPTION", "const_value", PropertyTemplateType.Integer,
                ValueId, "CONSTANTS.CATEGORY.VALUE", true, false, "", "", 1, 1);


            factory.CreateNodeTemplate(PiId, "CONSTANTS.NODE.PI.NAME", "CONSTANTS.NODE.PI.DESCRIPTION", "const_pi", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.Double, Int32.MaxValue, false);

            factory.CreateNodeTemplate(HalfPiId, "CONSTANTS.NODE.HALF_PI.NAME", "CONSTANTS.NODE.HALF_PI.DESCRIPTION", "const_halfpi", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.Double, Int32.MaxValue, false);


            factory.CreateNodeTemplate(DoublePiId, "CONSTANTS.NODE.DOUBLE_PI.NAME", "CONSTANTS.NODE.DOUBLE_PI.DESCRIPTION", "const_doublepi", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.Double, Int32.MaxValue, false);
            
            
            factory.CreateNodeTemplate(StringValueId, "CONSTANTS.NODE.STRING.NAME", "CONSTANTS.NODE.STRING.DESCRIPTION", "const_string", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.String, Int32.MaxValue, false);
            factory.CreatePropertyTemplate(StringPropertyValueId, "CONSTANTS.PROPERTY.VALUE.NAME", "CONSTANTS.PROPERTY.VALUE.DESCRIPTION", "const_value", PropertyTemplateType.Text,
                StringValueId, "CONSTANTS.CATEGORY.VALUE", true, false, "", "", 1, 1);



            factory.CreateNodeTemplate(TrueId, "CONSTANTS.NODE.TRUE.NAME", "CONSTANTS.NODE.TRUE.DESCRIPTION", "const_true", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.Double, Int32.MaxValue, false);


            factory.CreateNodeTemplate(FalseId, "CONSTANTS.NODE.FALSE.NAME", "CONSTANTS.NODE.FALSE.DESCRIPTION", "const_false", InterfaceId,
                GuidTemplateTypeAttribute.GetFromEnum(InterfaceTypeEnum.Value), false, true, true, false, true, NodeDataType.Double, Int32.MaxValue, false);

        }

        public override IDriver CreateDriver(IDriverContext config)
        {
            return new ConstantsDriver(config);
        }

        public override void AfterSave(NodeInstance instance)
        {
            // do nothing
        }
    }
}
