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

        public void Filecopy(string source, string target)
        {
            string targetdirectory = Path.GetDirectoryName(target) + Path.DirectorySeparatorChar;
            if (!System.IO.Directory.Exists(targetdirectory))   //create/test directory
            {
                System.IO.Directory.CreateDirectory(targetdirectory);
            }
            if (!System.IO.File.Exists(target)) //copy
            {
                for (int i = 1; i <= NumberOfRetries; ++i)
                {
                    try
                    {
                        GC.Collect();    //start GC manual
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Copy(source, target, true);
                    }
                    catch (Exception ex)
                    {
                        if (i == NumberOfRetries) // Last one, (re)throw exception and exit
                            throw new IOException(ex.Message);
                        Thread.Sleep(DelayOnRetry);
                    }
                }
            }
        }

        public bool FileDelete(string target)
        {
            if (!System.IO.File.Exists(target)) //check file
            {
                for (int i = 1; i <= NumberOfRetries; i++)
                {
                    try
                    {
                        GC.Collect();    //start GC manual
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(target);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (i == NumberOfRetries) //last one, (re)throw exception, exit
                            throw new IOException(ex.Message);
                        Thread.Sleep(DelayOnRetry);
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
