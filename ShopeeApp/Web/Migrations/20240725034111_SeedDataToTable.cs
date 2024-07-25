using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "EndDate", "Name", "Percentage", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "Description for Discount 1", new DateTime(2024, 8, 6, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8382), "Discount 1", 42.0, new DateTime(2024, 7, 24, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8379), (byte)1 },
                    { 2, "Description for Discount 2", new DateTime(2024, 8, 13, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8440), "Discount 2", 49.0, new DateTime(2024, 7, 24, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8438), (byte)1 },
                    { 3, "Description for Discount 3", new DateTime(2024, 8, 10, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8487), "Discount 3", 17.0, new DateTime(2024, 7, 19, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8485), (byte)1 },
                    { 4, "Description for Discount 4", new DateTime(2024, 8, 5, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8534), "Discount 4", 18.0, new DateTime(2024, 7, 24, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8532), (byte)1 },
                    { 5, "Description for Discount 5", new DateTime(2024, 8, 21, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8580), "Discount 5", 46.0, new DateTime(2024, 7, 16, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8579), (byte)1 },
                    { 6, "Description for Discount 6", new DateTime(2024, 8, 15, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8631), "Discount 6", 16.0, new DateTime(2024, 7, 23, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8629), (byte)1 },
                    { 7, "Description for Discount 7", new DateTime(2024, 8, 19, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8678), "Discount 7", 2.0, new DateTime(2024, 7, 21, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8676), (byte)1 },
                    { 8, "Description for Discount 8", new DateTime(2024, 8, 21, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8725), "Discount 8", 28.0, new DateTime(2024, 7, 18, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8723), (byte)1 },
                    { 9, "Description for Discount 9", new DateTime(2024, 8, 16, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8771), "Discount 9", 1.0, new DateTime(2024, 7, 24, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8770), (byte)1 },
                    { 10, "Description for Discount 10", new DateTime(2024, 8, 5, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8822), "Discount 10", 30.0, new DateTime(2024, 7, 17, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8820), (byte)1 },
                    { 11, "Description for Discount 11", new DateTime(2024, 8, 15, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8934), "Discount 11", 16.0, new DateTime(2024, 7, 19, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8931), (byte)1 },
                    { 12, "Description for Discount 12", new DateTime(2024, 8, 23, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8982), "Discount 12", 46.0, new DateTime(2024, 7, 16, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(8980), (byte)1 },
                    { 13, "Description for Discount 13", new DateTime(2024, 8, 8, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9030), "Discount 13", 43.0, new DateTime(2024, 7, 18, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9028), (byte)1 },
                    { 14, "Description for Discount 14", new DateTime(2024, 8, 9, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9076), "Discount 14", 27.0, new DateTime(2024, 7, 20, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9075), (byte)1 },
                    { 15, "Description for Discount 15", new DateTime(2024, 8, 7, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9123), "Discount 15", 22.0, new DateTime(2024, 7, 22, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9121), (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CloseTime", "Description", "Image", "Name", "OptenTime" },
                values: new object[,]
                {
                    { 1, new TimeOnly(18, 0, 0), "Description for Store 1", "Image for Store 1", "Store 1", new TimeOnly(10, 0, 0) },
                    { 2, new TimeOnly(17, 0, 0), "Description for Store 2", "Image for Store 2", "Store 2", new TimeOnly(9, 0, 0) },
                    { 3, new TimeOnly(17, 0, 0), "Description for Store 3", "Image for Store 3", "Store 3", new TimeOnly(7, 0, 0) },
                    { 4, new TimeOnly(20, 0, 0), "Description for Store 4", "Image for Store 4", "Store 4", new TimeOnly(10, 0, 0) },
                    { 5, new TimeOnly(18, 0, 0), "Description for Store 5", "Image for Store 5", "Store 5", new TimeOnly(8, 0, 0) },
                    { 6, new TimeOnly(21, 0, 0), "Description for Store 6", "Image for Store 6", "Store 6", new TimeOnly(8, 0, 0) },
                    { 7, new TimeOnly(20, 0, 0), "Description for Store 7", "Image for Store 7", "Store 7", new TimeOnly(10, 0, 0) },
                    { 8, new TimeOnly(19, 0, 0), "Description for Store 8", "Image for Store 8", "Store 8", new TimeOnly(9, 0, 0) },
                    { 9, new TimeOnly(21, 0, 0), "Description for Store 9", "Image for Store 9", "Store 9", new TimeOnly(7, 0, 0) },
                    { 10, new TimeOnly(21, 0, 0), "Description for Store 10", "Image for Store 10", "Store 10", new TimeOnly(7, 0, 0) },
                    { 11, new TimeOnly(18, 0, 0), "Description for Store 11", "Image for Store 11", "Store 11", new TimeOnly(7, 0, 0) },
                    { 12, new TimeOnly(21, 0, 0), "Description for Store 12", "Image for Store 12", "Store 12", new TimeOnly(8, 0, 0) },
                    { 13, new TimeOnly(17, 0, 0), "Description for Store 13", "Image for Store 13", "Store 13", new TimeOnly(9, 0, 0) },
                    { 14, new TimeOnly(19, 0, 0), "Description for Store 14", "Image for Store 14", "Store 14", new TimeOnly(10, 0, 0) },
                    { 15, new TimeOnly(20, 0, 0), "Description for Store 15", "Image for Store 15", "Store 15", new TimeOnly(7, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "CreatedAt", "Email", "FullName", "Gender", "Password", "PhoneNumber", "RoleId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Avatar for User 1", new DateTime(2024, 7, 7, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6211), "user111@Example.com", "User 1", (byte)0, "111", "123164151", 1, (byte)1, new DateTime(2024, 7, 4, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6232) },
                    { 2, "Avatar for User 2", new DateTime(2024, 7, 20, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6388), "user222@Example.com", "User 2", (byte)0, "222", "123264152", 1, (byte)1, new DateTime(2024, 6, 27, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6391) },
                    { 3, "Avatar for User 3", new DateTime(2024, 7, 10, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6473), "user333@Example.com", "User 3", (byte)0, "333", "123364153", 1, (byte)1, new DateTime(2024, 7, 15, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6475) },
                    { 4, "Avatar for User 4", new DateTime(2024, 7, 10, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6548), "user444@Example.com", "User 4", (byte)1, "444", "123464154", 1, (byte)1, new DateTime(2024, 7, 1, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6550) },
                    { 5, "Avatar for User 5", new DateTime(2024, 7, 6, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6622), "user555@Example.com", "User 5", (byte)0, "555", "123564155", 1, (byte)1, new DateTime(2024, 7, 8, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6624) },
                    { 6, "Avatar for User 6", new DateTime(2024, 7, 20, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6702), "user666@Example.com", "User 6", (byte)1, "666", "123664156", 1, (byte)1, new DateTime(2024, 7, 4, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6703) },
                    { 7, "Avatar for User 7", new DateTime(2024, 6, 29, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6777), "user777@Example.com", "User 7", (byte)1, "777", "123764157", 1, (byte)1, new DateTime(2024, 7, 18, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6778) },
                    { 8, "Avatar for User 8", new DateTime(2024, 7, 3, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6849), "user888@Example.com", "User 8", (byte)0, "888", "123864158", 1, (byte)1, new DateTime(2024, 7, 16, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(6851) },
                    { 9, "Avatar for User 9", new DateTime(2024, 7, 11, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7021), "user999@Example.com", "User 9", (byte)0, "999", "123964159", 1, (byte)1, new DateTime(2024, 6, 28, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7024) },
                    { 10, "Avatar for User 10", new DateTime(2024, 7, 14, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7105), "user101010@Example.com", "User 10", (byte)1, "101010", "12310641510", 1, (byte)1, new DateTime(2024, 7, 7, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7106) },
                    { 11, "Avatar for User 11", new DateTime(2024, 7, 1, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7178), "user111111@Example.com", "User 11", (byte)1, "111111", "12311641511", 1, (byte)1, new DateTime(2024, 6, 28, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7179) },
                    { 12, "Avatar for User 12", new DateTime(2024, 7, 5, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7251), "user121212@Example.com", "User 12", (byte)0, "121212", "12312641512", 1, (byte)1, new DateTime(2024, 7, 14, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7252) },
                    { 13, "Avatar for User 13", new DateTime(2024, 7, 17, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7323), "user131313@Example.com", "User 13", (byte)1, "131313", "12313641513", 1, (byte)1, new DateTime(2024, 7, 17, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7324) },
                    { 14, "Avatar for User 14", new DateTime(2024, 7, 17, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7394), "user141414@Example.com", "User 14", (byte)0, "141414", "12314641514", 1, (byte)1, new DateTime(2024, 7, 3, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7395) },
                    { 15, "Avatar for User 15", new DateTime(2024, 7, 18, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7538), "user151515@Example.com", "User 15", (byte)0, "151515", "12315641515", 1, (byte)1, new DateTime(2024, 6, 28, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(7541) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DiscountId", "Image", "Name", "Price", "StoreId", "SubCategoryId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2024, 7, 15, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9193), "Description for Product 1", 9, "Image for product 1", "Product 1", 348.54242005712081, 6, 3, new DateTime(2024, 7, 24, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9196) },
                    { 2, 5, new DateTime(2024, 6, 28, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9256), "Description for Product 2", 3, "Image for product 2", "Product 2", 45.247897212635756, 9, 3, new DateTime(2024, 6, 26, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9257) },
                    { 3, 4, new DateTime(2024, 7, 20, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9309), "Description for Product 3", 15, "Image for product 3", "Product 3", 29.521948594870892, 3, 2, new DateTime(2024, 7, 9, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9311) },
                    { 4, 2, new DateTime(2024, 7, 3, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9362), "Description for Product 4", 9, "Image for product 4", "Product 4", 726.67255189117566, 6, 1, new DateTime(2024, 7, 15, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9364) },
                    { 5, 1, new DateTime(2024, 7, 21, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9414), "Description for Product 5", 12, "Image for product 5", "Product 5", 785.82630373304016, 1, 3, new DateTime(2024, 7, 21, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9416) },
                    { 6, 3, new DateTime(2024, 7, 1, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9472), "Description for Product 6", 13, "Image for product 6", "Product 6", 655.94462031942339, 2, 1, new DateTime(2024, 7, 1, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9474) },
                    { 7, 5, new DateTime(2024, 7, 8, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9525), "Description for Product 7", 5, "Image for product 7", "Product 7", 37.203663641703947, 13, 1, new DateTime(2024, 7, 13, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9527) },
                    { 8, 5, new DateTime(2024, 6, 29, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9637), "Description for Product 8", 11, "Image for product 8", "Product 8", 395.78751358617774, 2, 2, new DateTime(2024, 7, 23, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9639) },
                    { 9, 1, new DateTime(2024, 7, 25, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9696), "Description for Product 9", 8, "Image for product 9", "Product 9", 274.32075513967732, 12, 3, new DateTime(2024, 7, 15, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9698) },
                    { 10, 5, new DateTime(2024, 6, 27, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9755), "Description for Product 10", 7, "Image for product 10", "Product 10", 589.3571084092714, 13, 1, new DateTime(2024, 7, 2, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9757) },
                    { 11, 5, new DateTime(2024, 7, 25, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9808), "Description for Product 11", 6, "Image for product 11", "Product 11", 462.95595240706763, 6, 3, new DateTime(2024, 7, 7, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9810) },
                    { 12, 2, new DateTime(2024, 7, 5, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9861), "Description for Product 12", 7, "Image for product 12", "Product 12", 748.5220655414189, 6, 2, new DateTime(2024, 7, 25, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9863) },
                    { 13, 5, new DateTime(2024, 7, 19, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9914), "Description for Product 13", 14, "Image for product 13", "Product 13", 559.01216819624415, 3, 3, new DateTime(2024, 7, 17, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9916) },
                    { 14, 2, new DateTime(2024, 7, 14, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9967), "Description for Product 14", 7, "Image for product 14", "Product 14", 906.74165197140326, 13, 2, new DateTime(2024, 7, 17, 10, 41, 10, 811, DateTimeKind.Local).AddTicks(9968) },
                    { 15, 1, new DateTime(2024, 7, 14, 10, 41, 10, 812, DateTimeKind.Local).AddTicks(19), "Description for Product 15", 13, "Image for product 15", "Product 15", 199.60368721806509, 13, 1, new DateTime(2024, 7, 14, 10, 41, 10, 812, DateTimeKind.Local).AddTicks(21) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Store",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
