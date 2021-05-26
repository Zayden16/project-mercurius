﻿using MercuriusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MercuriusApi.DataAccess
{
    public class PostgreSqlContext: DbContext  
    {  
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)  
        {  
        }  
  
        public DbSet<User> User { get; set; }  
  
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>()
                .HasKey(x => x.Article_Id);
            
            builder.Entity<Article>()
                .HasOne<TaxRate>()
                .WithMany()
                .HasForeignKey(x => x.Article_TaxRate);

            builder.Entity<Article>()
                .HasOne<ArticleUnit>()
                .WithMany()
                .HasForeignKey(x => x.Article_Unit);

            builder.Entity<ArticlePosition>()
                .HasKey(x => x.ArticlePosition_Id);

            builder.Entity<ArticlePosition>()
                .HasOne<Article>()
                .WithMany()
                .HasForeignKey(x => x.Article_Id);

            builder.Entity<ArticleUnit>()
                .HasKey(x => x.ArticleUnit_Id);

            builder.Entity<Customer>()
                .HasKey(x => x.Customer_Id);

            builder.Entity<Customer>()
                .HasOne<Plz>()
                .WithMany()
                .HasForeignKey(x => x.Customer_PlzId);

            builder.Entity<Document>()
                .HasKey(x => x.Document_Id);

            builder.Entity<Document>()
                .HasOne<DocumentType>()
                .WithMany()
                .HasForeignKey(x => x.Document_TypeId);

            builder.Entity<Document>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(x => x.Document_CreatorId);

            builder.Entity<Document>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.Document_SendeeId);

            builder.Entity<Document>()
                .HasOne<DocumentStatus>()
                .WithMany()
                .HasForeignKey(x => x.Document_StatusId);

            builder.Entity<Document>()
                .HasOne<ArticlePosition>()
                .WithMany()
                .HasForeignKey(x => x.Document_ArticlePositionId);

            builder.Entity<DocumentStatus>()
                .HasKey(x => x.DocumentStatus_Id);

            builder.Entity<DocumentType>()
                .HasKey(x => x.DocumentType_Id);

            builder.Entity<Plz>()
                .HasKey(x => x.Plz_Id);

            builder.Entity<TaxRate>()
                .HasKey(x => x.Taxrate_Id);

            builder.Entity<User>()
                .HasKey(x => x.User_Id);

            base.OnModelCreating(builder);  
        }  
  
        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        }  
    }  
}
