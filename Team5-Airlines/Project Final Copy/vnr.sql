drop database vnr

create database vnr

use vnr

--admin--
create table Admins
(
	admin_id int primary key identity,
	admin_username varchar(20),
	admin_password varchar(20)
)



--places--
create table Places 
(
	place_id int primary key,
	place_name varchar(20)
)

--Route master--
create table Routes_Master
(
	route_id int primary key,
	departure int constraint rm_dep_fk foreign key references Places(place_id),
	arrival int constraint rm_arr_fk foreign key references Places(place_id) on delete cascade,
	economy_cost money,
	business_cost money
)

--Flight details--
create table Flights_Master
(
	flight_id int primary key identity (501,1),
	flight_name varchar(10),
	business_capacity int default 50,
	economy_capacity int default 150,
	route_id int constraint fm_rid_fk foreign key references Routes_Master(route_id) on delete cascade,
	flight_status varchar(10)
)

--schedule table-
create table Flights_Schedule
(
	route_id int constraint route_idFk foreign key references Routes_Master(route_id),
	departure_time time,
	arrival_time time,
	duration time,
	flight_id int constraint f_idFk foreign key references Flights_Master(flight_id) on delete cascade,
	journey_date date,
	bc_availability int default 50,
	ec_availability int default 150,
	primary key(flight_id,journey_date)
)

--passenger reg--
create table Passenger_Reg
(
	passenger_id int primary key identity(1,1),
	title varchar(5),
	first_name varchar(30) not null,
	last_name varchar(30),
	email varchar(50) unique not null,
	pwd varchar(30) not null,
	confirm_pwd varchar(30) not null,
	dob date not null ,
	mobile varchar(10) not null
)

--passenger booking details--
create table Passenger_booking_details
(
	booking_id bigint primary key identity(1000001,1),
	no_of_seats int not null,
	class varchar(10),
	departure int constraint pass_deptFk foreign key references Places(place_id) ,
	arrival int constraint pass_arrFk foreign key references Places(place_id),
	flight_id int constraint fid_Fk foreign key references Flights_Master(flight_id) ,
	passenger_id int constraint pid_Fk foreign key references Passenger_Reg(passenger_id),
	booking_Date datetime default GETDATE(),
	journey_date date   
)

--passenger details--
create table Passengers_Details
(
	first_name varchar(30) not null,
	last_name varchar(30),
	age int not null,
	seat_no int not null,
	passenger_id int constraint passDet_pid_Fk foreign key references Passenger_Reg(passenger_id),
	booking_id bigint constraint pdet_bid_Fk foreign key references Passenger_booking_details(booking_id),
	perhead_cost money,
	status binary,
	primary key(seat_no)
)

--payment--
create table Payments
(
	payment_id int primary key,
	payment_status  varchar(6),
	booking_id bigint constraint payment_bid_Fk foreign key references Passenger_booking_details(booking_id),
	total_cost money
)

--feedback
create table feedback
(
	feedback_id int primary key,
	feedback varchar(1000),
	passenger_id int constraint fb_pid_Fk foreign key references Passenger_Reg(passenger_id),
)
drop table Payments

alter table Flights_master 
add constraint bc_def default 50 for  business_capacity

alter table Flights_master 
add constraint ec_def default 150 for  economy_capacity

--insert into admin
insert into Admins values('RashAirlines','rash')

--insert passenger_registration-
insert into Passenger_Reg values('mis','rashmi','rv','rash@gmail.com','12345','12345','02-22-1997','9568743210')
insert into Passenger_Reg values('mr','vasu','k','vas@gmail.com','12345','12345','02-22-1997','9568743210')
insert into Passenger_Reg values('ms','neha','rv','neha@gmail.com','12345','12345','02-22-1997','9568743210')
insert into Passenger_Reg values('mr','vineet','m','vin@gmail.com','12345','12345','02-22-1997','9568743210')
insert into Passenger_Reg values('miss','kratika','s','krat@gmail.com','12345','12345','05-26-1997','9568743210')


select * from Passenger_Reg


--insert into PLaces--
insert into Places values(560300,'bangalore')
insert into Places values(400099,'mumbai')
insert into Places values(600016,'chennai')
insert into Places values(110057,'delhi')
insert into Places values(700052,'kolkata')
insert into Places values(411032,'pune')


--insert into Routes--
insert into Routes_Master values(2001,	560300,	600016,	5000,	10000)
insert into Routes_Master values(2002	,560300	,700052	,5000	,10000)			
insert into Routes_Master values(2003,	700052,	400099,	5000,	10000)
insert into Routes_Master values(2004,	400099,	560300,	5000,	10000)
insert into Routes_Master values(2005,	110057,	700052,	5000,	10000)


-- insert into Flights Master--
insert into Flights_Master(flight_name,route_id,flight_status) values('RA501',2001,'VALID')
insert into Flights_Master(flight_name,route_id,flight_status) values('RA502',2002,'VALID')
insert into Flights_Master(flight_name,route_id,flight_status) values('RA503',2003,'VALID')
insert into Flights_Master(flight_name,route_id,flight_status) values('RA504',2004,'VALID')
insert into Flights_Master(flight_name,route_id,flight_status) values('RA505',2005,'VALID')
select * from Flights_Master
--insert into Flights_Schedule--
insert into Flights_Schedule(route_id,departure_time,arrival_time,duration,flight_id,journey_date) values(2001,'05:30:00','08:30:00','03:00:00',501,'02-12-2019')
insert into Flights_Schedule(route_id,departure_time,arrival_time,duration,flight_id,journey_date) values(2002,'06:30:00','09:30:00','03:00:00',502,'02-13-2019')
insert into Flights_Schedule(route_id,departure_time,arrival_time,duration,flight_id,journey_date) values(2003,'07:30:00','10:30:00','03:00:00',503,'02-14-2019')
insert into Flights_Schedule(route_id,departure_time,arrival_time,duration,flight_id,journey_date) values(2004,'08:30:00','11:30:00','03:00:00',504,'02-15-2019')


delete from Flights_Schedule where route_id= 2004

--insertion into Passenger Bookin Details
insert into Passenger_booking_details(no_of_seats,class,departure,arrival,flight_id,passenger_id,journey_date) values(1,'Business',	560300,	600016,501,1,'09-01-2019')
insert into Passenger_booking_details(no_of_seats,class,departure,arrival,flight_id,passenger_id,journey_date) values(2,'Economic',	560300,	600016,502,2,'9-2-2019')			
insert into Passenger_booking_details(no_of_seats,class,departure,arrival,flight_id,passenger_id,journey_date) values(3,'Economic',700052,400099,503,3,'9/3/2019')		
insert into Passenger_booking_details(no_of_seats,class,departure,arrival,flight_id,passenger_id,journey_date) values(3	,'Business',400099,560300,504,4,'9/4/2019')		
insert into Passenger_booking_details(no_of_seats,class,departure,arrival,flight_id,passenger_id,journey_date) values(1	,'Economic',110057,700052,505,1,'9/5/2019')		

select * from Flights_Master

create table Passengers_Details
(
	first_name varchar(30) not null,
	last_name varchar(30),
	age int not null,
	seat_no int not null,
	passenger_id int constraint passDet_pid_Fk foreign key references Passenger_Reg(passenger_id),
	booking_id bigint constraint pdet_bid_Fk foreign key references Passenger_booking_details(booking_id),
	perhead_cost money,
	status binary,
	primary key(seat_no)
)

--insertion into passenger details--
insert into Passengers_Details values('tirumala','kulkarni',22,1,1,1000001,2500,1)
insert into Passengers_Details values('vineet','mallya',22,2,1,1000001,5000,1)
insert into Passengers_Details values('rashmi','v',	22,23,2,1000006,5000,1)
insert into Passengers_Details values('ram','a',22,12,3,1000007,5000,1)
insert into Passengers_Details values('sham','c',22,13,4,1000008,5000,1)
insert into Passengers_Details values('bham','f',22,14,5,1000009,5000,1)
insert into Passengers_Details values('dhan','d',22,15,1,1000001,5000,1)
insert into Passengers_Details values('dana','d',22,16,2,1000006,5000,1)
insert into Passengers_Details values('dhan','d',22,17,3,1000007,5000,1)
insert into Passengers_Details values('vin','e',22,18,4,1000008,5000,1)
 
--for home page search--
alter proc search_flight(@dept int,@arr int,@journey_date date)
as 
begin
select flight_name,s.departure_time,arrival_time,p.place_name as Departure,p1.place_name as Arrival,s.journey_date
from Flights_Master f,Flights_Schedule s,Routes_Master r,places p,places p1
where  s.route_id= r.route_id  and r.route_id=f.route_id and r.departure=p.place_id and r.arrival=p1.place_id and  r.departure= @dept and r.arrival=@arr 
and s.journey_date=@journey_date
end

exec search_flight 560300,	600016, '02-12-2019'
insert into Flights_Schedule (route_id,departure_time,arrival_time,duration,flight_id,journey_date) values(2001,'11:30:00','14:30:00','03:00:00',505,'11-19-2019')

--Passenger Ticket Check
create proc Passenger_ticket_check(@passenger_id int)
as 
begin
select booking_id,no_of_seats,class,p1.place_name as Departure,p2.place_name as Arrival,f.journey_date
from Passenger_booking_details p,Flights_Schedule f,Routes_Master r,places p1,places p2
where p.departure = r.departure and r.route_id = f.route_id and r.departure=p1.place_id and r.arrival=p2.place_id and passenger_id=@passenger_id

end
exec Passenger_ticket_check 1

select * from Passenger_booking_details


alter proc display_ticket(@booking_id int)
as 
begin
select first_name,booking_date,fs.journey_date,pb.booking_id,seat_no,duration,class,p1.place_name as Departure,p2.place_name as Arrival
from Passenger_booking_details pb,Passengers_Details pd,Flights_Schedule fs,places p1,places p2,Routes_Master r
where pb.passenger_id = pd.passenger_id and pb.flight_id = fs.flight_id and r.departure=pb.departure 
and r.departure=p1.place_id and r.arrival=p2.place_id and  pb.booking_id=@booking_id
end
exec display_ticket 1000007

select * from flights_Master
alter table flights_Master
add  route_id int constraint fm_rid_fk foreign key references Routes_Master(route_id)

