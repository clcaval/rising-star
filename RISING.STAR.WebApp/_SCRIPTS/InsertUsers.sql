USE [RISINGSTAR]
GO

INSERT INTO [dbo].[User]
           ([Guid]
           ,[Active]
           ,[DateCreated]
           ,[DateLastModified]
           ,[LastModifiedBy]
           ,[Login]
           ,[PasswordHash]
           ,[IsADM]
           ,[EmailAddress]
           ,[ResetPassword])
     VALUES
           (newid()
           ,1
           ,getdate()
           ,getdate()
           ,1
           ,'techguru@risingstartechnology.com'
           ,'1000:JEE1CSnhxTgeH17KMsjHTEv8Aa2wxtHj:rN6mWMHRkFG4dOdmMcw2NYInhbsdjvK6'
           ,1
           ,'techguru@risingstartechnology.com'
           ,0)
GO


