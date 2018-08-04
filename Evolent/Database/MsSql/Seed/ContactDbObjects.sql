IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contact' AND TABLE_SCHEMA = 'dbo')
DROP TABLE dbo.Contact;
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[AddressLine1] [varchar](100) NULL,
    [AddressLine2] [varchar](100) NULL,
    [City] [varchar](50) NULL,
    [PinCode] [varchar](50) NULL,
    [State] [varchar](50) NULL,
    [Country] [varchar](50) NULL,
	[Status] [int] NULL
) ON [PRIMARY]
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SPInsertContacts')
DROP PROCEDURE SPInsertContacts
GO
CREATE PROCEDURE SPInsertContacts 

	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(100),
	@PhoneNumber varchar(15),
	@AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @City varchar(50),
    @PinCode varchar(50),
    @State varchar(50),
    @Country varchar(50),
	@Status int
AS
BEGIN

	INSERT INTO [dbo].[Contact]
			([FirstName]
           ,[LastName]
           ,[Email]
           ,[PhoneNumber]
           ,[AddressLine1]
           ,[AddressLine2]
           ,[City]
           ,[PinCode]
           ,[State]
           ,[Country]
           ,[Status])
     VALUES
           (@FirstName,
            @LastName, 
            @Email, 
            @PhoneNumber,
            @AddressLine1,
			@AddressLine2,
			@City,
			@PinCode,
			@State,
			@Country,
            @Status)
END
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SPUpdateContacts')
DROP PROCEDURE SPUpdateContacts
GO
CREATE PROCEDURE SPUpdateContacts 

	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(100),
	@PhoneNumber varchar(15),
	@AddressLine1 varchar(100),
    @AddressLine2 varchar(100),
    @City varchar(50),
    @PinCode varchar(50),
    @State varchar(50),
    @Country varchar(50),
	@Status int,
	@Id int
AS
BEGIN

		UPDATE 
			[dbo].[Contact]
		SET 
			[FirstName] = @FirstName,
			[LastName] = @LastName,
			[Email] = @Email, 
			[PhoneNumber] = @PhoneNumber,
			[AddressLine1] = @AddressLine1,
			[AddressLine2] = @AddressLine2,
			[City] = @City,
			[PinCode] = @PinCode,
			[State] = @State,
			[Country] = @Country,
			[Status] = @Status
		WHERE Id=@Id
END
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SPDeleteContact')
DROP PROCEDURE SPDeleteContact
GO
CREATE PROCEDURE SPDeleteContact 	
	@Id int
AS
BEGIN

		DELETE FROM [dbo].[Contact]      
		WHERE Id=@Id
END
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'SPGetContacts')
DROP PROCEDURE SPGetContacts
GO
CREATE PROCEDURE SPGetContacts 		
AS
BEGIN
	
	SELECT 
		[Id],[FirstName],[LastName],[Email],[PhoneNumber],[Status] 
	FROM 
		[dbo].[Contact]
END