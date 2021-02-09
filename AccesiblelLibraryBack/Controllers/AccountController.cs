﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AccesiblelLibraryBack.Models;
using AccesiblelLibraryBack.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static AccesiblelLibraryBack.Extensions.Extension;

namespace AccesiblelLibraryBack.Controllers
{
    public class AccountController : Controller
    {

        public readonly UserManager<AppUser> _usermanager;
        public readonly SignInManager<AppUser> _signinmanager;
        public readonly RoleManager<IdentityRole> _rolemanager;
        public readonly IWebHostEnvironment _env;

        public AccountController(UserManager<AppUser> usermanager, SignInManager<AppUser> signinmanager, RoleManager<IdentityRole> rolemanager, IWebHostEnvironment env)
        {
            _usermanager = usermanager;
            _signinmanager = signinmanager;
            _rolemanager = rolemanager;
            _env = env;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LayoutVM layoutVM)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "Home");
            AppUser newUser = new AppUser
            {
                Name = layoutVM.RegisterVM.Name,
                Surname = layoutVM.RegisterVM.Surname,
                UserName = layoutVM.RegisterVM.Username,
                Email = layoutVM.RegisterVM.Email,
                CreateTime = DateTime.UtcNow
            };
            IdentityResult identityResult = await _usermanager.CreateAsync(newUser, layoutVM.RegisterVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }
            if (identityResult.Succeeded)
            {
                var token = await _usermanager.GenerateEmailConfirmationTokenAsync(newUser);
                var confirmationLink = Url.Action(nameof(VerifyEmail), "Account", new { token, email = newUser.Email }, Request.Scheme);
                var mailto = newUser.Email;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("imbackend4000@gmail.com", "backend318");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage message = new MailMessage("imbackend4000@gmail.com", mailto);
                message.Subject = "Verify Email";


                message.Body = $"<a href=\"{confirmationLink}\">Verify Email</a>";
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;
                client.Send(message);
                return RedirectToAction("EmailVerification", new { email = newUser.Email });
            }

            await _usermanager.AddToRoleAsync(newUser, Roles.Member.ToString());
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            var user = await _usermanager.FindByEmailAsync(email);
            if (user == null) return BadRequest();

            if (!await _usermanager.IsEmailConfirmedAsync(user))
            {
                var result = await _usermanager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View("Error");
            }
        }
        public IActionResult EmailVerification(string email)
        {
            ViewBag.Email = email;
            return View();

        }

        public  IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LayoutVM layoutVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser user;
            if (await _usermanager.FindByEmailAsync(layoutVM.LoginVM.Username) != null)
            {
                user = await _usermanager.FindByEmailAsync(layoutVM.LoginVM.Username);

            }
            else
            {
                user = await _usermanager.FindByNameAsync(layoutVM.LoginVM.Username);

            }
            if (user == null)
            {
                ModelState.AddModelError("", "Email,Username or Password is incorrect");
                return View();
            }
            if (user.IsDeleted)
            {
                ModelState.AddModelError("", "Email,Username or Password is incorrect");
                return View();
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signinmanager.PasswordSignInAsync(user, layoutVM.LoginVM.Password, true, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Try again few minutes later");
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email, Username or Password is incorrect");
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signinmanager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Profile(string username)
        {
            if (username != null)
            {
                AppUser appUser = await _usermanager.FindByNameAsync(username);
                return View(appUser);
            }
            else
            {
                AppUser appUser = await _usermanager.FindByNameAsync(User.Identity.Name);
                return View(appUser);
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(AppUser user)
        {

            AppUser appUser = await _usermanager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return View(appUser);
            if (ModelState.IsValid)
            {
                appUser.UserName = user.UserName;
                appUser.Name = user.Name;
                appUser.Surname = user.Surname;
                appUser.Email = user.Email;
            }
            if (user.Photo != null)
            {

                if (!user.Photo.IsImage())
                {
                    ModelState.AddModelError("", "Please,add Image file");
                    return View(appUser);
                }

                string folder = Path.Combine("img", "user");
                string fileName = await user.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                appUser.Image = fileName;
            }

            IdentityResult identityResult = await _usermanager.UpdateAsync(appUser);
            if (!identityResult.Succeeded)
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(appUser);
            }
            await _signinmanager.RefreshSignInAsync(appUser);
            return RedirectToAction("Profile");
        }

        #region CreateRole
        public async Task CreateRole()
        {
            if (!await _rolemanager.RoleExistsAsync(Roles.Admin.ToString()))
            {
                await _rolemanager.CreateAsync(new IdentityRole { Name = Roles.Admin.ToString() });
            };
            if (!await _rolemanager.RoleExistsAsync(Roles.Member.ToString()))
            {
                await _rolemanager.CreateAsync(new IdentityRole { Name = Roles.Member.ToString() });
            };
        }
        #endregion

    }

}
