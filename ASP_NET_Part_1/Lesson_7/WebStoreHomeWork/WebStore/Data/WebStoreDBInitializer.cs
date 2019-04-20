using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;
using WebStore.Domain;

namespace WebStore.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreContext _db;
        private readonly UserManager<User> _um;
        private readonly RoleManager<IdentityRole> _rm;

        public WebStoreDBInitializer(WebStoreContext db, UserManager<User> um, RoleManager<IdentityRole> rm)
        {
            _db = db;
            _um = um;
            _rm = rm;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync();

            await InitRoleAsync();

            if (await _db.Microcontrollers.AnyAsync())
                return;

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                await _db.Categories.AddRangeAsync(TestData.Categories);

                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Categories] ON");
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Categories] OFF");

                transaction.Commit();
            }

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                await _db.Microcontrollers.AddRangeAsync(TestData.Microcontrollers);

                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Microcontrollers] ON");
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[Microcontrollers] OFF");

                transaction.Commit();
            }
            

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                await _db.MCDescriptions.AddRangeAsync(TestData.MCDescriptions);

                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[MCDescriptions] ON");
                await _db.SaveChangesAsync();
                await _db.Database.ExecuteSqlCommandAsync("SET IDENTITY_INSERT [dbo].[MCDescriptions] OFF");

                transaction.Commit();
            }
        }

        private async Task InitRoleAsync()
        {
            if (!await _rm.RoleExistsAsync(User.AdminRoleName))
                await _rm.CreateAsync(new IdentityRole(User.AdminRoleName));

            if (!await _rm.RoleExistsAsync(User.UserRoleName))
                await _rm.CreateAsync(new IdentityRole(User.UserRoleName));

            if(await _um.FindByNameAsync("Admin") == null)
            {
                var admin = new User
                {
                    UserName = "Admin",
                    Email = @"admin123@gmail.com"
                };

                await _um.CreateAsync(admin, User.DefaultAdminPassword);
                await _um.AddToRoleAsync(admin, User.AdminRoleName);
            }
        }
    }
}
