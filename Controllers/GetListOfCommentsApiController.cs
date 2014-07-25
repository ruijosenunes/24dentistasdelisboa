using _24dentistasdelisboa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.WebApi;

namespace _24dentistasdelisboa.Controllers
{
    public class GetListOfCommentsApiController : UmbracoApiController
    {

        public List<CommentViewModel> GetListOfCommentsForPage()
        {
            UmbracoHelper helper = new UmbracoHelper(this.UmbracoContext);

 //           IPublishedContent content = helper.TypedContent(PageId);

            IPublishedContent content = helper.TypedContentAtRoot().FirstOrDefault();

            List<CommentViewModel> ListOfComments = new List<CommentViewModel>();

            var ListOfCommentsContent = content.DescendantsOrSelf("Comment");

            foreach (var item in ListOfCommentsContent)
            {
                if (item.ContentType.Alias == "Comment")
                {
                    ListOfComments.Add(new CommentViewModel
                    {
                        Name = item.GetPropertyValue("name").ToString(),
                        Email = item.GetPropertyValue("email").ToString(),
                        Comment = item.GetPropertyValue("comment").ToString(),
                        DateAndTime = item.GetPropertyValue("dateAndTime").ToString()
                    });
                }

            }

            return ListOfComments;
        }

    }
}
