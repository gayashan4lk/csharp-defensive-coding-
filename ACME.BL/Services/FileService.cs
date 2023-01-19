using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.BL.Services
{
    internal class FileService
    {
        public void SavePrice(int productId, decimal cost, decimal price, string category, string reason)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (String.IsNullOrEmpty(docPath)) throw new InvalidOperationException("Path cannot be null.");

            StreamWriter sw = File.AppendText(Path.Combine(docPath, "log.txt"));
            sw.WriteLine("");
            sw.WriteLine("Log Entry: ");
            sw.WriteLine($"{DateTime.Now.ToLongTimeString()}");
            sw.WriteLine($"{productId} : {cost} : {price} : {category} : {reason}");
            sw.WriteLine("-----------------------------");
        }
    }
}
