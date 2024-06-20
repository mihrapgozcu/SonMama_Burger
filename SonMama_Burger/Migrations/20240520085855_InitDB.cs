using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SonMama_Burger.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmCode = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraMalzemeler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cesit = table.Column<int>(type: "int", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMalzemeler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Siparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sepettekiler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: true),
                    ExtraMalzemeID = table.Column<int>(type: "int", nullable: true),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Boyut = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SilinmeZamani = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sepettekiler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sepettekiler_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sepettekiler_ExtraMalzemeler_ExtraMalzemeID",
                        column: x => x.ExtraMalzemeID,
                        principalTable: "ExtraMalzemeler",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Sepettekiler_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ExtraMalzemelerSiparisler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraMalzemeID = table.Column<int>(type: "int", nullable: false),
                    SiparisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMalzemelerSiparisler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExtraMalzemelerSiparisler_ExtraMalzemeler_ExtraMalzemeID",
                        column: x => x.ExtraMalzemeID,
                        principalTable: "ExtraMalzemeler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraMalzemelerSiparisler_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiparislerMenuler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiparisID = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Boyut = table.Column<int>(type: "int", nullable: false),
                    TotalFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OlusturmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparislerMenuler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SiparislerMenuler_Menuler_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menuler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiparislerMenuler_Siparisler_SiparisID",
                        column: x => x.SiparisID,
                        principalTable: "Siparisler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "54aa7f65-92d2-466f-bcba-9c02dce029f0", "Musteri", "MUSTERI" },
                    { 2, "ae49830d-1331-46b5-bdae-c921f6c7dc4e", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Ad", "Cinsiyet", "ConcurrencyStamp", "ConfirmCode", "DogumTarihi", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Soyad", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "Cevdet", 0, "f613a099-ff25-40ad-897e-96cc23df3001", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cevdet@deneme.com", true, false, null, "CEVDET@DENEME.COM", "CEVDET@DENEME.COM", "AQAAAAIAAYagAAAAEKMjbmu9KJd1QFaKhqkSUNPogfBYuU4hh92VJBWgkSobrGhMOJJ5Iud+PXlh27yjCg==", null, false, "59c53e18-6709-4e42-922a-db9e1eff23f4", "Heredot", false, "cevdet@deneme.com" });

            migrationBuilder.InsertData(
                table: "ExtraMalzemeler",
                columns: new[] { "ID", "Adi", "AktifMi", "Cesit", "Fiyat", "GuncellemeZamani", "OlusturmaZamani", "SilinmeZamani" },
                values: new object[,]
                {
                    { 1, "Ketçap", true, 0, 5m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1897), null },
                    { 2, "Mayonez", true, 0, 5m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1917), null },
                    { 3, "Ranch Sos", true, 0, 5m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1919), null },
                    { 4, "Barbekü Sos", true, 0, 5m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1921), null },
                    { 6, "Sufle", true, 2, 5m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1922), null },
                    { 7, "Patates Kızartması", true, 1, 45m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1923), null },
                    { 8, "Mac&Cheese Balls", true, 1, 60m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1925), null },
                    { 9, "Mozarella Sticks", true, 1, 70m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1926), null },
                    { 10, "Dondurma", true, 2, 20m, null, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(1928), null }
                });

            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "ID", "Adi", "AktifMi", "Fiyat", "Fotograf", "GuncellemeZamani", "MenuID", "OlusturmaZamani", "SilinmeZamani" },
                values: new object[,]
                {
                    { 1, "Beefy Burgers", true, 150m, "~/template2/img/yenimenu.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6083), null },
                    { 2, "Burger Bizz", true, 270m, "~/template2/img/iki.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6092), null },
                    { 3, "Burger Boys", true, 120m, "~/template2/img/uc.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6094), null },
                    { 4, "Crackles Burger", true, 150m, "~/template2/img/dort.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6095), null },
                    { 5, "Bull Burgers", true, 200m, "~/template2/img/bes.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6097), null },
                    { 6, "Rocket Burgers", true, 200m, "~/template2/img/alti.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6098), null },
                    { 7, "Smokin Burger", true, 300m, "~/template2/img/yedi.jpg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6099), null },
                    { 8, "Delish Burger", true, 150m, "~/template2/img/sekiz.png", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6101), null },
                    { 9, "MAMA Burger", true, 150m, "~/template2/img/dokuz.jpeg", null, 0, new DateTime(2024, 5, 20, 11, 58, 55, 163, DateTimeKind.Local).AddTicks(6102), null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 1 });

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
                name: "IX_ExtraMalzemelerSiparisler_ExtraMalzemeID",
                table: "ExtraMalzemelerSiparisler",
                column: "ExtraMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMalzemelerSiparisler_SiparisID",
                table: "ExtraMalzemelerSiparisler",
                column: "SiparisID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_ExtraMalzemeID",
                table: "Sepettekiler",
                column: "ExtraMalzemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_MenuID",
                table: "Sepettekiler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Sepettekiler_UserID",
                table: "Sepettekiler",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_AppUserId",
                table: "Siparisler",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SiparislerMenuler_MenuID",
                table: "SiparislerMenuler",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_SiparislerMenuler_SiparisID",
                table: "SiparislerMenuler",
                column: "SiparisID");
        }

        /// <inheritdoc />
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
                name: "ExtraMalzemelerSiparisler");

            migrationBuilder.DropTable(
                name: "Sepettekiler");

            migrationBuilder.DropTable(
                name: "SiparislerMenuler");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExtraMalzemeler");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
