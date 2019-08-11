-- Create a new table called 'Users' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
DROP TABLE dbo.Users
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Users
(
   UserId       INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- primary key column
   Name         [NVARCHAR](50)  NOT NULL,
   Location     [NVARCHAR](100),                --City, province, district
   Country      [NVARCHAR](2) NOT NULL,
   Email        [NVARCHAR](100)  NOT NULL,
   BirthDate    [DATE] NOT NULL
);
GO

-- Create a new table called 'Event_Types' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Event_Types', 'U') IS NOT NULL
DROP TABLE dbo.Event_Types
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Event_Types
(
   EventTypeId  TINYINT NOT NULL PRIMARY KEY, -- primary key column
   Name         [NVARCHAR](50)  NOT NULL
);
GO



-- Create a new table called 'Healthy_Events' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Healthy_Events', 'U') IS NOT NULL
DROP TABLE dbo.Healthy_Events
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Healthy_Events
(
   EventId          INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- primary key column
   UserId           INT NOT NULL,
   Logged           [DATETIME2]  NOT NULL,
   EventTypeId      [TINYINT] NOT NULL,         --Events catalog in [Event_Types]
   Milliliters      [SMALLINT],                 --Pure water milliliters ingested
   WalkingDistance  [DECIMAL](5,2),             --Walking distance in kilometers
   TimeElapsed      [DECIMAL](5,2),             --Time elapsed during the walks in hours
   Calories         [SMALLINT],                 --Calories burnt walking in kcal
   Score            [TINYINT] NOT NULL,         --Score for event
   CONSTRAINT FK_UserEvents FOREIGN KEY (UserId) 
   REFERENCES Users(UserId),
   CONSTRAINT FK_EventTypes FOREIGN KEY (EventTypeId)
   REFERENCES Event_Types(EventTypeId)
);
GO


-- Create a new table called 'Weight_Monitoring' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.Weight_Monitoring', 'U') IS NOT NULL
DROP TABLE dbo.Weight_Monitoring
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Weight_Monitoring
(
   EventId          INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- primary key column
   UserId           INT NOT NULL,
   Logged           [DATETIME2]  NOT NULL,
   WeightKgs        [DECIMAL](5,2),             --Weight in kilograms
   CONSTRAINT FK_UserWeight FOREIGN KEY (UserId) 
   REFERENCES Users(UserId)
);
GO


