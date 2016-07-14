using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.ConsoleAppTests
{
    class Program
    {
        public static void Main(string[] args)
        {

            var robot = new FileRobot.ParseFilename();
            try
            {
                robot.Execute();
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }
    }
}
