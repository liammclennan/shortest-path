using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Send : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var message = new MailMessage(GetOptionalParameter("Email", "SendTo"), ConfigurationManager.AppSettings["SendTo"]);
        message.Subject = GetOptionalParameter("Subject");
        message.Body = BuildBody();
        message.IsBodyHtml = false;

        var smtp = new SmtpClient();
        smtp.Send(message);

        Response.Redirect(GetOptionalParameter("Redirect"));
    }

    private string BuildBody()
    {
        var builder = new StringBuilder();
        for (int i = 0; i < Request.Form.Count; i++)
        {
            if (!Request.Form[i].Equals("Send") 
                && !Request.Form.AllKeys[i].Equals("Subject")
                && !Request.Form.AllKeys[i].Equals("Email")
                && !Request.Form.AllKeys[i].Equals("Redirect")) 
                builder.Append(Request.Form.AllKeys[i] + " " + Request.Form[i] + " \n");
        }
        return builder.ToString();
    }

    private string GetOptionalParameter(string formValueName, string appSettingKey)
    {
        return Request.Form.AllKeys.Contains(formValueName) && !String.IsNullOrEmpty(Request.Form[formValueName])
                   ? Request.Form[formValueName]
                   : ConfigurationManager.AppSettings[appSettingKey];
    }

    private string GetOptionalParameter(string formValueName)
    {
        return GetOptionalParameter(formValueName, formValueName);
    }
}
