# TestApplication - Каталог товаров

  

## Описание

TestApplication - это веб-приложение для управления каталогом товаров, построенное с использованием .NET 8. Приложение позволяет создавать, редактировать, удалять и просматривать товары, а также экспортировать их список в Excel.

  

## Технологии

* .NET 8

* PostgreSQL

* Entity Framework Core

* FluentValidation

* EPPlus (для работы с Excel)

* Serilog

* Swagger

  

## Архитектура

Проект построен с использованием чистой архитектуры и разделен на следующие слои:

* **TestApplication.API** - слой представления, содержащий контроллеры и конфигурацию API

* **TestApplication.Application** - слой бизнес-логики

* **TestApplication.Domain** - слой доменной модели

* **TestApplication.Infrastructure** - слой инфраструктуры и доступа к данным

  

## Основные функции

1. CRUD операции с товарами:

* Создание товара

* Получение списка товаров

* Обновление информации о товаре

* Удаление товара

2. Экспорт списка товаров в Excel

3. Валидация данных с использованием FluentValidation

4. Логирование с использованием Serilog

  

## Модели данных

### Товар (Item)

* Id (Guid)

* Name (string)

* Description (string)

* Price (decimal)

* Count (int)

* CategoryId (Guid)

* CreatedTime (DateTime)

* UpdatedTime (DateTime?)

  

### Категория (Category)

* Id (Guid)

* Name (string)

* Description (string)
