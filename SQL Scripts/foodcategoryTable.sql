use restaurant;

show tables;

create table foodcategory
(
	category 	varchar(15) not null,
    primary key (category)
);

alter table foodCategory
add column defaultimage varchar(150) not null;

insert into foodcategory (category) values
	('pizza'),
    ('pasta'),
    ('sandwich'),
    ('salad'),
    ('beverage');
    
select * from foodcategory;
update foodcategory set category='Beverage' where category = 'beverage';

update foodcategory set defaultimage='file:///F:/IUST/AP/AP_Final_Project/FoodOrderingSystem/bin/Debug/Images/pasta.jfif' where category='Pasta';