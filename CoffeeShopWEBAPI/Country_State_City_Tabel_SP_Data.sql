CREATE TABLE Country (
    CountryID INT PRIMARY KEY IDENTITY(1,1),
    CountryName NVARCHAR(100) NOT NULL,
    CountryCode NVARCHAR(10) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NULL
);

CREATE TABLE State (
    StateID INT PRIMARY KEY IDENTITY(1,1),
    CountryID INT NOT NULL,
    StateName NVARCHAR(100) NOT NULL,
    StateCode NVARCHAR(10),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NULL,
    FOREIGN KEY (CountryID) REFERENCES Country(CountryID)
);

CREATE TABLE City (
    CityID INT PRIMARY KEY IDENTITY(1,1),
    StateID INT NOT NULL,
    CountryID INT NOT NULL,
    CityName NVARCHAR(100) NOT NULL,
    CityCode NVARCHAR(10),
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    ModifiedDate DATETIME NULL,
    FOREIGN KEY (StateID) REFERENCES State(StateID),
    FOREIGN KEY (CountryID) REFERENCES Country(CountryID)
);

INSERT INTO Country (CountryName, CountryCode, CreatedDate) VALUES
('United States', 'US', GETDATE()),
('India', 'IN', GETDATE()),
('Australia', 'AU', GETDATE()),
('Canada', 'CA', GETDATE()),
('United Kingdom', 'UK', GETDATE()),
('Germany', 'DE', GETDATE()),
('France', 'FR', GETDATE()),
('Japan', 'JP', GETDATE()),
('China', 'CN', GETDATE()),
('Brazil', 'BR', GETDATE());

INSERT INTO State (StateName, StateCode, CountryID, CreatedDate) VALUES
('California', 'CA', 1, GETDATE()),
('Texas', 'TX', 1, GETDATE()),
('Gujarat', 'GJ', 2, GETDATE()),
('Maharashtra', 'MH', 2, GETDATE()),
('New South Wales', 'NSW', 3, GETDATE()),
('Victoria', 'VIC', 3, GETDATE()),
('Ontario', 'ON', 4, GETDATE()),
('Quebec', 'QC', 4, GETDATE()),
('England', 'ENG', 5, GETDATE()),
('Scotland', 'SCT', 5, GETDATE());

INSERT INTO City (CityName, CityCode, StateID, CountryID, CreatedDate) VALUES
('Los Angeles', 'LA', 1, 1, GETDATE()),
('Houston', 'HOU', 2, 1, GETDATE()),
('Ahmedabad', 'AMD', 3, 2, GETDATE()),
('Mumbai', 'MUM', 4, 2, GETDATE()),
('Sydney', 'SYD', 5, 3, GETDATE()),
('Melbourne', 'MEL', 6, 3, GETDATE()),
('Toronto', 'TOR', 7, 4, GETDATE()),
('Montreal', 'MTL', 8, 4, GETDATE()),
('London', 'LDN', 9, 5, GETDATE()),
('Edinburgh', 'EDI', 10, 5, GETDATE());

Select * from City;

Create PROCEDURE [dbo].[PR_LOC_City_SelectAll]
AS 
SELECT
		[dbo].[City].[CityID],
		[dbo].[City].[StateID],
		[dbo].[Country].CountryID,
		[dbo].[Country].[CountryName],
		[dbo].[State].[StateName],
		[dbo].[State].[StateCode],
		[dbo].[City].[CreatedDate],
		[dbo].[City].[ModifiedDate],
		[dbo].[City].[CityName],
		[dbo].[City].[CityCode]
		
FROM [dbo].[City]
LEFT OUTER JOIN [dbo].[State]
ON [dbo].[State].[StateID] = [dbo].[City].[StateID]
LEFT OUTER JOIN [dbo].[Country]
ON [dbo].[Country].[CountryID] = [dbo].[State].[CountryID];

EXEC [dbo].[PR_LOC_City_SelectAll]

CREATE PROCEDURE PR_LOC_City_SelectByPK
    @CityID INT
AS
BEGIN
    SELECT CityID, CityName, StateID, CountryID, CityCode
    FROM City
    WHERE CityID = @CityID
END

EXEC [dbo].[PR_LOC_City_SelectByPK] 3

CREATE PROCEDURE PR_LOC_City_Insert
    @CityName NVARCHAR(100),
    @CityCode NVARCHAR(10),
    @StateID INT,
    @CountryID INT
AS
BEGIN
    INSERT INTO City (CityName, CityCode, StateID, CountryID, CreatedDate)
    VALUES (@CityName, @CityCode, @StateID, @CountryID, GETDATE());
END

CREATE PROCEDURE PR_LOC_City_Update
    @CityID INT,
    @CityName NVARCHAR(100),
    @CityCode NVARCHAR(10),
    @StateID INT,
    @CountryID INT
AS
BEGIN
    UPDATE City
    SET CityName = @CityName,
        CityCode = @CityCode,
        StateID = @StateID,
        CountryID = @CountryID,
        ModifiedDate = GETDATE()
    WHERE CityID = @CityID;
END

CREATE PROCEDURE PR_LOC_City_Delete
    @CityID INT
AS
BEGIN
    DELETE FROM City
    WHERE CityID = @CityID
END

CREATE PROCEDURE PR_LOC_State_SelectAll
AS
BEGIN
    SELECT * FROM State;
END

EXEC PR_LOC_State_SelectAll

CREATE PROCEDURE PR_LOC_State_SelectByPK
    @StateID INT
AS
BEGIN
    SELECT * FROM State WHERE StateID = @StateID;
END

EXEC PR_LOC_State_SelectByPK 2

CREATE PROCEDURE PR_LOC_State_Insert
    @StateName NVARCHAR(100),
    @CountryID INT,
    @StateCode NVARCHAR(50)
AS
BEGIN
    INSERT INTO State (StateName, CountryID, StateCode,CreatedDate)
    VALUES (@StateName, @CountryID, @StateCode,GETDATE());
END

CREATE PROCEDURE PR_LOC_State_Update
    @StateID INT,
    @StateName NVARCHAR(100),
    @CountryID INT,
    @StateCode NVARCHAR(50)

AS
BEGIN
    UPDATE State
    SET StateName = @StateName,
        CountryID = @CountryID,
        StateCode = @StateCode,
		ModifiedDate = GETDATE() 
    WHERE StateID = @StateID;
END


CREATE PROCEDURE PR_LOC_State_Delete
    @StateID INT
AS
BEGIN
    DELETE FROM State WHERE StateID = @StateID;
END


CREATE PROCEDURE PR_LOC_Country_SelectAll
AS
BEGIN
    SELECT * FROM Country;
END

EXEC PR_LOC_Country_SelectAll 

CREATE PROCEDURE PR_LOC_Country_SelectByPK
    @CountryID INT
AS
BEGIN
    SELECT * FROM Country WHERE CountryID = @CountryID;
END

EXEC PR_LOC_Country_SelectByPK 2

CREATE PROCEDURE PR_LOC_Country_Insert
    @CountryName NVARCHAR(100),
    @CountryCode NVARCHAR(50)
AS
BEGIN
    INSERT INTO Country (CountryName, CountryCode,CreatedDate)
    VALUES (@CountryName, @CountryCode,GETDATE());
END

CREATE PROCEDURE PR_LOC_Country_Update
    @CountryID INT,
    @CountryName NVARCHAR(100),
    @CountryCode NVARCHAR(50)
AS
BEGIN
    UPDATE Country
    SET CountryName = @CountryName,
        CountryCode = @CountryCode,
		ModifiedDate = GETDATE()
    WHERE CountryID = @CountryID;
END

CREATE PROCEDURE PR_LOC_Country_Delete
    @CountryID INT
AS
BEGIN
    DELETE FROM Country WHERE CountryID = @CountryID;
END

