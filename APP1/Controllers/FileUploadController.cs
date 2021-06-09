using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace WebApplication2.Controllers
{
    public class FileUploadController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post()
        {
            List<string> imageLinks = new List<string>();
            var httpContext = HttpContext.Current;

            // Check for any uploaded file  
            if (httpContext.Request.Files.Count > 0)
            {
                //Loop through uploaded files  
                for (int i = 0; i < httpContext.Request.Files.Count; i++)
                {
                    HttpPostedFile httpPostedFile = httpContext.Request.Files[i];

                    // this is an example of how you can extract addional values from the Ajax call
                    string name = httpContext.Request.Form["name"];

                    if (httpPostedFile != null)
                    {
                        DateTime dt = DateTime.Now;

                        // Construct file save path  
                        //var fileSavePath = Path.Combine(HostingEnvironment.MapPath(ConfigurationManager.AppSettings["fileUploadFolder"]), httpPostedFile.FileName);
                        string fname = httpPostedFile.FileName.Split('\\').Last();

                        string namebak = dt.Year + "-" + dt.Month + "-" + dt.Day + "-" + dt.Hour + "-" + dt.Minute + "-" + dt.Second + "-" + name;
                        var fileSavePath = Path.Combine(HostingEnvironment.MapPath("~/uploaded_Files"), name);
                        var bakfileSavePath = Path.Combine(HostingEnvironment.MapPath("~/uploaded_Files"), namebak);

                        // Save the uploaded file
                        httpPostedFile.SaveAs(fileSavePath);
                        httpPostedFile.SaveAs(bakfileSavePath);


                        imageLinks.Add("uploaded_Files/" + namebak);
                        imageLinks.Add("uploaded_Files/"+ fname);
                    }
                }
            }

            // Return status code  
            return Request.CreateResponse(HttpStatusCode.Created, imageLinks);
        }

    }
}
