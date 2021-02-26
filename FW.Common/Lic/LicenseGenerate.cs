using Org.Tao.FW.Common.Lic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Org.Tao.FW.Common.Lic
{
    public class LicenseGenerate
    {
        public static bool validateLicense()
        {
            try
            {
                string text = System.IO.File.ReadAllText("license.txt");
                string decryptText = DESHelper.Decrypt(text.Trim(), "sdfjskdl");
                string expiredDateStr = decryptText.Split(":")[1];
                int result = DateTime.Now.CompareTo(DateTime.ParseExact(expiredDateStr, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture));
                return result < 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Main()
        {
            string text = "ExpiredDate:2021-04-01";
            Console.WriteLine(DESHelper.Encode(text, "sdfjskdl"));
        }
    }
}
