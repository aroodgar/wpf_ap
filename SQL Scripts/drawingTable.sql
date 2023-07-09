use restaurant;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

show tables;

create table drawing
(
	personid varchar(10) not null,
    primary key(personid)
);

describe drawing;

select * from drawing;

alter table drawing
add column registeredorderid varchar(50) not null after personid; 

alter table drawing
rename column registerdorderid to registerorderid;