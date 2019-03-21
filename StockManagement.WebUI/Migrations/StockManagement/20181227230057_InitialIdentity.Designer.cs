﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using StockManagement.WebUI.Repository.Concrete.EntityFramework;
using System;

namespace StockManagement.WebUI.Migrations.StockManagement
{
    [DbContext(typeof(StockManagementContext))]
    [Migration("20181227230057_InitialIdentity")]
    partial class InitialIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockManagement.WebUI.Entity.Atik", b =>
                {
                    b.Property<int>("AtikId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AtikTarih");

                    b.Property<int>("StoklarId");

                    b.HasKey("AtikId");

                    b.HasIndex("StoklarId");

                    b.ToTable("Atiklar");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Bolum", b =>
                {
                    b.Property<int>("BolumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BolumAdi");

                    b.HasKey("BolumId");

                    b.ToTable("Bolumler");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Calisan", b =>
                {
                    b.Property<int>("CalisanId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BolumId");

                    b.Property<string>("CalisanAdi")
                        .IsRequired();

                    b.Property<string>("CalisanSoyadi")
                        .IsRequired();

                    b.Property<bool>("IsYetkili");

                    b.HasKey("CalisanId");

                    b.HasIndex("BolumId");

                    b.ToTable("Calisanlar");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Stok", b =>
                {
                    b.Property<int>("StokId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Adet");

                    b.Property<int>("UrunId");

                    b.HasKey("StokId");

                    b.HasIndex("UrunId")
                        .IsUnique();

                    b.ToTable("Stok");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Stoklar", b =>
                {
                    b.Property<int>("StoklarId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UrunId");

                    b.HasKey("StoklarId");

                    b.HasIndex("UrunId");

                    b.ToTable("Stoklar");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Urun", b =>
                {
                    b.Property<int>("UrunId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Aciklamasi");

                    b.Property<double>("BirimFiyat");

                    b.Property<string>("Firma")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ParcaTipi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("SatinAlmaTarihi");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("UrunKategoriId");

                    b.HasKey("UrunId");

                    b.HasIndex("UrunKategoriId");

                    b.ToTable("Urunler");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.UrunKategori", b =>
                {
                    b.Property<int>("UrunKategoriId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KategoriAdi");

                    b.HasKey("UrunKategoriId");

                    b.ToTable("UrunKategoriler");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Zimmet", b =>
                {
                    b.Property<int>("ZimmetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalisanId");

                    b.Property<int>("StoklarId");

                    b.Property<DateTime>("ZimmetTarih");

                    b.HasKey("ZimmetId");

                    b.HasIndex("CalisanId");

                    b.HasIndex("StoklarId");

                    b.ToTable("Zimmetler");
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Atik", b =>
                {
                    b.HasOne("StockManagement.WebUI.Entity.Stoklar", "Stoklar")
                        .WithMany()
                        .HasForeignKey("StoklarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Calisan", b =>
                {
                    b.HasOne("StockManagement.WebUI.Entity.Bolum", "Bolum")
                        .WithMany("Calisanlar")
                        .HasForeignKey("BolumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Stok", b =>
                {
                    b.HasOne("StockManagement.WebUI.Entity.Urun", "Urun")
                        .WithOne("Stok")
                        .HasForeignKey("StockManagement.WebUI.Entity.Stok", "UrunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Stoklar", b =>
                {
                    b.HasOne("StockManagement.WebUI.Entity.Urun", "Urun")
                        .WithMany()
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Urun", b =>
                {
                    b.HasOne("StockManagement.WebUI.Entity.UrunKategori", "UrunKategori")
                        .WithMany("Urunler")
                        .HasForeignKey("UrunKategoriId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.WebUI.Entity.Zimmet", b =>
                {
                    b.HasOne("StockManagement.WebUI.Entity.Calisan", "Calisan")
                        .WithMany()
                        .HasForeignKey("CalisanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StockManagement.WebUI.Entity.Stoklar", "Stoklar")
                        .WithMany()
                        .HasForeignKey("StoklarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
