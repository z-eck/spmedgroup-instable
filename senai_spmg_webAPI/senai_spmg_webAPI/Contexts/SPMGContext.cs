using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_spmg_webAPI.Domains;

#nullable disable

namespace senai_spmg_webAPI.Contexts
{
    public partial class SPMGContext : DbContext
    {
        public SPMGContext()
        {
        }

        public SPMGContext(DbContextOptions<SPMGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Localaddress> Localaddresses { get; set; }
        public virtual DbSet<Medic> Medics { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Scheduling> Schedulings { get; set; }
        public virtual DbSet<Situation> Situations { get; set; }
        public virtual DbSet<Specialty> Specialties { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userimg> Userimgs { get; set; }
        public virtual DbSet<Usertype> Usertypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NOTE0113C3\\SQLEXPRESS; initial catalog=SENAI_SPMG; user Id=sa; pwd=Senai@132;");
                //optionsBuilder.UseSqlServer("Data Source=CAL\\SQLEXPRESS; initial catalog=SENAI_SPMG; user Id=sa; pwd=Senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.IdClinic)
                    .HasName("PK__CLINIC__A0E46310EEFCD72B");

                entity.ToTable("CLINIC");

                entity.HasIndex(e => e.ClinicAddress, "UQ__CLINIC__3149A0DC1A9A497C")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__CLINIC__35BD3E480AEE4E6F")
                    .IsUnique();

                entity.HasIndex(e => e.ClinicName, "UQ__CLINIC__C342B1FB492F40FC")
                    .IsUnique();

                entity.Property(e => e.IdClinic)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idClinic");

                entity.Property(e => e.ClinicAddress)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("clinicAddress");

                entity.Property(e => e.ClinicName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("clinicName");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("cnpj")
                    .IsFixedLength(true);

                entity.Property(e => e.CorporateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("corporateName");
            });

            modelBuilder.Entity<Localaddress>(entity =>
            {
                entity.HasKey(e => e.IdAddress)
                    .HasName("PK__LOCALADD__67E8C78CA78BA979");

                entity.ToTable("LOCALADDRESS");

                entity.HasIndex(e => e.Cep, "UQ__LOCALADD__D83671A5CEFDCEAF")
                    .IsUnique();

                entity.Property(e => e.IdAddress).HasColumnName("idAddress");

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("addressName");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("cep")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.District)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("district");

                entity.Property(e => e.Fu)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("fu")
                    .IsFixedLength(true);

                entity.Property(e => e.Place)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("place");
            });

            modelBuilder.Entity<Medic>(entity =>
            {
                entity.HasKey(e => e.IdMedic)
                    .HasName("PK__MEDIC__28E7F571E4A9DBDC");

                entity.ToTable("MEDIC");

                entity.HasIndex(e => e.IdUser, "UQ__MEDIC__3717C983792B9AAE")
                    .IsUnique();

                entity.HasIndex(e => e.Crm, "UQ__MEDIC__D836F7D11567104D")
                    .IsUnique();

                entity.Property(e => e.IdMedic).HasColumnName("idMedic");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("crm")
                    .IsFixedLength(true);

                entity.Property(e => e.IdClinic).HasColumnName("idClinic");

                entity.Property(e => e.IdSpecialty).HasColumnName("idSpecialty");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.MedicLastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("medicLastname");

                entity.Property(e => e.MedicName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("medicName");

                entity.HasOne(d => d.IdClinicNavigation)
                    .WithMany(p => p.Medics)
                    .HasForeignKey(d => d.IdClinic)
                    .HasConstraintName("FK__MEDIC__idClinic__3C69FB99");

                entity.HasOne(d => d.IdSpecialtyNavigation)
                    .WithMany(p => p.Medics)
                    .HasForeignKey(d => d.IdSpecialty)
                    .HasConstraintName("FK__MEDIC__idSpecial__3B75D760");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Medic)
                    .HasForeignKey<Medic>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MEDIC__idUser__3A81B327");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("PK__PATIENT__8C2428053C7A0156");

                entity.ToTable("PATIENT");

                entity.HasIndex(e => e.Rg, "UQ__PATIENT__321433109BDFA331")
                    .IsUnique();

                entity.HasIndex(e => e.IdUser, "UQ__PATIENT__3717C98304B11C32")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__PATIENT__D836E71F50757473")
                    .IsUnique();

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.AddressNumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("addressNumber");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birthDate");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DddPhone)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("dddPhone")
                    .IsFixedLength(true);

                entity.Property(e => e.IdAddress).HasColumnName("idAddress");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("patientName");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("rg")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAddressNavigation)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.IdAddress)
                    .HasConstraintName("FK__PATIENT__idAddre__45F365D3");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PATIENT__idUser__44FF419A");
            });

            modelBuilder.Entity<Scheduling>(entity =>
            {
                entity.HasKey(e => e.IdScheduling)
                    .HasName("PK__SCHEDULI__B8BB090D19AC2A70");

                entity.ToTable("SCHEDULING");

                entity.Property(e => e.IdScheduling).HasColumnName("idScheduling");

                entity.Property(e => e.IdMedic).HasColumnName("idMedic");

                entity.Property(e => e.IdPatient).HasColumnName("idPatient");

                entity.Property(e => e.IdSituation)
                    .HasColumnName("idSituation")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.SchedulingDateHour)
                    .HasColumnType("datetime")
                    .HasColumnName("schedulingDateHour");

                entity.Property(e => e.SchedulingDescription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("schedulingDescription");

                entity.HasOne(d => d.IdMedicNavigation)
                    .WithMany(p => p.Schedulings)
                    .HasForeignKey(d => d.IdMedic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SCHEDULIN__idMed__4BAC3F29");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Schedulings)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SCHEDULIN__idPat__4CA06362");

                entity.HasOne(d => d.IdSituationNavigation)
                    .WithMany(p => p.Schedulings)
                    .HasForeignKey(d => d.IdSituation)
                    .HasConstraintName("FK__SCHEDULIN__idSit__4E88ABD4");
            });

            modelBuilder.Entity<Situation>(entity =>
            {
                entity.HasKey(e => e.IdSituation)
                    .HasName("PK__SITUATIO__35C76303406383E3");

                entity.ToTable("SITUATION");

                entity.HasIndex(e => e.SituationDescription, "UQ__SITUATIO__C1DCA1EC6CA374C1")
                    .IsUnique();

                entity.Property(e => e.IdSituation)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituation");

                entity.Property(e => e.SituationDescription)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("situationDescription");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasKey(e => e.IdSpecialty)
                    .HasName("PK__SPECIALT__631D186FC55F2072");

                entity.ToTable("SPECIALTY");

                entity.HasIndex(e => e.SpecialtyName, "UQ__SPECIALT__9BDDB60AD0C392D3")
                    .IsUnique();

                entity.Property(e => e.IdSpecialty).HasColumnName("idSpecialty");

                entity.Property(e => e.SpecialtyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("specialtyName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__USERS__3717C98227C13649");

                entity.ToTable("USERS");

                entity.HasIndex(e => e.Email, "UQ__USERS__AB6E616422C37BE4")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdUserType).HasColumnName("idUserType");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("passwd");

                entity.HasOne(d => d.IdUserTypeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdUserType)
                    .HasConstraintName("FK__USERS__idUserTyp__300424B4");
            });

            modelBuilder.Entity<Userimg>(entity =>
            {
                entity.HasKey(e => e.IdUserImg)
                    .HasName("PK__USERIMG__F97020FC096A63E4");

                entity.ToTable("USERIMG");

                entity.HasIndex(e => e.IdUser, "UQ__USERIMG__3717C98366AFC30D")
                    .IsUnique();

                entity.Property(e => e.IdUserImg).HasColumnName("idUserImg");

                entity.Property(e => e.ArchiveName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("archiveName");

                entity.Property(e => e.BinaryNumber)
                    .IsRequired()
                    .HasColumnName("binaryNumber");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.InclusionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("inclusionDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Userimg)
                    .HasForeignKey<Userimg>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USERIMG__idUser__34C8D9D1");
            });

            modelBuilder.Entity<Usertype>(entity =>
            {
                entity.HasKey(e => e.IdUserType)
                    .HasName("PK__USERTYPE__96375927F646FE26");

                entity.ToTable("USERTYPE");

                entity.HasIndex(e => e.UserTypeDescription, "UQ__USERTYPE__31524FB4E36ACD02")
                    .IsUnique();

                entity.Property(e => e.IdUserType)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUserType");

                entity.Property(e => e.UserTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userTypeDescription");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
