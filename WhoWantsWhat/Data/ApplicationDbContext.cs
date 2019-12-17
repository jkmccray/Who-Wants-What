using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WhoWantsWhat.Models;

namespace WhoWantsWhat.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<ListType> ListTypes { get; set; }
        public DbSet<GiftList> GiftLists { get; set; }
        public DbSet<GiftListItem> GiftListItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ImportantDate> ImportantDates { get; set; }
        public DbSet<GroupWishList> GroupWishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Restrict deletion of related gift list when GiftListItem entry is removed
            modelBuilder.Entity<GiftList>()
                .HasMany(o => o.GiftListItems)
                .WithOne(l => l.GiftList)
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict deletion of related wish list when WishListItem entry is removed
            modelBuilder.Entity<WishList>()
                .HasMany(o => o.WishListItems)
                .WithOne(l => l.WishList)
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict deletion of related group when GroupUser entry is removed
            modelBuilder.Entity<Group>()
                .HasMany(o => o.GroupUsers)
                .WithOne(l => l.Group)
                .OnDelete(DeleteBehavior.Restrict);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                StreetAddress = "123 Infinity Way",
                City = "Nashville",
                State = "TN",
                ZipCode = "12345",
                Birthday = new DateTime(2001, 05, 23),
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser tom = new ApplicationUser
            {
                FirstName = "Tom",
                LastName = "Cat",
                StreetAddress = "123 Feline Way",
                City = "Nashville",
                State = "TN",
                ZipCode = "12345",
                Birthday = new DateTime(1986, 06, 11),
                UserName = "tom@cat.com",
                NormalizedUserName = "TOM@CAT.COM",
                Email = "tom@cat.com",
                NormalizedEmail = "TOM@CAT.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                Id = "00000000-ffff-ffff-ffff-fffffffffffg"
            };
            var tomPasswordHash = new PasswordHasher<ApplicationUser>();
            tom.PasswordHash = passwordHash.HashPassword(tom, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(tom);

            modelBuilder.Entity<Group>().HasData(
                new Group()
                {
                    GroupId = 1,
                    Name = "McCray Family"
                }
            );

            modelBuilder.Entity<GroupUser>().HasData(
                new GroupUser()
                {
                    GroupUserId = 1,
                    GroupId = 1,
                    UserId = user.Id,
                    Joined = true
                },
                new GroupUser()
                {
                    GroupUserId = 2,
                    GroupId = 1,
                    UserId = tom.Id,
                    Joined = false
                }
            );

            modelBuilder.Entity<ListType>().HasData(
                new ListType()
                {
                    ListTypeId = 1,
                    Label = "Holiday"
                },
                new ListType()
                {
                    ListTypeId = 2,
                    Label = "Birthday"
                },
                new ListType()
                {
                    ListTypeId = 3,
                    Label = "Anniversary"
                },
                new ListType()
                {
                    ListTypeId = 4,
                    Label = "Other"
                }
            );

            modelBuilder.Entity<GiftList>().HasData(
                new GiftList()
                {
                    GiftListId = 1,
                    ListTypeId = 1,
                    Name = "Christmas Gift Ideas for Tom",
                    CreatorId = user.Id,
                    ReceiverId = tom.Id,
                    DateNeeded = new DateTime(2019, 12, 23),
                    Budget = 100
                },
                new GiftList()
                {
                    GiftListId = 2,
                    ListTypeId = 2,
                    Name = "Birthday Gift Ideas for Admina",
                    CreatorId = tom.Id,
                    ReceiverId = user.Id,
                    DateNeeded = new DateTime(2020, 05, 20),
                    Budget = 250
                },
                new GiftList()
                {
                    GiftListId = 3,
                    ListTypeId = 2,
                    Name = "Birthday Gift Ideas for Andrea",
                    CreatorId = tom.Id,
                    ReceiverName = "Andrea",
                    DateNeeded = new DateTime(2020, 01, 02),
                    Budget = 150
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    Name = "Hammock",
                    CreatorId = user.Id,
                    Purchased = false,
                    Link = "https://www.amazon.com/Kootek-Adjustable-Lightweight-Parachute-Backpacking/dp/B071LGPYVH/ref=sxin_3_ac_d_rm?ac_md=0-0-aGFtbW9jaw%3D%3D-ac_d_rm&keywords=hammock&pd_rd_i=B071LGPYVH&pd_rd_r=a14ec169-d773-4285-a6c1-aaa6375e3cbe&pd_rd_w=le7wg&pd_rd_wg=jMe4e&pf_rd_p=6d29ef56-fc35-411a-8a8e-7114f01518f7&pf_rd_r=J7YEC1Z3PYB7BDFJVMJ6&psc=1&qid=1575923009"
                },
                new Item()
                {
                    ItemId = 2,
                    Name = "Cookbook",
                    CreatorId = tom.Id,
                    Purchased = false,
                    Link = "https://www.amazon.com/Salt-Fat-Acid-Heat-Mastering/dp/1476753830/ref=sxin_2_osp75-2d8e34d5_cov?ascsubtag=2d8e34d5-a699-4c81-a121-3d173d5ec902&creativeASIN=1476753830&cv_ct_id=amzn1.osp.2d8e34d5-a699-4c81-a121-3d173d5ec902&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=cookbook&linkCode=oas&pd_rd_i=1476753830&pd_rd_r=0346d4be-fd3b-4920-89f8-50e211c143cf&pd_rd_w=CtEYm&pd_rd_wg=4AJBb&pf_rd_p=a23a388c-add5-49df-b293-a31ade89c6bf&pf_rd_r=0HWVA6N211TSAX216V10&qid=1575923081&tag=workingmotherbonnier_os-20"
                },
                new Item()
                {
                    ItemId = 3,
                    Name = "Stand Mixer",
                    CreatorId = user.Id,
                    Purchased = true,
                    Link = "https://www.amazon.com/KitchenAid-KSM150PSER-Artisan-Tilt-Head-Pouring/dp/B00005UP2P/ref=sxin_2_osp17-3e8a3e53_cov?ascsubtag=3e8a3e53-bc0c-4cea-9974-5923639d470a&creativeASIN=B00005UP2P&cv_ct_id=amzn1.osp.3e8a3e53-bc0c-4cea-9974-5923639d470a&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=stand+mixer&linkCode=oas&pd_rd_i=B00005UP2P&pd_rd_r=4649871d-12fe-4617-80fb-674bf8c0d721&pd_rd_w=cIBDs&pd_rd_wg=8Ycmg&pf_rd_p=a23a388c-add5-49df-b293-a31ade89c6bf&pf_rd_r=V9BWSW7FNVXPNQR92TRS&qid=1575923133&tag=digitaltren0b-20"
                },
                new Item ()
                {
                    ItemId = 4,
                    Name = "Slippers",
                    CreatorId = tom.Id,
                    Purchased = true,
                    Link = "https://www.amazon.com/ULTRAIDEAS-Womens-Gridding-Velvet-Slippers/dp/B01LRKY6NS/ref=sxin_1_osp32-da63ad88_cov?ascsubtag=da63ad88-f999-4d67-abfd-f567e677e732&creativeASIN=B01LRKY6NS&cv_ct_id=amzn1.osp.da63ad88-f999-4d67-abfd-f567e677e732&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=slippers&linkCode=oas&pd_rd_i=B01LRKY6NS&pd_rd_r=57ff78eb-bc97-4845-85d3-ad8989e6943a&pd_rd_w=RZabM&pd_rd_wg=IUBji&pf_rd_p=53eff971-6e12-4016-9864-b6dfd929b2b3&pf_rd_r=EGBHK1G2270XAWP2KK3Y&qid=1575923192&tag=thesprucepublish-20"
                },
                new Item()
                {
                    ItemId = 5,
                    Name = "Legos",
                    CreatorId = user.Id,
                    Purchased = false,
                    Link = "https://www.amazon.com/dp/B07JXP6R13/ref=cm_gf_atg_i01_i02_i07_d_p0_c0_qd0___________tv3dHpCPMcC70qMnOuA9"
                },
                new Item()
                {
                    ItemId = 6,
                    Name = "Roomba",
                    CreatorId = tom.Id,
                    Purchased = false,
                    Link = "https://www.amazon.com/iRobot-Roomba-675-Connectivity-Carpets/dp/B07DL4QY5V/ref=sr_1_3?keywords=roomba&qid=1575923318&smid=ATVPDKIKX0DER&sr=8-3"
                }
            );

            modelBuilder.Entity<GiftListItem>().HasData(
                new GiftListItem()
                {
                    GiftListItemId = 1,
                    GiftListId = 1,
                    ItemId = 2
                },
                new GiftListItem()
                {
                    GiftListItemId = 2,
                    GiftListId = 2,
                    ItemId = 1
                },
                new GiftListItem()
                {
                    GiftListItemId = 3,
                    GiftListId = 1,
                    ItemId = 4
                },
                new GiftListItem()
                {
                    GiftListItemId = 4,
                    GiftListId = 2,
                    ItemId = 3
                }
            );

            modelBuilder.Entity<WishList>().HasData(
                new WishList()
                {
                    WishListId = 1,
                    Name = "Admina's Wish List",
                    UserId = user.Id
                },
                new WishList()
                {
                    WishListId = 2,
                    Name = "Tom's Wish List",
                    UserId = tom.Id
                }
            );

            modelBuilder.Entity<WishListItem>().HasData(
                new WishListItem()
                {
                    WishListItemId = 1,
                    WishListId = 1,
                    ItemId = 1
                },
                new WishListItem()
                {
                    WishListItemId = 2,
                    WishListId = 2,
                    ItemId = 2
                },
                new WishListItem()
                {
                    WishListItemId = 3,
                    WishListId = 1,
                    ItemId = 3
                },
                new WishListItem()
                {
                    WishListItemId = 4,
                    WishListId = 2,
                    ItemId = 4
                },
                new WishListItem()
                {
                    WishListItemId = 5,
                    WishListId = 1,
                    ItemId = 5
                },
                new WishListItem()
                {
                    WishListItemId = 6,
                    WishListId = 2,
                    ItemId = 6
                }
            );
        }
    }
}
