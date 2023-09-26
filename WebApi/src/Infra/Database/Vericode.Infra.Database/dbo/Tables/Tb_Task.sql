﻿CREATE TABLE [dbo].[Tb_Task]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(512) NOT NULL, 
    [Status] SMALLINT NOT NULL, 
    [Date] DATETIME NOT NULL,
    [Created] DATETIME NOT NULL,
    [Updated] DATETIME NULL
)
