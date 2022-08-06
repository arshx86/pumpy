#region

using System;
using System.IO;

#endregion

namespace Pumpy.GUI
{
    internal class Pumper
    {
        public static FileInfo Pump(string asm, int mb)
        {
            FileStream fileStream = File.OpenWrite(asm);
            long num = fileStream.Seek(0L, SeekOrigin.End);
            int num2 = mb;
            decimal d = new decimal(Convert.ToInt64(num2 * 1048576) + fileStream.Length);
            while (decimal.Compare(new decimal(num), d) < 0)
            {
                num += 1L;
                fileStream.WriteByte(0);
            }

            fileStream.Close();
            return new FileInfo(asm);
        }
    }
}