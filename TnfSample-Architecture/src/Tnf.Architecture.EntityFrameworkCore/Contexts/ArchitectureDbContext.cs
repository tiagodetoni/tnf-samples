﻿using Microsoft.EntityFrameworkCore;
using Tnf.Architecture.EntityFrameworkCore.Entities;
using Tnf.EntityFrameworkCore;

namespace Tnf.Architecture.EntityFrameworkCore.Contexts
{
    public class ArchitectureDbContext : TnfDbContext
    {
        public DbSet<CountryPoco> Countries { get; set; }

        public ArchitectureDbContext(DbContextOptions<ArchitectureDbContext> options)
            : base(options)
        {
        }
    }
}