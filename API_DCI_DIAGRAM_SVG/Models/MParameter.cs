using System.Reflection.Emit;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public class MParameter
    {
        public class MParamLayoutInfo
        {
            public string LayoutCode { get; set; }
            public DateTime dataDate { get; set; }
            public string dataShift { get; set; }
        }

        public class MParamObjectAddInfo
        {
            //ObjCode
            public string LayoutCode { get; set; }
            public string ObjMasterId { get; set; }
            public string ObjType { get; set; }
            public string ObjTitle { get; set; }
            public string ObjSubtitle { get; set; }
            public double ObjX { get; set; }
            public double ObjY { get; set; }

            //public string ObjStatus
            //EmpCode
            //ObjLastCheckDt
        }

        public class MParamObjectCodeInfo
        {
            public string ObjCode { get; set; }
        }

        public class MParamObjectEditXYInfo
        {
            public string ObjCode { get; set; }
            public double ObjX { get; set; }
            public double ObjY { get; set; }

            //public string ObjStatus
            //EmpCode
            //ObjLastCheckDt
        }

        public class MParamObjectEditTitleInfo
        {
            public string ObjCode { get; set; }            
            public string ObjTitle { get; set; }
            public string ObjSubtitle { get; set; }
        }

        public class MParamCheckInOutInfo
        {
            public string ObjCode { get; set; }
            public string EmpCode { get; set; }
            public string Ckdate { get; set; }            
            public string Ckshift { get; set; }
            public string Cktype { get; set; }
            
        }

    }
}
