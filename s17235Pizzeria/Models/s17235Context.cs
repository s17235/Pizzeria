using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace s17235Pizzeria.Models
{
    public partial class s17235Context : DbContext
    {
        public s17235Context()
        {
        }

        public s17235Context(DbContextOptions<s17235Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<Dodatek> Dodatek { get; set; }
        public virtual DbSet<DodatekZamowienie> DodatekZamowienie { get; set; }
        public virtual DbSet<Emp> Emp { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuDodatek> MenuDodatek { get; set; }
        public virtual DbSet<MenuNapoj> MenuNapoj { get; set; }
        public virtual DbSet<MenuPizza> MenuPizza { get; set; }
        public virtual DbSet<Napoj> Napoj { get; set; }
        public virtual DbSet<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual DbSet<PizzaZamowienie> PizzaZamowienie { get; set; }
        public virtual DbSet<Pizzeria> Pizzeria { get; set; }
        public virtual DbSet<PizzeriaPromocja> PizzeriaPromocja { get; set; }
        public virtual DbSet<Promocja> Promocja { get; set; }
        public virtual DbSet<Rodzaj> Rodzaj { get; set; }
        public virtual DbSet<Rozmiar> Rozmiar { get; set; }
        public virtual DbSet<RozmiarNapoj> RozmiarNapoj { get; set; }
        public virtual DbSet<RozmiarPizza> RozmiarPizza { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Zamowienie> Zamowienie { get; set; }

        // Unable to generate entity type for table 'dbo.DEPT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SALGRADE'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s17235;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.HasKey(e => e.IdAdministrator)
                    .HasName("Administrator_pk");

                entity.Property(e => e.IdAdministrator)
                    .HasColumnName("idAdministrator")
                    .ValueGeneratedNever();

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasColumnName("imie")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasColumnName("nazwisko")
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dodatek>(entity =>
            {
                entity.HasKey(e => e.IdDodatek)
                    .HasName("Dodatek_pk");

                entity.Property(e => e.IdDodatek)
                    .HasColumnName("idDodatek")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DodatekZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.DodatekIdDodatek, e.ZamowienieIdZamowienie })
                    .HasName("DodatekZamowienie_pk");

                entity.Property(e => e.DodatekIdDodatek).HasColumnName("Dodatek_idDodatek");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_idZamowienie");

                entity.HasOne(d => d.DodatekIdDodatekNavigation)
                    .WithMany(p => p.DodatekZamowienie)
                    .HasForeignKey(d => d.DodatekIdDodatek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DodatekZamowienie_Dodatek");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.DodatekZamowienie)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DodatekZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Emp>(entity =>
            {
                entity.HasKey(e => e.Empno)
                    .HasName("PK__EMP__14CCF2EE1F73B9E8");

                entity.ToTable("EMP");

                entity.Property(e => e.Empno)
                    .HasColumnName("EMPNO")
                    .ValueGeneratedNever();

                entity.Property(e => e.Comm).HasColumnName("COMM");

                entity.Property(e => e.Deptno).HasColumnName("DEPTNO");

                entity.Property(e => e.Ename)
                    .HasColumnName("ENAME")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnName("HIREDATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Job)
                    .HasColumnName("JOB")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.Mgr).HasColumnName("MGR");

                entity.Property(e => e.Sal).HasColumnName("SAL");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("Menu_pk");

                entity.Property(e => e.IdMenu)
                    .HasColumnName("idMenu")
                    .ValueGeneratedNever();

                entity.Property(e => e.PizzeriaIdPizzeria).HasColumnName("Pizzeria_idPizzeria");

                entity.HasOne(d => d.PizzeriaIdPizzeriaNavigation)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.PizzeriaIdPizzeria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Menu_Pizzeria");
            });

            modelBuilder.Entity<MenuDodatek>(entity =>
            {
                entity.HasKey(e => new { e.MenuIdMenu, e.DodatekIdDodatek })
                    .HasName("MenuDodatek_pk");

                entity.Property(e => e.MenuIdMenu).HasColumnName("Menu_idMenu");

                entity.Property(e => e.DodatekIdDodatek).HasColumnName("Dodatek_idDodatek");

                entity.HasOne(d => d.DodatekIdDodatekNavigation)
                    .WithMany(p => p.MenuDodatek)
                    .HasForeignKey(d => d.DodatekIdDodatek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuDodatek_Dodatek");

                entity.HasOne(d => d.MenuIdMenuNavigation)
                    .WithMany(p => p.MenuDodatek)
                    .HasForeignKey(d => d.MenuIdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuDodatek_Menu");
            });

            modelBuilder.Entity<MenuNapoj>(entity =>
            {
                entity.HasKey(e => new { e.MenuIdMenu, e.NapojIdNapoj })
                    .HasName("MenuNapoj_pk");

                entity.Property(e => e.MenuIdMenu).HasColumnName("Menu_idMenu");

                entity.Property(e => e.NapojIdNapoj).HasColumnName("Napoj_idNapoj");

                entity.HasOne(d => d.MenuIdMenuNavigation)
                    .WithMany(p => p.MenuNapoj)
                    .HasForeignKey(d => d.MenuIdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuNapoj_Menu");

                entity.HasOne(d => d.NapojIdNapojNavigation)
                    .WithMany(p => p.MenuNapoj)
                    .HasForeignKey(d => d.NapojIdNapoj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuNapoj_Napoj");
            });

            modelBuilder.Entity<MenuPizza>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.MenuIdMenu })
                    .HasName("MenuPizza_pk");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.Property(e => e.MenuIdMenu).HasColumnName("Menu_idMenu");

                entity.HasOne(d => d.MenuIdMenuNavigation)
                    .WithMany(p => p.MenuPizza)
                    .HasForeignKey(d => d.MenuIdMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuPizza_Menu");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.MenuPizza)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MenuPizza_Pizza");
            });

            modelBuilder.Entity<Napoj>(entity =>
            {
                entity.HasKey(e => e.IdNapoj)
                    .HasName("Napoj_pk");

                entity.Property(e => e.IdNapoj)
                    .HasColumnName("idNapoj")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NapojZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.NapojIdNapoj, e.ZamowienieIdZamowienie })
                    .HasName("NapojZamowienie_pk");

                entity.Property(e => e.NapojIdNapoj).HasColumnName("Napoj_idNapoj");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_idZamowienie");

                entity.HasOne(d => d.NapojIdNapojNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.NapojIdNapoj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NapojZamowienie_Napoj");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.NapojZamowienie)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("NapojZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.IdPizza)
                    .HasName("Pizza_pk");

                entity.Property(e => e.IdPizza)
                    .HasColumnName("idPizza")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaSkladnik>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.SkladnikIdSkladnik })
                    .HasName("PizzaSkladnik_pk");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_idSkladnik");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Pizza");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaSkladnik)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaSkladnik_Skladnik");
            });

            modelBuilder.Entity<PizzaZamowienie>(entity =>
            {
                entity.HasKey(e => new { e.PizzaIdPizza, e.ZamowienieIdZamowienie })
                    .HasName("PizzaZamowienie_pk");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.Property(e => e.ZamowienieIdZamowienie).HasColumnName("Zamowienie_idZamowienie");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaZamowienie_Pizza");

                entity.HasOne(d => d.ZamowienieIdZamowienieNavigation)
                    .WithMany(p => p.PizzaZamowienie)
                    .HasForeignKey(d => d.ZamowienieIdZamowienie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaZamowienie_Zamowienie");
            });

            modelBuilder.Entity<Pizzeria>(entity =>
            {
                entity.HasKey(e => e.IdPizzeria)
                    .HasName("Pizzeria_pk");

                entity.Property(e => e.IdPizzeria)
                    .HasColumnName("idPizzeria")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasColumnName("adres")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzeriaPromocja>(entity =>
            {
                entity.HasKey(e => new { e.PizzeriaIdPizzeria, e.PromocjaIdPromocja })
                    .HasName("PizzeriaPromocja_pk");

                entity.Property(e => e.PizzeriaIdPizzeria).HasColumnName("Pizzeria_idPizzeria");

                entity.Property(e => e.PromocjaIdPromocja).HasColumnName("Promocja_idPromocja");

                entity.HasOne(d => d.PizzeriaIdPizzeriaNavigation)
                    .WithMany(p => p.PizzeriaPromocja)
                    .HasForeignKey(d => d.PizzeriaIdPizzeria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzeriaPromocja_Pizzeria");

                entity.HasOne(d => d.PromocjaIdPromocjaNavigation)
                    .WithMany(p => p.PizzeriaPromocja)
                    .HasForeignKey(d => d.PromocjaIdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzeriaPromocja_Promocja");
            });

            modelBuilder.Entity<Promocja>(entity =>
            {
                entity.HasKey(e => e.IdPromocja)
                    .HasName("Promocja_pk");

                entity.Property(e => e.IdPromocja)
                    .HasColumnName("idPromocja")
                    .ValueGeneratedNever();

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rodzaj>(entity =>
            {
                entity.HasKey(e => e.IdRodzaju)
                    .HasName("Rodzaj_pk");

                entity.Property(e => e.IdRodzaju)
                    .HasColumnName("idRodzaju")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rozmiar>(entity =>
            {
                entity.HasKey(e => e.IdRozmiar)
                    .HasName("Rozmiar_pk");

                entity.Property(e => e.IdRozmiar)
                    .HasColumnName("idRozmiar")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nazwa).HasColumnName("nazwa");
            });

            modelBuilder.Entity<RozmiarNapoj>(entity =>
            {
                entity.HasKey(e => new { e.RozmiarIdRozmiar, e.NapojIdNapoj })
                    .HasName("RozmiarNapoj_pk");

                entity.Property(e => e.RozmiarIdRozmiar).HasColumnName("Rozmiar_idRozmiar");

                entity.Property(e => e.NapojIdNapoj).HasColumnName("Napoj_idNapoj");

                entity.HasOne(d => d.NapojIdNapojNavigation)
                    .WithMany(p => p.RozmiarNapoj)
                    .HasForeignKey(d => d.NapojIdNapoj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RozmiarNapoj_Napoj");

                entity.HasOne(d => d.RozmiarIdRozmiarNavigation)
                    .WithMany(p => p.RozmiarNapoj)
                    .HasForeignKey(d => d.RozmiarIdRozmiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RozmiarNapoj_Rozmiar");
            });

            modelBuilder.Entity<RozmiarPizza>(entity =>
            {
                entity.HasKey(e => new { e.RozmiarIdRozmiar, e.PizzaIdPizza })
                    .HasName("RozmiarPizza_pk");

                entity.Property(e => e.RozmiarIdRozmiar).HasColumnName("Rozmiar_idRozmiar");

                entity.Property(e => e.PizzaIdPizza).HasColumnName("Pizza_idPizza");

                entity.HasOne(d => d.PizzaIdPizzaNavigation)
                    .WithMany(p => p.RozmiarPizza)
                    .HasForeignKey(d => d.PizzaIdPizza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RozmiarPizza_Pizza");

                entity.HasOne(d => d.RozmiarIdRozmiarNavigation)
                    .WithMany(p => p.RozmiarPizza)
                    .HasForeignKey(d => d.RozmiarIdRozmiar)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RozmiarPizza_Rozmiar");
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik)
                    .HasColumnName("idSkladnik")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasColumnName("nazwa")
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.RodzajIdRodzaju).HasColumnName("Rodzaj_idRodzaju");

                entity.HasOne(d => d.RodzajIdRodzajuNavigation)
                    .WithMany(p => p.Skladnik)
                    .HasForeignKey(d => d.RodzajIdRodzaju)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Skladnik_Rodzaj");
            });

            modelBuilder.Entity<Zamowienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienie)
                    .HasName("Zamowienie_pk");

                entity.Property(e => e.IdZamowienie)
                    .HasColumnName("idZamowienie")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresDostawy)
                    .IsRequired()
                    .HasColumnName("adresDostawy")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.DataZamowienia)
                    .HasColumnName("dataZamowienia")
                    .HasColumnType("datetime");

                entity.Property(e => e.PromocjaIdPromocja).HasColumnName("Promocja_idPromocja");

                entity.HasOne(d => d.PromocjaIdPromocjaNavigation)
                    .WithMany(p => p.Zamowienie)
                    .HasForeignKey(d => d.PromocjaIdPromocja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamowienie_Promocja");
            });
        }
    }
}
