IF NOT EXISTS (
    SELECT name 
    FROM sys.databases
    WHERE name = N'Healthy'
)
CREATE DATABASE [Healthy]
GO

ALTER DATABASE [Healthy] SET QUERY_STORE=ON
