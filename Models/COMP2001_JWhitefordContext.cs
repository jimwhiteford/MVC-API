using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using COMP2001_API_2;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace COMP2001_API_2.Models
{
    public partial class COMP2001_JWhitefordContext : DbContext   // database context class
    {
        private readonly string _connection;
       
        public COMP2001_JWhitefordContext()
        {
        }
        public COMP2001_JWhitefordContext(DbContextOptions<COMP2001_JWhitefordContext> options) : base(options)
        {
            _connection = Database.GetConnectionString();
        }
        public virtual DbSet<Programme> Programmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=socem1.uopnet.plymouth.ac.uk;Database=COMP2001_JWhiteford;User Id=JWhiteford;Password=PgcE773*;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Programme>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("pkProgramme");

                entity.ToTable("Programme", "CW2");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public void Create(Programme sp)
        {
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("CW2.CreateProgramme", sql)) // name of procedure created.
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("code", sp.@Code));
                    cmd.Parameters.Add(new SqlParameter("title", sp.@Title));

                    sql.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(Programme sp)
        {
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("CW2.EditProgramme", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Code", sp.@Code)); // int can not be null 
                    cmd.Parameters.Add(new SqlParameter("@Title", string.IsNullOrEmpty(sp.@Title) ? (object)DBNull.Value : sp.@Title)); // checks to see if if it exists or is null

                    sql.Open();

                    cmd.ExecuteNonQuery();  // executes the stored procedure
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connection))
            {
                using (SqlCommand cmd = new SqlCommand("CW2.DeleteProgramme", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("code", id));

                    sql.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
