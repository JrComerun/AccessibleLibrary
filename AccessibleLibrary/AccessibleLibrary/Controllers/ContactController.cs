using AccessibleLibrary.DAL;
using AccessibleLibrary.Extensions;
using AccessibleLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _usermanager;
        public ContactController(AppDbContext db, UserManager<AppUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }
        public IActionResult Index()
        {
           
            return View();
        }
      
        public async Task<IActionResult> ContactUs(string Email, string Subject, string Message, string Name)
        {

            if (Subject == null || Message == null)
            {
                return Content("Mesajı yollaya bilmədiz zəhmət olmasa bütün xanaları düzgün şəkildə doldurasınız!");
            }

            else
            {
                if (User.Identity.IsAuthenticated)
                {
                    AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                    ContactUs contactUs = new ContactUs
                    {
                        Name = user.Name,
                        Email = user.Email,
                        Messages = Message,
                        Subjects = Subject,
                    };
                    await _db.ContactUs.AddAsync(contactUs);
                    await _db.SaveChangesAsync();
                    string bodyMes = $" Email : { user.Email} < /br> From : {user.Name} </br> Message : {Message} ";
                    await Helper.SendMessage(Subject, bodyMes, "knjc621@gmail.com");
                    return Content("Mesajınız uğurla göndərildi gün ərzində sizə cavab veriləcək !");

                }
                else
                {
                    if (Email != null && Name != null && Subject != null && Message != null)
                    {
                        ContactUs contactUs = new ContactUs
                        {
                            Name = Name,
                            Email = Email,
                            Messages = Message,
                            Subjects = Subject,
                        };
                        await _db.ContactUs.AddAsync(contactUs);
                        await _db.SaveChangesAsync();
                        string bodyMes = $" Email : {Email} </br> From : {Name} </br> Message : {Message} ";
                        await Helper.SendMessage(Subject, bodyMes, "knjc621@gmail.com");
                        return Content("Mesajınız uğurla göndərildi gün ərzində sizə cavab veriləcək !");
                    }

                    else
                    {
                        return Content("Mesajı yollaya bilmədiz zəhmət olmasa bütün xanaları düzgün şəkildə doldurasınız!");
                    }


                }

            }
        }

        public async Task<IActionResult> AddSubscribe()
        {
            
           
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                bool IsExist = _db.SubScribes.Any(s => s.Email.ToLower().Trim() == user.Email.ToLower().Trim());
                if (!IsExist)
                {
                    SubScribe subScribe = new SubScribe
                    {
                        Email = user.Email,
                    };
                    await _db.SubScribes.AddAsync(subScribe);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    SubScribe subScribe =await  _db.SubScribes.FirstOrDefaultAsync(s => s.Email == user.Email);
                    _db.SubScribes.Remove(subScribe);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View("Error");
            }

        }
    }
}
