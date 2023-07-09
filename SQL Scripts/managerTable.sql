show databases;
create database restaurant;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

use restaurant;

create table managers
(
	username 	varchar(20) not null,
    logincounts	int unsigned not null,
    primary key	(username)
);

show tables;

describe admins;

select * from admins;

alter table admins
add column imagefile varchar(150) after lastname;

update admins set logincounts='0' where username='admintester';

insert into managers (username, logincounts) values
('adminroudgar', 0),
('admintester', 0);

update admins set email = "a_roudgar@comp.iust.ac.ir" where username = "admintester";

alter table admins
add column nationalid varchar(10) not null after lastname;

insert into managers (username, logincounts) values
('adminroudgar', 0);



