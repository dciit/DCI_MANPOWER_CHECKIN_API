using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace API_DCI_DIAGRAM_SVG.Controllers
{
    public class SvgController : Controller
    {
        private readonly DBDCI _contextDCI;

        public SvgController(DBDCI contextDCI)
        {
            _contextDCI = contextDCI;
        }

        [HttpGet]
        [Route("/master/equipment")]
        public IActionResult masterEquipment()
        {
            var content = _contextDCI.LnsEquipmentMasters.Where(x => x.ObjW == 0 && x.ObjH == 0).OrderByDescending(x => x.ObjId).ToList();
            return Ok(content);
        }

        [HttpGet]
        [Route("/master/equipment/id/{id}")]
        public IActionResult masterEquipmentById(string id = "")
        {


            DateTime dtNow = DateTime.Now;
            //DateTime.Now.ToString("yyyy-MM-dd") + " 08:00:00     ====>  "
            DateTime dtStart = DateTime.Parse(DateTime.Now.ToString() + " 08:00:00");

            var content = _contextDCI.LnsEquipmentMasters.Where(x => x.ObjId == id).FirstOrDefault();
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
            var content = _contextDCI.LnsEquipmentMasters.Where(x => x.ObjId == param.ObjId).FirstOrDefault();
            if (content == null)
            {
                param.ObjW = 0;
                param.ObjH = 0;
                _contextDCI.LnsEquipmentMasters.Add(param);
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
            var content = _contextDCI.LnsEquipmentMasters.Where(x => x.ObjId == param.ObjId).FirstOrDefault();
            if (content != null)
            {
                content.ObjW = 0;
                content.ObjH = 0;
                content.ObjSvg = param.ObjSvg;
                _contextDCI.LnsEquipmentMasters.Update(content);
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
            var equipment = _contextDCI.LnsEquipments.FirstOrDefault(x => x.EqpId == param.EqpId);
            if (equipment != null)
            {
                double condDays = equipment.ObjMstNextYear == 1 ? 30 : 10;  // -30
                double diffDays = Math.Ceiling(((DateTime)equipment.EqpNextCheckDt - DateTime.Now).TotalDays); // 14
                if (diffDays >= (condDays * -1) && diffDays <= condDays)
                {
                    param.Nbr = _contextDCI.LnsEquipmentCheckLogs.Count().ToString();
                    param.EqpCheckDt = DateTime.Now;
                    param.EqpNextCheckDt = equipment.EqpNextCheckDt;
                    param.EqpStatus = status == "true" ? "normal" : "abnormal";
                    param.EqpCheckBy = param.EqpCheckBy;
                    _contextDCI.LnsEquipmentCheckLogs.Add(param);
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
            var content = _contextDCI.LnsEquipments.ToList();
            return Ok(content);
        }


        [HttpGet]
        [Route("/equipment/get/id/{eqpId}")]
        public IActionResult GetEquipments(string eqpId)
        {
            var content = (from eqp in _contextDCI.LnsEquipments.Where(x => x.EqpId == eqpId).ToList()
                           join emp in _contextDCI.Employees
                           on eqp.EqpLastCheckBy equals emp.Code
                           join master in _contextDCI.LnsEquipmentMasters
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
            var context = (from eqp in _contextDCI.LnsEquipments.DefaultIfEmpty()
                           join obj in _contextDCI.LnsEquipmentMasters
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
                               Status = (_contextDCI.LnsEquipmentCheckLogs.Where(x => x.EqpId == eqp.EqpId).OrderByDescending(x => x.EqpCheckDt).FirstOrDefault().EqpStatus)
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
            var ObjIdMaster = _contextDCI.LnsEquipments.Where(x => x.ObjId.StartsWith(param.ObjId)).ToList().LastOrDefault();
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
            _contextDCI.LnsEquipments.Add(param);
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
            var content = _contextDCI.LnsEquipmentMasters.Where(x => x.ObjId == id).FirstOrDefault();
            if (content != null)
            {
                _contextDCI.LnsEquipmentMasters.Remove(content);
            }
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
        }

        [HttpPost]
        [Route("/equipment/delete")]
        public IActionResult DeleteEquipment([FromBody] LnsEquipment param)
        {
            var content = _contextDCI.LnsEquipments.FirstOrDefault(x => x.EqpId == param.EqpId);
            if (content != null)
            {
                _contextDCI.LnsEquipments.Remove(content);
            }
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
        }


        [HttpPost]
        [Route("/layout/add")]
        public IActionResult AddLayout([FromBody] LnsLayout param)
        {
            _contextDCI.LnsLayouts.Add(param);
            int res = _contextDCI.SaveChanges();
            return Ok(new { status = res });
        }

        [HttpGet]
        [Route("/layout")]
        public IActionResult GetLayouts()
        {
            var content = _contextDCI.LnsLayouts.OrderBy(x => x.LayoutCode).ToList();
            return Ok(content);
        }

        [HttpGet]
        [Route("/layout/{layoutCode}")]
        public IActionResult GetLayoutsByCode(string layoutCode)
        {
            var content = _contextDCI.LnsLayouts.Where(x => x.LayoutCode == layoutCode).OrderBy(x => x.LayoutCode).ToList();
            return Ok(content);
        }

        [HttpGet]
        [Route("/layout/equipment/del/{eqpId}")]
        public IActionResult DelEquipmentOfLayout(string eqpId)
        {
            var content = _contextDCI.LnsEquipments.FirstOrDefault(x => x.EqpId == eqpId);
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
            var equipmentLog = _contextDCI.LnsEquipmentCheckLogs.ToList();
            if (id != "" && id != "ALL")
            {
                equipmentLog = equipmentLog.Where(x => x.EqpId == id).ToList();
            }
            var content = from eqpLog in equipmentLog
                          join emp in _contextDCI.Employees
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
            var layout = _contextDCI.LnsLayouts.FirstOrDefault(x => x.LayoutCode == layoutCode);
            var content = from eqp in _contextDCI.LnsEquipments.Where(x => x.LayoutCode == layoutCode).ToList()
                          join master in _contextDCI.LnsEquipmentMasters
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
            var content = _contextDCI.LnsEquipments.Where(x => x.EqpId == param.EqpId).ToList();
            foreach (LnsEquipment equipment in content)
            {
                equipment.EqpX = param.EqpX;
                equipment.EqpY = param.EqpY;
                _contextDCI.LnsEquipments.Update(equipment).Property(x => x.EqpPriority).IsModified = false;
            }
            int res = _contextDCI.SaveChanges();
            return Ok(new
            {
                status = res
            });
        }

    }
}
