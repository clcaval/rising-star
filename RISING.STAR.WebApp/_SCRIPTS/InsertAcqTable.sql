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
          )
     VALUES
           ((select max([Id_Acq])+1 from Acquisitions_Table)
           ,newid()
           ,596
           ,'9A26BE43-5C71-49B8-92D2-761265E33199'
           ,'2015-11-10'
           ,'2015-11-10 10:00:00'
           ,0
           ,1
           ,'S'
           ,0.2)
GO




SELECT Id_Acq, DATE, OSI
FROM Acquisitions_Table
WHERE FK_Guid_Patient = '9A26BE43-5C71-49B8-92D2-761265E33199'
  AND type_num = 2
  AND OD = 1
  AND DATE BETWEEN '2015-1-1' AND '2015-12-1'
ORDER BY DATE

delete from Acquisitions_Table where id_acq = 1090