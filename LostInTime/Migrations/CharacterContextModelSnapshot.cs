﻿// <auto-generated />
using System;
using LostInTime.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LostInTime.Migrations
{
    [DbContext(typeof(LostInTimeContext))]
    partial class CharacterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("LostInTime.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("ItemLevel")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("LostInTime.Models.TemplateGroup", b =>
                {
                    b.Property<int>("TemplateGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("TemplateGroupId");

                    b.ToTable("TemplateGroups");
                });

            modelBuilder.Entity("LostInTime.Models.TemplateGroupItem", b =>
                {
                    b.Property<int>("TemplateGroupItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ResetType")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TemplateGroupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TemplateGroupItemId");

                    b.HasIndex("TemplateGroupId");

                    b.ToTable("TemplateGroupItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("TemplateGroupItem");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("LostInTime.Models.CheckBoxTemplateGroupItem", b =>
                {
                    b.HasBaseType("LostInTime.Models.TemplateGroupItem");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("CheckBoxTemplateGroupItem");
                });

            modelBuilder.Entity("LostInTime.Models.TextTemplateGroupItem", b =>
                {
                    b.HasBaseType("LostInTime.Models.TemplateGroupItem");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TextTemplateGroupItem");
                });

            modelBuilder.Entity("LostInTime.Models.TemplateGroupItem", b =>
                {
                    b.HasOne("LostInTime.Models.TemplateGroup", null)
                        .WithMany("Items")
                        .HasForeignKey("TemplateGroupId");
                });

            modelBuilder.Entity("LostInTime.Models.TemplateGroup", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
