﻿using Lali.Common;
using Lali.DataAccess.Data;
using LaliWebShop.Server.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LaliWebShop.Server.Service
{
    public class DbInitializer : IDbInitializer
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ShopDbContext _db;
        public DbInitializer( UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            ShopDbContext db)
        {
            _db = db;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void Initialize()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count()>0)
                {
                    _db.Database.Migrate();
                }
                if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                    _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
                }
                else
                {
                    return;
                }

                IdentityUser user = new()
                {
                    UserName= "omar.tamr@absolute.de",
                    Email= "omar.tamr@absolute.de",
                    EmailConfirmed=true
                };

                _userManager.CreateAsync(user, "Admin123@").GetAwaiter().GetResult();

                _userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
