# GoalZone - Premier League 2007/08 Web API & MVC UI

GoalZone, 2007/08 Premier League sezonu için geliştirilmiş ASP.NET Core tabanlı bir futbol veri yönetim ve canlı skor uygulamasıdır.

Proje; maçlar, takımlar, puan durumu, fikstür, maç detayları, canlı skorlar ve admin panel üzerinden veri yönetimi özelliklerini içerir.

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core 8 Web API
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- AutoMapper
- FluentValidation
- Repository Pattern
- Layered Architecture
- Bootstrap Icons
- Razor Views

## 🧱 Proje Mimarisi

Proje katmanlı mimari kullanılarak geliştirilmiştir.

```text
PremierLeague07API
├── EntityLayer
├── DataAccessLayer
├── BussinesLayer
├── DTOLayer
├── PremierLigApi
└── PremierLigUi