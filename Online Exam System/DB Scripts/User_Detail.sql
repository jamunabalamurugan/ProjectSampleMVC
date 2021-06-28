
CREATE TABLE USER_DETAIL
(
USERID INT PRIMARY KEY IDENTITY(1,1),
FULL_NAME VARCHAR(20),
EMAIL VARCHAR(30),
PASSWORD VARCHAR(20) NOT NULL,
MOBILE VARCHAR(15),
CITY VARCHAR(20),
DOB DATE,
STATE VARCHAR(15),
QUALIFICATION VARCHAR(10),
YEAR_OF_COMPLETION INT
)

DROP TABLE USER_DETAIL

SELECT * FROM USER_DETAIL

INSERT INTO USER_DETAIL VALUES
('Louretta Spandhana',
'louretta.spandhu@gmail.com',
'louretta',
9884884111,
'Chennai',
'1/3/1995',
'Tamilnadu',
'B.Tech',
2017)

INSERT INTO USER_DETAIL VALUES
('Sharukh Khan',
'sharuksharuk@gmail.com',
'sharukh',
9884884222,
'Mumbai',
'9/29/1997',
'Maharashtra',
'B.E',
2019)

INSERT INTO USER_DETAIL VALUES
('Shweta Sukul',
'shwethasukul@gmail.com',
'shweta',
9884884333,
'Bengaluru',
'10/26/1994',
'Karnataka',
'MCA',
2016)

INSERT INTO USER_DETAIL VALUES
('Arjun Reddy',
'reddyarjun@yahoo.com',
'arjun',
9884884444,
'Hyderabad',
'10/19/1997',
'Telangana',
'B.Tech',
2019)

INSERT INTO USER_DETAIL VALUES
('Nivin Pauly',
'nivin.pauly@gmail.com',
'nivin',
9884884555,
'Kochi',
'10/10/1996',
'Kerala',
'MCA',
2018)

INSERT INTO USER_DETAIL VALUES
('Sai Pallavi',
'pallavipallavi@gmail.com',
'saipallavi',
9884884666,
'Trivandrum',
'3/4/1995',
'Kerala',
'B.Tech',
2017)

INSERT INTO USER_DETAIL VALUES
('Preethi Veronica',
'preethi.vero@gmail.com',
'preethi',
9884884777,
'Noida',
'5/7/1996',
'Uttar Pradesh',
'MCA',
2018)

INSERT INTO USER_DETAIL VALUES
('Monisha Sampath',
'monisha29@gmail.com',
'monisha',
9884884888,
'Bellary',
'8/9/1996',
'Karnataka',
'B.E',
2018)

INSERT INTO USER_DETAIL VALUES
('Kumaran Sabapathy',
'kumaran98@gmail.com',
'kumaran',
9884884999,
'Madurai',
'12/12/1997',
'Tamilnadu',
'B.Tech',
2019)

INSERT INTO USER_DETAIL VALUES
('Harish Balasubranian',
'harishb@gmail.com',
'harish',
9884884000,
'Vishakapattinam',
'1/2/1995',
'Andhra Pradesh',
'B.E',
2017)