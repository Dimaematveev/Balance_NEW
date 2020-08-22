use TesNew;
exec [dic].[WorkingWith_Location] @LocationName=N'Прилет (+4) 01', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Прилет (+4) 02', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Прилет (+4) 03', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Прилет (+4) 04', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Вылет (+8) 01', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Вылет (+8) 02', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Вылет (+8) 03', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] @LocationName=N'Вылет (+8) 04', @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_Location] 

exec [dic].[WorkingWith_SpSi] @RegisterNumber=N'RG=1',@Deal=N'D=55',@Page=N'100-105', @IsSp=false, @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_SpSi] @RegisterNumber=N'RG=23',@Deal=N'D=45',@Page=N'10-105', @IsSp=true, @TypeProcedure=N'Insert'
exec [dic].[WorkingWith_SpSi] 

exec [dic].[WorkingWith_DeviceGadget] @GadgetName=N'Printer',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceGadget] @GadgetName=N'Monitor',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceGadget] @GadgetName=N'Mouse',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceGadget] @GadgetName=N'Keyboard',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceGadget]

exec [dic].[WorkingWith_DeviceType] @GadgetID=1,@TypeName=N'Принтер',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceType] @GadgetID=2,@TypeName=N'Монитор',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceType] @GadgetID=3,@TypeName=N'Мышь',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceType] @GadgetID=4,@TypeName=N'Клавиатура',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceType]

exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'Canon PIXMA MG2440',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'HP LaserJet 1022n',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'HP LaserJet 1020',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'HP LaserJet P1102',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'HP LaserJet P2055d',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'Epson Stylus CX9300F',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'HP LaserJet Pro M104a',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName=N'HP LaserJet M1522nf',@TypeProcedure=N'Insert'

exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName=N'ASUS VW199',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName=N'DELL E2016H',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName=N'ASUS VS207',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName=N'Acer V193 WL',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName=N'Acer V173',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName=N'ASUS VS228H',@TypeProcedure=N'Insert'

exec [dic].[WorkingWith_DeviceModel] @TypeID=3,@ModelName=N'Logitech',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=3,@ModelName=N'Genius',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=3,@ModelName=N'Depo',@TypeProcedure=N'Insert'

exec [dic].[WorkingWith_DeviceModel] @TypeID=4,@ModelName=N'Logitech',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=4,@ModelName=N'Dell',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=4,@ModelName=N'Mitsumi',@TypeProcedure=N'Insert'
exec [dic].[WorkingWith_DeviceModel]
