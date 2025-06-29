﻿using Banking.Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.DateOfBirth);

        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(x => x.LastLoginAt);

        // Indexes
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.PhoneNumber)
            .IsUnique()
            .HasFilter("[PhoneNumber] IS NOT NULL");

        // Query filter for soft delete
        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}
