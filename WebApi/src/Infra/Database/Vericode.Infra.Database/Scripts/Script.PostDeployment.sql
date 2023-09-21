/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO

DECLARE @type_version NVARCHAR(64) = ''
SELECT @type_version = type_version FROM msdb.dbo.sysdac_instances_internal WHERE instance_name = DB_NAME()

IF @type_version = ''
BEGIN 
    GOTO CreateDataBase
END
ELSE IF @type_version = '1.0.0.0'
BEGIN
    GOTO MigracaoDaVersao1000
END

CreateDataBase:
:r .\Post-Deployment\CargaInicial.sql
GOTO Sair

MigracaoDaVersao1000:
:r .\Post-Deployment\migracao_da_versao_1_0_0_0.sql
GOTO Sair

Sair:
:r .\Post-Deployment\configuracoes.sql

Print 'Migrate complete'

GO