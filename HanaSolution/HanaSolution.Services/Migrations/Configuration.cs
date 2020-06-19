namespace HanaSolution.Services.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<HanaSolution.Services.EntitiesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HanaSolution.Services.EntitiesDbContext context)
        {
            using (var db = new EntitiesDbContext())
            {
                if (db.Staffs.Where(x => x.Account == "admin").Count() == 0)
                {
                    db.Staffs.Add(new Data.Models.Staff { Account = "admin", Password = "admin", Address = "Main", Gender = 1, Mail = "Main", Name = "Quản trị viên", Phone = "Main", Status = true }); ;
                    db.Commit();
                }

                db.Dispose();
            }
        }
    }
}
