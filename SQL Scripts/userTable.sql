use restaurant;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

show tables;

create table users
(
	firstname	varchar(20) not null,
    lastname	varchar(20) not null,
	address		varchar(100) not null,
    email		varchar(50) not null,
    phonenumber	varchar(20) not null,
    imagefile	varchar(150),
    nationalid  varchar(10) not null,
    passcode	varchar(16) not null,
    primary key (nationalid)
);

-- drop table users;

select * from customers;

describe customers;

delete from customers where nationalid='6599927531';

alter table users
rename to customers;

update customers set votestring='';

alter table customers
add column votestring varchar(100) not null after passcode;

update customers set votestring='' where nationalid='6599927531';

insert into users (firstname, lastname, address, email, phonenumber, nationalid, passcode) values
('Amirhossein', 'Roudgar', 'Tehran', '2000amir1379@gmail.com', '09199145913', '0023630000', '20amir79%');
