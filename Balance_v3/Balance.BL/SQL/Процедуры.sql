use TesNew;
go
CREATE PROCEDURE [dic].[WorkingWith_DeviceGadget]
	@ID int = null,
	@GadgetName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET NOCOUNT ON;

	if @TypeProcedure='Select'
	begin
		select * from [dic].[DeviceGadget] 
		return
	end
	if @TypeProcedure='Update'
	begin
		update [dic].[DeviceGadget] set [Name]=@GadgetName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceGadget] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		insert into [dic].[DeviceGadget] ([Name]) Values (@GadgetName)
		select * from [dic].[DeviceGadget] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		update [dic].[DeviceGadget] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceGadget] where [ID]=@ID
		return
	end
END

go
CREATE PROCEDURE [dic].[WorkingWith_DeviceType]
	@ID int = null,
	@GadgetID int = null,
	@TypeName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET NOCOUNT ON;

	if @TypeProcedure='Select'
	begin
		select * from [dic].[DeviceType] 
		return
	end
	if @TypeProcedure='Update'
	begin
		update [dic].[DeviceType] set [DeviceGadgetID]=@GadgetID, [Name]=@TypeName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceType] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		insert into [dic].[DeviceType] ([DeviceGadgetID],[Name]) Values (@GadgetID, @TypeName)
		select * from [dic].[DeviceType] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		update [dic].[DeviceType] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceType] where [ID]=@ID
		return
	end
END
go
CREATE PROCEDURE [dic].[WorkingWith_DeviceModel]
	@ID int = null,
	@TypeID int = null,
	@ModelName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET NOCOUNT ON;

	if @TypeProcedure='Select'
	begin
		select * from [dic].[DeviceModel] 
		return
	end
	if @TypeProcedure='Update'
	begin
		update [dic].[DeviceModel] set [DeviceTypeID]=@TypeID, [Name]=@ModelName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceModel] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		insert into [dic].[DeviceModel] ([DeviceTypeID],[Name]) Values (@TypeID, @ModelName)
		select * from [dic].[DeviceModel] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		update [dic].[DeviceModel] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceModel] where [ID]=@ID
		return
	end
END

go
CREATE PROCEDURE [dic].[WorkingWith_SpSi]
	@ID int = null,
	@RegisterNumber nvarchar(150)=NULL,
	@Deal nvarchar(50)=NULL,
	@Page nvarchar(10)=NULL,
	@IsSp bit=NULL,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET NOCOUNT ON;

	if @TypeProcedure='Select'
	begin
		select * from [dic].[SpSi] 
		return
	end
	if @TypeProcedure='Update'
	begin
		update [dic].[SpSi] set [RegisterNumber]=@RegisterNumber, [Deal]=@Deal, [Page]=@Page, [IsSp]=@IsSp, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[SpSi] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		insert into [dic].[SpSi] ([RegisterNumber],[Deal],[Page],[IsSp]) Values (@RegisterNumber, @Deal, @Page, @IsSp)
		select * from [dic].[SpSi] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		update [dic].[SpSi] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[SpSi] where [ID]=@ID
		return
	end
END

go
CREATE PROCEDURE [dic].[WorkingWith_Location]
	@ID int = null,
	@LocationName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET NOCOUNT ON;

	if @TypeProcedure='Select'
	begin
		select * from [dic].[Location] 
		return
	end
	if @TypeProcedure='Update'
	begin
		update [dic].[Location] set [Name]=@LocationName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[Location] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		insert into [dic].[Location] ([Name]) Values (@LocationName)
		select * from [dic].[Location] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		update [dic].[Location] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[Location] where [ID]=@ID
		return
	end
END