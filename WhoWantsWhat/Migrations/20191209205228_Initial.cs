using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhoWantsWhat.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListTypes",
                columns: table => new
                {
                    ListTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTypes", x => x.ListTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_Groups_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImportantDates",
                columns: table => new
                {
                    ImportantDateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportantDates", x => x.ImportantDateId);
                    table.ForeignKey(
                        name: "FK_ImportantDates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Purchased = table.Column<bool>(nullable: false),
                    PurchasedAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Read = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    WishListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.WishListId);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftLists",
                columns: table => new
                {
                    GiftListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false),
                    ReceiverId = table.Column<string>(nullable: true),
                    ReceiverName = table.Column<string>(nullable: true),
                    ListTypeId = table.Column<int>(nullable: false),
                    DateNeeded = table.Column<DateTime>(nullable: false),
                    Budget = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftLists", x => x.GiftListId);
                    table.ForeignKey(
                        name: "FK_GiftLists_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiftLists_ListTypes_ListTypeId",
                        column: x => x.ListTypeId,
                        principalTable: "ListTypes",
                        principalColumn: "ListTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiftLists_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    GroupUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    Joined = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.GroupUserId);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishListItems",
                columns: table => new
                {
                    WishListItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WishListId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListItems", x => x.WishListItemId);
                    table.ForeignKey(
                        name: "FK_WishListItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WishListItems_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "WishListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftListItems",
                columns: table => new
                {
                    GiftListItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftListId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftListItems", x => x.GiftListItemId);
                    table.ForeignKey(
                        name: "FK_GiftListItems_GiftLists_GiftListId",
                        column: x => x.GiftListId,
                        principalTable: "GiftLists",
                        principalColumn: "GiftListId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GiftListItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "StreetAddress", "TwoFactorEnabled", "UserName", "ZipCode" },
                values: new object[,]
                {
                    { "00000000-ffff-ffff-ffff-ffffffffffff", 0, new DateTime(2001, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nashville", "b401ab4d-917d-444e-8ad4-d3fbeb7a614d", "admin@admin.com", true, "Admina", "Straytor", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGA2vK/x/B7m9upH3aBVToAzLwUMHimZKPuc4svMAzlrIS0AeBHsRt31I4fJSIizVw==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", "TN", "123 Infinity Way", false, "admin@admin.com", "12345" },
                    { "00000000-ffff-ffff-ffff-fffffffffffg", 0, new DateTime(1986, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nashville", "5252bd20-fbb9-4d5d-87b4-ba3d63dc8001", "tom@cat.com", true, "Tom", "Cat", false, null, "TOM@CAT.COM", "TOM@CAT.COM", "AQAAAAEAACcQAAAAEDBxuvx26ZDJqJCGPZv1fOA8LFOv4R8Qxv/LG9CW5NQmL6HYtFyqAanQB59zAtBxBA==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794578", "TN", "123 Feline Way", false, "tom@cat.com", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "ApplicationUserId", "Name" },
                values: new object[,]
                {
                    { 1, null, "McCray Family" },
                    { 2, null, "Nashville Friends" }
                });

            migrationBuilder.InsertData(
                table: "ListTypes",
                columns: new[] { "ListTypeId", "Label" },
                values: new object[,]
                {
                    { 1, "Holiday" },
                    { 2, "Birthday" },
                    { 3, "Anniversary" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "GiftLists",
                columns: new[] { "GiftListId", "Budget", "CreatorId", "DateNeeded", "ListTypeId", "Name", "ReceiverId", "ReceiverName" },
                values: new object[,]
                {
                    { 1, 100, "00000000-ffff-ffff-ffff-ffffffffffff", new DateTime(2019, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Christmas Gift Ideas for Tom", "00000000-ffff-ffff-ffff-fffffffffffg", null },
                    { 2, 250, "00000000-ffff-ffff-ffff-fffffffffffg", new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Birthday Gift Ideas for Admina", "00000000-ffff-ffff-ffff-ffffffffffff", null },
                    { 3, 150, "00000000-ffff-ffff-ffff-fffffffffffg", new DateTime(2020, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Birthday Gift Ideas for Andrea", null, "Andrea" }
                });

            migrationBuilder.InsertData(
                table: "GroupUsers",
                columns: new[] { "GroupUserId", "GroupId", "Joined", "UserId" },
                values: new object[,]
                {
                    { 1, 1, true, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, 1, false, "00000000-ffff-ffff-ffff-fffffffffffg" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CreatorId", "Link", "Name", "Purchased", "PurchasedAmount" },
                values: new object[,]
                {
                    { 1, "00000000-ffff-ffff-ffff-ffffffffffff", "https://www.amazon.com/Kootek-Adjustable-Lightweight-Parachute-Backpacking/dp/B071LGPYVH/ref=sxin_3_ac_d_rm?ac_md=0-0-aGFtbW9jaw%3D%3D-ac_d_rm&keywords=hammock&pd_rd_i=B071LGPYVH&pd_rd_r=a14ec169-d773-4285-a6c1-aaa6375e3cbe&pd_rd_w=le7wg&pd_rd_wg=jMe4e&pf_rd_p=6d29ef56-fc35-411a-8a8e-7114f01518f7&pf_rd_r=J7YEC1Z3PYB7BDFJVMJ6&psc=1&qid=1575923009", "Hammock", false, 0.0 },
                    { 3, "00000000-ffff-ffff-ffff-ffffffffffff", "https://www.amazon.com/KitchenAid-KSM150PSER-Artisan-Tilt-Head-Pouring/dp/B00005UP2P/ref=sxin_2_osp17-3e8a3e53_cov?ascsubtag=3e8a3e53-bc0c-4cea-9974-5923639d470a&creativeASIN=B00005UP2P&cv_ct_id=amzn1.osp.3e8a3e53-bc0c-4cea-9974-5923639d470a&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=stand+mixer&linkCode=oas&pd_rd_i=B00005UP2P&pd_rd_r=4649871d-12fe-4617-80fb-674bf8c0d721&pd_rd_w=cIBDs&pd_rd_wg=8Ycmg&pf_rd_p=a23a388c-add5-49df-b293-a31ade89c6bf&pf_rd_r=V9BWSW7FNVXPNQR92TRS&qid=1575923133&tag=digitaltren0b-20", "Stand Mixer", true, 0.0 },
                    { 5, "00000000-ffff-ffff-ffff-ffffffffffff", "https://www.amazon.com/dp/B07JXP6R13/ref=cm_gf_atg_i01_i02_i07_d_p0_c0_qd0___________tv3dHpCPMcC70qMnOuA9", "Legos", false, 0.0 },
                    { 2, "00000000-ffff-ffff-ffff-fffffffffffg", "https://www.amazon.com/Salt-Fat-Acid-Heat-Mastering/dp/1476753830/ref=sxin_2_osp75-2d8e34d5_cov?ascsubtag=2d8e34d5-a699-4c81-a121-3d173d5ec902&creativeASIN=1476753830&cv_ct_id=amzn1.osp.2d8e34d5-a699-4c81-a121-3d173d5ec902&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=cookbook&linkCode=oas&pd_rd_i=1476753830&pd_rd_r=0346d4be-fd3b-4920-89f8-50e211c143cf&pd_rd_w=CtEYm&pd_rd_wg=4AJBb&pf_rd_p=a23a388c-add5-49df-b293-a31ade89c6bf&pf_rd_r=0HWVA6N211TSAX216V10&qid=1575923081&tag=workingmotherbonnier_os-20", "Cookbook", false, 0.0 },
                    { 4, "00000000-ffff-ffff-ffff-fffffffffffg", "https://www.amazon.com/ULTRAIDEAS-Womens-Gridding-Velvet-Slippers/dp/B01LRKY6NS/ref=sxin_1_osp32-da63ad88_cov?ascsubtag=da63ad88-f999-4d67-abfd-f567e677e732&creativeASIN=B01LRKY6NS&cv_ct_id=amzn1.osp.da63ad88-f999-4d67-abfd-f567e677e732&cv_ct_pg=search&cv_ct_wn=osp-search&keywords=slippers&linkCode=oas&pd_rd_i=B01LRKY6NS&pd_rd_r=57ff78eb-bc97-4845-85d3-ad8989e6943a&pd_rd_w=RZabM&pd_rd_wg=IUBji&pf_rd_p=53eff971-6e12-4016-9864-b6dfd929b2b3&pf_rd_r=EGBHK1G2270XAWP2KK3Y&qid=1575923192&tag=thesprucepublish-20", "Slippers", true, 0.0 },
                    { 6, "00000000-ffff-ffff-ffff-fffffffffffg", "https://www.amazon.com/iRobot-Roomba-675-Connectivity-Carpets/dp/B07DL4QY5V/ref=sr_1_3?keywords=roomba&qid=1575923318&smid=ATVPDKIKX0DER&sr=8-3", "Roomba", false, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "WishListId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Admina's Wish List", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, "Tom's Wish List", "00000000-ffff-ffff-ffff-fffffffffffg" }
                });

            migrationBuilder.InsertData(
                table: "GiftListItems",
                columns: new[] { "GiftListItemId", "GiftListId", "ItemId", "Notes" },
                values: new object[,]
                {
                    { 1, 1, 2, null },
                    { 3, 1, 4, null },
                    { 2, 2, 1, null },
                    { 4, 2, 3, null }
                });

            migrationBuilder.InsertData(
                table: "WishListItems",
                columns: new[] { "WishListItemId", "ItemId", "Notes", "WishListId" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 3, 3, null, 1 },
                    { 5, 5, null, 1 },
                    { 2, 2, null, 2 },
                    { 4, 4, null, 2 },
                    { 6, 6, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GiftListItems_GiftListId",
                table: "GiftListItems",
                column: "GiftListId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftListItems_ItemId",
                table: "GiftListItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftLists_CreatorId",
                table: "GiftLists",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftLists_ListTypeId",
                table: "GiftLists",
                column: "ListTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftLists_ReceiverId",
                table: "GiftLists",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ApplicationUserId",
                table: "Groups",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportantDates_UserId",
                table: "ImportantDates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CreatorId",
                table: "Items",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_ItemId",
                table: "WishListItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_WishListId",
                table: "WishListItems",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "GiftListItems");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "ImportantDates");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "WishListItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GiftLists");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "ListTypes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
