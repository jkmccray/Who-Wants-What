﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhoWantsWhat.Data;

namespace WhoWantsWhat.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191216165427_updateAppDbContext")]
    partial class updateAppDbContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WhoWantsWhat.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Nashville",
                            ConcurrencyStamp = "6d86770a-6eea-4721-b96a-43da53bc03c4",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Admina",
                            LastName = "Straytor",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELo+27nDpm1tY7eK/wI56Lo/WJr1wZYRfBObgb+grNHkdsq81wd+j7Sov9DqNP3gRg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            State = "TN",
                            StreetAddress = "123 Infinity Way",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com",
                            ZipCode = "12345"
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-fffffffffffg",
                            AccessFailedCount = 0,
                            Birthday = new DateTime(1986, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Nashville",
                            ConcurrencyStamp = "84fd92f2-7b4f-49ff-a9ae-37189a9569d9",
                            Email = "tom@cat.com",
                            EmailConfirmed = true,
                            FirstName = "Tom",
                            LastName = "Cat",
                            LockoutEnabled = false,
                            NormalizedEmail = "TOM@CAT.COM",
                            NormalizedUserName = "TOM@CAT.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEB8j8PgeiKzeFZ1aSBCxXb+uyXZCdISDiy/R2yubFj8FoVXgQAWLpfvEFVGvX2fcCg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                            State = "TN",
                            StreetAddress = "123 Feline Way",
                            TwoFactorEnabled = false,
                            UserName = "tom@cat.com",
                            ZipCode = "12345"
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GiftList", b =>
                {
                    b.Property<int>("GiftListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateNeeded")
                        .HasColumnType("datetime2");

                    b.Property<int>("ListTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReceiverName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GiftListId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ListTypeId");

                    b.HasIndex("ReceiverId");

                    b.ToTable("GiftLists");

                    b.HasData(
                        new
                        {
                            GiftListId = 1,
                            Budget = 100,
                            CreatorId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            DateNeeded = new DateTime(2019, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListTypeId = 1,
                            Name = "Christmas Gift Ideas for Tom",
                            ReceiverId = "00000000-ffff-ffff-ffff-fffffffffffg"
                        },
                        new
                        {
                            GiftListId = 2,
                            Budget = 250,
                            CreatorId = "00000000-ffff-ffff-ffff-fffffffffffg",
                            DateNeeded = new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListTypeId = 2,
                            Name = "Birthday Gift Ideas for Admina",
                            ReceiverId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            GiftListId = 3,
                            Budget = 150,
                            CreatorId = "00000000-ffff-ffff-ffff-fffffffffffg",
                            DateNeeded = new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ListTypeId = 2,
                            Name = "Birthday Gift Ideas for Andrea",
                            ReceiverName = "Andrea"
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GiftListItem", b =>
                {
                    b.Property<int>("GiftListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GiftListId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("GiftListItemId");

                    b.HasIndex("GiftListId");

                    b.HasIndex("ItemId");

                    b.ToTable("GiftListItems");

                    b.HasData(
                        new
                        {
                            GiftListItemId = 1,
                            GiftListId = 1,
                            ItemId = 2
                        },
                        new
                        {
                            GiftListItemId = 2,
                            GiftListId = 2,
                            ItemId = 1
                        },
                        new
                        {
                            GiftListItemId = 3,
                            GiftListId = 1,
                            ItemId = 4
                        },
                        new
                        {
                            GiftListItemId = 4,
                            GiftListId = 2,
                            ItemId = 3
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            Name = "McCray Family"
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GroupUser", b =>
                {
                    b.Property<int>("GroupUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<bool>("Joined")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GroupUserId");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupUsers");

                    b.HasData(
                        new
                        {
                            GroupUserId = 1,
                            GroupId = 1,
                            Joined = true,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            GroupUserId = 2,
                            GroupId = 1,
                            Joined = false,
                            UserId = "00000000-ffff-ffff-ffff-fffffffffffg"
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GroupWishList", b =>
                {
                    b.Property<int>("GroupWishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("WishListId")
                        .HasColumnType("int");

                    b.HasKey("GroupWishListId");

                    b.HasIndex("GroupId");

                    b.HasIndex("WishListId");

                    b.ToTable("GroupWishLists");
                });

            modelBuilder.Entity("WhoWantsWhat.Models.ImportantDate", b =>
                {
                    b.Property<int>("ImportantDateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ImportantDateId");

                    b.HasIndex("UserId");

                    b.ToTable("ImportantDates");
                });

            modelBuilder.Entity("WhoWantsWhat.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Purchased")
                        .HasColumnType("bit");

                    b.Property<double>("PurchasedAmount")
                        .HasColumnType("float");

                    b.Property<string>("PurchaserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ItemId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("PurchaserId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            CreatorId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            Link = "https://www.amazon.com/Kootek-Adjustable-Lightweight-Parachute-Backpacking/dp/B071LGPYVH/ref=sxin_3_ac_d_rm?ac_md=0-0-aGFtbW9jaw%3D%3D-ac_d_rm&keywords=hammock&pd_rd_i=B071LGPYVH&pd_rd_r=a14ec169-d773-4285-a6c1-aaa6375e3cbe&pd_rd_w=le7wg&pd_rd_wg=jMe4e&pf_rd_p=6d29ef56-fc35-411a-8a8e-7114f01518f7&pf_rd_r=J7YEC1Z3PYB7BDFJVMJ6&psc=1&qid=1575923009",
                            Name = "Hammock",
                            Purchased = false,
                            PurchasedAmount = 0.0
                        },
                        new
                        {
                            ItemId = 2,
                            CreatorId = "00000000-ffff-ffff-ffff-fffffffffffg",
                            Link = "https://www.amazon.com/Salt-Fat-Acid-Heat-Mastering/dp/1476753830/ref=sxin_2_osp75-2d8e34d5_cov?ascsubtag=2d8e34d5-a699-4c81-a121-3d173d5ec902&creativeASIN=1476753830&cv_ct_id=amzn1.osp.2d8e34d5-a699-4c81-a121-3d173d5ec902&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=cookbook&linkCode=oas&pd_rd_i=1476753830&pd_rd_r=0346d4be-fd3b-4920-89f8-50e211c143cf&pd_rd_w=CtEYm&pd_rd_wg=4AJBb&pf_rd_p=a23a388c-add5-49df-b293-a31ade89c6bf&pf_rd_r=0HWVA6N211TSAX216V10&qid=1575923081&tag=workingmotherbonnier_os-20",
                            Name = "Cookbook",
                            Purchased = false,
                            PurchasedAmount = 0.0
                        },
                        new
                        {
                            ItemId = 3,
                            CreatorId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            Link = "https://www.amazon.com/KitchenAid-KSM150PSER-Artisan-Tilt-Head-Pouring/dp/B00005UP2P/ref=sxin_2_osp17-3e8a3e53_cov?ascsubtag=3e8a3e53-bc0c-4cea-9974-5923639d470a&creativeASIN=B00005UP2P&cv_ct_id=amzn1.osp.3e8a3e53-bc0c-4cea-9974-5923639d470a&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=stand+mixer&linkCode=oas&pd_rd_i=B00005UP2P&pd_rd_r=4649871d-12fe-4617-80fb-674bf8c0d721&pd_rd_w=cIBDs&pd_rd_wg=8Ycmg&pf_rd_p=a23a388c-add5-49df-b293-a31ade89c6bf&pf_rd_r=V9BWSW7FNVXPNQR92TRS&qid=1575923133&tag=digitaltren0b-20",
                            Name = "Stand Mixer",
                            Purchased = true,
                            PurchasedAmount = 0.0
                        },
                        new
                        {
                            ItemId = 4,
                            CreatorId = "00000000-ffff-ffff-ffff-fffffffffffg",
                            Link = "https://www.amazon.com/ULTRAIDEAS-Womens-Gridding-Velvet-Slippers/dp/B01LRKY6NS/ref=sxin_1_osp32-da63ad88_cov?ascsubtag=da63ad88-f999-4d67-abfd-f567e677e732&creativeASIN=B01LRKY6NS&cv_ct_id=amzn1.osp.da63ad88-f999-4d67-abfd-f567e677e732&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=slippers&linkCode=oas&pd_rd_i=B01LRKY6NS&pd_rd_r=57ff78eb-bc97-4845-85d3-ad8989e6943a&pd_rd_w=RZabM&pd_rd_wg=IUBji&pf_rd_p=53eff971-6e12-4016-9864-b6dfd929b2b3&pf_rd_r=EGBHK1G2270XAWP2KK3Y&qid=1575923192&tag=thesprucepublish-20",
                            Name = "Slippers",
                            Purchased = true,
                            PurchasedAmount = 0.0
                        },
                        new
                        {
                            ItemId = 5,
                            CreatorId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            Link = "https://www.amazon.com/dp/B07JXP6R13/ref=cm_gf_atg_i01_i02_i07_d_p0_c0_qd0___________tv3dHpCPMcC70qMnOuA9",
                            Name = "Legos",
                            Purchased = false,
                            PurchasedAmount = 0.0
                        },
                        new
                        {
                            ItemId = 6,
                            CreatorId = "00000000-ffff-ffff-ffff-fffffffffffg",
                            Link = "https://www.amazon.com/iRobot-Roomba-675-Connectivity-Carpets/dp/B07DL4QY5V/ref=sr_1_3?keywords=roomba&qid=1575923318&smid=ATVPDKIKX0DER&sr=8-3",
                            Name = "Roomba",
                            Purchased = false,
                            PurchasedAmount = 0.0
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.ListType", b =>
                {
                    b.Property<int>("ListTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ListTypeId");

                    b.ToTable("ListTypes");

                    b.HasData(
                        new
                        {
                            ListTypeId = 1,
                            Label = "Holiday"
                        },
                        new
                        {
                            ListTypeId = 2,
                            Label = "Birthday"
                        },
                        new
                        {
                            ListTypeId = 3,
                            Label = "Anniversary"
                        },
                        new
                        {
                            ListTypeId = 4,
                            Label = "Other"
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Read")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("WhoWantsWhat.Models.WishList", b =>
                {
                    b.Property<int>("WishListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WishListId");

                    b.HasIndex("UserId");

                    b.ToTable("WishLists");

                    b.HasData(
                        new
                        {
                            WishListId = 1,
                            Name = "Admina's Wish List",
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffff"
                        },
                        new
                        {
                            WishListId = 2,
                            Name = "Tom's Wish List",
                            UserId = "00000000-ffff-ffff-ffff-fffffffffffg"
                        });
                });

            modelBuilder.Entity("WhoWantsWhat.Models.WishListItem", b =>
                {
                    b.Property<int>("WishListItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("WishListId")
                        .HasColumnType("int");

                    b.HasKey("WishListItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("WishListId");

                    b.ToTable("WishListItems");

                    b.HasData(
                        new
                        {
                            WishListItemId = 1,
                            ItemId = 1,
                            WishListId = 1
                        },
                        new
                        {
                            WishListItemId = 2,
                            ItemId = 2,
                            WishListId = 2
                        },
                        new
                        {
                            WishListItemId = 3,
                            ItemId = 3,
                            WishListId = 1
                        },
                        new
                        {
                            WishListItemId = 4,
                            ItemId = 4,
                            WishListId = 2
                        },
                        new
                        {
                            WishListItemId = 5,
                            ItemId = 5,
                            WishListId = 1
                        },
                        new
                        {
                            WishListItemId = 6,
                            ItemId = 6,
                            WishListId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GiftList", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.ListType", "ListType")
                        .WithMany("GiftLists")
                        .HasForeignKey("ListTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GiftListItem", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.GiftList", "GiftList")
                        .WithMany("GiftListItems")
                        .HasForeignKey("GiftListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.Item", "Item")
                        .WithMany("GiftListItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GroupUser", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.Group", "Group")
                        .WithMany("GroupUsers")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "User")
                        .WithMany("GroupUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.GroupWishList", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.Group", "Group")
                        .WithMany("GroupWishLists")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.WishList", "WishList")
                        .WithMany("GroupWishLists")
                        .HasForeignKey("WishListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.ImportantDate", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.Item", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "Purchaser")
                        .WithMany()
                        .HasForeignKey("PurchaserId");
                });

            modelBuilder.Entity("WhoWantsWhat.Models.Notification", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.WishList", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WhoWantsWhat.Models.WishListItem", b =>
                {
                    b.HasOne("WhoWantsWhat.Models.Item", "Item")
                        .WithMany("WishListItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WhoWantsWhat.Models.WishList", "WishList")
                        .WithMany("WishListItems")
                        .HasForeignKey("WishListId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
