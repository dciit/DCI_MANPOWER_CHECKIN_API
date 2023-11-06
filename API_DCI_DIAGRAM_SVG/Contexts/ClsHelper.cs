using API_DCI_DIAGRAM_SVG.Models;

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
            int nxt = rand.Next(1,999999);

            return $"{dtNow.ToString("yyyyMMddHHmmssffff")}{nxt.ToString("000000")}";
        }
    
        

    
    
    }
}
