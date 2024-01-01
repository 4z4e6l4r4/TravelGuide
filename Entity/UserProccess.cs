using SeyahatRehberi.Entity.Interface;
using SeyahatRehberi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeyahatRehberi.Entity
{
    public class UserProccess : ICrud<Users>
    {
        DataContext db = new DataContext();
        public string Add(Users entity)
        {
            string result = "";
            var user = db.Users.FirstOrDefault(x => x.Email == entity.Email);
            if (user == null &&
                !String.IsNullOrWhiteSpace(entity.Name) &&
                !String.IsNullOrWhiteSpace(entity.Email) &&
                !String.IsNullOrWhiteSpace(entity.Password)
                )
            {
                db.Users.Add(entity);
                db.SaveChanges();
                result = entity.Email + " Kullanıcı ekleme işleminiz başarılı.";
            }
            else
            {
                result = entity.Email + " Mail adresi daha önce kullanılmış. Farklı bir mail adresi ile deneyebilirsiniz";
            }
            return result;
        }

        public bool Delete(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id && !x.IsDelete);
            if (user != null)
            {
                user.IsDelete = true;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Users Get(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id==id && !x.IsDelete);
            return user;
        }

        public List<Users> GetAll()
        {
            //INCLUDE EKLEME PROBLEMİ   yeniden bak
            return db.Users.Where(x => !x.IsDelete).Include(u => u.Role).ToList();
        }

        public bool Update(Users entity, int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id== id && !x.IsDelete);
            if (user != null)
            {
                user.Name = entity.Name;
                user.IsStatus = entity.IsStatus;
                user.RoleId = entity.RoleId;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public string PasswordChange(int id, string oldPassword, string newPassword, string newPasswordRepeat)
        {
            string result = "";

            var user = db.Users.FirstOrDefault(x => x.Id==id && !x.IsDelete);
            if (user != null)
            {
                if (user.Password==oldPassword)
                {
                    if (user.Password != newPassword)
                    {
                        if (newPassword == newPasswordRepeat)
                        {
                            user.Password = newPassword;
                            db.SaveChanges();
                            result = "Şifre Değiştirme Başarılı";
                        }
                        else
                        {
                            result = "Girilen yeni şifreler aynı değil. Lütfen tekrar deneyiniz.";
                        }
                    }
                    else
                    {
                        result = "Eski şifrenizi kullanamazsınız. Lütfen yeniden deneyiniz.";
                    }
                }
                else
                {
                    result = "Şifreniz Hatalı";
                }
            }
            else
            {
                result = "Kullanıcı Bulunamadı";
            }
            return result;
        }

        public Role Proccess(Role role)
        {
            throw new NotImplementedException();
        }
    }
}