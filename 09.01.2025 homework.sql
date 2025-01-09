create schema market;

create table market.products (
	product_id int primary key generated always as identity,
	product_name varchar(100) not null,
	price numeric not null
);

insert into market.products(product_name , price)
values ('apple' ,1.00) ,('banana' , 0.50) ,('cherry' , 2.50) ,('date', 3.00);

insert into market.products(product_name , price)
values ('apple',2.00) ,('watermelon' ,4.00) , ('cherry' , 2.75);

create table market.sales(
	sale_id int primary key generated always as identity,
	product_id int,
	foreign key (product_id) references market.products(product_id),
	quantity_sold int
);

insert into market.sales(product_id , quantity_sold)
values(1 , 50),(2 , 30),(3 , 70),(4 , 20);

create table market.categories(
	category_id int primary key generated always as identity,
	category_name varchar(100) not null
);

INSERT INTO market.categories (category_name)
VALUES ('Fruits'), ('Dry Fruits'), ('Berries');
--2

select pr.product_name , pr.price from market.products as pr where(
select AVG(price) from market.products) < pr.price;

--1

SELECT ProductName, Price
FROM Products
WHERE Price > (SELECT AVG(Price) FROM Products);
--3 

select p.product_name from market.products as p 
join (select product_id from market.sales
	  group by product_id 
	  having count(product_id) > 1	  
	  ) sold on p.product_id = sold.product_id;
	  
--4

select p.product_name, sum(p.price * s.quantity_sold) as TotalRevenue
from market.products p
join market.sales s on p.product_id = s.product_id
group by p.product_name
order by TotalRevenue desc
limit 3;






















