  USE RISINGSTAR
  UPDATE Acquisitions_Table 
	SET 
		Acquisitions_Table.FK_Guid_Patient = A.Guid
	FROM
		Patients_Table AS A 
			INNER JOIN Acquisitions_Table AS B ON 
				B.FK_Id_Patient = A.Id
				

