﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneTimeAccess.Models;

#nullable disable

namespace OneTimeAccess.Migrations
{
    [DbContext(typeof(OneTimeAccessTokenContext))]
    partial class OneTimeAccessTokenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("OneTimeAccess.Models.OneTimeAccessToken", b =>
                {
                    b.Property<int>("OneTimeAccessTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TokenContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("OneTimeAccessTokenId");

                    b.ToTable("Tokens");
                });
#pragma warning restore 612, 618
        }
    }
}