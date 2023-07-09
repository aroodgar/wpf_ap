use restaurant;

show tables;

create table orders
(
	id			varchar(50) not null,
    personid	varchar(10) not null,
    foodstring	varchar(100) not null,
    deliverdate varchar(10) not null,
    orderdate	varchar(10) not null,
    totalprice	float not null,
    primary key (id)
);

alter table orders 
add column ordertype varchar(1) not null after orderdate;

alter table orders
add column discount int not null after ordertype;

alter table orders
modify column signatureaddress varchar(200) after totalprice;

alter table orders
modify column orderdate varchar(30) not null;

describe orders;

select * from orders;

-- insert into orders (id, personid, foodstring, deliverdate, orderdate, ordertype, discount, totalprice) values
-- ('ABCD', '*******', 'A-3-50', '8/8/2020', '7/5/2020', 'B', 0, 50);

update orders set orderdate='7/5/2020 2:00:00 PM' , deliverdate='8/8/2020 9:00:00 AM' where id='ABCD';
