using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Threading.Tasks;

namespace RISING.STAR.Utils.File
{
    public class FileHandling
    {

        public List<String> GetFilesFromLocation(string location)
        {
            return this.GetFilesFromLocation(location, "*.*");
        }

        public List<String> GetFilesFromLocation(string location, string fileType)
        {
            if (Directory.Exists(location))
            {
                var files = Directory.GetFiles(location, fileType, SearchOption.TopDirectoryOnly).Where(x => !(x.EndsWith(".DCM")));
                if (files == null)
                    return null;
                else
                    return files.ToList<string>();
            }
            else
            {
                return null;
            }
        }
            
        public bool MoveFile(string filePathSource, string filePathDestination)
        {
            try
            {
                System.IO.File.Copy(filePathSource, filePathDestination);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }
    
    }
}
