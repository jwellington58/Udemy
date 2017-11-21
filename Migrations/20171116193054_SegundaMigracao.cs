using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Udemy.Migrations
{
    public partial class SegundaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbModel_tbMake_makeId",
                table: "tbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_tbModel_modelId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "nome",
                table: "tbModel");

            migrationBuilder.RenameColumn(
                name: "modelId",
                table: "Vehicles",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_modelId",
                table: "Vehicles",
                newName: "IX_Vehicles_ModelId");

            migrationBuilder.RenameColumn(
                name: "makeId",
                table: "tbModel",
                newName: "MakeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbModel_makeId",
                table: "tbModel",
                newName: "IX_tbModel_MakeId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tbMake",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tbModel",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_tbModel_tbMake_MakeId",
                table: "tbModel",
                column: "MakeId",
                principalTable: "tbMake",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_tbModel_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "tbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbModel_tbMake_MakeId",
                table: "tbModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_tbModel_ModelId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tbModel");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "Vehicles",
                newName: "modelId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                newName: "IX_Vehicles_modelId");

            migrationBuilder.RenameColumn(
                name: "MakeId",
                table: "tbModel",
                newName: "makeId");

            migrationBuilder.RenameIndex(
                name: "IX_tbModel_MakeId",
                table: "tbModel",
                newName: "IX_tbModel_makeId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbMake",
                newName: "name");

            migrationBuilder.AddColumn<string>(
                name: "nome",
                table: "tbModel",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_tbModel_tbMake_makeId",
                table: "tbModel",
                column: "makeId",
                principalTable: "tbMake",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_tbModel_modelId",
                table: "Vehicles",
                column: "modelId",
                principalTable: "tbModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
