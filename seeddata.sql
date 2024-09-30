/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------

TRUNCATE TABLE [Candidates]

USE [WenhuiCTS]
GO

INSERT INTO [dbo].[Candidates] (FirstName,LastName,Email,PhoneNumber,ZipCode) VALUES
('James','Smith', 'jsmith@abc.com', '512-100-1234', '78756'),
('Michael','Johnson', 'mjhnson@abc.com', '936-200-1234', '77384'),
('Robert','Williams', 'rwilliams@abc.com', '512-300-1234', '78751'),
('John','Brown', 'jbrown@abc.com', '936-400-1234', '77384'),
('David','Williams', 'dwilliams@abc.com', '512-500-1234', '78753')
GO

SELECT * FROM Candidates

--------------------------------------------------------------------------------------*/



