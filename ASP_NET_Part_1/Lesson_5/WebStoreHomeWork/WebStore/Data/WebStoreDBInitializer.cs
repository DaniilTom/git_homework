using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreContext _db;

        public WebStoreDBInitializer(WebStoreContext db)
        {
            _db = db;
        }

        public async Task InitializeAsync()
        {
            await _db.Database.MigrateAsync();

            if (await _db.Microcontrollers.AnyAsync())
                return;

            using (var transaction = _db.Database.BeginTransaction())
            {
                _db.Microcontrollers.AddRange(TestData.Microcontrollers);

                _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Microcontrollers] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Microcontrollers] OFF");

                transaction.Commit();
            }

            using (var transaction = _db.Database.BeginTransaction())
            {
                _db.Categories.AddRange(TestData.Categories);

                _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Categories] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Categories] OFF");

                transaction.Commit();
            }

            using (var transaction = _db.Database.BeginTransaction())
            {
                _db.MCDescriptions.AddRange(TestData.MCDescriptions);

                _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[MCDescriptions] ON");
                _db.SaveChanges();
                _db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[MCDescriptions] OFF");

                transaction.Commit();
            }
        }
    }
}
