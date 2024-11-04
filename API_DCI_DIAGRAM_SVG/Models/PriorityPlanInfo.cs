using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for PriorityPlanInfo
/// </summary>
public class PriorityPlanInfo
{

    public PriorityPlanInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int row = 0;
    private string seq = "";
    private string p_wcno = "";
    private string p_group = "";
    private string p_model = "";
    private string p_startdate = "";
    private string p_starttime = "";
    private string p_enddate = "";
    private string p_endtime = "";
    private string p_modelcode = "";
    private double p_palnqty = 0;
    private string p_mc = "";
    private double p_planqty = 0;
    public string subline { get; set; }
    //private List<string> _p_comment = new List<string>();
    private List<PriorityPlanSubInfo> _p_packing = new List<PriorityPlanSubInfo>();
    private List<PackingData> packingList = new List<PackingData>();

    private string p_comment = "";
    private string p_packing = "";
    private double p_palletqty = 0;
    private string plancode = "";
    private string p_rev = "";
    private string p_plancode = "";

    private DateTime p_StartDateT = new DateTime();
    private double plqty = 0;

    public string P_wcno
    {
        get
        {
            return p_wcno;
        }

        set
        {
            p_wcno = value;
        }
    }

    public string P_group
    {
        get
        {
            return p_group;
        }

        set
        {
            p_group = value;
        }
    }

    public string P_model
    {
        get
        {
            return p_model;
        }

        set
        {
            p_model = value;
        }
    }

    public string P_startdate
    {
        get
        {
            return p_startdate;
        }

        set
        {
            p_startdate = value;
        }
    }

    public string P_starttime
    {
        get
        {
            return p_starttime;
        }

        set
        {
            p_starttime = value;
        }
    }

    public string P_enddate
    {
        get
        {
            return p_enddate;
        }

        set
        {
            p_enddate = value;
        }
    }

    public string P_endtime
    {
        get
        {
            return p_endtime;
        }

        set
        {
            p_endtime = value;
        }
    }

    public string P_modelcode
    {
        get
        {
            return p_modelcode;
        }

        set
        {
            p_modelcode = value;
        }
    }

    public double P_palnqty
    {
        get
        {
            return p_palnqty;
        }

        set
        {
            p_palnqty = value;
        }
    }

    //public List<string> _P_comment
    //{
    //    get
    //    {
    //        return _p_comment;
    //    }

    //    set
    //    {
    //        _p_comment = value;
    //    }
    //}

    public List<PriorityPlanSubInfo> _P_packing
    {
        get
        {
            return _p_packing;
        }

        set
        {
            _p_packing = value;
        }
    }



    public DateTime P_StartDateT
    {
        get
        {
            return p_StartDateT;
        }

        set
        {
            p_StartDateT = value;
        }
    }

    public double Plqty
    {
        get
        {
            return plqty;
        }

        set
        {
            plqty = value;
        }
    }

    public int Row
    {
        get
        {
            return row;
        }

        set
        {
            row = value;
        }
    }

    public string P_comment
    {
        get
        {
            return p_comment;
        }

        set
        {
            p_comment = value;
        }
    }

    public string P_packing
    {
        get
        {
            return p_packing;
        }

        set
        {
            p_packing = value;
        }
    }

    public double P_palletqty
    {
        get
        {
            return p_palletqty;
        }

        set
        {
            p_palletqty = value;
        }
    }

    public string Plancode
    {
        get
        {
            return plancode;
        }

        set
        {
            plancode = value;
        }
    }

    public string Seq
    {
        get
        {
            return seq;
        }

        set
        {
            seq = value;
        }
    }

    public string P_mc
    {
        get
        {
            return p_mc;
        }

        set
        {
            p_mc = value;
        }
    }

    public string P_rev
    {
        get
        {
            return p_rev;
        }

        set
        {
            p_rev = value;
        }
    }

    public string P_plancode
    {
        get
        {
            return p_plancode;
        }

        set
        {
            p_plancode = value;
        }
    }

    public double P_planqty
    {
        get
        {
            return p_planqty;
        }

        set
        {
            p_planqty = value;
        }
    }

    public List<PackingData> PackingList
    {
        get
        {
            return packingList;
        }

        set
        {
            packingList = value;
        }
    }
}

public class PackingData
{
    private string p_MODEL = "";
    private string p_PACKING = "";
    private string p_comment = "";
    private decimal p_QTYPLAN = 0;
    private decimal p_QTYSTD = 0;
    private decimal p_PALLETQTY = 0;
    private decimal p_REPORT_QTY = 0;
    public string P_MODEL
    {
        get
        {
            return p_MODEL;
        }

        set
        {
            p_MODEL = value;
        }
    }

    public string P_PACKING
    {
        get
        {
            return p_PACKING;
        }

        set
        {
            p_PACKING = value;
        }
    }

    public decimal P_QTYSTD
    {
        get
        {
            return p_QTYSTD;
        }

        set
        {
            p_QTYSTD = value;
        }
    }

    public decimal P_PALLETQTY
    {
        get
        {
            return p_PALLETQTY;
        }

        set
        {
            p_PALLETQTY = value;
        }
    }
    // PEERAPONG ADD 20240527
    public decimal P_REPORT_QTY
    {
        get
        {
            return p_REPORT_QTY;
        }

        set
        {
            p_REPORT_QTY = value;
        }
    }
    public decimal P_QTYPLAN
    {
        get
        {
            return p_QTYPLAN;
        }

        set
        {
            p_QTYPLAN = value;
        }
    }

    public string P_comment
    {
        get
        {
            return p_comment;
        }

        set
        {
            p_comment = value;
        }
    }
}

public class PriorityInfo
{
    private DateTime p_prdstart_dt = new DateTime();
    private string p_model = "";
    private string p_maincode = "";
    private string p_masteroperationcode = "";
    private string p_mainresource = "";
    private string p_order = "";

    public DateTime P_prdstart_dt
    {
        get
        {
            return p_prdstart_dt;
        }

        set
        {
            p_prdstart_dt = value;
        }
    }

    public string P_model
    {
        get
        {
            return p_model;
        }

        set
        {
            p_model = value;
        }
    }

    public string P_maincode
    {
        get
        {
            return p_maincode;
        }

        set
        {
            p_maincode = value;
        }
    }

    public string P_masteroperationcode
    {
        get
        {
            return p_masteroperationcode;
        }

        set
        {
            p_masteroperationcode = value;
        }
    }

    public string P_mainresource
    {
        get
        {
            return p_mainresource;
        }

        set
        {
            p_mainresource = value;
        }
    }

    public string P_order
    {
        get
        {
            return p_order;
        }

        set
        {
            p_order = value;
        }
    }
}


public class ProductionActualInfo
{
    private string p_prd_line = "";
    private string p_wcno = "";
    private DateTime p_prd_date = new DateTime();
    private string p_modelcode = "";
    private string p_model = "";
    private double p_act_qty = 0;

    public string P_prd_line
    {
        get
        {
            return p_prd_line;
        }

        set
        {
            p_prd_line = value;
        }
    }

    public string P_wcno
    {
        get
        {
            return p_wcno;
        }

        set
        {
            p_wcno = value;
        }
    }

    public DateTime P_prd_date
    {
        get
        {
            return p_prd_date;
        }

        set
        {
            p_prd_date = value;
        }
    }

    public double P_act_qty
    {
        get
        {
            return p_act_qty;
        }

        set
        {
            p_act_qty = value;
        }
    }

    public string P_model
    {
        get
        {
            return p_model;
        }

        set
        {
            p_model = value;
        }
    }

    public string P_modelcode
    {
        get
        {
            return p_modelcode;
        }

        set
        {
            p_modelcode = value;
        }
    }
}