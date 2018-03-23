﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SuperMarket.Backoffice.Sales.Domain.Entities;
using SuperMarket.Backoffice.Sales.Infra.Contexts;
using System;

namespace SuperMarket.Backoffice.Sales.Infra.Migrations
{
    [DbContext(typeof(SalesContext))]
    partial class SalesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SuperMarket.Backoffice.Sales.Infra.Pocos.PurchaseOrderPoco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BaseValue")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<Guid>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18, 6)");

                    b.Property<Guid>("Number");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

                    b.Property<decimal?>("Tax")
                        .IsRequired()
                        .HasColumnType("decimal(18, 6)");

                    b.Property<decimal?>("TotalValue")
                        .IsRequired()
                        .HasColumnType("decimal(18, 6)");

                    b.HasKey("Id");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("SuperMarket.Backoffice.Sales.Infra.Pocos.PurchaseOrderProductPoco", b =>
                {
                    b.Property<Guid>("ProductId");

                    b.Property<Guid>("PurchaseOrderId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitValue")
                        .HasColumnType("decimal(18, 6)");

                    b.HasKey("ProductId", "PurchaseOrderId");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseOrderProducts");
                });

            modelBuilder.Entity("SuperMarket.Backoffice.Sales.Infra.Pocos.PurchaseOrderProductPoco", b =>
                {
                    b.HasOne("SuperMarket.Backoffice.Sales.Infra.Pocos.PurchaseOrderPoco", "PurchaseOrder")
                        .WithMany("PurchaseOrderProducts")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
