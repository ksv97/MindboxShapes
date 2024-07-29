/*
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, 
в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». 
Если у продукта нет категорий, то его имя все равно должно выводиться.
По возможности — положите ответ рядом с кодом из первого вопроса.

*/

-- Предполагаемая архитектура БД

/*

table Products(

Id: int (PK)
Name: varchar(150) 
CategoryId: int (FK) NULL
)

table Categories(

Id: int (PK)
Name: varchar(50)

)

Запрос:

SELECT p.Name AS "Имя продукта", 
     (CASE 
        WHEN p.CategoryId IS NULL 
            THEN "Без категории" 
        ELSE c.Name 
      END) AS "Имя категории"
FROM
Products p
LEFT JOIN
Categories c
ON p.CategoryId = c.Id

*/