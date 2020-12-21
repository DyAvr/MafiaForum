using Microsoft.EntityFrameworkCore.Migrations;

namespace MafiaForum.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReplies_AspNetUsers_UserId",
                table: "PostReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReplies",
                table: "PostReplies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forums",
                table: "Forums");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "PostReplies",
                newName: "PostReply");

            migrationBuilder.RenameTable(
                name: "Forums",
                newName: "Forum");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Post",
                newName: "IX_Post_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ForumId",
                table: "Post",
                newName: "IX_Post_ForumId");

            migrationBuilder.RenameIndex(
                name: "IX_PostReplies_UserId",
                table: "PostReply",
                newName: "IX_PostReply_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostReplies_PostId",
                table: "PostReply",
                newName: "IX_PostReply_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReply",
                table: "PostReply",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forum",
                table: "Forum",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Forum_ForumId",
                table: "Post",
                column: "ForumId",
                principalTable: "Forum",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReply_Post_PostId",
                table: "PostReply",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReply_AspNetUsers_UserId",
                table: "PostReply",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Forum_ForumId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_UserId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReply_Post_PostId",
                table: "PostReply");

            migrationBuilder.DropForeignKey(
                name: "FK_PostReply_AspNetUsers_UserId",
                table: "PostReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostReply",
                table: "PostReply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forum",
                table: "Forum");

            migrationBuilder.RenameTable(
                name: "PostReply",
                newName: "PostReplies");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "Forum",
                newName: "Forums");

            migrationBuilder.RenameIndex(
                name: "IX_PostReply_UserId",
                table: "PostReplies",
                newName: "IX_PostReplies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_PostReply_PostId",
                table: "PostReplies",
                newName: "IX_PostReplies_PostId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_ForumId",
                table: "Posts",
                newName: "IX_Posts_ForumId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostReplies",
                table: "PostReplies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forums",
                table: "Forums",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_Posts_PostId",
                table: "PostReplies",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostReplies_AspNetUsers_UserId",
                table: "PostReplies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Forums_ForumId",
                table: "Posts",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
