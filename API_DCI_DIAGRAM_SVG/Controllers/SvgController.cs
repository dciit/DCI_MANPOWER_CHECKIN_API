using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Models;
using Microsoft.AspNetCore.Mvc;
using static API_DCI_DIAGRAM_SVG.Models.MParameter;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace API_DCI_DIAGRAM_SVG.Controllers
{
    public class SvgController : Controller
    {
        private readonly DBDCI _contextDCI;
        private readonly ManpowerContext _contxMP;
        private readonly HRMContext _contxHRM;
        private readonly DBPDB _contextPDB;
        ClsHelper oHelper = new ClsHelper();

        public SvgController(DBDCI contextDCI, ManpowerContext contxMP, HRMContext contxHRM, DBPDB contextPDB)
        {
            _contextDCI = contextDCI;
            _contxMP = contxMP;
            _contxHRM = contxHRM;
            _contextPDB = contextPDB;
        }

        //public SvgController(DBDCI contextDCI, ManpowerContext contxMP, HRMContext contxHRM)
        //{
        //    _contextDCI = contextDCI;
        //    _contxMP = contxMP;
        //    _contxHRM = contxHRM;
        //}

        [HttpGet]
        [Route("/master/equipment")]
        public IActionResult masterEquipment()
        {
            var content = _contextDCI.LnsEquipmentMaster.Where(x => x.ObjW == 0 && x.ObjH == 0).OrderByDescending(x => x.ObjId).ToList();
            return Ok(content);
        }

        [HttpGet]
        [Route("/master/equipment/id/{id}")]
        public IActionResult masterEquipmentById(string id = "")
        {


            DateTime dtNow = DateTime.Now;
            //DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00     ====>  "
            DateTime dtStart = DateTime.Parse(DateTime.Now.ToString() + " 08:00:00");

            var content = _contextDCI.LnsEquipmentMaster.Where(x => x.ObjId == id).FirstOrDefault();
            return Ok(content);
        }


        [HttpPost]
        [Route("/master/equipment/add")]
        public IActionResult masterEquipmentAdd([FromBody] LnsEquipmentMaster param)
        {
            string msg = "";
            //string pattern = "(?<=\\<[^<>]*)\"(?=[^><]*\\>)";
            //string output = Regex.Replace(param.ObjSvg, pattern, "'");
            //output = output.Replace(@"""", @"\""");
            //param.ObjSvg = output;
            var content = _contextDCI.LnsEquipmentMaster.Where(x => x.ObjId == param.ObjId).FirstOrDefault();
            if (content == null)
            {
                param.ObjW = 0;
                param.ObjH = 0;
                _contextDCI.LnsEquipmentMaster.Add(param);
            }
            else
            {
                msg = "มีข้อมูล ID นี้อยู่แล้ว ในระบบ";
            }
            int insert = _contextDCI.SaveChanges();
            return Ok(new { status = insert, msg = msg });
        }


        [HttpPost]
        [Route("/master/equipment/update")]
        public IActionResult UpdateMaster([FromBody] LnsEquipmentMaster param)
        {
            string msg = "";
            //string pattern = "(?<=\\<[^<>]*)\"(?=[^><]*\\>)";
            //string output = Regex.Replace(param.ObjSvg, pattern, "'");
            //output = output.Replace(@"""", @"\""");
            //param.ObjSvg = output;
            var content = _contextDCI.LnsEquipmentMaster.Where(x => x.ObjId == param.ObjId).FirstOrDefault();
            if (content != null)
            {
                content.ObjW = 0;
                content.ObjH = 0;
                content.ObjSvg = param.ObjSvg;
                _contextDCI.LnsEquipmentMaster.Update(content);
            }
            int update = _contextDCI.SaveChanges();
            return Ok(new { status = update, msg = msg });
        }

        [HttpPost]
        [Route("/equipment/check")]
        public IActionResult EquipmentCheck([FromBody] LnsEquipmentCheckLog param)
        {
            int res = 0;
            string status = param.EqpStatus;
            var equipment = _contextDCI.LnsEquipment.FirstOrDefault(x => x.EqpId == param.EqpId);
            if (equipment != null)
            {
                double condDays = equipment.ObjMstNextYear == 1 ? 30 : 10;  // -30
                double diffDays = Math.Ceiling(((DateTime)equipment.EqpNextCheckDt - DateTime.Now).TotalDays); // 14
                if (diffDays >= (condDays * -1) && diffDays <= condDays)
                {
                    param.Nbr = _contextDCI.LnsEquipmentCheckLog.Count().ToString();
                    param.EqpCheckDt = DateTime.Now;
                    param.EqpNextCheckDt = equipment.EqpNextCheckDt;
                    param.EqpStatus = status == "true" ? "normal" : "abnormal";
                    param.EqpCheckBy = param.EqpCheckBy;
                    _contextDCI.LnsEquipmentCheckLog.Add(param);
                    int updateLog = _contextDCI.SaveChanges();
                    if (updateLog > 0)
                    {

                        equipment.EqpStatus = status == "true" ? "normal" : "abnormal";
                        if (status == "true")
                        {
                            if (equipment.ObjMstNextYear > 0)
                            {
                                equipment.EqpNextCheckDt = DateTime.Parse(equipment.EqpNextCheckDt.ToString()).AddYears((int)equipment.ObjMstNextYear);
                            }
                            if (equipment.ObjMstNextMonth > 0)
                            {
                                equipment.EqpNextCheckDt = DateTime.Parse(equipment.EqpNextCheckDt.ToString()).AddMonths((int)equipment.ObjMstNextMonth);
                            }
                            if (equipment.ObjMstNextDay > 0)
                            {
                                equipment.EqpNextCheckDt = DateTime.Parse(equipment.EqpNextCheckDt.ToString()).AddDays((int)equipment.ObjMstNextDay);
                            }
                        }

                        equipment.EqpRemark = param.EqpRemark;
                        equipment.EqpLastCheckDt = DateTime.Now;
                        equipment.EqpLastCheckBy = param.EqpCheckBy;
                        res = _contextDCI.SaveChanges();
                    }
                    return StatusCode(200, new { status = res, statusCode = "SUCCESS-200", message = "" });
                }
                else
                {
                    return StatusCode(417, new
                    {
                        status = false,
                        statusCode = "ERROR-417",
                        message = $"ไมอยู่ในรอบตรวจ"
                    });
                }
            }
            else
            {
                return StatusCode(422, new
                {
                    status = false,
                    statusCode = "ERROR-422",
                    message = $"ไม่พบข้อมูล {param.EqpId} "
                });
            }
        }

        [HttpGet]
        [Route("/equipment/get")]
        public IActionResult GetEquipments()
        {
            var content = _contextDCI.LnsEquipment.ToList();
            return Ok(content);
        }


        [HttpGet]
        [Route("/equipment/get/id/{eqpId}")]
        public IActionResult GetEquipments(string eqpId)
        {
            var content = (from eqp in _contextDCI.LnsEquipment.Where(x => x.EqpId == eqpId).ToList()
                           join emp in _contextDCI.Employee
                           on eqp.EqpLastCheckBy equals emp.Code
                           join master in _contextDCI.LnsEquipmentMaster
                           on eqp.ObjId equals master.ObjId
                           select new
                           {
                               eqp.EqpId,
                               eqp.LayoutCode,
                               eqp.ObjId,
                               eqp.EqpTitle,
                               eqp.EqpSubTitle,
                               eqp.EqpLastCheckDt,
                               eqp.EqpNextCheckDt,
                               eqp.EqpLastCheckBy,
                               eqp.EqpStatus,
                               eqp.Layout,
                               eqp.Factory,
                               shortname = emp.Name + "." + emp.Surn.Substring(0, 1),
                               master.ObjSvg,
                               //objSvg = "<svg height='30' width='100'><text x='0' y='15' fill='black'>{name}</text></svg>"
                           }).FirstOrDefault();


            return Ok(content);
        }

        [HttpPost]
        [Route("/equipment")]
        public IActionResult Equipment([FromBody] LnsEquipment param)
        {
            var context = (from eqp in _contextDCI.LnsEquipment.DefaultIfEmpty()
                           join obj in _contextDCI.LnsEquipmentMaster
                           on eqp.ObjId equals obj.ObjId
                           where eqp.EqpStatus == "pending" || eqp.EqpStatus == "completed"
                           select new
                           {
                               eqp.EqpPriority,
                               eqp.LayoutCode,
                               Id = eqp.ObjId,
                               eqp.EqpId,
                               Name = eqp.EqpTitle,
                               X = eqp.EqpX,
                               transform = "translate(" + eqp.EqpX + "," + eqp.EqpY + " )",
                               Y = eqp.EqpY,
                               H = eqp.EqpH,
                               Svg = obj.ObjSvg,
                               eqp.EqpTrigger,
                               eqp.EqpScale,
                               eqp.EqpNextCheckDt,
                               eqp.EqpRotate,
                               Status = (_contextDCI.LnsEquipmentCheckLog.Where(x => x.EqpId == eqp.EqpId).OrderByDescending(x => x.EqpCheckDt).FirstOrDefault().EqpStatus)
                           }).ToList();
            if (param.LayoutCode != "" && param.LayoutCode != "null" && param.LayoutCode != null)
            {
                context = context.Where(x => x.LayoutCode == param.LayoutCode).ToList();
            }
            return Ok(context.OrderBy(x => x.EqpPriority).ToList());

        }

        [HttpPost]
        [Route("/equipment/add")]
        public IActionResult EquipmentAdd([FromBody] LnsEquipment param)
        {
            string EqpId = "";
            var ObjIdMaster = _contextDCI.LnsEquipment.Where(x => x.ObjId.StartsWith(param.ObjId)).ToList().LastOrDefault();
            if (ObjIdMaster != null)
            {
                int Running = int.Parse(ObjIdMaster.EqpId.Substring(ObjIdMaster.EqpId.Length - 3));
                EqpId = param.ObjId + "-" + (Running + 1).ToString("D3");
            }
            else
            {
                EqpId = param.ObjId + "-001";
            }
            param.EqpId = EqpId;
            param.LayoutCode = param.LayoutCode;
            param.EqpStatus = "pending";
            param.Factory = "X";
            param.EqpStartCheckDt = DateTime.Now;
            param.EqpNextCheckDt = DateTime.Now.AddYears(1);
            param.EqpLastCheckBy = "41256";
            param.EqpLastCheckDt = DateTime.Now;
            param.EqpX = param.EqpX - (param.EqpW / 2);
            param.EqpY = param.EqpY - (param.EqpH / 2);
            param.EqpRotate = param.EqpRotate;
            _contextDCI.LnsEquipment.Add(param);
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
            //LnsPoint newPoint = new LnsPoint();
            //newPoint.ObjId = data.ObjId;
            //newPoint.PosX = data.PosX;
            //newPoint.PosW = data.PosW;
            //newPoint.PosY = data.PosY;
            //newPoint.PosH = data.PosH;
            //newPoint.Status = "ACTIVE";
            //newPoint.PosName = data.PosName;
            //_contextDCI.Add(newPoint);
            //int ins = _contextDCI.SaveChanges();
            //return Ok(new { status = ins });
        }

        [HttpPost]
        [Route("/getpoint")]
        public IActionResult GetPoint()
        {
            //var context = (from point in _contextDCI.LnsEquipments.DefaultIfEmpty()
            //               join obj in _contextDCI.LnsEquipmentMasters
            //               on point.ObjId equals obj.ObjId
            //               select new
            //               {
            //                   type = obj.ObjType,
            //                   Id = point.ObjId,
            //                   Name = point.PosName,
            //                   X = point.PosX,
            //                   transform = "translate(" + point.PosX + "," + point.PosY + " )",
            //                   Y = point.PosY,
            //                   H = point.PosH,
            //                   R = obj.ObjR,
            //                   Axis = obj.ObjAxis,
            //                   Svg = obj.ObjSvg
            //               }).ToList();
            //return Ok(context);
            return Ok();
        }
        [HttpGet]
        [Route("/removepoint/{posId}")]
        public IActionResult RemovePoint(int posId)
        {
            //var posItem = _contextDCI.LnsPoints.SingleOrDefault(x => x.PosId == posId);
            //if (posItem != null)
            //{
            //    _contextDCI.LnsPoints.Remove(posItem);

            //}
            //var result = _contextDCI.SaveChanges();
            //return Ok(result);
            return Ok();
        }

        [HttpGet]
        [Route("/removeobject/{objId}")]
        public IActionResult RemoveObject(int objId)
        {
            //var objItem = _contextDCI.LnsObjectMasters.SingleOrDefault(x => x.ObjId == objId);
            //if (objItem != null)
            //{
            //    _contextDCI.LnsObjectMasters.Remove(objItem);

            //}
            //var result = _contextDCI.SaveChanges();
            //return Ok(result);
            return Ok();
        }
        [HttpGet]
        [Route("/getobject")]
        public IActionResult GetObjectAll()
        {
            //try
            //{
            //    return Ok(_contextDCI.LnsObjectMasters.ToList());
            //}
            //catch
            //{
            //    return Ok();
            //}
            return Ok();
        }

        [HttpGet]
        [Route("/clearpoint")]
        public IActionResult ClearPoint()
        {
            //var context = _contextDCI.LnsPoints.ToList();
            //if (context != null)
            //{
            //    _contextDCI.LnsPoints.RemoveRange(context);
            //    _contextDCI.SaveChanges();
            //}
            //return Ok();
            return Ok();
        }

        [HttpPost]
        [Route("/insertpoint/")]
        public IActionResult insertPoint([FromBody] ModelInsertSvg item)
        {
            LnsObjectMaster NewObj = new LnsObjectMaster();
            NewObj.ObjName = item.title;
            NewObj.ObjAxis = "X";
            NewObj.ObjW = item.w;
            NewObj.ObjH = item.h;
            NewObj.ObjSvg = item.code;
            _contextDCI.Add(NewObj);
            _contextDCI.SaveChanges();
            return Ok(item);
        }

        [HttpGet]
        [Route("/master/equipment/delete/{id}")]
        public IActionResult DeleteMasterEquipment(string id)
        {
            var content = _contextDCI.LnsEquipmentMaster.Where(x => x.ObjId == id).FirstOrDefault();
            if (content != null)
            {
                _contextDCI.LnsEquipmentMaster.Remove(content);
            }
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
        }

        [HttpPost]
        [Route("/equipment/delete")]
        public IActionResult DeleteEquipment([FromBody] LnsEquipment param)
        {
            var content = _contextDCI.LnsEquipment.FirstOrDefault(x => x.EqpId == param.EqpId);
            if (content != null)
            {
                _contextDCI.LnsEquipment.Remove(content);
            }
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
        }


        [HttpPost]
        [Route("/layout/add")]
        public IActionResult AddLayout([FromBody] LnsLayout param)
        {
            _contextDCI.LnsLayout.Add(param);
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
        }

        [HttpGet]
        [Route("/layout")]
        public IActionResult GetLayouts()
        {
            var content = _contextDCI.LnsLayout.OrderBy(x => x.LayoutCode).ToList();
            return Ok(content);
        }

        [HttpGet]
        [Route("/layout/{layoutCode}")]
        public IActionResult GetLayoutsByCode(string layoutCode)
        {
            var content = _contextDCI.LnsLayout.Where(x => x.LayoutCode == layoutCode).OrderBy(x => x.LayoutCode).ToList();
            return Ok(content);
        }

        [HttpGet]
        [Route("/layout/equipment/del/{eqpId}")]
        public IActionResult DelEquipmentOfLayout(string eqpId)
        {
            var content = _contextDCI.LnsEquipment.FirstOrDefault(x => x.EqpId == eqpId);
            if (content != null)
            {
                _contextDCI.Remove(content);
                int delete = _contextDCI.SaveChanges();
                return Ok(new
                {
                    status = delete,
                    message = "ไม่พบข้อมูล "
                });
            }
            else
            {
                return Ok(new
                {
                    status = false,
                    message = "ไม่พบข้อมูล "
                });
            }
        }

        [HttpGet]
        [Route("/equipment/log/get/{id}")]
        public IActionResult getLogByEqpId(string id)
        {
            var equipmentLog = _contextDCI.LnsEquipmentCheckLog.ToList();
            if (id != "" && id != "ALL")
            {
                equipmentLog = equipmentLog.Where(x => x.EqpId == id).ToList();
            }
            var content = from eqpLog in equipmentLog
                          join emp in _contextDCI.Employee
                          on eqpLog.EqpCheckBy equals emp.Code
                          select new
                          {
                              eqpLog.EqpId,
                              eqpLog.EqpRemark,
                              eqpLog.EqpCheckBy,
                              eqpLog.EqpCheckDt,
                              eqpLog.EqpNextCheckDt,
                              eqpLog.EqpStatus,
                              shortname = emp.Name + "." + emp.Surn.Substring(0, 1)
                          };
            return Ok(content.OrderByDescending(x => x.EqpCheckDt).ToList());
        }

        //[HttpGet]
        //[Route("/layout/equipment/delete/{layoutCode}")]
        //public IActionResult DeleteEquipmentOfLayout(string layoutCode)
        //{
        //    var content = _contextDCI.LnsEquipments.Where(x => x.LayoutCode == layoutCode).ToList();
        //    foreach (LnsEquipment equipment in content)
        //    {
        //        equipment.EqpStatus = "remove";
        //        _contextDCI.LnsEquipments.Update(equipment).Property(x => x.EqpPriority).IsModified = false; ;
        //    }
        //    int res = _contextDCI.SaveChanges();
        //    return Ok(new
        //    {
        //        status = res
        //    });
        //}

        [HttpGet]
        [Route("/layout/equipment/{layoutCode}")]
        public IActionResult GetEquipmentOfLayout(string layoutCode)
        {
            var layout = _contextDCI.LnsLayout.FirstOrDefault(x => x.LayoutCode == layoutCode);
            var content = from eqp in _contextDCI.LnsEquipment.Where(x => x.LayoutCode == layoutCode).ToList()
                          join master in _contextDCI.LnsEquipmentMaster
                          on eqp.ObjId equals master.ObjId
                          select new
                          {
                              eqp.EqpId,
                              eqp.ObjId,
                              eqp.EqpTitle,
                              eqp.EqpSubTitle,
                              master.ObjName,
                              eqp.EqpX,
                              eqp.EqpY,
                              master.ObjSvg,
                              empcode = eqp.EqpSubTitle,
                              title = eqp.EqpTitle,
                              ot = true,
                              sa = false,
                              mq = true,
                              image = "http://websrv01.dci.daikin.co.jp/pic/" + eqp.EqpSubTitle + ".jpg"
                          };
            return Ok(new
            {
                equipment = content,
                layout = layout
            });
        }

        [HttpPost]
        [Route("/equipment/axis/")]
        public IActionResult UpdateAxisEquipment([FromBody] LnsEquipment param)
        {
            var content = _contextDCI.LnsEquipment.Where(x => x.EqpId == param.EqpId).ToList();
            foreach (LnsEquipment equipment in content)
            {
                equipment.EqpX = param.EqpX;
                equipment.EqpY = param.EqpY;
                _contextDCI.LnsEquipment.Update(equipment).Property(x => x.EqpPriority).IsModified = false;
            }
            int res = _contextDCI.SaveChanges();
            return Ok(new
            {
                status = res
            });
        }



        #region Layout
        [HttpPost]
        [Route("/mpck/getLayoutlist")]
        public IActionResult GetLayoutList([FromBody] MParamObjectCodeInfo param)
        {
            List<MpckLayout> oLayouts = new List<MpckLayout>();
            if (param.ObjCode.Trim() == "")
            {
                oLayouts = _contxMP.MpckLayout.ToList();
                List<BoardDatum> boardList = _contextPDB.BoardData.ToList();
            }
            else
            {
                oLayouts = _contxMP.MpckLayout.Where(l => l.LayoutCode == param.ObjCode).ToList();
            }
            return Ok(oLayouts);
        }

        [HttpPost]
        [Route("/mpck/addLayout")]
        public IActionResult AddLayout([FromBody] MpckLayout param)
        {
            string dockey = "MPCK_LAYOUT";
            List<SpDCRunNbr> nbr = _contxMP.SpDCRunNbr.FromSqlRaw($"sp_DCRunNbr '{dockey}','' ").ToList();

            try
            {
                if (nbr.Count > 0)
                {
                    MpckLayout oLayout = new MpckLayout();
                    oLayout.LayoutCode = nbr[0].RunNbr;
                    oLayout.LayoutName = param.LayoutName;
                    oLayout.LayoutSubName = param.LayoutSubName;
                    oLayout.Factory = param.Factory;
                    oLayout.Line = param.Line;
                    oLayout.SubLine = param.SubLine;
                    oLayout.LayoutStatus = "ACTIVE";
                    oLayout.BypassSa = "FALSE";
                    oLayout.BypassMq = "FALSE";
                    oLayout.UpdateBy = param.UpdateBy;
                    oLayout.UpdateDate = DateTime.Now;

                    _contxMP.MpckLayout.Attach(oLayout);
                    _contxMP.Entry(oLayout).State = EntityState.Added;
                    int res = _contxMP.SaveChanges();

                    return Ok(new { status = res, msg = nbr[0].RunNbr });
                }
                else
                {
                    return Ok(new { status = "0", msg = "error gen nbr" });
                }
            }
            catch
            {
                return Ok(new { status = "0", msg = "error" });
            }
        }

        [HttpPost]
        [Route("/mpck/updateStatusLayout")]
        public IActionResult UpdateStatusLayout([FromBody] MParamObjectStatusInfo param)
        {
            List<MpckLayout> oLayouts = _contxMP.MpckLayout.Where(m => m.LayoutCode == param.ObjCode).ToList();

            if (oLayouts.Count > 0)
            {
                MpckLayout oLayout = oLayouts[0];
                oLayout.LayoutStatus = param.ObjStatus;
                _contxMP.MpckLayout.Attach(oLayout);
                _contxMP.Entry(oLayout).State = EntityState.Modified;
                int res = _contxMP.SaveChanges();

                return Ok(new { status = res });
            }
            else
            {
                return Ok(new { status = "0" });
            }
        }
        #endregion


        #region Object
        [HttpPost]
        [Route("/mpck/getObjectlistbylayout")]
        public IActionResult GetObjectListByLayout([FromBody] MParamLayoutInfo param)
        {
            //&& (o.Rq == ctNow.Day.ToString() || o.Rq == ctNow.Day.ToString()+"0")

            List<ViMpckObjectList> oObjects = _contxMP.ViMpckObjectList.Where(o => o.LayoutStatus == "ACTIVE" && o.LayoutCode == param.LayoutCode).ToList();
            DateTime ctNow = DateTime.Now.AddHours(-8);
            string ymd = ctNow.ToString("yyyyMMdd");
            string ymd2 = ctNow.AddDays(1).ToString("yyyyMMdd");

            List<OtrqReq> oEmpOTs = _contxHRM.OtrqReq.Where(o => ((o.ReqStatus == "REQUEST" && o.ProgBit == "U") || (o.ReqStatus == "APPROVE" && (o.ProgBit == "M" || o.ProgBit == "F")))
                            && (o.Odate == ctNow.Date || o.Odate == ctNow.AddDays(1).Date)
                            && (o.Rq == ctNow.Day.ToString() || o.Rq == ctNow.Day.ToString() + "0")
                            ).ToList();
            Service serv = new Service(_contextDCI, _contxMP, _contxHRM);
            if (oObjects.FirstOrDefault(x => x.ObjPriority != 0) == null)
            {
                int priority = 0;
                foreach (ViMpckObjectList item in oObjects.OrderBy(b => b.MstOrder).ToList())
                {
                    MpckObject itemContext = _contxMP.MpckObject.FirstOrDefault(x => x.ObjCode == item.ObjCode);
                    if (itemContext != null)
                    {
                        itemContext.ObjPriority = priority;
                        _contxMP.MpckObject.Update(itemContext);
                        priority++;
                    }
                }
                _contxMP.SaveChanges();
            }

            oObjects = oObjects.FirstOrDefault(x => x.ObjPriority != 0) == null ? oObjects.OrderBy(b => b.MstOrder).ToList() : oObjects.OrderBy(b => b.ObjPriority).ToList();
            var result = from obj in oObjects
                         join ot in oEmpOTs
                         on obj.EmpCode equals ot.Code into d2
                         from f in d2.DefaultIfEmpty()
                         select new
                         {
                             obj.ObjCode,
                             obj.LayoutCode,
                             obj.ObjMasterId,
                             obj.ObjType,
                             obj.ObjTitle,
                             obj.ObjSubtitle,
                             obj.ObjPath,
                             obj.ObjX,
                             obj.ObjY,
                             obj.ObjStatus,
                             obj.EmpCode,
                             obj.ObjLastCheckDt,
                             obj.LayoutName,
                             obj.LayoutSubName,
                             obj.Factory,
                             obj.Line,
                             obj.SubLine,
                             obj.LayoutStatus,
                             obj.BypassMq,
                             obj.BypassSa,
                             obj.Mq,
                             obj.Sa,
                             Ot = (obj.EmpCode != "") ? (f != null) ? "TRUE" : "FALSE" : "FALSE",
                             obj.EmpImage,
                             obj.EmpName,
                             obj.ObjSvg,
                             obj.MstOrder,
                             manskill = serv.getCounter(obj.ObjCode).counter,
                             obj.ObjPicture,
                             objSA = serv.getSAofObj(obj.ObjCode),
                             objMQ = serv.getMQofObj(obj.ObjCode),
                             obj.ObjWidth,
                             obj.ObjHeight,
                             obj.ObjBackgroundColor,
                             obj.ObjBorderColor,
                             obj.ObjPriority,
                             sync = false,
                             obj.ObjPosition
                         };
            return Ok(result.OrderByDescending(x => x.ObjPriority).ToList());

        }

        [HttpPost]
        [Route("/mpck/getObjectlistbyCode")]
        public IActionResult GetObjectListByCode([FromBody] MParamObjectCodeInfo param)
        {
            List<ViMpckObjectList> oObjects = _contxMP.ViMpckObjectList.Where(o => o.ObjStatus == "ACTIVE" && o.ObjCode == param.ObjCode).ToList();
            DateTime ctNow = DateTime.Now.AddHours(-8);
            List<OtrqReq> oEmpOTs = _contxHRM.OtrqReq.Where(o => ((o.ReqStatus == "REQUEST" && o.ProgBit == "U") || (o.ReqStatus == "APPROVE" && (o.ProgBit == "M" || o.ProgBit == "F")))
                            && (o.Odate == ctNow.Date || o.Odate == ctNow.AddDays(1).Date) && o.Code == oObjects[0].EmpCode
                            && (o.Rq == ctNow.Day.ToString() || o.Rq == ctNow.Day.ToString() + "0")
                            ).ToList();

            var result = from obj in oObjects.OrderBy(b => b.MstOrder)
                         join ot in oEmpOTs
                         on obj.EmpCode equals ot.Code into d2
                         from f in d2.DefaultIfEmpty()
                         select new
                         {
                             obj.ObjCode,
                             obj.LayoutCode,
                             obj.ObjMasterId,
                             obj.ObjType,
                             obj.ObjTitle,
                             obj.ObjSubtitle,
                             obj.ObjPath,
                             obj.ObjX,
                             obj.ObjY,
                             obj.ObjStatus,
                             obj.EmpCode,
                             obj.ObjLastCheckDt,
                             obj.LayoutName,
                             obj.LayoutSubName,
                             obj.Factory,
                             obj.Line,
                             obj.SubLine,
                             obj.LayoutStatus,
                             obj.BypassMq,
                             obj.BypassSa,
                             obj.Mq,
                             obj.Sa,
                             Ot = (obj.EmpCode != "") ? (f != null) ? "TRUE" : "FALSE" : "FALSE",
                             obj.EmpImage,
                             obj.EmpName,
                             obj.ObjSvg,
                             obj.MstOrder,
                             obj.ObjPicture,
                             obj.ObjPosition
                         };



            return Ok(result);

        }



        [HttpPost]
        [Route("/mpck/getObjectInfoByCode")]
        public IActionResult GetObjectInfoByCode([FromBody] MParamObjectCodeInfo param)
        {
            //***** Object Info *******
            List<ViMpckObjectList> oObjects = _contxMP.ViMpckObjectList.Where(o => o.ObjStatus == "ACTIVE" && o.ObjCode == param.ObjCode).ToList();
            object result = (dynamic)null;

            //***** Employee Info *******
            if (oObjects.Count > 0)
            {
                ViMpckObjectList oObject = oObjects[0];
                List<MpckDictionary> oMQs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == param.ObjCode && d.DictType == "MQ").ToList();
                List<MpckDictionary> oSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == param.ObjCode && d.DictType == "SA").ToList();

                List<TrLineProcess> oMQALLs = _contextDCI.TrLineProcess.Where(l => l.ProcType == "MQ").ToList();
                List<SkcDictMstr> oSAALLs = _contxMP.SkcDictMstr.Where(d => d.Code == d.RefCode && d.DictStatus == true && d.DictType == "LICENSE").ToList();

                //****** Log ******
                object arLogObj = new { };
                arLogObj = _contxMP.ViMpckCheckInOutLog.Where(l => l.ObjCode == param.ObjCode).ToList().Take(10).OrderByDescending(o => o.CkdateTime);

                //******* LOG EMP *****/
                MpckObject oObj = _contxMP.MpckObject.FirstOrDefault(x => x.ObjCode == param.ObjCode);
                object arLogEmpObj = new { };
                if (oObj != null)
                {
                    if (oObj.EmpCode != "")
                    {
                        arLogObj = _contxMP.ViMpckCheckInOutLog.Where(l => l.EmpCode == oObj.EmpCode).ToList().Take(10).OrderByDescending(o => o.CkdateTime);
                    }
                }
                object arObj_MQ = new { };
                if (oMQs.Count > 0)
                {
                    arObj_MQ = from mq in oMQs.OrderBy(b => b.DictCode)
                               join mqall in oMQALLs
                               on mq.DictCode equals mqall.ProcessCode
                               select new
                               {
                                   MQCode = mq.DictCode,
                                   MQName = mqall.ProcessName
                               };
                }
                object arObj_SA = new { };
                if (oSAs.Count > 0)
                {
                    arObj_SA = from sa in oSAs.OrderBy(b => b.DictCode)
                               join saall in oSAALLs
                               on sa.DictCode equals saall.Code
                               select new
                               {
                                   SACode = sa.DictCode,
                                   SAName = saall.DictDesc
                               };
                }


                if (oObject.EmpCode != "" && oObject.EmpCode != "-")
                {
                    Employee oEmp = _contxHRM.Employee.Where(e => e.Code == oObject.EmpCode).FirstOrDefault();

                    if (oEmp != null)
                    {
                        var oEmpMQs = _contextDCI.ViTrTrainessLog.Where(tr => tr.EmpCode == oEmp.Code && tr.Result == "P" && tr.Status == "post").ToList().GroupBy(g => g.MqNo);
                        var oEmpSAs = _contxMP.SkcLicenseTraining.Where(ct => ct.Empcode == oEmp.Code && ct.EffectiveDate <= DateTime.Now && ct.ExpiredDate >= DateTime.Now).ToList().GroupBy(g => g.DictCode);

                        object arEmp_MQ = new { };

                        if (oEmpMQs.Count() > 0)
                        {
                            arEmp_MQ = from mq in oEmpMQs.OrderBy(b => b.Key)
                                       join mqall in oMQALLs
                                       on mq.Key equals mqall.ProcessCode
                                       select new
                                       {
                                           MQCode = mq.Key,
                                           MQName = mqall.ProcessName
                                       };
                        }

                        object arEmp_SA = new { };
                        if (oEmpSAs.Count() > 0)
                        {
                            arEmp_SA = from sa in oEmpSAs.OrderBy(b => b.Key)
                                       join saall in oSAALLs
                                       on sa.Key equals saall.Code
                                       select new
                                       {
                                           SACode = sa.Key,
                                           SAName = saall.DictDesc
                                       };
                        }


                        //****** Log ******
                        object arLogEmp = new { };
                        arLogEmp = _contxMP.ViMpckCheckInOutLog.Where(l => l.EmpCode == oObject.EmpCode).ToList().Take(10).OrderByDescending(o => o.CkdateTime);

                        Service serv = new Service(_contextDCI, _contxMP, _contxHRM);
                        result = from obj in oObjects
                                 select new
                                 {
                                     obj.ObjCode,
                                     obj.ObjTitle,
                                     obj.ObjSubtitle,
                                     obj.Factory,
                                     obj.SubLine,
                                     obj.Line,
                                     obj.Ot,
                                     obj.Mq,
                                     obj.Sa,
                                     obj.EmpCode,
                                     obj.EmpName,
                                     obj.EmpImage,
                                     EmpJoin = Convert.ToDateTime(oEmp!.Join).ToString("dd/MMM/yyyy"),
                                     EmpWorkDay = (DateTime.Now - Convert.ToDateTime(oEmp!.Join)).TotalDays.ToString(),
                                     EmpWorkYear = Math.Floor((DateTime.Now - Convert.ToDateTime(oEmp!.Join)).TotalDays / 365).ToString(),
                                     EmpPosit = oEmp.Posit,
                                     ObjMQ = arObj_MQ,
                                     ObjSA = arObj_SA,
                                     ObjLog = arLogObj,
                                     EmpMQ = arEmp_MQ,
                                     EmpSA = arEmp_SA,
                                     EmpLog = arLogEmpObj,
                                     manSkill = serv.getCounter(obj.ObjCode),
                                     obj.ObjPicture,
                                     obj.ObjWidth,
                                     obj.ObjHeight,
                                     obj.ObjBackgroundColor,
                                     obj.ObjBorderColor,
                                     obj.ObjType,
                                     obj.ObjPosition
                                 };
                    } // end check have employee
                }
                else
                {
                    result = from obj in oObjects
                             select new
                             {
                                 obj.ObjCode,
                                 obj.ObjTitle,
                                 obj.ObjSubtitle,
                                 obj.Factory,
                                 obj.SubLine,
                                 obj.Line,
                                 obj.Ot,
                                 obj.Mq,
                                 obj.Sa,
                                 obj.EmpCode,
                                 obj.EmpName,
                                 obj.EmpImage,
                                 EmpJoin = "",
                                 EmpWorkDay = "",
                                 EmpWorkYear = "",
                                 EmpPosit = "",
                                 ObjMQ = arObj_MQ,
                                 ObjSA = arObj_SA,
                                 ObjLog = arLogObj,
                                 EmpMQ = new { },
                                 EmpSA = new { },
                                 EmpLog = new { },
                                 manSkill = 0,
                                 obj.ObjWidth,
                                 obj.ObjHeight,
                                 obj.ObjBackgroundColor,
                                 obj.ObjBorderColor,
                                 obj.ObjType
                             };
                }
            }

            return Ok(result);

        }

        [HttpPost]
        [Route("/mpck/getObjectlist")]
        public IActionResult GetObjectList([FromBody] MParamObjectCodeInfo param)
        {
            List<MpckObject> oMstObjs = new List<MpckObject>();
            if (param.ObjCode.Trim() == "")
            {
                oMstObjs = _contxMP.MpckObject.ToList();
            }
            else
            {
                oMstObjs = _contxMP.MpckObject.Where(l => l.ObjCode == param.ObjCode).ToList();
            }

            return Ok(oMstObjs);

        }

        [HttpPost]
        [Route("/mpck/addObject")]
        public IActionResult AddObject([FromBody] MParamObjectAddInfo param)
        {
            string dockey = (param.ObjType == "MP") ? "MPCK_OBJECT_MP" : "MPCK_OBJECT_OTH";
            List<SpDCRunNbr> nbr = _contxMP.SpDCRunNbr.FromSqlRaw($"sp_DCRunNbr '{dockey}','' ").ToList();
            try
            {
                if (nbr.Count > 0)
                {
                    MpckObject contentLast = _contxMP.MpckObject.OrderByDescending(x => x.ObjPriority).FirstOrDefault();
                    int? priority = contentLast != null ? contentLast.ObjPriority + 1 : 0;
                    MpckObject mObj = new MpckObject();
                    mObj.ObjCode = nbr[0].RunNbr;
                    mObj.LayoutCode = param.LayoutCode;
                    mObj.ObjMasterId = param.ObjMasterId;
                    mObj.ObjType = param.ObjType;
                    mObj.ObjTitle = param.ObjTitle;
                    mObj.ObjSubtitle = param.ObjSubtitle;
                    mObj.ObjPath = "";
                    mObj.ObjX = param.ObjX;
                    mObj.ObjY = param.ObjY;
                    mObj.ObjStatus = "ACTIVE";
                    mObj.EmpCode = "";
                    mObj.ObjLastCheckDt = DateTime.Now;
                    mObj.ObjInsertDt = DateTime.Now;
                    mObj.ObjPicture = "";
                    mObj.ObjWidth = param.ObjWidth;
                    mObj.ObjHeight = param.ObjHeight;
                    mObj.ObjBackgroundColor = "";
                    mObj.ObjBorderColor = "";
                    mObj.ObjPriority = priority;
                    mObj.ObjPosition = "OP";
                    _contxMP.MpckObject.Attach(mObj);
                    _contxMP.Entry(mObj).State = EntityState.Added;
                    int res = _contxMP.SaveChanges();
                    return Ok(new { status = res, msg = nbr[0].RunNbr });
                }
                else
                {
                    return Ok(new { status = "0", msg = "error gen nbr" });
                }
            }
            catch
            {
                return Ok(new { status = "0", msg = "error" });
            }

        }

        [HttpPost]
        [Route("/mpck/deleteObject")]
        public IActionResult DeleteObject([FromBody] MParamObjectCodeInfo param)
        {

            List<MpckObject> oObjects = _contxMP.MpckObject.Where(o => o.ObjCode == param.ObjCode).ToList();

            if (oObjects.Count > 0)
            {
                MpckObject oObject = oObjects[0];

                _contxMP.MpckObject.Attach(oObject);
                _contxMP.Entry(oObject).State = EntityState.Deleted;
                int res = _contxMP.SaveChanges();
                return Ok(new { status = res });
            }
            else
            {
                return Ok(new { status = "0" });
            }


        }

        [HttpPost]
        [Route("/mpck/editObjectTitle")]
        public IActionResult EditTitleObject([FromBody] MParamObjectEditTitleInfo param)
        {
            List<MpckObject> oObjs = _contxMP.MpckObject.Where(o => o.ObjCode == param.ObjCode).ToList();

            if (oObjs.Count > 0)
            {
                MpckObject oObjUpd = oObjs[0];
                oObjUpd.ObjTitle = param.ObjTitle;
                oObjUpd.ObjSubtitle = param.ObjSubtitle;

                _contxMP.MpckObject.Attach(oObjUpd);
                _contxMP.Entry(oObjUpd).State = EntityState.Modified;
                int changed = _contxMP.SaveChanges();

                return Ok(new { status = changed });
            }
            else
            {
                return Ok(new { status = "0" });
            }
        }


        [HttpPost]
        [Route("/mpck/editObjectPosition")]
        public IActionResult EditPositionObject([FromBody] MParamObjectEditXYInfo param)
        {
            List<MpckObject> oObjs = _contxMP.MpckObject.Where(o => o.ObjCode == param.ObjCode).ToList();

            if (oObjs.Count > 0)
            {
                MpckObject oObjUpd = oObjs[0];
                oObjUpd.ObjX = param.ObjX;
                oObjUpd.ObjY = param.ObjY;

                _contxMP.MpckObject.Attach(oObjUpd);
                _contxMP.Entry(oObjUpd).State = EntityState.Modified;
                int changed = _contxMP.SaveChanges();

                return (changed == 1) ? Ok(new { status = "updated" }) : Ok(new { status = $"not update ({changed})" });
            }
            else
            {
                return Ok(new { status = "no data" });
            }
        }

        [HttpPost]
        [Route("/mpck/management")]
        public IActionResult GetFactory([FromBody] MParamFactory param)
        {
            List<MOutputManagementLayout> listLayout = new List<MOutputManagementLayout>();
            var listFactory = _contxMP.MpckLayout.Where(x => x.Factory == param.Factory && x.LayoutStatus == "ACTIVE").ToList();
            foreach (var item in listFactory)
            {
                MOutputManagementLayout oLayout = new MOutputManagementLayout();
                oLayout.layoutName = item.LayoutName;
                oLayout.layoutCode = item.LayoutCode;
                List<MOutputManagementObject> itemObj = new List<MOutputManagementObject>();
                var oListObjs = _contxMP.MpckObject.Where(x => x.LayoutCode == item.LayoutCode && x.ObjType == "MP" && x.ObjTitle != "" && x.ObjStatus == "ACTIVE").ToList();
                oLayout.listObj = oListObjs;
                listLayout.Add(oLayout);
            }
            return Ok(listLayout);
        }



        #endregion


        #region Master Object

        [HttpPost]
        [Route("/mpck/getMasterlist")]
        public IActionResult GetMasterList([FromBody] MParamObjectCodeInfo param)
        {
            List<MpckObjectMaster> oMstObjs = new List<MpckObjectMaster>();
            if (param.ObjCode.Trim() == "")
            {
                oMstObjs = _contxMP.MpckObjectMaster.ToList();
            }
            else
            {
                oMstObjs = _contxMP.MpckObjectMaster.Where(l => l.ObjMasterId == param.ObjCode).ToList();
            }

            return Ok(oMstObjs);

        }

        [HttpPost]
        [Route("/mpck/generateMasterNbr")]
        public IActionResult generateMasterNbr()
        {
            string dockey = "MPCK_MASTER";
            List<SpDCRunNbr> nbr = _contxMP.SpDCRunNbr.FromSqlRaw($"sp_DCRunNbr '{dockey}','' ").ToList();
            if (nbr.Count > 0)
            {
                return Ok(new { DocNbr = nbr[0].RunNbr });
            }
            else
            {
                return BadRequest(new { DocNbr = "error" });
            }

        }

        [HttpPost]
        [Route("/mpck/addMaster")]
        public IActionResult AddMaster([FromBody] MpckObjectMaster param)
        {
            try
            {
                MpckObjectMaster oMst = new MpckObjectMaster();
                oMst.ObjMasterId = param.ObjMasterId;
                oMst.MstName = param.MstName;
                oMst.ObjSvg = param.ObjSvg;
                oMst.MstOrder = param.MstOrder;
                oMst.MstStatus = "ACTIVE";

                _contxMP.MpckObjectMaster.Attach(oMst);
                _contxMP.Entry(oMst).State = EntityState.Added;
                int res = _contxMP.SaveChanges();

                return Ok(new { status = res, msg = param.ObjMasterId });
            }
            catch
            {
                return Ok(new { status = "0", msg = "error" });
            }
        }


        [HttpPost]
        [Route("/mpck/editMaster")]
        public IActionResult EditMaster([FromBody] MpckObjectMaster param)
        {
            List<MpckObjectMaster> oMasters = _contxMP.MpckObjectMaster.Where(m => m.ObjMasterId == param.ObjMasterId).ToList();

            if (oMasters.Count > 0)
            {
                MpckObjectMaster oMaster = oMasters[0];
                oMaster.ObjSvg = param.ObjSvg;
                oMaster.MstName = param.MstName;
                oMaster.MstStatus = param.MstStatus;
                oMaster.MstOrder = param.MstOrder;

                _contxMP.MpckObjectMaster.Attach(oMaster);
                _contxMP.Entry(oMaster).State = EntityState.Modified;
                int res = _contxMP.SaveChanges();

                return Ok(new { status = res });
            }
            else
            {
                return Ok(new { status = "0" });
            }
        }


        [HttpPost]
        [Route("/mpck/updateStatusMaster")]
        public IActionResult UpdateStatusMaster([FromBody] MParamObjectStatusInfo param)
        {
            List<MpckObjectMaster> oMasters = _contxMP.MpckObjectMaster.Where(m => m.ObjMasterId == param.ObjCode).ToList();

            if (oMasters.Count > 0)
            {
                MpckObjectMaster oMaster = oMasters[0];
                oMaster.MstStatus = param.ObjStatus;
                _contxMP.MpckObjectMaster.Attach(oMaster);
                _contxMP.Entry(oMaster).State = EntityState.Modified;
                int res = _contxMP.SaveChanges();

                return Ok(new { status = res });
            }
            else
            {
                return Ok(new { status = "0" });
            }
        }

        #endregion


        #region MQ / SA
        [HttpPost]
        [Route("/mpck/getMQSAListByLayout")]
        public IActionResult SearchMQSAByLayout([FromBody] MParamDictSearchInfo param)
        {
            List<MpckDictionary> oMQSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode2 == param.SearchCode && d.DictType == param.SearchType).ToList();
            return Ok(oMQSAs);
        }

        [HttpPost]
        [Route("/mpck/getMQSAListByObject")]
        public IActionResult SearchMQSAByObject([FromBody] MParamDictSearchInfo param)
        {
            List<MpckDictionary> oMQSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == param.SearchCode && d.DictType == param.SearchType).ToList();
            return Ok(oMQSAs);
        }


        [HttpPost]
        [Route("/mpck/addMQSA")]
        public IActionResult AddMQSA([FromBody] MParamDictInfo param)
        {

            List<MpckDictionary> oMQSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == param.ObjCode && d.DictCode == param.DictCode && d.DictType == param.DictType).ToList();

            if (oMQSAs.Count == 0)
            {
                MpckDictionary oDict = new MpckDictionary();
                oDict.DictType = param.DictType;
                oDict.DictCode = param.DictCode;
                oDict.DictName = "";
                oDict.DictSubName = "";
                oDict.DictRefCode = param.ObjCode;
                oDict.DictRefCode2 = param.LayOutCode;
                oDict.DictRefName = "";
                oDict.DictRefSubName = "";

                _contxMP.MpckDictionary.Attach(oDict);
                _contxMP.Entry(oDict).State = EntityState.Added;
                int res = _contxMP.SaveChanges();

                return Ok(new { status = res });
            }
            else
            {
                return Ok(new { status = "0", msg = "duplicate" });
            }
        }

        [HttpPost]
        [Route("/mpck/deleteMQSA")]
        public IActionResult DeleteMQSA([FromBody] MParamDictInfo param)
        {
            List<MpckDictionary> oMQSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == param.ObjCode && d.DictCode == param.DictCode && d.DictType == param.DictType).ToList();

            if (oMQSAs.Count > 0)
            {
                MpckDictionary oDict = oMQSAs[0];

                _contxMP.MpckDictionary.Attach(oDict);
                _contxMP.Entry(oDict).State = EntityState.Deleted;
                int res = _contxMP.SaveChanges();

                return Ok(new { status = res });
            }
            else
            {
                return Ok(new { status = "0", msg = "duplicate" });
            }
        }


        [HttpPost]
        [Route("/mpck/getSAList")]
        public IActionResult GetSAList()
        {

            List<SkcDictMstr> oSAs = _contxMP.SkcDictMstr.Where(d => d.Code == d.RefCode && d.DictStatus == true && d.DictType == "LICENSE").ToList();
            return Ok(oSAs);
        }


        [HttpPost]
        [Route("/mpck/getMQList")]
        public IActionResult GetMQList()
        {
            List<TrLineProcess> oMQs = _contextDCI.TrLineProcess.Where(l => l.ProcType == "MQ").ToList();
            return Ok(oMQs);
        }

        #endregion


        #region Check In/Out

        [HttpPost]
        [Route("/mpck/checkInOut")]
        public IActionResult CheckInOut([FromBody] MParamCheckInOutInfo param)
        {
            List<MpckObject> oObjs = _contxMP.MpckObject.Where(o => o.ObjCode == param.ObjCode && o.ObjStatus == "ACTIVE").ToList();
            if (oObjs.Count > 0)
            {
                MpckObject oObjUpd = oObjs[0];
                MpckLayout oLayout = _contxMP.MpckLayout.Where(l => l.LayoutCode == oObjUpd.LayoutCode).FirstOrDefault() ?? new MpckLayout();
                bool stsUpd = false;
                if (param.Cktype == "IN")
                {

                    //**** Check not have employee check in before *****
                    if (oObjUpd.EmpCode == "")
                    {

                        //**** Check employee not check-in before *****
                        if (oObjs.Where(o => o.EmpCode == param.EmpCode).Count() > 0)
                        {
                            return Ok(new { status = "0", msg = "employee already check-in" });
                        }



                        bool byPassMQ = (oLayout.BypassMq == "TRUE") ? true : false;
                        bool byPassSA = (oLayout.BypassSa == "TRUE") ? true : false;


                        //****** check in ******
                        List<MpckDictionary> oMQSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == param.ObjCode).OrderBy(or => or.DictType).ToList();
                        if (oMQSAs.Count > 0)
                        {
                            //***** SET Default ******
                            foreach (MpckDictionary oMQSA in oMQSAs)
                            {
                                oMQSA.DictName = "FALSE";
                            }

                            //***************************************
                            //      CHECK EMPLOYEE HAVE MQ / SA 
                            //***************************************
                            List<ViTrTrainessLog> oEmpMQs = _contextDCI.ViTrTrainessLog.Where(tr => tr.EmpCode == param.EmpCode && tr.Result == "P" && tr.Status == "post").ToList();
                            List<SkcLicenseTraining> oEmpSAs = _contxMP.SkcLicenseTraining.Where(ct => ct.Empcode == param.EmpCode && ct.EffectiveDate <= DateTime.Now && ct.ExpiredDate >= DateTime.Now).ToList();

                            //***** Loop Foreach ******
                            foreach (MpckDictionary oMQSA in oMQSAs)
                            {
                                if (oMQSA.DictType == "MQ")
                                {
                                    // bypass MQ
                                    if (byPassMQ)
                                    {
                                        oMQSA.DictName = "TRUE";
                                    }
                                    else
                                    {
                                        if (oEmpMQs.Count > 0)
                                        {
                                            if (oEmpMQs.Where(mq => mq.MqNo == oMQSA.DictCode).Count() > 0)
                                            {
                                                oMQSA.DictName = "TRUE";
                                            }
                                        }
                                    }
                                }
                                else if (oMQSA.DictType == "SA")
                                {
                                    if (oEmpSAs.Count > 0)
                                    {
                                        // bypass SA
                                        if (byPassSA)
                                        {
                                            oMQSA.DictName = "TRUE";
                                        }
                                        else
                                        {
                                            if (oEmpSAs.Where(sa => sa.DictCode == oMQSA.DictCode).Count() > 0)
                                            {
                                                oMQSA.DictName = "TRUE";
                                            }
                                        }
                                    }
                                }
                            } // end foreach
                              //***************************************
                              //      CHECK EMPLOYEE HAVE MQ / SA 
                              //***************************************



                        } // end if check have MQ/SA


                        //**** MQ = OK , SA = OK *****
                        if (byPassSA && byPassMQ)
                        {
                            stsUpd = true;
                            oObjUpd.EmpCode = param.EmpCode;
                        }
                        else
                        {
                            if ((!byPassMQ && byPassSA) && oMQSAs.Where(m => m.DictType == "MQ").Count() > 0 && oMQSAs.Where(m => m.DictName == "FALSE" && m.DictType == "MQ").Count() == 0)
                            {
                                stsUpd = true;
                                oObjUpd.EmpCode = param.EmpCode;
                            }
                            else if ((!byPassSA && byPassMQ) && oMQSAs.Where(m => m.DictType == "SA").Count() > 0 && oMQSAs.Where(m => m.DictName == "FALSE" && m.DictType == "SA").Count() == 0)
                            {
                                stsUpd = true;
                                oObjUpd.EmpCode = param.EmpCode;
                            }
                            else if ((!byPassSA && !byPassMQ) && oMQSAs.Count() > 0 && oMQSAs.Where(m => m.DictName == "FALSE").Count() == 0)
                            {
                                stsUpd = true;
                                oObjUpd.EmpCode = param.EmpCode;
                            }
                            else
                            {
                                return Ok(new { status = "0", msg = "not MQ SA" });
                            }
                        }
                    }
                    else
                    {
                        return Ok(new { status = "0", msg = "object is not avaiable" });
                    }

                }
                else if (param.Cktype == "OUT")
                {
                    if (param.EmpCode == oObjUpd.EmpCode)
                    {
                        stsUpd = true;
                        oObjUpd.EmpCode = "";
                    }
                    else
                    {
                        return Ok(new { status = "0", msg = "employee not match" });
                    }
                }

                if (stsUpd)
                {
                    //****** Update Object Check In/Out ********
                    oObjUpd.ObjLastCheckDt = DateTime.Now;
                    _contxMP.MpckObject.Attach(oObjUpd);
                    _contxMP.Entry(oObjUpd).State = EntityState.Modified;
                    int changed = _contxMP.SaveChanges();


                    //****** Insert Log Check In/Out ********
                    MpckCheckInLog oLog = new MpckCheckInLog();
                    oLog.Nbr = oHelper.generateNbr();
                    oLog.Ckdate = param.Ckdate;
                    oLog.Ckshift = param.Ckshift;
                    oLog.Cktype = param.Cktype;
                    oLog.CkdateTime = DateTime.Now;
                    oLog.EmpCode = param.EmpCode;
                    oLog.ObjCode = param.ObjCode;

                    _contxMP.MpckCheckInLog.Attach(oLog);
                    _contxMP.Entry(oLog).State = EntityState.Added;
                    int added = _contxMP.SaveChanges();

                    return (changed == 1) ? Ok(new { status = changed, msg = "OK" }) : Ok(new { status = "0", msg = "can not updated" });
                }
                else
                {
                    return Ok(new { status = "0", msg = "can not updated" });
                }

            }
            else
            {
                return Ok(new { status = "no object data" });
            }
        }


        #endregion

        [HttpPost]
        [Route("/mpck/getManSkills")]
        public IActionResult GetManSkills([FromBody] MModels.MManSkill obj)
        {
            string objCode = obj.objCode;
            MModels.MManSkill resp = new MModels.MManSkill();
            Service serv = new Service(_contextDCI, _contxMP, _contxHRM);
            if (objCode != null)
            {
                resp = serv.GetEmployeeListInMQSA(objCode);
            }
            return Ok(resp);
        }

        [HttpPost]
        [Route("/mpck/setFiles")]
        public async Task<IActionResult> SetFiles(MFiles param)
        {
            var file = param.files;
            string objCode = param.objCode;
            string surn = file.FileName.Split(".").Last();
            string fac = param.fac;
            string line = param.line;
            string fileName = $"{objCode}.{surn.ToLower()}";
            string parentPath = $"..\\DCI_MANPOWER_APP";
            string targetPath = $"\\upload\\FAC{fac}\\LINE{line}";
            string currentPath = $"{parentPath}{targetPath}";
            string newPathFile = $"{currentPath}\\{fileName}";
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }
            if (System.IO.File.Exists(newPathFile))
            {
                System.IO.File.Delete(newPathFile);
            }
            using (Stream stream = new FileStream(newPathFile, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var obj = _contxMP.MpckObject.FirstOrDefault(x => x.ObjCode == objCode);
            if (obj != null)
            {
                var newObject = obj;
                newObject.ObjPicture = $"http://dciweb.dci.daikin.co.jp/dcimanpower/{targetPath}/{fileName}".Replace("/\\", "/").Replace("\\", "/");
                _contxMP.MpckObject.Update(newObject);
                int res = _contxMP.SaveChanges();
                return Ok(new
                {
                    status = res
                });
            }
            else
            {
                return Ok(new
                {
                    status = false
                });
            }
            return Ok(newPathFile);
        }

        [HttpPost]
        [Route("/mpck/updateObject")]
        public async Task<IActionResult> UpdateObject([FromBody] ViMpckObjectList param)
        {
            MpckObject context = await _contxMP.MpckObject.FirstOrDefaultAsync(x => x.ObjCode == param.ObjCode);
            if (context != null)
            {
                context.ObjBackgroundColor = param.ObjBackgroundColor;
                context.ObjBorderColor = param.ObjBorderColor;
                context.ObjTitle = param.ObjTitle;
                context.ObjSubtitle = param.ObjSubtitle;
                context.ObjType = param.ObjType;
                context.ObjWidth = param.ObjWidth;
                context.ObjHeight = param.ObjHeight;
                _contxMP.MpckObject.Update(context);
                int update = await _contxMP.SaveChangesAsync();
                if (update > 0)
                {
                    return Ok(new
                    {
                        status = update,
                        obj = _contxMP.MpckObject.FirstOrDefault(x => x.ObjCode == param.ObjCode)
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = false
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    status = false
                });
            }
        }

        [HttpPost]
        [Route("/mpck/updatePriority")]
        public async Task<IActionResult> UpdateObject([FromBody] MUpdatePriority param)
        {
            string objCode = param.objCode;
            string action = param.objAction;
            bool status = false;
            MpckObject content = _contxMP.MpckObject.FirstOrDefault(x => x.ObjCode == objCode);
            if (content != null)
            {
                string layoutCode = content.LayoutCode;
                int? priority = content.ObjPriority;
                if (action == "up")
                {
                    if (priority != null)
                    {
                        //priority = priority - 1;
                        if (priority >= 0)
                        {
                            MpckObject contentPrev = _contxMP.MpckObject.FirstOrDefault(x => x.LayoutCode == layoutCode && x.ObjPriority > priority);
                            if (contentPrev != null)
                            {
                                int? priorityPrev = content.ObjPriority;
                                content.ObjPriority = contentPrev.ObjPriority;
                                _contxMP.MpckObject.Update(content);
                                int updateCurrent = _contxMP.SaveChanges();
                                if (updateCurrent > 0)
                                {
                                    contentPrev.ObjPriority = priorityPrev;
                                    _contxMP.MpckObject.Update(contentPrev);
                                    int updatePrev = _contxMP.SaveChanges();
                                    if (updatePrev > 0)
                                    {
                                        status = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (action == "down")
                {
                    if (priority != null)
                    {
                        if (priority >= 0)
                        {
                            MpckObject contentPrev = _contxMP.MpckObject.OrderByDescending(x => x.ObjPriority).FirstOrDefault(x => x.LayoutCode == layoutCode && x.ObjPriority < content.ObjPriority);
                            if (contentPrev != null)
                            {
                                int? priorityPrev = contentPrev.ObjPriority;
                                int? priorityContent = content.ObjPriority;
                                content.ObjPriority = priorityPrev;
                                _contxMP.MpckObject.Update(content);
                                int updateCurrent = _contxMP.SaveChanges();
                                if (updateCurrent > 0)
                                {
                                    contentPrev.ObjPriority = priorityContent;
                                    _contxMP.MpckObject.Update(contentPrev);
                                    int updatePrev = _contxMP.SaveChanges();
                                    if (updatePrev > 0)
                                    {
                                        status = true;
                                    }
                                }
                            }
                        }
                    }
                }
                if (action == "change" && param.prev != null && param.next != null && param.prev != param.next)
                {
                    int prev = param.prev;
                    int next = param.next;
                    var contextPrev = _contxMP.MpckObject.FirstOrDefault(x => x.LayoutCode == layoutCode && x.ObjPriority == prev);
                    var contextNext = _contxMP.MpckObject.FirstOrDefault(x => x.LayoutCode == layoutCode && x.ObjPriority == next);
                    if (contextPrev != null && contextNext != null)
                    {
                        contextPrev.ObjPriority = next;
                        contextNext.ObjPriority = prev;
                        _contxMP.MpckObject.Update(contextPrev);
                        _contxMP.MpckObject.Update(contextNext);
                    }
                    int updateChange = _contxMP.SaveChanges();
                    if (updateChange > 0)
                    {
                        status = true;
                    }
                }
                if (action == "back")
                {
                    List<MpckObject> listObj = await _contxMP.MpckObject.Where(x => x.LayoutCode == layoutCode && x.ObjCode != content.ObjCode).OrderBy(x => x.ObjPriority).ToListAsync();
                    content.ObjPriority = 0;
                    int newPriority = 1;
                    foreach (MpckObject item in listObj)
                    {
                        item.ObjPriority = newPriority;
                        newPriority++;
                        _contxMP.MpckObject.Update(item);
                    }
                    int updateBack = await _contxMP.SaveChangesAsync();
                    if (updateBack > 0)
                    {
                        status = true;
                    }
                }
                if (action == "front")
                {
                    List<MpckObject> listObj = await _contxMP.MpckObject.Where(x => x.LayoutCode == layoutCode && x.ObjCode != content.ObjCode).OrderBy(x => x.ObjPriority).ToListAsync();
                    int? lastPriority = listObj.LastOrDefault() != null ? listObj.LastOrDefault().ObjPriority : 100;
                    content.ObjPriority = lastPriority;
                    int? newPriority = lastPriority - 1;
                    _contxMP.MpckObject.Update(content);
                    listObj = listObj.OrderByDescending(x => x.ObjPriority).ToList();
                    foreach (MpckObject item in listObj.OrderByDescending(x => x.ObjPriority))
                    {
                        item.ObjPriority = newPriority;
                        newPriority--;
                        _contxMP.MpckObject.Update(item);
                    }
                    int updateBack = await _contxMP.SaveChangesAsync();
                    if (updateBack > 0)
                    {
                        status = true;
                    }
                }
            }
            return Ok(new
            {
                status = status
            });
        }


        [HttpPost]
        [Route("/mpck/editObject")]
        public async Task<IActionResult> editObject([FromBody] MpckObject param)
        {
            bool status = false;
            string objCode = param.ObjCode;
            string position = param.ObjPosition;
            MpckObject content = await _contxMP.MpckObject.FirstOrDefaultAsync(x => x.ObjCode == objCode);
            if (content != null)
            {
                content.ObjPosition = position;
                _contxMP.MpckObject.Update(content);
                int update = await _contxMP.SaveChangesAsync();
                if (update > 0)
                {
                    status = true;
                }
            }
            return Ok(new
            {
                status = status
            });
        }

        [HttpPost]
        [Route("/mpck/getDataAndonboard")]
        public async Task<IActionResult> getDataAndonBoard([FromBody] DataLog param)
        {
            string boardId = param.BoardId;
            List<DataLog> res = new List<DataLog>();

            if (boardId != null)
            {
                if (boardId.Contains(';'))
                {
                    string[] listBoard = boardId.Split(';');

                    foreach (string board in listBoard)
                    {
                        DataLog item = new DataLog();
                        BoardDatum boardData = await _contextPDB.BoardData.FirstOrDefaultAsync(x => x.BoardId == board);
                        item = await _contextPDB.DataLogs.OrderByDescending(x => x.LogTime).FirstOrDefaultAsync(x => x.BoardId == board && x.Status == "Run");
                        if (boardData != null)
                        {
                            item.Status = boardData.PdName;
                        }
                        res.Add(item);
                    }
                }
            }

            return Ok(res);

        }

        [HttpGet]
        [Route("/mpck/getListAndonBoard")]
        public IActionResult GetBoard(string boardId)
        {
            List<BoardDatum> listAndonBoard = _contextPDB.BoardData.ToList();
            return Ok(listAndonBoard);
        }
    }
}
