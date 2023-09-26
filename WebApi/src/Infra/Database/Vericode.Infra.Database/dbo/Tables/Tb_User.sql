﻿CREATE TABLE [dbo].[Tb_User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Login] VARCHAR(127) NOT NULL, 
    [Email] VARCHAR(255) NULL, 
    [Password] VARCHAR(127) NULL,
    [Created] DATETIME NOT NULL,
    [Updated] DATETIME NULL
)
