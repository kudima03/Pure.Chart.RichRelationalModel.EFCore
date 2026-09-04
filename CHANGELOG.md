# Changelog

All notable changes to Pure.Chart.RichRelationalModel.EFCore are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [0.1.0-preview.5.1.1] — 2026-08-04

- Maintenance release: dependency and build updates.

## [0.1.0-preview.5.1.0] — 2026-06-25

- Maintenance release: dependency and build updates.

## [0.1.0-preview.5.0.0] — 2026-04-26

- Maintenance release: dependency and build updates.

## [0.1.0-preview.4.0.0] — 2026-04-20

### Changed

- **`ChartDbContext.Series`** now exposes `DbSet<ChartSeriesEFCoreModel>` instead of
  `DbSet<SeriesEFCoreModel>`, and its model configuration now applies
  `ChartSeriesConfiguration` instead of `SeriesConfiguration`. Consumers referencing
  `SeriesEFCoreModel` or `SeriesConfiguration` must switch to the renamed types.

## [0.1.0-preview.3.0.0] — 2026-02-27

- Maintenance release: dependency and build updates.

## [0.1.0-preview.2.0.0] — 2026-02-19

### Changed

- **`ChartDbContext.Diagrams`** renamed to **`ChartDbContext.Charts`**.

### Fixed

- **`ChartDbContext`** now applies `AxisConfiguration` during model creation. Previously
  `SeriesConfiguration` was applied twice and axis entity configuration was never
  registered, so `AxisEFCoreModel` was not correctly configured.

## [0.1.0-preview.1.0.0] — 2026-02-18

- Maintenance release: dependency and build updates.

## [0.1.0-preview.0.2.1] — 2026-02-18

- Maintenance release: dependency and build updates.

## [0.1.0-preview.0.2.0] — 2026-02-18

- Maintenance release: dependency and build updates.

## [0.1.0-preview.0.1.0] — 2026-02-17

### Added

- Initial release. **`ChartDbContext`**, an EF Core `DbContext` exposing:
  - `Diagrams` — `DbSet<ChartEFCoreModel>`
  - `Types` — `DbSet<ChartTypeEFCoreModel>`
  - `Axes` — `DbSet<AxisEFCoreModel>`
  - `Series` — `DbSet<SeriesEFCoreModel>`

  Model configuration is applied via `ChartConfiguration`, `ChartTypeConfiguration`, and
  `SeriesConfiguration` from `Pure.Chart.RichRelationalModel.EFCore.Models.Configurations`.
