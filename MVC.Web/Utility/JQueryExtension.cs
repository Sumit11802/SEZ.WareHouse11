using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MVC.Web
{
    public static class JQueryExtensions
    {
        sealed class JQueryHelperResult : ActionResult
        {
            public JQueryHelperResult(string message)
            {
                Message = message ?? string.Empty;
            }

            string Message { get; set; }

            public override void ExecuteResult(ControllerContext context)
            { 
                      
                context.HttpContext.Response.Write("<script>   window.location.assign('" + Message + "')   </script>");
            }
        }

        #region CSharpExtension
        public static string StarkFileUploaderCSharp(HttpPostedFileBase ProfilePic, string SavePath)
        {
            //if (!per())
            //{
            //    return "";
            //}
            string extension = Path.GetExtension(ProfilePic.FileName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ProfilePic.FileName);
            string text = Path.GetFileNameWithoutExtension(ProfilePic.FileName) + DateTime.Now.ToString("ddMMyyyyhhmmss") + extension;
            ProfilePic.SaveAs(Path.Combine(SavePath, text));
            return text;
        }



        #endregion

        #region ExtensionForJqueryActivity

      
        public static string GetSiteRoot()
        {
            string result = "";
            if (HttpContext.Current != null)
            {
                string text = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
                text = ((text != null && !(text == "80") && !(text == "443")) ? (":" + text) : string.Empty);
                string text2 = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];
                text2 = ((text2 != null && !text2.Equals("0")) ? "https://" : "http://");
                string text3 = HttpContext.Current.Request.ApplicationPath;
                if (text3 == "/")
                {
                    text3 = "";
                }
                result = text2 + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] + text + text3;
            }
            return result;
        }

        public static MvcHtmlString StarkAjaxJquery(this HtmlHelper stark, string JsonData, string url, string type, string contentType, string AfterSuccessJsCode, string AfterErrorJsCode)
        {
            //if (!per())
            //{
            //    return new MvcHtmlString("");
            //}
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<script type=\"text/javascript\">");
            stringBuilder.AppendLine("$(document).ready(function () {");
            stringBuilder.AppendLine("var dataRow = {");
            stringBuilder.AppendLine(JsonData.TrimEnd(',') ?? "");
            stringBuilder.AppendLine("}");
            stringBuilder.AppendLine("    $.ajax({");
            stringBuilder.AppendLine("        url: '" + url + "',");
            stringBuilder.AppendLine("        type: '" + type + "',");
            stringBuilder.AppendLine("        data: dataRow,");
            stringBuilder.AppendLine("        contentType: " + contentType + ",");
            stringBuilder.AppendLine("        success: function (data) {");
            stringBuilder.AppendLine("                 " + AfterSuccessJsCode);
            stringBuilder.AppendLine("        },");
            stringBuilder.AppendLine("       error: function (data) {");
            stringBuilder.AppendLine("                " + AfterErrorJsCode);
            stringBuilder.AppendLine("       }");
            stringBuilder.AppendLine("    });");
            stringBuilder.AppendLine("});");
            stringBuilder.AppendLine("</script>");
            return new MvcHtmlString(stringBuilder.ToString());
        }

     

        #endregion
    }
}
