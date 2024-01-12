﻿using Microsoft.EntityFrameworkCore;
using NTierApplication.DataAccess.Map;
using NTierApplication.DataAccess.Models;

namespace NTierApplication.DataAccess;

public class MainContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<User> Users { get; set; }


    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ItemMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
