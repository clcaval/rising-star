using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RISING.STAR.DAL;
using RISING.STAR.Entities.FileRobot;

namespace RISING.STAR.Business.Documents
{
    public class DocumentBusiness : BusinessBase
    {

        public bool DocumentExists(string fileName)
        {
            var document = dbContext.Documents.Where(x => x.FileName == fileName).FirstOrDefault();
            return document == null;
        }

        public void AddDocument(FileInformation fileInfo)
        {

            var doc = new Document();
            doc.DeleteMoveBy = string.Empty;
            doc.DeleteMoveDate = null;
            doc.DimX = null;
            doc.DimY = null;
            doc.DocumentDate = fileInfo.ExamDatetime;
            doc.DocumentId = Guid.NewGuid();

            // TODO: try this one out
            // doc.ExamType1 = dbContext.ExamTypes.Where(x => x.ExamTypeFilename == fileInfo.Exam).FirstOrDefault();
            doc.Eye = String.Format("{0}{1}", "O", fileInfo.Eye == "L" ? "S" : "D");
            doc.FileName = fileInfo.FileName;
            doc.FileType = fileInfo.FileName.Split('.')[1]; // TODO: make this better
            doc.MovedToPatientId = null;
            doc.PatientId = dbContext.Patients_Table.Where(x => x.Id == fileInfo.PatientID).FirstOrDefault().Guid; // TODO: this better

            this.AddDocument(doc);

        }

        public void AddDocument(Document doc)
        {
            try
            {
                dbContext.Documents.Add(doc);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

    }
}
