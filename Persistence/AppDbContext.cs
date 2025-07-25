using System;
using System.Diagnostics;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
public required DbSet<Domain.Activity> TotalAnesthesiaCare { get; set; }
}
