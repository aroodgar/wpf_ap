use restaurant;

SET SQL_SAFE_UPDATES = 0;
SET SQL_SAFE_UPDATES = 1;

show tables;

create table specialbonus
(
	personid varchar(10) not null,
    primary key(personid)
);

describe specialbonus;

select * from specialbonus;