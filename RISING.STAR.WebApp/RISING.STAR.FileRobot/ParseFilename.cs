using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using RISING.STAR.Entities.FileRobot;
using RISING.STAR.Utils.File;
using RISING.STAR.Business.Documents;


namespace RISING.STAR.FileRobot
{
    public class ParseFilename
    {
        
        public void Execute()
        {

            var filePath = System.Configuration.ConfigurationManager.AppSettings["FileLocation"].ToString();
            var fileHandling = new FileHandling();
            var docBusiness = new DocumentBusiness();

            var files = fileHandling.GetFilesFromLocation(filePath);
            var fileList = new List<FileInformation>();

            foreach (var item in files)
            {
                var fileName = Path.GetFileName(item);
                if (File.Exists(item) && docBusiness.DocumentExists(fileName))
                {                    
                    var aux = this.ParseFile(fileName);
                    fileList.Add(aux);
                }
            }

            this.AddToDatabase(fileList);
            this.MoveToSolution(fileList);

        }

        private FileInformation ParseFile(string fileName)
        {

            var aux = new FileInformation();
            var fileAttributes = fileName.Split('_');

            if(fileAttributes != null && fileAttributes.Count() > 0)
            {

                aux.FileName = fileName;
                aux.Exam = fileAttributes[0];
                aux.PatientID = int.Parse(fileAttributes[1]);
                aux.Eye = fileAttributes[2];
                aux.ExamDatetime = DateTime.ParseExact(fileAttributes[3], "yyyy-MM-ddTHH-mm-ss",
                                                        System.Globalization.CultureInfo.InvariantCulture);

                if(fileAttributes.Count() == 5)
                {
                    var splits = fileAttributes[4].Split('.');
                    aux.Sequence = int.Parse(splits[0]);
                }
                else if(fileAttributes.Count() == 6)
                {
                    aux.ImageType = fileAttributes[4];
                    var splits = fileAttributes[5].Split('.');
                    aux.Sequence = int.Parse(splits[0]);
                }
                else
                {
                    throw new Exception("erro generico, verificar");
                }
                                
            }
            
            return aux;
        }
        
        private void AddToDatabase(List<FileInformation> fileList)
        {
            var docBuss = new DocumentBusiness();
            foreach (var item in fileList)
            {
                docBuss.AddDocument(item);
            }
        }

        private void MoveToSolution(List<FileInformation> fileList)
        {

            var fileOriginPath = System.Configuration.ConfigurationManager.AppSettings["DestinationFileLocation"].ToString();
            var fileDestinationPath = System.Configuration.ConfigurationManager.AppSettings["DestinationFileLocation"].ToString();
            var fileHandler = new FileHandling();

            foreach (var item in fileList)
            {
                fileHandler.MoveFile(String.Format("{0}{1}", fileOriginPath, item.FileName), String.Format("{0}{1}", fileDestinationPath, item.FileName));
            }

        }

    }
}
