using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vocabulator
{
    class Util
    {
        private const int NumberOfRetries = 10;
        private const int DelayOnRetry = 1000;

        public void Filecopy(string source, string target, string oldFileName,string newFileName)
        {
            string sourceFile = System.IO.Path.Combine(source, oldFileName);
            string destFile = System.IO.Path.Combine(target, newFileName);

            //test directory
            if (!System.IO.Directory.Exists(target))
            {
                System.IO.Directory.CreateDirectory(target);
            }
            //copy
            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message);
            }
        }

        public bool FileDelete(string target)
        {
            //start GC manual,....dispose in Teacherform seems not to relase that filelock, rly poor
            GC.Collect();
            GC.WaitForPendingFinalizers();
            //check file
            if (!System.IO.File.Exists(target))
            {
                for (int i = 1; i <= NumberOfRetries; ++i)
                {
                    try
                    {
                        System.IO.File.Delete(target);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (i == NumberOfRetries) // Last one, (re)throw exception and exit
                            throw new IOException(ex.Message);
                        Thread.Sleep(DelayOnRetry);
                    }
                }
            }
            return false;   
        }
    }
}
