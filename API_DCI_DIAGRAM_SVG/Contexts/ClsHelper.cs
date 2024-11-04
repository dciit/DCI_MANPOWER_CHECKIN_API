using API_DCI_DIAGRAM_SVG.Models;
using API_DCI_DIAGRAM_SVG.Props;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public class ClsHelper
    {

        public ClsHelper()
        {

        }

        public string generateNbr()
        {
            DateTime dtNow = DateTime.Now;
            Random rand = new Random(1000000);
            int nxt = rand.Next(1, 999999);

            return $"{dtNow.ToString("yyyyMMddHHmmssffff")}{nxt.ToString("000000")}";
        }

        public string Conv2Currency(string val)
        {
            try
            {
                return Convert.ToDecimal(val).ToString("N0");
            }
            catch
            {
                return val;
            }
        }
        public string ConvInt2Str(int val)
        {
            try
            {
                return Convert.ToString(val);
            }
            catch
            {
                return "";
            }
        }
        public decimal ConvStr2Dec(string val)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch
            {
                return 0;
            }
        }

        public decimal ConvInt2Dec(int? val)
        {
            try
            {
                return Convert.ToDecimal(val);
            }
            catch
            {
                return 0;
            }
        }
        public double ConvIntToDB(int val)
        {
            try
            {
                return Convert.ToDouble(val);
            }
            catch
            {
                return 0;
            }
        }
        public int ConvStr2Int(string val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }
        public decimal? GetItemWIP(List<PropWIP> data,string subline = "")
        {
            try
            {
                PropWIP item = data.FirstOrDefault(x => x.subline == subline);
                if (item != null)
                {
                    return item.bal;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        public int ConvUnStr2Int(string? val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }
        public int ConvDec2Int(decimal val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }
        public decimal ConvUnDecToDec(decimal? val)
        {
            try
            {
                return val != null ? Convert.ToDecimal(val) : 0;
            }
            catch
            {
                return 0;
            }
        }
        public int ConvUnDec2Int(decimal? val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch
            {
                return 0;
            }
        }
        public string ConvUnDec2StrCurrency(decimal? value)
        {
            try
            {
                return value?.ToString("#,###");
            }
            catch
            {
                return "";
            }
        }

        public DateTime ConvStrToDate(string ymd)
        {
            try
            {
                return new DateTime(Convert.ToInt16(ymd.Substring(0, 4)), Convert.ToInt16(ymd.Substring(4, 2)), Convert.ToInt16(ymd.Substring(6, 2)));
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

    }
}
