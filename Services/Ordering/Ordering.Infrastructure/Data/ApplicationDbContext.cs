﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Orders.Data;
using Ordering.Domain.Models;

namespace Ordering.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Scans assembly for IEntityTypeConfiguration implementations
        
        base.OnModelCreating(builder);
    }
}