using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using _24dentistasdelisboa.Models;
using System.Net.Mail;
using System.Globalization;
using umbraco;

namespace _24dentistasdelisboa.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {
        //
        // GET: /ContactFormSurface/

        [ChildActionOnly]
        public ActionResult GenerateContactForm(int returnPageId, int thankYouPageId)
        {
            return PartialView("ContactForm", new ContactFormViewModel
                                {
                                    ReturnPageId = returnPageId,
                                    ThankYouPageId = thankYouPageId

                                });
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(ContactFormViewModel model)
        {
            // send email from the post inserted
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            MailMessage message = new MailMessage();
            message.To.Add("rui_jose_nunes@hotmail.com");
            message.Subject = "New contact detals";
            message.From = new System.Net.Mail.MailAddress(model.ContactEmail, model.ContactName);
            message.Body = model.ContactMessage;

            SmtpClient client = new SmtpClient();

            try { client.Send(message); }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());

            }



            //var thankYouPageUrl = library.NiceUrl(model.ThankYouPageId);

            //var thankYouPageUrl2 = thankYouPageUrl + "?id=";

            //var thankYouPageUrl3 = thankYouPageUrl2 + model.ReturnPageId.ToString();

            var thankYouPageUrl = library.NiceUrl(model.ThankYouPageId) + "?id=" + model.ReturnPageId.ToString(); 

            Response.Redirect(thankYouPageUrl);

            return CurrentUmbracoPage();


        }
       

    }
}
