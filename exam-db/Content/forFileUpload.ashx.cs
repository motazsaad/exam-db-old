
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;

public class forFileUpload : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";

        string dirFullPath = HttpContext.Current.Server.MapPath("~/Content/MediaUploader/");
        string[] files;
        int numFiles;
        files = System.IO.Directory.GetFiles(dirFullPath);
        numFiles = files.Length;
        numFiles = numFiles + 1;

        string str_image = "";
        string fileExtension = "";

        foreach (string s in context.Request.Files)
        {
            HttpPostedFile file = context.Request.Files[s];
            //  int fileSizeInBytes = file.ContentLength;
            string fileName = file.FileName;
            fileExtension = file.ContentType;

            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = "MyFILE_" + numFiles.ToString() + fileExtension;
                string pathToSave_100 = HttpContext.Current.Server.MapPath("~/Content/MediaUploader/") + str_image;
                file.SaveAs(pathToSave_100);
            }
        }

        context.Response.Write(str_image);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}