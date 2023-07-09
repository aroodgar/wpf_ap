use restaurant;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

show tables;

create table carts
(
	personid varchar(10) not null,
    foodstring varchar(100) not null,
    primary key(personid)
);

describe carts;

select * from carts;

insert into carts (personid, foodstring, deliverdate, registerdate) values
	('*******', '', '', '');

alter table carts
add column deliverdate varchar(20) not null after foodstring;


alter table carts
add column registerdate varchar(20) not null after deliverdate;
