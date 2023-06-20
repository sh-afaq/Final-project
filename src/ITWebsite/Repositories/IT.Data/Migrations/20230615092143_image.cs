using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IT.Data.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
       name: "ImageUrl",
       table: "blogs",
       type: "nvarchar(max)",
       nullable: true);

        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
