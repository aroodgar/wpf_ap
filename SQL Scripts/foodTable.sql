use restaurant;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

show tables;

-- drop table foods;

create table foods
(
	id			varchar(1) not null,
    foodname	varchar(30) not null,
    category	varchar(15) not null,
    price		int unsigned not null,
    imagefile	varchar(150),
    ingredients	varchar(50) not null,
    supplycount	int unsigned not null,
    score		float,
    primary key (id)
);

describe foods;

select * from foods;

alter table foods
modify price float not null;

update foods set imagefile='file:///F:/IUST/AP/AP_Final_Project/FoodOrderingSystem/bin/Debug/Images/yogurt.png' where id='Y';

update foods set category='Appetizer' where category='appetizer';

alter table foods
modify ingredients varchar(150) not null;

alter table foods
drop column supplycount;

alter table foods
modify column id varchar(3) not null;

insert into foods(id, foodname, category, price, ingredients, supplycount, vote)
values ('A', 'Pizza Margarita', 'Pizza', 40, 'Meat-Vegetable', 25, 0);