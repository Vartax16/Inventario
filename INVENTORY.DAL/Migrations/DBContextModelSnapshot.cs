﻿// <auto-generated />
using System;
using INVENTARIO.DAL.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace INVENTORY.DAL.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("INVENTORY.MODEL.Models.Categorias", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Clientes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UltimaCompra")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Compras", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductoID")
                        .HasColumnType("int");

                    b.Property<string>("Productos")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Comprobantes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Comprobantes");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Productos", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoriaID")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrecioCompra")
                        .HasColumnType("real");

                    b.Property<float>("PrecioVenta")
                        .HasColumnType("real");

                    b.Property<int>("ProveedorID")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("Venta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategoriaID");

                    b.HasIndex("ProveedorID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Proveedores", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celular")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Usuarios", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Perfil")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UltimoLogin")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Ventas", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("Codigo")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ComprobanteID")
                        .HasColumnType("int");

                    b.Property<float>("Descuento")
                        .HasColumnType("real");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("MetodoPago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moneda")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<float>("Neto")
                        .HasColumnType("real");

                    b.Property<int>("ProductoID")
                        .HasColumnType("int");

                    b.Property<string>("Productos")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClienteID");

                    b.HasIndex("ComprobanteID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Compras", b =>
                {
                    b.HasOne("INVENTORY.MODEL.Models.Productos", "Producto")
                        .WithMany("Compras")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INVENTORY.MODEL.Models.Usuarios", "Usuario")
                        .WithMany("Compras")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Productos", b =>
                {
                    b.HasOne("INVENTORY.MODEL.Models.Categorias", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INVENTORY.MODEL.Models.Proveedores", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("ProveedorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Ventas", b =>
                {
                    b.HasOne("INVENTORY.MODEL.Models.Clientes", "Cliente")
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INVENTORY.MODEL.Models.Comprobantes", "Comprobante")
                        .WithMany("Ventas")
                        .HasForeignKey("ComprobanteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INVENTORY.MODEL.Models.Productos", "Producto")
                        .WithMany("Ventas")
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("INVENTORY.MODEL.Models.Usuarios", "Usuario")
                        .WithMany("Ventas")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Comprobante");

                    b.Navigation("Producto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Categorias", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Clientes", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Comprobantes", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Productos", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Proveedores", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("INVENTORY.MODEL.Models.Usuarios", b =>
                {
                    b.Navigation("Compras");

                    b.Navigation("Ventas");
                });
#pragma warning restore 612, 618
        }
    }
}
