﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cdf_api_integrador.Repositories.Entity;

#nullable disable

namespace cdfapiintegrador.Migrations
{
    [DbContext(typeof(ContextEntity))]
    [Migration("20230121171141_CriaBaseDeDados")]
    partial class CriaBaseDeDados
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cdf_api_integrador.Models.Campanha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DtCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LojaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LojaId");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Loja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Longitude")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.PedidoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("pedidos-produtos");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.PosicoesProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CampanhaId")
                        .HasColumnType("int");

                    b.Property<int>("PosicaoX")
                        .HasColumnType("int");

                    b.Property<int>("PosicaoY")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CampanhaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("posicoes-produtos");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QtdEstoque")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Regra")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Campanha", b =>
                {
                    b.HasOne("cdf_api_integrador.Models.Loja", "loja")
                        .WithMany()
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("loja");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Cliente", b =>
                {
                    b.HasOne("cdf_api_integrador.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Loja", b =>
                {
                    b.HasOne("cdf_api_integrador.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.Pedido", b =>
                {
                    b.HasOne("cdf_api_integrador.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.PedidoProduto", b =>
                {
                    b.HasOne("cdf_api_integrador.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cdf_api_integrador.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("cdf_api_integrador.Models.PosicoesProduto", b =>
                {
                    b.HasOne("cdf_api_integrador.Models.Campanha", "Campanha")
                        .WithMany()
                        .HasForeignKey("CampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cdf_api_integrador.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campanha");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
