using System;
using System.Collections.Generic;
using System.Text;

namespace Vericode.Infra.Data.SQLRepository.Task
{
    public static class TaskRepositoryCommands
    {
		public const string GetAll = @"SELECT [Id], [Description], [Status], [Date], [Created], [Updated] FROM TbTask";

        public const string Save = @"MERGE INTO [TbTask] AS Target
				USING
				(
			      VALUES
                   (@Id, @Description, @Status, @Date, GETDATE(), GETDATE())
				) AS Source 
				 ([Id], [Description], [Status], [Date], [Created], [Updated])
							
                ON Target.[Id] = Source.[Id]

				WHEN MATCHED THEN
					UPDATE SET 
                             [Id] = Source.[Id]
                            ,[Description] = Source.[Description]
                            ,[Status] = Source.[Status]            
                            ,[Date] = Source.[Date]
                            ,[Created] = Source.[Created]
                            ,[Updated] = GETDATE()
                
				--inseri novos registros que não existem no target e existem no source
                WHEN NOT MATCHED BY TARGET THEN 
	                INSERT 
                        ([Id],
						[Description],
						[Status],
						[Date],
						[Created],
                        [Updated])
                    VALUES
                        ([Id],
						[Description],
						[Status],
						[Date],
						GETDATE(),
						NULL);
				SELECT [Id], [Description], [Status], [Date], [Created], [Updated] FROM [TbTask];";
    }
}
