USE [Person_Registration]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[People](
	[IdPeople] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[LastName] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](15) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[State] [varchar](255) NULL,
	[Country] [varchar](255) NULL,
	[ZipCode] [varchar](10) NULL,
	[Age] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPeople] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NaturalPerson](
	[IdNaturalPerson] [int] IDENTITY(1,1) NOT NULL,
	[CPF] [varchar](11) NULL,
	[BirthDate] [datetime] NULL,
	[PeopleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdNaturalPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[NaturalPerson]  WITH CHECK ADD FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([IdPeople])
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LegalPerson](
	[IdLegalPerson] [int] IDENTITY(1,1) NOT NULL,
	[CNPJ] [varchar](14) NULL,
	[OpeningDate] [datetime] NULL,
	[CompanyName] [varchar](255) NULL,
	[TradingName] [varchar](255) NULL,
	[RegistrationStatus] [varchar](255) NULL,
	[PeopleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLegalPerson] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LegalPerson]  WITH CHECK ADD FOREIGN KEY([PeopleId])
REFERENCES [dbo].[People] ([IdPeople])
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdatePeople]
    @IdPeople INT,
    @Name VARCHAR(255),
    @LastName VARCHAR(255),
    @Email VARCHAR(255),
    @Phone VARCHAR(15),
    @Address VARCHAR(255),
    @City VARCHAR(255),
    @State VARCHAR(255),
    @Country VARCHAR(255),
    @ZipCode VARCHAR(10),
    @Age INT
AS
BEGIN
    UPDATE People
    SET
        Name = @Name,
        LastName = @LastName,
        Email = @Email,
        Phone = @Phone,
        Address = @Address,
        City = @City,
        State = @State,
        Country = @Country,
        ZipCode = @ZipCode,
        Age = @Age
    WHERE IdPeople = @IdPeople;

    SELECT * FROM People WHERE IdPeople = @IdPeople;
END;
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateNaturalPerson]
    @IdNaturalPerson INT,
    @CPF VARCHAR(11),
    @BirthDate DATE
AS
BEGIN
    UPDATE NaturalPerson
    SET
        CPF = @CPF,
        BirthDate = @BirthDate
    WHERE IdNaturalPerson = @IdNaturalPerson;

    SELECT * FROM NaturalPerson WHERE IdNaturalPerson = @IdNaturalPerson;
END;
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateLegalPerson]
    @LegalPersonId INT,
    @CNPJ VARCHAR(14),
    @OpeningDate DATETIME,
    @CompanyName VARCHAR(255),
    @TradingName VARCHAR(255),
    @RegistrationStatus VARCHAR(255),
    @PeopleId INT
AS
BEGIN
    UPDATE LegalPerson
    SET
        CNPJ = @CNPJ,
        OpeningDate = @OpeningDate,
        CompanyName = @CompanyName,
        TradingName = @TradingName,
        RegistrationStatus = @RegistrationStatus,
        PeopleId = @PeopleId
    WHERE IdLegalPerson = @LegalPersonId;

    SELECT * FROM LegalPerson WHERE IdLegalPerson = @LegalPersonId;
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPeople]
    @Name VARCHAR(255),
    @LastName VARCHAR(255),
    @Email VARCHAR(255),
    @Phone VARCHAR(15),
    @Address VARCHAR(255),
    @City VARCHAR(255),
    @State VARCHAR(255),
    @Country VARCHAR(255),
    @ZipCode VARCHAR(10),
    @Age INT
AS
BEGIN
    INSERT INTO People (Name, LastName, Email, Phone, Address, City, State, Country, ZipCode, Age)
    VALUES (@Name, @LastName, @Email, @Phone, @Address, @City, @State, @Country, @ZipCode, @Age);

    SELECT * FROM People WHERE IdPeople = SCOPE_IDENTITY();
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertNaturalPerson]
    @CPF VARCHAR(11),
    @BirthDate DATE,
    @PeopleId INT
AS
BEGIN
    INSERT INTO NaturalPerson (CPF, BirthDate, PeopleId)
    VALUES (@CPF, @BirthDate, @PeopleId);

    SELECT * FROM NaturalPerson WHERE IdNaturalPerson = SCOPE_IDENTITY();
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertLegalPerson]
    @CNPJ VARCHAR(14),
    @OpeningDate DATETIME,
    @CompanyName VARCHAR(255),
    @TradingName VARCHAR(255),
    @RegistrationStatus VARCHAR(255),
    @PeopleId INT
AS
BEGIN
    INSERT INTO LegalPerson (CNPJ, OpeningDate, CompanyName, TradingName, RegistrationStatus, PeopleId)
    VALUES (@CNPJ, @OpeningDate, @CompanyName, @TradingName, @RegistrationStatus, @PeopleId);

    SELECT * FROM LegalPerson WHERE IdLegalPerson = SCOPE_IDENTITY();
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetNaturalPersonById]
    @NaturalPersonId INT
AS
BEGIN
    SELECT  
		A.IdNaturalPerson,
		A.CPF,
		A.BirthDate,
		B.IdPeople,
		B.Name,
		B.LastName,
		B.Email,
		B.Phone,
		B.Address,
		B.City,
		B.State,
		B.Country,
		B.ZipCode,
		B.Age
	FROM NaturalPerson (nolock) A 
	left join People (nolock) B
		on B.IdPeople = A.PeopleId
	WHERE IdNaturalPerson = @NaturalPersonId;
END;
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetLegalPersonById]
    @IdLegalPerson INT
AS
BEGIN
    SELECT 
		A.IdLegalPerson,
		A.CNPJ,
		A.OpeningDate,
		A.CompanyName,
		A.TradingName,
		A.RegistrationStatus,
		B.IdPeople,
		B.Name,
		B.LastName,
		B.Email,
		B.Phone,
		B.Address,
		B.City,
		B.State,
		B.Country,
		B.ZipCode,
		B.Age
	FROM LegalPerson (nolock) A
	left join People (nolock) B
		on B.IdPeople = A.PeopleId
	WHERE IdLegalPerson = @IdLegalPerson;
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetByIdPeople]
    @PeopleId INT
AS
BEGIN
    SELECT * FROM People WHERE IdPeople = @PeopleId;
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPeople]
AS
BEGIN
    SELECT * FROM People;
END;

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllNaturalPerson]
AS
BEGIN
    SELECT * FROM NaturalPerson;
END;
GO



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllLegalPerson]
AS
BEGIN
    SELECT * FROM LegalPerson;
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeletePeople]
    @IdPeople INT
AS
BEGIN
    DELETE FROM dbo.People WHERE IdPeople = @IdPeople;
END;
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteNaturalPerson]
    @NaturalPersonId INT
AS
BEGIN
    DELETE FROM NaturalPerson WHERE IdNaturalPerson = @NaturalPersonId;
END;
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteLegalPerson]
    @LegalPersonId INT
AS
BEGIN
    DELETE FROM LegalPerson WHERE IdLegalPerson = @LegalPersonId;
END;
GO







