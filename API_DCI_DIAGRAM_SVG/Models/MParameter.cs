using System.Reflection.Emit;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public class MParameter
    {
        public class MParamFactory
        {
            public string Factory { get; set; }
        }
        public class MParamLayoutInfo
        {
            public string LayoutCode { get; set; }
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
            public int? ObjWidth { get; set; }
            public int? ObjHeight { get; set; }

            //public string ObjStatus
            //EmpCode
            //ObjLastCheckDt
        }

        public class MParamObjectCodeInfo
        {
            public string ObjCode { get; set; }
        }

        public class MParamObjectStatusInfo
        {
            public string ObjCode { get; set; }
            public string ObjStatus { get; set; }
        }

        public class MParamObjectEditXYInfo
        {
            public string ObjCode { get; set; }
            public double ObjX { get; set; }
            public double ObjY { get; set; }

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

        public class MParamDictInfo
        {
            public string ObjCode { get; set; }
            public string LayOutCode { get; set; }
            public string DictCode { get; set; }
            public string DictType { get; set; }
            public string EmpCode { get; set; }

        }

        public class MParamDictSearchInfo
        {
            public string SearchCode { get; set; }
            public string SearchType { get; set; }

        }

        public class MOutputManagement
        {
            public List<MParamFactory> listLayout { get; set; }
        }
        public class MOutputManagementLayout
        {
            public string? layoutCode { get; set; }
            public string? layoutName { get; set; }
            public List<MpckObject> listObj { get; set; }
        }

        public class MOutputManagementObject
        {
            public string ObjCode { get; set; }
        }

    }
}
