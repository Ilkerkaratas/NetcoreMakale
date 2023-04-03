using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccesLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 20, nullable: false),
                    CategoryStatus = table.Column<bool>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subject = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ContactMail = table.Column<string>(nullable: false),
                    Contacttext = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "follows",
                columns: table => new
                {
                    followID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakiEdenID = table.Column<int>(nullable: false),
                    TakipEdilenID = table.Column<int>(nullable: false),
                    statu = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follows", x => x.followID);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    LikeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lİke_ = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    MakaleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.LikeID);
                });

            migrationBuilder.CreateTable(
                name: "Makale",
                columns: table => new
                {
                    MakaleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Like = table.Column<int>(nullable: false),
                    MakaleBaşlik = table.Column<string>(maxLength: 20, nullable: false),
                    MakaleResim = table.Column<string>(nullable: true),
                    MakaleAciklama = table.Column<string>(nullable: false),
                    MakaleStatus = table.Column<bool>(nullable: true),
                    CategoryID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makale", x => x.MakaleID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(maxLength: 15, nullable: false),
                    KullaniciResim = table.Column<string>(nullable: true),
                    Sifre = table.Column<string>(maxLength: 90, nullable: false),
                    role = table.Column<string>(nullable: true),
                    takipcisayisi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    YorumID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    yorum_text = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    MakaleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.YorumID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "follows");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Makale");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Yorum");
        }
    }
}
