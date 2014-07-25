using _24dentistasdelisboa.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace _24dentistasdelisboa.Controllers
{
    public class CommentFormSurfaceController : SurfaceController
    {
        //
        // GET: /CommentFormSurface/

        public ActionResult Index()
        {
            return PartialView("CommentForm", new CommentViewModel());
        }

        [HttpPost]
        public ActionResult HandleFormSubmit(CommentViewModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();

            var newComment = Services.ContentService.CreateContent("comentario", CurrentPage.Id, "Comment");
            
            CultureInfo culture = new CultureInfo("pt");
            DateTime dt = DateTime.Now;

            newComment.SetValue("name", model.Name);
            newComment.SetValue("email", model.Email);
            newComment.SetValue("comment", model.Comment);
            newComment.SetValue("dateAndTime", dt.ToString("g", culture));
            newComment.SetValue("umbracoNaviHide", true);
            newComment.SetValue("hideInFooter", true);
            

            Services.ContentService.SaveAndPublishWithStatus(newComment);

            return RedirectToCurrentUmbracoPage();

        }
    }
}
