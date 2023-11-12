using Microsoft.EntityFrameworkCore;


namespace PlanesTuristicos.Models;

public partial class PlanesTuristicosContext : DbContext
{
   

    public PlanesTuristicosContext(DbContextOptions<PlanesTuristicosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Turista> Usuarios { get; set; }
    public virtual DbSet<Proveedor> Proveedor { get; set; }
    public virtual DbSet<PlanesT> PlanesT { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Turista>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF971AB28277");

            entity.ToTable("Usuario");

            entity.Property(e => e.Cedula).HasColumnName("cedula");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.NombreTurista)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_turista");

        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id_Proveedor).HasName("PK__Proveedores__Id");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Cedula).HasColumnName("cedula");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.nombreProveedor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_turista");
            entity.Property(e => e.Rut)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("Rut");

        });
           modelBuilder.Entity<PlanesT>(entity =>
        {
            entity.HasKey(e => e.Id_PlanTuristicos).HasName("PK__PlanesT__Id");

            entity.ToTable("PlanesT");

            entity.Property(e => e.Rut).HasColumnName("Rut");
            entity.Property(e => e.Municipio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Municipio");
            entity.Property(e => e.Precio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Precio");
            entity.Property(e => e.Actividades)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Actividades");
            entity.Property(e => e.Duracion)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("Duracion");
            entity.Property(e => e.Nombre_PlanTuristico)
               .HasMaxLength(50)
               .IsUnicode(false)
               .HasColumnName("Nombre_PlanTuristico");
            entity.Property(e => e.Informacion)
              .HasMaxLength(50)
              .HasColumnName("Informacion");


        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
