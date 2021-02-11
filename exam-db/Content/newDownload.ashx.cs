using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using exam_db.Models;

namespace exam_db.Content
{
    /// <summary>
    /// Summary description for newDownload
    /// </summary>
    public class newDownload : IHttpHandler
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var form = context.Request.Form;
            int id = int.Parse(context.Request.QueryString["id"]);
            File file = db.Files.Find(id);
            file.Download_number = file.Download_number + 1;

            db.Entry(file).State = EntityState.Modified;
            db.SaveChanges();
            context.Response.Write(true);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}