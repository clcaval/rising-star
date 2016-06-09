USE [RISINGSTAR]
GO

INSERT INTO [dbo].[Acquisitions_Table]
           ([Id_Acq]
           ,[Guid]
           ,[FK_Id_Patient]
           ,[FK_Guid_Patient]
           ,[DATE]
           ,[HOUR]
           ,[OS]
           ,[OD]
           ,[OS_OD]
           ,[OSI]
		   ,[Type_Num]
          )
     VALUES
           ((select max([Id_Acq])+1 from Acquisitions_Table)
           ,newid()
           ,596
           ,'5d1efdf2-ba2d-4c69-bda6-f02d64b54d83'
           ,'2016-11-10'
           ,'2016-11-10 10:00:00'
           ,0
           ,1
           ,'D'
           ,2.1
		   ,2)
GO




SELECT Id_Acq, DATE, OSI
FROM Acquisitions_Table
WHERE FK_Guid_Patient = '5d1efdf2-ba2d-4c69-bda6-f02d64b54d83'
  AND type_num = 2
  AND OD = 1
  AND DATE >= '2016-1-1' AND DATE <= '2016-12-1'
ORDER BY DATE


select * from Acquisitions_Table where id_acq = 1096

delete from Acquisitions_Table where id_acq = 1096

SELECT * FROM [Acquisitions_Table]