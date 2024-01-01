using SeyahatRehberi.Entity.Interface;
using SeyahatRehberi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Entity
{
    public class BlogProccess : ICrud<BlogPosts>
    {
        DataContext db = new DataContext();
        public string Add(BlogPosts entity)
        {
            string result = "";

            try
            {
                var blog = db.BlogPosts.FirstOrDefault(x => x.Name == entity.Name);

                if (blog == null)
                {
                    db.BlogPosts.Add(entity);
                    db.SaveChanges();
                    result = entity.Name + " adlı bloğunuz eklendi";
                }
                else
                {
                    result = entity.Name + "Bu isimde zaten bir Blog paylaştınız. Başka bir Blog ismi deneyebilirsiniz.";
                }
            }
            catch (Exception ex)
            {
                result += ex.Message;
            }
            return result;
        }

        public bool Delete(int id)
        {
            var Blog = db.BlogPosts.Find(id);

            if (Blog != null)
            {
                Blog.IsDelete = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public BlogPosts Get(int id)
        {
            var Blog = db.BlogPosts.FirstOrDefault(x => x.Id == id && !x.IsDelete);

            return Blog;
        }

        public List<BlogPosts> GetAll()
        {
            return db.BlogPosts.Where(x => x.IsDelete).ToList();
        }

        public Role Proccess(Role role)
        {
            throw new NotImplementedException();
        }

        public bool Update(BlogPosts entity, int id)
        {
            var Blog = db.BlogPosts.FirstOrDefault(x => x.Id == id && !x.IsDelete);
            if (Blog != null)
            {
                Blog.Name = entity.Name;
                Blog.IsStatus = entity.IsStatus;
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}