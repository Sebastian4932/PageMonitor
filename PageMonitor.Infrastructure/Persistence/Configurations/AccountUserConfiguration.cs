﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PageMonitor.Domain.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageMonitor.Infrastructure.Persistence.Configurations
{
    public class AccountUserConfiguration : IEntityTypeConfiguration<AccountUser>
    {
        public void Configure(EntityTypeBuilder<AccountUser> builder)
        {
            builder.HasOne(p => p.Account)
                .WithMany(a => a.AccountUsers)
                .HasForeignKey(k => k.AccountId);

            builder.HasOne(p => p.User)
                .WithMany(a => a.AccountUsers)
                .HasForeignKey(k => k.UserId);
        }
    }
}
