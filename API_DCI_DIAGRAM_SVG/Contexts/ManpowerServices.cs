using API_DCI_DIAGRAM_SVG.Models;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace API_DCI_DIAGRAM_SVG.Contexts
{
    public class ManpowerServices
    {
        private SqlConnectDB oHRM = new SqlConnectDB("dbHRM");
        private SqlConnectDB oSCM = new SqlConnectDB("dbSCM");
        private OraConnectDB oOraAL1 = new OraConnectDB("ALPHA01");
        private ClsHelper oHelp = new ClsHelper();


        public List<ManpowerInfo> getManpower(DateTime dataDate, string dataShift)
        {
            List<ManpowerInfo> oMPs = new List<ManpowerInfo>();




            string strLn = @"SELECT * FROM HR_DICT WHERE DICT_TYPE = 'MP_MONITOR' ";
            SqlCommand cmdLn = new SqlCommand();
            cmdLn.CommandText = strLn;
            DataTable dtLn = oHRM.Query(cmdLn);

            foreach (DataRow drLn in dtLn.Rows)
            {

                DataTable dtLineCode = new DataTable();
                string strLineCode = $@"SELECT E.DVCD, LineCode, ISNULL(ln.ln_name,'') LineName, ISNULL(S.EN_Std_D,0) EN_Std_D , ISNULL(S.EN_Std_N,0) EN_Std_N, 
                                ISNULL(S.Regis_Std_D,0) Regis_Std_D , ISNULL(S.Regis_Std_N,0) Regis_Std_N , 
                                ISNULL(S.HR_Std_D,0) HR_Std_D , ISNULL(S.HR_Std_N,0) HR_Std_N , dm.SORT_NO,  dm.DV_ENAME ,
                                COUNT(E.CODE) CNT
                            FROM [dbHRM].[dbo].[DVCD_Std] S 
                            LEFT JOIN [dbHRM].[dbo].[Employee] E ON S.DVCD = E.DVCD AND S.ln_code = E.LineCode  
                            LEFT JOIN [dbHRM].[dbo].[DVCD_MSTR] dm ON dm.[DV_CD] = E.DVCD  
                            LEFT JOIN [dbHRM].[dbo].[EMCL] ec ON ec.YM = FORMAT(@dataDate,'yyyyMM') AND ec.CODE = E.CODE  
                            LEFT JOIN [dbHRM].[dbo].[LineMstr] ln ON ln.ln_code = E.LineCode 
                            WHERE (RESIGN = '1900-01-01' or resign >= @dataDate ) AND WSTS = 'E' AND [DVCD_Status] = 'ACTIVE'
                                    AND SUBSTRING(ec.STSH , DAY(@dataDate), 1) = @shift  AND E.DVCD = @DVCD
                            GROUP BY E.DVCD, LineCode, ISNULL(ln.ln_name,''), S.EN_Std_D,S.EN_Std_N,S.Regis_Std_D,S.Regis_Std_N,S.HR_Std_D,S.HR_Std_N,dm.SORT_NO,dm.DV_ENAME  
                            ORDER BY E.DVCD ASC, dm.SORT_NO ASC  ";
                SqlCommand cmdLineCode = new SqlCommand();
                cmdLineCode.CommandText = strLineCode;
                cmdLineCode.Parameters.Add(new SqlParameter("@dataDate", dataDate));
                cmdLineCode.Parameters.Add(new SqlParameter("@shift", dataShift));
                cmdLineCode.Parameters.Add(new SqlParameter("@DVCD", drLn["DICT_Value"].ToString()));
                dtLineCode = oHRM.Query(cmdLineCode);

                #region 
                //================================
                //         EMPLOYEE
                //================================
                DataTable dtMP = new DataTable();
                string strMP = $@"SELECT E.DVCD, LineCode,  E.CODE    
                                  FROM [dbHRM].[dbo].[Employee] E
                                  LEFT JOIN [dbHRM].[dbo].[EMCL] ec ON ec.YM = FORMAT(@dataDate,'yyyyMM') AND ec.CODE = E.CODE  
                                  WHERE (RESIGN = '1900-01-01' or resign >= @dataDate ) AND WSTS = 'E' AND SUBSTRING(ec.STSH , DAY(@dataDate), 1) = @shift  AND E.DVCD = @DVCD
                                  ORDER BY E.DVCD ASC  ";
                SqlCommand cmdMP = new SqlCommand();
                cmdMP.CommandText = strMP;
                cmdMP.Parameters.Add(new SqlParameter("@dataDate", dataDate));
                cmdMP.Parameters.Add(new SqlParameter("@shift", dataShift));
                cmdMP.Parameters.Add(new SqlParameter("@DVCD", drLn["DICT_Value"].ToString()));
                dtMP = oHRM.Query(cmdMP);
                //================================
                //         END EMPLOYEE
                //================================


                //================================
                //         TAFF RECORD
                //================================
                DataTable dtTaff = new DataTable();
                string strTaff = $@"SELECT T.[CODE],[TaffType],[TaffRecord], E.DVCD , E.LineCode 
                                FROM [dbHRM].[dbo].[HR_Taff] T
                                LEFT JOIN [dbHRM].[dbo].Employee E ON E.CODE = T.CODE 
                                LEFT JOIN [dbHRM].[dbo].[EMCL] ec ON ec.YM = FORMAT(@dataDate,'yyyyMM') AND ec.CODE = E.CODE  
                                WHERE TaffType = 'I' AND TaffRecord BETWEEN @TaffStart AND @TaffEnd 
                                        AND SUBSTRING(ec.STSH , DAY(@dataDate), 1) = @shift  AND E.DVCD = @DVCD  ";
                SqlCommand cmdTaff = new SqlCommand();
                cmdTaff.CommandText = strTaff;
                cmdTaff.Parameters.Add(new SqlParameter("@TaffStart", (dataShift == "D") ? dataDate.ToString("yyyy-MM-dd 06:00:00") : dataDate.ToString("yyyy-MM-dd 18:00:00")));
                cmdTaff.Parameters.Add(new SqlParameter("@TaffEnd", (dataShift == "D") ? dataDate.ToString("yyyy-MM-dd 11:00:00") : dataDate.ToString("yyyy-MM-dd 23:00:00")));
                cmdTaff.Parameters.Add(new SqlParameter("@dataDate", dataDate));
                cmdTaff.Parameters.Add(new SqlParameter("@shift", dataShift));
                cmdTaff.Parameters.Add(new SqlParameter("@DVCD", drLn["DICT_Value"].ToString()));
                dtTaff = oHRM.Query(cmdTaff);
                //================================
                //        END TAFF RECORD
                //================================


                //================================
                //         OT RECORD
                //================================
                DataTable dtOT = new DataTable();
                string strOT = $@"SELECT O.[CODE], E.DVCD , E.LineCode 
                              FROM [dbHRM].[dbo].[OTRQ_REQ] O
                              LEFT JOIN [dbHRM].[dbo].Employee E ON E.CODE = O.CODE 
                              LEFT JOIN [dbHRM].[dbo].[EMCL] ec ON ec.YM = FORMAT(@dataDate,'yyyyMM') AND ec.CODE = E.CODE  
                              WHERE [ProgBit] in ('F','M') AND [REQ_STATUS] = 'APPROVE' 
                                    AND ODATE BETWEEN @dataDate AND DATEADD(DAY, 1, @dataDate) 
                                    AND RQ IN (DAY(@dataDate), CONCAT(DAY(@dataDate),'0'))  
                                    AND SUBSTRING(ec.STSH , DAY(@dataDate), 1) = @shift  AND E.DVCD = @DVCD  ";
                SqlCommand cmdOT = new SqlCommand();
                cmdOT.CommandText = strOT;
                cmdOT.Parameters.Add(new SqlParameter("@dataDate", dataDate));
                cmdOT.Parameters.Add(new SqlParameter("@shift", dataShift));
                cmdOT.Parameters.Add(new SqlParameter("@DVCD", drLn["DICT_Value"].ToString()));
                dtOT = oHRM.Query(cmdOT);
                //================================
                //        END OT RECORD
                //================================


                //================================
                //         LEAVE RECORD
                //================================
                DataTable dtLEAVE = new DataTable();
                string strLEAVE = $@"SELECT L.[CODE],[TYPE], E.DVCD , E.LineCode 
                                 FROM [dbHRM].[dbo].[LVRQ_REQ] L
                                 LEFT JOIN [dbHRM].[dbo].Employee E ON E.CODE = L.CODE 
                                 LEFT JOIN [dbHRM].[dbo].[EMCL] ec ON ec.YM = FORMAT(@dataDate,'yyyyMM') AND ec.CODE = E.CODE  
                                 WHERE [ProgBit] in ('F','M') AND [REQ_STATUS] = 'APPROVE' 
                                    AND CDATE = @dataDate  AND SUBSTRING(ec.STSH , DAY(@dataDate), 1) = @shift  AND E.DVCD = @DVCD  ";
                SqlCommand cmdLEAVE = new SqlCommand();
                cmdLEAVE.CommandText = strLEAVE;
                cmdLEAVE.Parameters.Add(new SqlParameter("@dataDate", dataDate));
                cmdLEAVE.Parameters.Add(new SqlParameter("@shift", dataShift));
                cmdLEAVE.Parameters.Add(new SqlParameter("@DVCD", drLn["DICT_Value"].ToString()));
                dtLEAVE = oHRM.Query(cmdLEAVE);
                //================================
                //        END LEAVE RECORD
                //================================


                //================================
                //        CHECK-IN RECORD
                //================================
                DataTable dtChkIn = new DataTable();
                string strChkIn = @"SELECT Obj_Code, LayoutCode, Obj_MasterID, EmpCode Code, Obj_LastCheckDT, E.DVCD, E.LineCode 
                                FROM [dbSCM].[dbo].[MPCK_Object] O 
                                LEFT JOIN [dbHRM].[dbo].Employee E ON E.CODE COLLATE THAI_CI_AS = O.EmpCode 
                                LEFT JOIN [dbHRM].[dbo].[EMCL] ec ON ec.YM = FORMAT(@dataDate,'yyyyMM') AND ec.CODE = E.CODE  
                                WHERE Obj_Type = 'MP' AND Obj_MasterID = 'MST23028' AND Obj_Status = 'ACTIVE'  
                                    AND EmpCode <> '' AND FORMAT(DATEADD(HOUR, -8, Obj_LastCheckDT),'yyyy-MM-dd') = @dataDate  
                                    AND SUBSTRING(ec.STSH , DAY(@dataDate), 1) = @shift  AND E.DVCD = @DVCD ";
                SqlCommand cmdChkIn = new SqlCommand();
                cmdChkIn.CommandText = strChkIn;
                cmdChkIn.Parameters.Add(new SqlParameter("@dataDate", dataDate));
                cmdChkIn.Parameters.Add(new SqlParameter("@shift", dataShift));
                cmdChkIn.Parameters.Add(new SqlParameter("@DVCD", drLn["DICT_Value"].ToString()));
                dtChkIn = oHRM.Query(cmdChkIn);
                //================================
                //        END CHECK-IN RECORD
                //================================
                #endregion


                if (dtLineCode.Rows.Count > 0)
                {
                    foreach (DataRow drLineCode in dtLineCode.Rows)
                    {
                        int regis = 0, act = 0, diff = 0;

                        regis = Convert.ToInt32((dataShift == "D") ? drLineCode["Regis_Std_D"].ToString() : drLineCode["Regis_Std_N"].ToString());
                        act = Convert.ToInt32(drLineCode["CNT"].ToString());
                        diff = act - regis;


                        ManpowerInfo oMP = new ManpowerInfo();
                        oMP.dataDate = dataDate;
                        oMP.dataShift = dataShift;
                        oMP.lineNo = drLn["DICT_Name"].ToString();
                        oMP.lineType = drLn["DICT_Descr2"].ToString();
                        oMP.lineSubCode = drLineCode["LineCode"].ToString();
                        oMP.lineSubName = drLineCode["DV_ENAME"].ToString();
                        oMP.DVCD = drLineCode["DVCD"].ToString();
                        oMP.mpPDPlan = (dataShift == "D") ? drLineCode["Regis_Std_D"].ToString() : drLineCode["Regis_Std_N"].ToString();
                        oMP.mpStandard = (dataShift == "D") ? drLineCode["Regis_Std_D"].ToString() : drLineCode["Regis_Std_N"].ToString();
                        oMP.mpRegis = regis.ToString();
                        oMP.mpRegisLists = new List<empCodeInfo>();
                        oMP.mpActual = act.ToString();
                        oMP.mpActualLists = new List<empCodeInfo>();
                        oMP.mpDiff = diff.ToString();

                        DataRow[] filLeave = (dtLEAVE.Rows.Count > 0) ? dtLEAVE.Select($" DVCD = '{drLineCode["DVCD"].ToString()}' AND LineCode='{drLineCode["LineCode"].ToString()}' ") : null;
                        DataRow[] filOT = (dtOT.Rows.Count > 0) ? dtOT.Select($" DVCD = '{drLineCode["DVCD"].ToString()}' AND LineCode='{drLineCode["LineCode"].ToString()}' ") : null;
                        DataRow[] filWork = (dtTaff.Rows.Count > 0) ? dtTaff.Select($" DVCD = '{drLineCode["DVCD"].ToString()}' AND LineCode='{drLineCode["LineCode"].ToString()}' ") : null;
                        DataRow[] filAnnual = (dtLEAVE.Rows.Count > 0) ? dtLEAVE.Select($" DVCD = '{drLineCode["DVCD"].ToString()}' AND TYPE='ANNU' AND LineCode='{drLineCode["LineCode"].ToString()}' ") : null;
                        DataRow[] filChekIn = (dtChkIn.Rows.Count > 0) ? dtChkIn.Select($" DVCD = '{drLineCode["DVCD"].ToString()}' AND LineCode='{drLineCode["LineCode"].ToString()}'  ") : null;

                        //======== Check and Get Employee Not In Taff ==========
                        var idsTaff = dtTaff.AsEnumerable().Select(row => $"{row.Field<string>("LineCode")}-{row.Field<string>("CODE")}");
                        var dataMPNotInTaff = dtMP.AsEnumerable().Where(row => row.Field<string>("LineCode") == drLineCode["LineCode"].ToString()
                                                                            && !idsTaff.Contains($"{row.Field<string>("LineCode")}-{row.Field<string>("CODE")}"));
                        List<empCodeInfo> oAbsents = new List<empCodeInfo>();
                        foreach (DataRow row in dataMPNotInTaff)
                        {
                            empCodeInfo oAbs = new empCodeInfo();
                            oAbs.empCode = row["Code"].ToString();
                            oAbsents.Add(oAbs);
                        }


                        //======== Check and Get Employee Not In CheckIn ==========
                        var idsChkIn = dtChkIn.AsEnumerable().Select(row => $"{row.Field<string>("LineCode")}-{row.Field<string>("CODE")}");
                        //var dataMPNotInCheckIn = dtMP.AsEnumerable().Where(row => !idsChkIn.Contains(row.Field<string>("CODE")));
                        var dataMPNotInCheckIn = dtMP.AsEnumerable().Where(row => row.Field<string>("LineCode") == drLineCode["LineCode"].ToString()
                                                                            && !idsChkIn.Contains($"{row.Field<string>("LineCode")}-{row.Field<string>("CODE")}"));
                        List<empCodeInfo> oNoCheckIns = new List<empCodeInfo>();
                        foreach (DataRow row in dataMPNotInCheckIn)
                        {
                            empCodeInfo oNoChkIn = new empCodeInfo();
                            oNoChkIn.empCode = row["Code"].ToString();
                            oNoCheckIns.Add(oNoChkIn);
                        }

                        oMP.mpAbsent = oAbsents.Count.ToString();
                        oMP.mpAbsentLists = oAbsents;
                        oMP.mpSupportOut = "";
                        oMP.mpSupportOutLists = new List<empCodeInfo>();
                        oMP.mpSupportIn = "";
                        oMP.mpSupportInLists = new List<empCodeInfo>();
                        oMP.mpAnnual = (filAnnual != null) ? filAnnual.Count().ToString() : "";
                        oMP.mpAnnualLists = getEmpCode(filAnnual);
                        oMP.attWork = (filWork != null) ? filWork.Count().ToString() : "";
                        oMP.attWorkLists = getEmpCode(filWork);
                        oMP.attOT = (filOT != null) ? filOT.Count().ToString() : "";
                        oMP.attOTLists = getEmpCode(filOT);
                        oMP.attCheckIn = (filChekIn != null) ? filChekIn.Count().ToString() : "";
                        oMP.attCheckInLists = getEmpCode(filChekIn);
                        oMP.attNoLicense = "";
                        oMP.attNoLicenseLists = new List<empCodeInfo>();
                        oMP.attNoSkill = "";
                        oMP.attNoSkillLists = new List<empCodeInfo>();
                        oMP.attNoSA = "";
                        oMP.attNoSALists = new List<empCodeInfo>();
                        oMP.attNoMQ = "";
                        oMP.attNoMQLists = new List<empCodeInfo>();
                        oMP.attNoCheckIn = oNoCheckIns.Count.ToString();
                        oMP.attNoCheckInLists = oNoCheckIns;

                        oMPs.Add(oMP);
                    }
                }

            } // end foreach Line


            return oMPs;

        }


        public List<LineTitleInfo> getManpowerTitle(string LineNo)
        {
            List<LineTitleInfo> oLNs = new List<LineTitleInfo>();

            string strLn = $@"SELECT [DICT_Type],[DICT_Code],[DICT_Name],[DICT_Value],[DICT_Descr],[DICT_Descr2], dm.DV_ENAME, s.ln_code, ln.ln_name, dm.SORT_NO , ln.ln_group 
                            FROM HR_DICT d
                            LEFT JOIN [dbHRM].[dbo].[DVCD_Std] s ON s.DVCD = d.DICT_Value 
                            LEFT JOIN [dbHRM].[dbo].[DVCD_MSTR] dm ON dm.[DV_CD] = d.DICT_Value  
                            LEFT JOIN [dbHRM].[dbo].[LineMstr] ln ON ln.ln_code = s.ln_code  
                            WHERE DICT_TYPE = 'MP_MONITOR' AND [DICT_Code] LIKE '{LineNo}%' 
                            ORDER BY dm.SORT_NO ASC, ln.ln_group ASC ";
            SqlCommand cmdLn = new SqlCommand();
            cmdLn.CommandText = strLn;

            DataTable dtLn = dtLn = oHRM.Query(cmdLn);


            foreach (DataRow drLn in dtLn.Rows)
            {
                LineTitleInfo oLN = new LineTitleInfo();
                oLN.lineTitle = drLn["DV_ENAME"].ToString();
                oLN.lineNo = drLn["DICT_Name"].ToString();
                oLN.lineType = drLn["DICT_Descr2"].ToString();
                oLN.lineSubCode = drLn["ln_code"].ToString();
                oLN.lineSubName = drLn["ln_name"].ToString();
                oLN.DVCD = drLn["DICT_Value"].ToString();
                oLN.SortOrder = $"{drLn["SORT_NO"].ToString()}-{drLn["ln_group"].ToString()}";

                oLNs.Add(oLN);

            } // end foreach Line

            return oLNs;

        }



        public List<empCodeInfo> getEmpCode(DataRow[] dr)
        {
            List<empCodeInfo> oEmps = new List<empCodeInfo>();
            if (dr != null && dr.Count() > 0)
            {
                foreach (DataRow row in dr)
                {
                    empCodeInfo oEmp = new empCodeInfo();
                    oEmp.empCode = row["CODE"].ToString();
                    oEmps.Add(oEmp);
                }
            }
            return oEmps;
        }


        public List<EmpInfo> getEmployeeWithOT(DateTime dataDate)
        {
            List<EmpInfo> oEmps = new List<EmpInfo>();

            string str = $@"SELECT E.Code, Name, Surn, CONCAT(Name,'.',SUBSTRING(Surn,1,1)) FName, Posit, DVCD, LineCode, ISNULL(O.REQ_STATUS,'') REQ_STATUS  
                            FROM Employee E
                            LEFT JOIN (  SELECT CODE,  REQ_STATUS 
                                          FROM [dbHRM].[dbo].[OTRQ_REQ]
                                          WHERE ProgBit in ('M','U','F') AND REQ_STATUS IN ('APPROVE','REQUEST')
                                             AND ODATE BETWEEN @DATE AND DATEADD(DAY,1,@DATE) 
	                                         AND RQ IN (DATEPART(DAY,@DATE), CONCAT(DATEPART(DAY,@DATE),'0')) ) O ON O.Code = E.Code 
                            WHERE RESIGN = '1900-01-01' OR RESIGN >= @DATE
                            ORDER BY RESIGN DESC ";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = str;
            cmd.Parameters.Add(new SqlParameter("@DATE", dataDate.ToString("yyyy-MM-dd")));
            DataTable dt = oHRM.Query(cmd);


            foreach (DataRow dr in dt.Rows)
            {
                EmpInfo oEmp = new EmpInfo();
                oEmp.Code = dr["Code"].ToString();
                oEmp.Name = dr["Name"].ToString();
                oEmp.Surn = dr["Surn"].ToString();
                oEmp.FName = dr["FName"].ToString();
                oEmp.Posit = dr["Posit"].ToString();
                oEmp.OTStatus = dr["REQ_STATUS"].ToString();
                oEmp.Dvcd = dr["DVCD"].ToString();
                oEmp.LineCode = dr["LineCode"].ToString();

                oEmps.Add(oEmp);

            } // end foreach Line

            return oEmps;
        }


        public UserInfo authenALPHA(string _Username, string _Password)
        {
            UserInfo oUser = new UserInfo();

            DataTable dtLogin = new DataTable();
            string strLogin = $@"SELECT DISTINCT USERID, GROUPID, TRIM(CURRENT_PWD) AS PASS, USERNAME   
            FROM ( 
                  SELECT USERID, PASSWORD OLD, GROUPID, USERNAME,    
                    CASE WHEN LENGTH(PASSWORD) - 0 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 0 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 1 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 1 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 2 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 2 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 3 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 3 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 4 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 4 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 5 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 5 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 6 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 6 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 7 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 7 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 8 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 8 ,1)) + 1) ELSE '' END ||
                    CASE WHEN LENGTH(PASSWORD) - 9 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 9 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 10 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 10 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 11 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 11 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 12 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 12 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 13 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 13 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 14 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 14 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 15 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 15 ,1)) - 1) ELSE '' END || 
                     CASE WHEN LENGTH(PASSWORD) - 16 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 16 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 17 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 17 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 18 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 18 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 19 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 19 ,1)) - 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 20 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 20 ,1)) + 1) ELSE '' END || 
                    CASE WHEN LENGTH(PASSWORD) - 21 > 0 THEN CHR(ASCII(SUBSTR(PASSWORD,LENGTH(PASSWORD) - 21 ,1)) - 1) ELSE '' END CURRENT_PWD 
                    FROM SCRMGR.ND_MNGUSERENG_TBL 
                    WHERE USERID = TRIM('{_Username}') )  WHERE TRIM(CURRENT_PWD) = '{_Password}'  ";
            OracleCommand cmdLogin = new OracleCommand();
            cmdLogin.CommandText = strLogin;
            cmdLogin.CommandTimeout = 120;
            dtLogin = oOraAL1.Query(cmdLogin);

            if (dtLogin.Rows.Count > 0)
            {
                DataTable dtEmp = new DataTable();
                string strEmp = @"SELECT Code, Name, Surn, CONCAT(Name,'.',SUBSTRING(Surn,1,1)) fullName FROM Employee WHERE Code=@Code AND RESIGN = '1900-01-01' ";
                SqlCommand cmdEmp = new SqlCommand();
                cmdEmp.CommandText = strEmp;
                cmdEmp.Parameters.Add(new SqlParameter("@Code", _Username));
                dtEmp = oHRM.Query(cmdEmp);

                if (dtEmp.Rows.Count > 0)
                {
                    oUser.code = dtEmp.Rows[0]["Code"].ToString();
                    oUser.name = dtEmp.Rows[0]["Name"].ToString();
                    oUser.surn = dtEmp.Rows[0]["Surn"].ToString();
                    oUser.fullName = dtEmp.Rows[0]["fullName"].ToString();
                    oUser.img = dtEmp.Rows[0]["Code"].ToString();
                }
            }

            return oUser;
        }



        public List<NoticeInfo> getNoticeData(DataTable dtNotice, DataRow drWIP)
        {
            DataRow[] drNotices = dtNotice.Select($" WCNO='{drWIP["WCNO"].ToString()}' AND PartNo='{drWIP["PartNo"].ToString()}' AND CM='{drWIP["CM"].ToString()}' ");
            List<NoticeInfo> oNotices = new List<NoticeInfo>();
            if (drNotices.Count() > 0)
            {
                foreach (DataRow drNotice in drNotices)
                {
                    DateTime NoteDate = new DateTime(1900, 1, 1);
                    try
                    {
                        NoteDate = Convert.ToDateTime(drNotice["CRE_DT"].ToString());
                    }
                    catch { }

                    NoticeInfo oNotice = new NoticeInfo();
                    oNotice.Prd_PlanCode = drNotice["PRD_PlanCode"].ToString();
                    oNotice.Ymd = drNotice["YMD"].ToString();
                    oNotice.Sht = drNotice["SHT"].ToString();
                    oNotice.Notices = drNotice["NT_Notice"].ToString();
                    oNotice.WCNO = drNotice["WCNO"].ToString();
                    oNotice.PartNo = drNotice["PartNo"].ToString();
                    oNotice.CM = drNotice["CM"].ToString();
                    oNotice.CreateBy = drNotice["CRE_BY"].ToString();
                    oNotice.CreateDT = NoteDate;
                    oNotices.Add(oNotice);
                }
            }

            return oNotices;
        }

        public bool getSafetyStockDataStatus(DataRow drWIP)
        {
            double sf_bal = 0;
            try
            {
                sf_bal = Convert.ToDouble(drWIP["SF_BAL"].ToString());
            }
            catch { }

            return (sf_bal <= 0);

        }

        public FGWIPInfo getFGWIP(string modelName)
        {

            DateTime dataDate = DateTime.Now.AddHours(-8);
            FGWIPInfo oFGWIP = new FGWIPInfo();

            DataTable dtNotice = new DataTable();
            string strNotice = @"SELECT n.[PRD_PlanCode] , FORMAT(DATEADD(HOUR, -8, n.CRE_DT),'yyyyMMdd') YMD
	                                  ,CASE WHEN DATEPART(HOUR, DATEADD(HOUR,-8,n.CRE_DT)) < 12 THEN 'D' ELSE 'N' END SHT 
                                      ,[NT_Notice] , p.WCNO,p.PartNo , p.CM , n.[CRE_BY], n.[CRE_DT] 
                                  FROM [dbSCM].[dbo].[APS_ProductionPlan_Notice] n
                                  LEFT JOIN [dbSCM].[dbo].[APS_ProductionPlan] p ON n.PRD_PlanCode = p.PRD_PlanCode 
                                  WHERE FORMAT(DATEADD(HOUR,-8,n.CRE_DT),'yyyyMMdd') = @YMD  
                                      AND p.LREV = '999' ";
            SqlCommand cmdNotice = new SqlCommand();
            cmdNotice.CommandText = strNotice;
            cmdNotice.Parameters.Add(new SqlParameter("@YMD", dataDate.ToString("yyyyMM")));
            dtNotice = oSCM.Query(cmdNotice);



            DataTable dtWIP = new DataTable();
            string strWIP = @"SELECT [CODE] ModelCode , [DESCRIPTION] ModelName , D.[REF1] PWCNO , [REF2] PartNo , [REF3] CM , [REF4] UsageQty , 
                                    D.[NOTE] LineSub , S.NOTE SortNo, CONCAT( D.[NOTE],'-',T.LNTYPE) LNTYPE, T.WCNO , T.BAL , 
                                    ISNULL((T.BAL * [REF4]),0) UsageBAL, SF.SafetyQty , (T.BAL - SF.SafetyQty) SF_BAL 
                                FROM [dbSCM].[dbo].[DictMstr] D
                                LEFT JOIN (SELECT REF_CODE, REF1, NOTE 
		                                FROM [dbSCM].[dbo].[DictMstr] 
		                                WHERE DICT_SYSTEM = 'WIP_STOCK' AND DICT_TYPE = 'SUB_LINE_SORT' AND DICT_STATUS = 'ACTIVE') S ON S.REF_CODE = D.NOTE AND S.REF1 = D.REF1 
                                LEFT JOIN (  SELECT  [REF4] LineSub, [NOTE] PartNo, REF1 SafetyQty
                                  FROM [dbSCM].[dbo].[DictMstr]
                                  WHERE DICT_SYSTEM like 'WIP_STOCK' AND DICT_TYPE LIKE 'MODEL_STANDARD' AND REF_CODE = 'SAFETY' AND [DESCRIPTION] = 'SF' 
                                  GROUP BY [REF4],[NOTE], [REF1] ) SF ON SF.PartNo = D.REF2 AND SF.LineSub = D.NOTE 
                                LEFT JOIN (SELECT CASE [WCNO] WHEN '904' THEN 'MAIN' ELSE 'SUBLINE' END LNTYPE, [WCNO],[PARTNO],[CM],[BAL]
			                                FROM [dbSCM].[dbo].[EKB_WIP_PART_STOCK]
			                                WHERE YM=@YM AND WCNO IN (SELECT [WCNO] FROM [dbSCM].[dbo].[AL_WC_Master]
											                                 WHERE GrpCode IN ('2200','2300') AND Product = 'SCR' AND WCNO NOT IN ('907'))) T ON T.PARTNO = D.[REF2] AND T.CM = D.[REF3] 
                                WHERE DICT_SYSTEM = 'WIP_STOCK' AND  DICT_TYPE like 'PART_SET_OUT' AND D.[DICT_STATUS] = 'ACTIVE' AND S.NOTE IS NOT NULL 
	                                AND  [DESCRIPTION] = @ModelName 
                                ";
            SqlCommand cmdWIP = new SqlCommand();
            cmdWIP.CommandText = strWIP;
            cmdWIP.Parameters.Add(new SqlParameter("@YM", dataDate.ToString("yyyyMM")));
            cmdWIP.Parameters.Add(new SqlParameter("@ModelName", modelName.Replace("-10", "")));
            dtWIP = oSCM.Query(cmdWIP);
            if (dtWIP.Rows.Count > 0)
            {

                decimal _minSetAll = 0, _minSetMain = 0;

                //var minSetAll = dtWIP.AsEnumerable().OrderBy(row => row.Field<decimal>("UsageBAL")).FirstOrDefault();
                //if (minSetAll != null)
                //{
                //    _minSetAll = minSetAll.Field<decimal>("UsageBAL");
                //}


                var minSetAll = dtWIP.AsEnumerable()
                          .GroupBy(row => row.Field<string>("LineSub"))
                          .Select(group => new
                          {
                              Category = group.Key,
                              SumAmount = group.Sum(row => row.Field<decimal>("UsageBAL"))
                          })
                          .Min(group => group.SumAmount);
                if (minSetAll != null)
                {
                    _minSetAll = minSetAll;
                }

                //====== Min Set By Main ========
                var minSetMain = dtWIP.AsEnumerable()
                      .Where(row => row.Field<string>("LNTYPE").Contains("-MAIN", StringComparison.OrdinalIgnoreCase))
                      .OrderBy(row => row.Field<decimal>("UsageBAL"))
                      .FirstOrDefault();
                if (minSetMain != null)
                {
                    _minSetMain = minSetMain.Field<decimal>("UsageBAL");
                }
                //====== End Min Set By Main ========



                foreach (DataRow drWIP in dtWIP.Rows)
                {

                    oFGWIP.WCNO = drWIP["PWCNO"].ToString();
                    oFGWIP.ModelCode = drWIP["ModelCode"].ToString();
                    oFGWIP.ModelName = drWIP["ModelName"].ToString();
                    oFGWIP.EstimateMainSet = oHelp.ConvDec2Int(_minSetMain);
                    oFGWIP.EstimateAllSet = _minSetAll.ToString();
                    oFGWIP.dataDateTime = DateTime.Now;

                    switch (drWIP["LNTYPE"].ToString())
                    {
                        case "STATOR-MAIN":
                            oFGWIP.StatorMain = drWIP["BAL"].ToString();
                            oFGWIP.StatorNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.StatorSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "STATOR-SUBLINE": oFGWIP.StatorSubLine = drWIP["BAL"].ToString(); break;
                        case "ROTOR-MAIN":
                            oFGWIP.RotorMain = drWIP["BAL"].ToString();
                            oFGWIP.RotorNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.RotorSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "ROTOR-SUBLINE": oFGWIP.RotorSubLine = drWIP["BAL"].ToString(); break;
                        case "FS-MAIN":
                            oFGWIP.FSMain = drWIP["BAL"].ToString();
                            oFGWIP.FSNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.FSSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "FS-SUBLINE": oFGWIP.FSSubLine = drWIP["BAL"].ToString(); break;
                        case "HS-MAIN":
                            oFGWIP.HSMain = drWIP["BAL"].ToString();
                            oFGWIP.HSNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.HSSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "HS-SUBLINE": oFGWIP.HSSubLine = drWIP["BAL"].ToString(); break;
                        case "CS-MAIN":
                            oFGWIP.CSMain = drWIP["BAL"].ToString();
                            oFGWIP.CSNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.CSSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "CS-SUBLINE": oFGWIP.CSSubLine = drWIP["BAL"].ToString(); break;
                        case "LW-MAIN":
                            oFGWIP.LWMain = drWIP["BAL"].ToString();
                            oFGWIP.LWNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.LWSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "LW-SUBLINE": oFGWIP.LWSubLine = drWIP["BAL"].ToString(); break;
                        case "BODY-MAIN":
                            oFGWIP.BODYMain = drWIP["BAL"].ToString();
                            oFGWIP.BODYNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.BODYSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "BODY-SUBLINE": oFGWIP.BODYSubLine = drWIP["BAL"].ToString(); break;
                        case "TOP-MAIN":
                            oFGWIP.TOPMain = drWIP["BAL"].ToString();
                            oFGWIP.TOPNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.TOPSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "TOP-SUBLINE": oFGWIP.TOPSubLine = drWIP["BAL"].ToString(); break;
                        case "BOTTOM-MAIN":
                            oFGWIP.BOTTOMMain = drWIP["BAL"].ToString();
                            oFGWIP.BOTTOMNotice = getNoticeData(dtNotice, drWIP);
                            oFGWIP.BOTTOMSafety = getSafetyStockDataStatus(drWIP);
                            break;
                        case "BOTTOM-SUBLINE": oFGWIP.BOTTOMSubLine = drWIP["BAL"].ToString(); break;

                    }


                } // end foreach
            } // end if


            return oFGWIP;
        }

        public List<ApsProductionPlanNotice> getNotice(string yyyyMMdd, string prdPlanCode = "")
        {
            List<ApsProductionPlanNotice> res = new List<ApsProductionPlanNotice>();
            try
            {
                DateTime dtNotify = DateTime.ParseExact(yyyyMMdd, "yyyyMMdd", CultureInfo.InvariantCulture);
                dtNotify = dtNotify.AddHours(-8);
                string condPrdPlanCode = prdPlanCode != "" ? $" AND PRD_PlanCode = '{prdPlanCode}'" : "";
                SqlCommand sql = new SqlCommand();
                sql.CommandText = $@"SELECT *  FROM [dbSCM].[dbo].[APS_ProductionPlan_Notice] WHERE CRE_DT >= '{dtNotify.ToString("yyyyMMdd HH:mm:ss")}' {condPrdPlanCode}  ORDER BY CRE_DT DESC";
                DataTable dt = oSCM.Query(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    ApsProductionPlanNotice oNotify = new ApsProductionPlanNotice();
                    oNotify.PrdPlanCode = dr["PRD_PlanCode"].ToString();
                    oNotify.NtType = dr["NT_TYPE"].ToString();
                    oNotify.NtCode = dr["NT_CODE"].ToString();
                    oNotify.NtNotice = dr["NT_Notice"].ToString();
                    oNotify.CreDt = DateTime.Parse(dr["CRE_DT"].ToString());
                    res.Add(oNotify);
                }
            }
            catch
            {
                res = new List<ApsProductionPlanNotice>();
            }
            return res;
        }

        public List<FGPlanInfo> getMainPlan(string YMD, string WCNO, List<ApsSublineStockBalance> stockBalances)
        {

            List<FGPlanInfo> oFGPlans = new List<FGPlanInfo>();
            DateTime _date = oHelp.ConvStrToDate(YMD);
            List<ApsProductionPlanNotice> Notifys = getNotice(YMD);
            string strPln = $@"SELECT [APS_Current], [PRD_PlanCode],[WCNO]
                              ,[SUBLINE],[APS_SEQ],[APS_PlanDate]
                              ,[APS_Distribute],[PRD_SEQ],B.SEBANGO AS MODELCODE,[PartNo],[CM]
                              ,[APS_PlanQty],[PRD_PlanQty],[REV],[LREV]
                          FROM [dbSCM].[dbo].[APS_ProductionPlan] A
						  LEFT JOIN (SELECT  MODEL,SEBANGO  FROM [dbSCM].[dbo].[WMS_MDW27_MODEL_MASTER] WHERE   LREV = '999' GROUP BY MODEL,SEBANGO) B
						  ON REPLACE(A.PartNo,'-10','') = B.MODEL
                          WHERE LREV = '999' AND SUBLINE like 'ASSEMBLY LINE4 (SCR)' 
                                AND APS_PlanDate >= '{_date.ToString("yyyy-MM-dd")}' AND APS_PlanDate <= '{_date.AddDays(2).ToString("yyyy-MM-dd")}' AND wcno = '{WCNO}'
                          ORDER BY APS_PlanDate ASC, CAST(PRD_SEQ AS INT) ASC  ";
            SqlCommand cmdPln = new SqlCommand();
            cmdPln.CommandText = strPln;
            DataTable dtPln = oSCM.Query(cmdPln);

            if (dtPln.Rows.Count > 0)
            {
                foreach (DataRow drPln in dtPln.Rows)
                {
                    FGPlanInfo oFGPlan = new FGPlanInfo();
                    int ApsQty = Convert.ToInt32(drPln["APS_PlanQty"].ToString());
                    int PrdQty = Convert.ToInt32(drPln["PRD_PlanQty"].ToString());
                    bool ChangePlanQty = ApsQty != PrdQty ? true : false;
                    string PrdPlanCode = drPln["PRD_PlanCode"].ToString();
                    oFGPlan.PrdPlanCode = PrdPlanCode;
                    oFGPlan.WCNO = drPln["WCNO"].ToString();
                    oFGPlan.SubLine = drPln["SUBLINE"].ToString();
                    oFGPlan.APSSeq = Convert.ToInt32(drPln["APS_SEQ"].ToString());
                    oFGPlan.APSPlanDate = Convert.ToDateTime(drPln["APS_PlanDate"].ToString());
                    oFGPlan.PrdSeq = Convert.ToInt32(drPln["PRD_SEQ"].ToString());
                    oFGPlan.PartNo = drPln["PartNo"].ToString();
                    oFGPlan.CM = drPln["CM"].ToString();
                    oFGPlan.ModelCode = drPln["MODELCODE"].ToString();
                    oFGPlan.APSPlanQty = ChangePlanQty ? PrdQty : ApsQty;
                    oFGPlan.ChangePlanQty = ChangePlanQty;
                    oFGPlan.PrdPlanQty = PrdQty;
                    oFGPlan.dataWIP = getFGWIP(drPln["PartNo"].ToString());
                    oFGPlan.ApsCurrent = drPln["APS_Current"].ToString();

                    #region find notify
                    List<ApsProductionPlanNotice> NotifysByPlanCode = Notifys.Where(x => x.PrdPlanCode == PrdPlanCode).ToList();
                    oFGPlan.notifys = NotifysByPlanCode;
                    #endregion

                    oFGPlans.Add(oFGPlan);
                }
            }
            int indexLoop = 0;
            int indexCurrent = oFGPlans.FindIndex(x => x.ApsCurrent == "CURRENT");
            indexCurrent = indexCurrent == -1 ? 0 : indexCurrent;
            List<string> ModelOfResult = stockBalances.GroupBy(x => x.Modelcode).Select(x => x.Key).ToList();
            foreach (FGPlanInfo oPlan in oFGPlans)
            {
                if (indexLoop < indexCurrent && ModelOfResult.Contains(oPlan.ModelCode))
                {
                    List<ApsSublineStockBalance> LogOfModel = stockBalances.Where(x => x.Modelcode == oPlan.ModelCode).ToList();
                    decimal? CntOfModel = LogOfModel.Count > 0 ? LogOfModel.Sum(x => x.ApsResult) : 0;
                    if (CntOfModel != null && (CntOfModel >= oPlan.APSPlanQty))
                    {
                        oPlan.StatusPlan = "success";
                    }
                    else
                    {
                        oPlan.StatusPlan = "some";
                    }
                }
                else if (indexLoop == indexCurrent && ModelOfResult.Contains(oPlan.ModelCode))
                {
                    oPlan.StatusPlan = "process";
                }
                else
                {
                    oPlan.StatusPlan = "wait";
                }
                indexLoop++;
            }

            //List<string> oModelCode = oFGPlans.Where(x => x.APSPlanDate.ToString("yyyyMMdd") == YMD).GroupBy(x => x.ModelCode).Select(o => o.Key).ToList();
            //stockBalances = stockBalances.Where(x => oModelCode.Contains(x.Modelcode)).ToList();
            //string? modelCode = stockBalances.Count > 0 ? stockBalances.LastOrDefault().Modelcode : "";
            //DateTime dtNow = DateTime.Now;
            //int indexProcess = oFGPlans.FindLastIndex(x => x.ModelCode == modelCode && x.APSPlanDate.ToString("yyyyMMdd") == YMD);
            ////int indexProcess = oFGPlans.FindLastIndex(x => x.ModelCode == modelCode);
            //if (indexProcess != -1)
            //{
            //    int indexLoop = 0;
            //    foreach (FGPlanInfo oPlan in oFGPlans)
            //    {
            //        string loopPlan = oPlan.APSPlanDate.ToString("yyyyMMdd");
            //        if (indexLoop < indexProcess && loopPlan == YMD)
            //        {
            //            oPlan.StatusPlan = "success";
            //        }
            //        else if (indexLoop == indexProcess && loopPlan == YMD)
            //        {
            //            oPlan.StatusPlan = "process";
            //        }
            //        else
            //        {
            //            oPlan.StatusPlan = "wait";
            //        }
            //        indexLoop++;
            //    }
            //}
            return oFGPlans;
        }




    }
}
