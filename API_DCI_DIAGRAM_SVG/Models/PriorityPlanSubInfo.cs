using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PriorityPlanSubInfo
/// </summary>
public class PriorityPlanSubInfo
{
    public PriorityPlanSubInfo()
    {

    }

    private string p_wcno = "";
    private string p_group = "";
    private string p_model = "";
    private string p_startdate = "";
    private string p_starttime = "";
    private string p_enddate = "";
    private string p_endtime = "";
    private string p_modelcode = "";
    private double p_palnqty = 0;
    private string p_comment = "";
    private string p_packing = "";
    private double p_palletqty = 0;
    private string p_plancode = "";
    private string p_rev;

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
}