USE [TesNew]
GO

/****** Object:  StoredProcedure [dic].[WorkingWith_DeviceGadget]    Script Date: 8/24/2020 10:09:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dic].[WorkingWith_DeviceGadget]
	@ID int = null,
	@GadgetName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON
	SET LANGUAGE Russian

	DECLARE @msg nvarchar(2048)
	set @msg = N'Процедура ['+ OBJECT_SCHEMA_NAME(@@PROCID) + N'].[' + OBJECT_NAME(@@PROCID) + N'].'
	DECLARE @thereIsError bit = 0

	if @TypeProcedure='Select'
	begin
		set @msg = @msg + N' Просмотр.'
		select * from [dic].[DeviceGadget] 
		return
	end
	if @TypeProcedure='Update'
	begin
		set @msg= @msg + N' Обновление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @GadgetName is null 
		begin
			set @msg = @msg + N' Параметр @GadgetName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[DeviceGadget] set [Name]=@GadgetName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceGadget] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		set @msg= @msg + N' Вставка.'
		if @GadgetName is null 
		begin
			set @msg = @msg + N' Параметр @GadgetName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		insert into [dic].[DeviceGadget] ([Name]) Values (@GadgetName)
		select * from [dic].[DeviceGadget] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
	
		set @msg= @msg + N' Удаление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[DeviceGadget] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceGadget] where [ID]=@ID
		return
	end

	set @msg=@msg + N' Неизвестная команда.'
		
	set @msg = @msg + N' Параметр @TypeProcedure имеет неизвестное значение=['
					+ @TypeProcedure
					+ N']. Возможные варианты "Select", "Update", "Insert", "Delete".' 
						 
	RAISERROR (@msg, 16, 1)
	return

END

GO


USE [TesNew]
GO

/****** Object:  StoredProcedure [dic].[WorkingWith_DeviceModel]    Script Date: 8/24/2020 10:10:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dic].[WorkingWith_DeviceModel]
	@ID int = null,
	@TypeID int = null,
	@ModelName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON
	SET LANGUAGE Russian

	DECLARE @msg nvarchar(2048)
	set @msg = N'Процедура ['+ OBJECT_SCHEMA_NAME(@@PROCID) + N'].[' + OBJECT_NAME(@@PROCID) + N'].'
	DECLARE @thereIsError bit = 0

	if @TypeProcedure='Select'
	begin
		set @msg = @msg + N' Просмотр.'
		select * from [dic].[DeviceModel] 
		return
	end
	if @TypeProcedure='Update'
	begin
		set @msg= @msg + N' Обновление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @TypeID is null 
		begin
			set @msg = @msg + N' Параметр @TypeID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @ModelName is null 
		begin
			set @msg = @msg + N' Параметр @ModelName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[DeviceModel] set [DeviceTypeID]=@TypeID, [Name]=@ModelName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceModel] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		set @msg= @msg + N' Вставка.'
		if @TypeID is null 
		begin
			set @msg = @msg + N' Параметр @TypeID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @ModelName is null 
		begin
			set @msg = @msg + N' Параметр @ModelName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		insert into [dic].[DeviceModel] ([DeviceTypeID],[Name]) Values (@TypeID, @ModelName)
		select * from [dic].[DeviceModel] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		set @msg= @msg + N' Удаление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		update [dic].[DeviceModel] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceModel] where [ID]=@ID
		return
	end

	set @msg=@msg + N' Неизвестная команда.'
		
	set @msg = @msg + N' Параметр @TypeProcedure имеет неизвестное значение=['
					+ @TypeProcedure
					+ N']. Возможные варианты "Select", "Update", "Insert", "Delete".' 
						 
	RAISERROR (@msg, 16, 1)
	return
END

GO


USE [TesNew]
GO

/****** Object:  StoredProcedure [dic].[WorkingWith_DeviceType]    Script Date: 8/24/2020 10:10:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dic].[WorkingWith_DeviceType]
	@ID int = null,
	@GadgetID int = null,
	@TypeName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON
	SET LANGUAGE Russian

	DECLARE @msg nvarchar(2048)
	set @msg = N'Процедура ['+ OBJECT_SCHEMA_NAME(@@PROCID) + N'].[' + OBJECT_NAME(@@PROCID) + N'].'
	DECLARE @thereIsError bit = 0


	if @TypeProcedure='Select'
	begin
		set @msg = @msg + N' Просмотр.'
		select * from [dic].[DeviceType] 
		return
	end
	if @TypeProcedure='Update'
	begin
		set @msg= @msg + N' Обновление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @GadgetID is null 
		begin
			set @msg = @msg + N' Параметр @GadgetID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @TypeName is null 
		begin
			set @msg = @msg + N' Параметр @TypeName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[DeviceType] set [DeviceGadgetID]=@GadgetID, [Name]=@TypeName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceType] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		set @msg= @msg + N' Вставка.'
		if @GadgetID is null 
		begin
			set @msg = @msg + N' Параметр @GadgetID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @TypeName is null 
		begin
			set @msg = @msg + N' Параметр @TypeName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		insert into [dic].[DeviceType] ([DeviceGadgetID],[Name]) Values (@GadgetID, @TypeName)
		select * from [dic].[DeviceType] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		set @msg= @msg + N' Удаление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		update [dic].[DeviceType] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[DeviceType] where [ID]=@ID
		return
	end
	set @msg=@msg + N' Неизвестная команда.'
		
	set @msg = @msg + N' Параметр @TypeProcedure имеет неизвестное значение=['
					+ @TypeProcedure
					+ N']. Возможные варианты "Select", "Update", "Insert", "Delete".' 
						 
	RAISERROR (@msg, 16, 1)
	return
END
GO


USE [TesNew]
GO

/****** Object:  StoredProcedure [dic].[WorkingWith_Location]    Script Date: 8/24/2020 10:10:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dic].[WorkingWith_Location]
	@ID int = null,
	@LocationName nvarchar(50) = null,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON
	SET LANGUAGE Russian

	DECLARE @msg nvarchar(2048)
	set @msg = N'Процедура ['+ OBJECT_SCHEMA_NAME(@@PROCID) + N'].[' + OBJECT_NAME(@@PROCID) + N'].'
	DECLARE @thereIsError bit = 0


	if @TypeProcedure='Select'
	begin
		set @msg = @msg + N' Просмотр.'
		select * from [dic].[Location] where [ID] > 0
		return
	end
	if @TypeProcedure='Update'
	begin
		set @msg= @msg + N' Обновление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @LocationName is null 
		begin
			set @msg = @msg + N' Параметр @LocationName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[Location] set [Name]=@LocationName, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[Location] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		set @msg= @msg + N' Вставка.'
		if @LocationName is null 
		begin
			set @msg = @msg + N' Параметр @LocationName не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		insert into [dic].[Location] ([Name]) Values (@LocationName)
		select * from [dic].[Location] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		set @msg= @msg + N' Удаление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[Location] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[Location] where [ID]=@ID
		return
	end
	set @msg=@msg + N' Неизвестная команда.'
		
	set @msg = @msg + N' Параметр @TypeProcedure имеет неизвестное значение=['
					+ @TypeProcedure
					+ N']. Возможные варианты "Select", "Update", "Insert", "Delete".' 
						 
	RAISERROR (@msg, 16, 1)
	return
END
GO


USE [TesNew]
GO

/****** Object:  StoredProcedure [dic].[WorkingWith_SPSI]    Script Date: 8/24/2020 10:10:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dic].[WorkingWith_SPSI]
	@ID int = null,
	@RegisterNumber nvarchar(150)=NULL,
	@Deal nvarchar(50)=NULL,
	@Page nvarchar(10)=NULL,
	@IsSp bit=NULL,
	@TypeProcedure nvarchar(10) = 'Select' 
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON
	SET LANGUAGE Russian

	DECLARE @msg nvarchar(2048)
	set @msg = N'Процедура ['+ OBJECT_SCHEMA_NAME(@@PROCID) + N'].[' + OBJECT_NAME(@@PROCID) + N'].'
	DECLARE @thereIsError bit = 0


	if @TypeProcedure='Select'
	begin
		set @msg = @msg + N' Просмотр.'
		select * from [dic].[SpSi] where [ID] > 0
		return
	end
	if @TypeProcedure='Update'
	begin
		set @msg= @msg + N' Обновление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @RegisterNumber is null 
		begin
			set @msg = @msg + N' Параметр @RegisterNumber не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		update [dic].[SpSi] set [RegisterNumber]=@RegisterNumber, [Deal]=@Deal, [Page]=@Page, [IsSp]=@IsSp, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[SpSi] where [ID]=@ID
		return
	end
	if @TypeProcedure='Insert'
	begin
		set @msg= @msg + N' Вставка.'
		if @RegisterNumber is null 
		begin
			set @msg = @msg + N' Параметр @RegisterNumber не должен быть равен NULL.'
			set @thereIsError = 1
		end
		if @thereIsError = 1
		begin
			RAISERROR (@msg, 16, 1)
			return
		end
		insert into [dic].[SpSi] ([RegisterNumber],[Deal],[Page],[IsSp]) Values (@RegisterNumber, @Deal, @Page, @IsSp)
		select * from [dic].[SpSi] where [ID]=SCOPE_IDENTITY()
		return
	end
	if @TypeProcedure='Delete'
	begin
		set @msg= @msg + N' Удаление.'
		if @ID is null 
		begin
			set @msg = @msg + N' Параметр @ID не должен быть равен NULL.'
			set @thereIsError = 1
		end
		update [dic].[SpSi] set [IsDelete]=1, [LastModified] = GETDATE() where [ID]=@ID
		select * from [dic].[SpSi] where [ID]=@ID
		return
	end
	set @msg=@msg + N' Неизвестная команда.'
		
	set @msg = @msg + N' Параметр @TypeProcedure имеет неизвестное значение=['
					+ @TypeProcedure
					+ N']. Возможные варианты "Select", "Update", "Insert", "Delete".' 
						 
	RAISERROR (@msg, 16, 1)
	return
END

GO


