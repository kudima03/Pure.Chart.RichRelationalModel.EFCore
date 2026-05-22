# Pure.Chart.RichRelationalModel.EFCore

Entity Framework Core `DbContext` for the **Pure.Chart** RichRelationalModel — maps chart, axis, chart type, and series entities to a relational database.

[![.NET build & test](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Chart.RichRelationalModel.EFCore)](https://www.nuget.org/packages/Pure.Chart.RichRelationalModel.EFCore)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`Pure.Chart.RichRelationalModel.EFCore` provides a ready-to-use EF Core `DbContext` for persisting chart data modelled with the Pure.Chart RichRelationalModel. It exposes typed `DbSet<T>` properties for every aggregate root and applies the full set of EF Core model configurations on startup.

## Public API

| Type | Kind | Description |
|------|------|-------------|
| `ChartDbContext` | `sealed class` | EF Core `DbContext` for the chart domain. Primary constructor accepts `DbContextOptions<ChartDbContext>`. |

### `ChartDbContext` — DbSets

| Property | Entity type | Description |
|----------|-------------|-------------|
| `Charts` | `ChartEFCoreModel` | Root chart aggregates |
| `Types` | `ChartTypeEFCoreModel` | Chart type lookup entries |
| `Axes` | `AxisEFCoreModel` | Axis definitions attached to charts |
| `Series` | `ChartSeriesEFCoreModel` | Data series belonging to charts |

`OnModelCreating` applies `ChartConfiguration`, `ChartTypeConfiguration`, `AxisConfiguration`, and `ChartSeriesConfiguration` from the companion configurations package.

## Dependencies

- [`Pure.Chart.RichRelationalModel.EFCore.Models.Configurations`](https://github.com/kudima03/Pure.Chart.RichRelationalModel.EFCore.Models.Configurations/tree/0.1.0-preview.4.0.0) — EF Core `IEntityTypeConfiguration<T>` implementations for all chart entities

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```bash
dotnet add package Pure.Chart.RichRelationalModel.EFCore
```

## Usage

Register `ChartDbContext` in your DI container:

```csharp
builder.Services.AddDbContext<ChartDbContext>(options =>
    options.UseNpgsql(connectionString));
```

Inject and query:

```csharp
public sealed class ChartRepository(ChartDbContext db)
{
    public Task<List<ChartEFCoreModel>> GetAllAsync(CancellationToken ct) =>
        db.Charts.ToListAsync(ct);
}
```
