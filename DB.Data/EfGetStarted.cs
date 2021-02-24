using Org.Tao.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Org.Tao.DB.Data
{
    public class EfGetStarted
    {
        private static void Main()
        {
            using (var db = new CommonDataContext())
            {
                // Note: This sample requires the database to be created before running.

                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new TagInfo { TagName = "00100001", FishClassName = "大头鱼" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var tagInfo = db.TagInfos
                    .OrderBy(b => b.TagName)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                tagInfo.FishClassName = "大头鱼吗?";
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(tagInfo);
                db.SaveChanges();
            }
        }
    }
}
