namespace Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB_Relief : DbContext
    {
        public DB_Relief()
            : base("name=DB_Relief")
        {
        }

        public virtual DbSet<categorize> categorizes { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Pesonal> Pesonals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Proof> Proofs { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Registration_form> Registration_forms { get; set; }
        public virtual DbSet<Relief> Reliefs { get; set; }
        public virtual DbSet<Relief_classification> Relief_classification { get; set; }
        public virtual DbSet<Role_Type> Role_Type { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }
        public virtual DbSet<Details_receipt> Details_receipt { get; set; }
        public virtual DbSet<Details_registration> Details_registration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categorize>()
                .Property(e => e.ID_cate)
                .IsUnicode(false);

            modelBuilder.Entity<District>()
                .Property(e => e.ID_district)
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .Property(e => e.ID_user)
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .Property(e => e.ID_type)
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .Property(e => e.ID_card)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Pesonal>()
                .HasMany(e => e.Registration_form)
                .WithRequired(e => e.Pesonal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID_product)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ID_cate)
                .IsUnicode(false);

            modelBuilder.Entity<Proof>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.ID_user)
                .IsUnicode(false);

            modelBuilder.Entity<Registration_form>()
                .Property(e => e.ID_user)
                .IsUnicode(false);

            modelBuilder.Entity<Relief>()
                .Property(e => e.ID_rc)
                .IsUnicode(false);

            modelBuilder.Entity<Relief>()
                .Property(e => e.ID_ward)
                .IsUnicode(false);

            modelBuilder.Entity<Relief>()
                .Property(e => e.map)
                .IsUnicode(false);

            modelBuilder.Entity<Relief>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<Relief>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<Relief>()
                .HasMany(e => e.Registration_form)
                .WithRequired(e => e.Relief)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Relief_classification>()
                .Property(e => e.ID_rc)
                .IsUnicode(false);

            modelBuilder.Entity<Relief_classification>()
                .HasMany(e => e.Reliefs)
                .WithRequired(e => e.Relief_classification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role_Type>()
                .Property(e => e.ID_type)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .Property(e => e.ID_ward)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .Property(e => e.ID_district)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.Reliefs)
                .WithRequired(e => e.Ward)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Details_receipt>()
                .Property(e => e.ID_product)
                .IsUnicode(false);

            modelBuilder.Entity<Details_registration>()
                .Property(e => e.ID_product)
                .IsUnicode(false);
        }
    }
}
