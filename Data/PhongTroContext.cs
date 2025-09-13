using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PhongTro123.Models;

namespace PhongTro123.Data;

public partial class PhongTroContext : DbContext
{
    public PhongTroContext()
    {
    }

    public PhongTroContext(DbContextOptions<PhongTroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomStatus> RoomStatuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.Amenityid).HasName("amenities_pkey");

            entity.ToTable("amenities");

            entity.Property(e => e.Amenityid).HasColumnName("amenityid");
            entity.Property(e => e.Amenityname)
                .HasMaxLength(100)
                .HasColumnName("amenityname");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .HasColumnName("categoryname");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Districtid).HasName("districts_pkey");

            entity.ToTable("districts");

            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Districtname)
                .HasMaxLength(100)
                .HasColumnName("districtname");
            entity.Property(e => e.Provinceid).HasColumnName("provinceid");

            entity.HasOne(d => d.Province).WithMany(p => p.Districts)
                .HasForeignKey(d => d.Provinceid)
                .HasConstraintName("districts_provinceid_fkey");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Favoriteid).HasName("favorites_pkey");

            entity.ToTable("favorites");

            entity.HasIndex(e => new { e.Userid, e.Roomid }, "favorites_userid_roomid_key").IsUnique();

            entity.Property(e => e.Favoriteid).HasColumnName("favoriteid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Room).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("favorites_roomid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("favorites_userid_fkey");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Imageid).HasName("images_pkey");

            entity.ToTable("images");

            entity.Property(e => e.Imageid).HasColumnName("imageid");
            entity.Property(e => e.Imageurl).HasColumnName("imageurl");
            entity.Property(e => e.Roomid).HasColumnName("roomid");

            entity.HasOne(d => d.Room).WithMany(p => p.Images)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("images_roomid_fkey");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Messageid).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.Property(e => e.Messageid).HasColumnName("messageid");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Receiverid).HasColumnName("receiverid");
            entity.Property(e => e.Senderid).HasColumnName("senderid");
            entity.Property(e => e.Sentat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("sentat");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.Receiverid)
                .HasConstraintName("messages_receiverid_fkey");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.Senderid)
                .HasConstraintName("messages_senderid_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("payments_pkey");

            entity.ToTable("payments");

            entity.Property(e => e.Paymentid).HasColumnName("paymentid");
            entity.Property(e => e.Amount)
                .HasPrecision(12, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.Paymentdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paymentdate");
            entity.Property(e => e.Paymentmethod)
                .HasMaxLength(50)
                .HasColumnName("paymentmethod");
            entity.Property(e => e.Paymentstatus)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Pending'::character varying")
                .HasColumnName("paymentstatus");
            entity.Property(e => e.Roomid).HasColumnName("roomid");

            entity.HasOne(d => d.Owner).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Ownerid)
                .HasConstraintName("payments_ownerid_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Roomid)
                .HasConstraintName("payments_roomid_fkey");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Provinceid).HasName("provinces_pkey");

            entity.ToTable("provinces");

            entity.Property(e => e.Provinceid).HasColumnName("provinceid");
            entity.Property(e => e.Provincename)
                .HasMaxLength(100)
                .HasColumnName("provincename");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Roomid).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Area)
                .HasPrecision(10, 2)
                .HasColumnName("area");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Isvip)
                .HasDefaultValue(false)
                .HasColumnName("isvip");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasColumnName("price");
            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.VipLevel)
                .HasDefaultValue(0)
                .HasColumnName("vip_level");
            entity.Property(e => e.Wardid).HasColumnName("wardid");

            entity.HasOne(d => d.Category).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("rooms_categoryid_fkey");

            entity.HasOne(d => d.Owner).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Ownerid)
                .HasConstraintName("rooms_ownerid_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Statusid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rooms_statusid_fkey");

            entity.HasOne(d => d.Ward).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.Wardid)
                .HasConstraintName("rooms_wardid_fkey");

            entity.HasMany(d => d.Amenities).WithMany(p => p.Rooms)
                .UsingEntity<Dictionary<string, object>>(
                    "RoomAmenity",
                    r => r.HasOne<Amenity>().WithMany()
                        .HasForeignKey("Amenityid")
                        .HasConstraintName("room_amenities_amenityid_fkey"),
                    l => l.HasOne<Room>().WithMany()
                        .HasForeignKey("Roomid")
                        .HasConstraintName("room_amenities_roomid_fkey"),
                    j =>
                    {
                        j.HasKey("Roomid", "Amenityid").HasName("room_amenities_pkey");
                        j.ToTable("room_amenities");
                        j.IndexerProperty<int>("Roomid").HasColumnName("roomid");
                        j.IndexerProperty<int>("Amenityid").HasColumnName("amenityid");
                    });
        });

        modelBuilder.Entity<RoomStatus>(entity =>
        {
            entity.HasKey(e => e.Statusid).HasName("room_status_pkey");

            entity.ToTable("room_status");

            entity.HasIndex(e => e.Statusname, "room_status_statusname_key").IsUnique();

            entity.Property(e => e.Statusid).HasColumnName("statusid");
            entity.Property(e => e.Statusname)
                .HasMaxLength(50)
                .HasColumnName("statusname");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "users_email_key").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Wardid).HasName("wards_pkey");

            entity.ToTable("wards");

            entity.Property(e => e.Wardid).HasColumnName("wardid");
            entity.Property(e => e.Districtid).HasColumnName("districtid");
            entity.Property(e => e.Wardname)
                .HasMaxLength(100)
                .HasColumnName("wardname");

            entity.HasOne(d => d.District).WithMany(p => p.Wards)
                .HasForeignKey(d => d.Districtid)
                .HasConstraintName("wards_districtid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
