using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
//using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

/// <summary>
/// Uses Logging Application Block to Log Errors
/// </summary>
public static class LovRubLogger
{
    public static void LogException(Exception ex)
    {
        int i = 0;
        
        if (null == ex) return;

        string message = ex.Message +
                        "\nSOURCE" + i.ToString() + ": " + ex.Source +
                        "\nTARGETSITE"  + i.ToString() + ": " + ex.TargetSite +
                        "\nSTACKTRACE"  + i.ToString() + ": " + ex.StackTrace;

        i++;
		while(ex.InnerException != null) 
        {
            message += ex.InnerException.Message +
                            "\nSOURCE" + i.ToString() + ": " + ex.InnerException.Source +
                            "\nTARGETSITE" + i.ToString() + ": " + ex.InnerException.TargetSite +
                            "\nSTACKTRACE" + i.ToString() + ": " + ex.InnerException.StackTrace;
            ex = ex.InnerException;
            i++;
		}

        Logger.Write(message);
    }


    public static void LogException(Exception ex, string strDescription)
    {
        int i = 0;

        if (null == ex) return;
        if (null == strDescription)
            strDescription = " ";

        string message = ex.Message +
                        "\nSOURCE" + i.ToString() + ": " + ex.Source +
                        "\nTARGETSITE" + i.ToString() + ": " + ex.TargetSite +
                        "\nSTACKTRACE" + i.ToString() + ": " + ex.StackTrace;

        i++;
        while (ex.InnerException != null)
        {
            message += ex.InnerException.Message +
                            "\nSOURCE" + i.ToString() + ": " + ex.InnerException.Source +
                            "\nTARGETSITE" + i.ToString() + ": " + ex.InnerException.TargetSite +
                            "\nSTACKTRACE" + i.ToString() + ": " + ex.InnerException.StackTrace;

            ex = ex.InnerException;
            i++;
        }

        message += "\nDESCRIPTION:" + strDescription;

        Logger.Write(message);
    }

}
