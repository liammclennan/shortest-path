create table [Log] (Id INT IDENTITY NOT NULL, Type NVARCHAR(255) not null, Data NVARCHAR(MAX) not null, IP NVARCHAR(255) not null, Timestamp DATETIME not null, primary key (Id))
create table [RouteTime] (Id INT IDENTITY NOT NULL, Start NVARCHAR(255) not null, Finish NVARCHAR(255) not null, Seconds BIGINT not null, primary key (Id))
