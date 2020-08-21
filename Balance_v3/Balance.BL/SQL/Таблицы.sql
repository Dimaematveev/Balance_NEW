/*
  Вопрос нам нужно чтобы индексы автоматически создавались? 1,2,3 ....
  
*/
/*
	create database TesNew
	GO
	use TesNew;
	go
	create schema [dic];
	GO
*/
begin try
	begin transaction Create_Database
		use TesNew;
		create table [dic].[DeviceGadget] (
						   [ID]int primary key IDENTITY
						  ,[Name] nvarchar(50) NOT NULL unique
						  ,[LastModified] datetime2(7) Default(GetDate()) NOT NULL 
						  ,[IsDelete] bit Default(0) NOT NULL
						  )

		create table [dic].[DeviceType] (
						   [ID]int primary key IDENTITY
						  ,[DeviceGadgetID] int NOT NULL  FOREIGN KEY REFERENCES [dic].[DeviceGadget]([ID])
						  ,[Name] nvarchar(50) NOT NULL unique
						  ,[LastModified] datetime2(7) Default(GetDate()) NOT NULL 
						  ,[IsDelete] bit Default(0) NOT NULL
						  ,constraint uq_DeviceGadget_Name unique ([DeviceGadgetID], [Name])
						  )
		create table [dic].[DeviceModel] (
							[ID]int primary key IDENTITY
						   ,[DeviceTypeID] int NOT NULL  FOREIGN KEY REFERENCES [dic].[DeviceType]([ID])
						   ,[Name] nvarchar(50) NOT NULL
						   ,[LastModified] datetime2(7) Default(GetDate()) NOT NULL 
						   ,[IsDelete] bit Default(0) NOT NULL
						   ,constraint uq_DeviceType_Name unique ([DeviceTypeID], [Name])
						   )

		
		create table [dic].[Location] (
								[ID]int primary key IDENTITY(0,1)
							   ,[Name] nvarchar(255)  NOT NULL unique
							   ,[LastModified] datetime2(7) Default(GetDate()) NOT NULL 
							   ,[IsDelete] bit Default(0) NOT NULL
								 )
		
		insert into [dic].[Location] ([Name]) values (N'В обработке!!!')
		
		create table [dic].[SpSi] (
							 [ID]int primary key IDENTITY(0,1)
							,[RegisterNumber] nvarchar(150)  NOT NULL unique
							,[Deal] nvarchar(50)
							,[Page] nvarchar(10)
							,[IsSp] bit 
							,[LastModified] datetime2(7) Default(GetDate()) NOT NULL 
							,[IsDelete] bit Default(0)  NOT NULL
							)
		
		insert into [dic].[SpSi] ([RegisterNumber]) values (N'В обработке')
		insert into [dic].[SpSi] ([RegisterNumber]) values (N'Отсутствует')
		


	COMMIT TRANSACTION Create_Database;
END TRY
BEGIN CATCH
	Declare @error nvarchar(MAX)=''
	SELECT @error=@error+ERROR_MESSAGE()
	print(@error)
   ROLLBACK TRANSACTION Create_Database
END CATCH



