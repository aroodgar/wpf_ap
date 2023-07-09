use restaurant;

show tables;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

create table calendar
(
	dayname			varchar(10) not null,
    dayfoodstring	varchar(50) not null,
    primary key 	(dayname)
);

alter table calendar
modify dayfoodstring varchar(50) not null;

describe calendar;

alter table calendar
modify datestring varchar(30) not null;

insert into calendar (dayname, dayfoodstring) values
	('Saturday', ''),
    ('Sunday', ''),
    ('Monday', ''),
    ('Tuesday', ''),
    ('Wednesday', ''),
    ('Thursday', ''),
    ('Friday', '');
    
update calendar set dayfoodstring='A-75,' where datestring='7/1/2020';

delete from calendar;

alter table calendar
modify dayfoodstring varchar(100) not null;

select * from calendar;