# D&DLiquid — Backend API

REST API для интернет-магазина **"D&DLiquid"**

## Стек

| Технология | Назначение |
|-----------|------------|
| **ASP.NET Core 10** Web API | Фреймворк |
| **C# / .NET 10** | Язык и платформа |
| **Entity Framework Core 10** | ORM |
| **PostgreSQL 16** | База данных |
| **Npgsql** | PostgreSQL драйвер |
| **JWT Bearer** | Аутентификация и авторизация |
| **BCrypt (BCrypt.Net)** | Хеширование паролей |
| **AutoMapper** | Маппинг Entity → DTO |
| **Swagger (Swashbuckle)** | OpenAPI-документация |
| **DotNetEnv** | Загрузка .env в локальной среде |

## Архитектура

Проект следует **Clean Architecture** — 4 слоя с разделёнными ответственностями:

```
DDLiquid.slnx
├── DDLiquid.API                     # ASP.NET контроллеры, middleware, DI
├── DDLiquid.BusinessLogic           # Сервисы, маппинг, хелперы
│   ├── Services/                    # Бизнес-логика
│   ├── Interfaces/                  # Контракты сервисов
│   ├── Mapping/                     # AutoMapper Profiles
│   └── Helpers/                     # PasswordHasher, JwtOptions
├── DDLiquid.DataAccess              # EF Core, миграции, репозитории
│   ├── DB/                          # DbContext'и, DataSeeder
│   ├── Reps/                        # Репозитории
│   ├── Interfaces/                  # IRepository, IUserRepository
│   └── Migrations/                  # Миграции БД
└── DDLiquid.Domain                  # Сущности, DTO, перечисления
    ├── Entities/                    # Entity-классы (Product, User, Order, Cart)
    ├── Enums/                       # OrderStatus, ProductCategory
    └── Models/                      # DTO (ProductDTO, OrderDTO, AdminStatsDTO)
```

## Модели данных

### Товары (Table-Per-Type inheritance)

- **ProductData** — базовая таблица (Name, Price, StockQuantity)
- **LiquidData → ProductData** — жидкости (Volume, Nicotine, IceLevel)
- **VapeData → ProductData** — вейпы (BatteryCapacity, MaxPower, Color)
- **ConsumableData → ProductData** — расходники

### Связи

- Product → Images (one-to-many)
- Product → Brands (many-to-one)
- Product → Categories (many-to-one)
- Product ↔ Tags (many-to-many)
- Liquid ↔ Flavors (many-to-many)
- User → Role (many-to-one)
- User → Cart (one-to-one)
- Order → OrderItems (one-to-many)

## API Endpoints

| Метод | Route | Доступ | Описание |
|-------|-------|--------|----------|
| `GET` | `/api/Product` | Public | Все товары |
| `GET` | `/api/Product/{id}` | Public | Товар по ID (с изображениями) |
| `GET` | `/api/Liquid` | Public | Все жидкости |
| `GET` | `/api/Vape` | Public | Все вейпы |
| `GET` | `/api/Consumable` | Public | Все расходники |
| `POST` | `/api/Auth/login` | Public | Вход |
| `POST` | `/api/Auth/register` | Public | Регистрация |
| `GET` | `/api/Order` | User | Заказы пользователя |
| `GET` | `/api/Admin/stats` | Admin | Статистика |
| `GET/POST/PUT/DELETE` | `/api/Product`, `/api/Image` | Admin | CRUD |

Полная документация доступна в Swagger UI: `http://localhost:5131/swagger`

## Запуск

### Локально

```bash
cd DotnetBackEnd/Control
dotnet run
```

API будет доступен на `http://localhost:5131`.

### Docker

```bash
docker compose up -d --build backend
```

### Сидер данных

При каждом запуске (локально или в Docker) `DataSeeder` автоматически заполняет БД тестовыми данными:

- 3 роли (Admin, User, Manager)
- 3 пользователя (admin, admin1, testuser)
- 10 жидкостей, 10 вейпов, 10 расходников (с изображениями)
- 5 стран, 5 брендов, 8 вкусов, 5 тегов
- 1 тестовый заказ

### Переменные окружения

| Переменная | Описание |
|-----------|----------|
| `JWT__Key` | Секретный ключ для JWT |
| `JWT__Issuer` | Издатель токена |
| `JWT__Audience` | Аудитория токена |
| `JWT__ExpireMinutes` | Время жизни токена |
| `CONNECTIONSTRINGS__DDLiquidDB` | Строка подключения к БД (только для Docker) |

Для локального запуска строка подключения читается из `appsettings.json` (Host=localhost).  
Для Docker — из `docker-compose.yml` (Host=db).
