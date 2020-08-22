use TesNew;
exec [dic].[WorkingWith_Location] @LocationName='Прилет (+4) 01', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Прилет (+4) 02', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Прилет (+4) 03', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Прилет (+4) 04', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Вылет (+8) 01', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Вылет (+8) 02', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Вылет (+8) 03', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] @LocationName='Вылет (+8) 04', @TypeProcedure='Insert'
exec [dic].[WorkingWith_Location] 

exec [dic].[WorkingWith_SpSi] @RegisterNumber='RG=1',@Deal='D=55',@Page='100-105', @IsSp=false, @TypeProcedure='Insert'
exec [dic].[WorkingWith_SpSi] @RegisterNumber='RG=23',@Deal='D=45',@Page='10-105', @IsSp=true, @TypeProcedure='Insert'
exec [dic].[WorkingWith_SpSi] 

exec [dic].[WorkingWith_DeviceGadget] @GadgetName='Printer',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceGadget] @GadgetName='Monitor',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceGadget] @GadgetName='Mouse',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceGadget] @GadgetName='Keyboard',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceGadget]

exec [dic].[WorkingWith_DeviceType] @GadgetID=1,@TypeName='Принтер',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceType] @GadgetID=2,@TypeName='Монитор',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceType] @GadgetID=3,@TypeName='Мышь',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceType] @GadgetID=4,@TypeName='Клавиатура',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceType]

exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='Canon PIXMA MG2440',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='HP LaserJet 1022n',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='HP LaserJet 1020',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='HP LaserJet P1102',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='HP LaserJet P2055d',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='Epson Stylus CX9300F',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='HP LaserJet Pro M104a',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=1,@ModelName='HP LaserJet M1522nf',@TypeProcedure='Insert'

exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName='ASUS VW199',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName='DELL E2016H',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName='ASUS VS207',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName='Acer V193 WL',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName='Acer V173',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=2,@ModelName='ASUS VS228H',@TypeProcedure='Insert'

exec [dic].[WorkingWith_DeviceModel] @TypeID=3,@ModelName='Logitech',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=3,@ModelName='Genius',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=3,@ModelName='Depo',@TypeProcedure='Insert'

exec [dic].[WorkingWith_DeviceModel] @TypeID=4,@ModelName='Logitech',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=4,@ModelName='Dell',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel] @TypeID=4,@ModelName='Mitsumi',@TypeProcedure='Insert'
exec [dic].[WorkingWith_DeviceModel]
