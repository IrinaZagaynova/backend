--task 2
CREATE TABLE dvd (
	dvd_id	INTEGER NOT NULL,
	title	TEXT NOT NULL,
	production_year	INTEGER NOT NULL,
	PRIMARY KEY(dvd_id AUTOINCREMENT)
);

CREATE TABLE customer (
	customer_id	INTEGER NOT NULL,
	first_name	TEXT NOT NULL,
	last_name	TEXT NOT NULL,
	passport_code	INTEGER NOT NULL,
	registration_date	TEXT NOT NULL,
	PRIMARY KEY(customer_id AUTOINCREMENT)
);

CREATE TABLE offer (
	offer_id	INTEGER NOT NULL,
	dvd_id	INTEGER NOT NULL,
	customer_id	INTEGER NOT NULL,
	offer_date	TEXT NOT NULL,
	return_date	TEXT,
	PRIMARY KEY(offer_id AUTOINCREMENT)
);

--task 3
INSERT INTO dvd (title, production_year)
VALUES ('Аватар', 2009);
INSERT INTO dvd (title, production_year)
VALUES ('Интерстеллар', 2014);
INSERT INTO dvd (title, production_year)
VALUES ('Заклятие', 2013);
INSERT INTO dvd (title, production_year)
VALUES ('Титаник', 1097);
INSERT INTO dvd (title, production_year)
VALUES ('Начало', 2010);
INSERT INTO dvd (title, production_year)
VALUES ('Властелин колец: Возвращение короля', 2003);
INSERT INTO dvd (title, production_year)
VALUES ('Гарри Поттер и Дары Смерти', 2010);
INSERT INTO dvd (title, production_year)
VALUES ('Гарри Поттер и философский камень', 2001);
INSERT INTO dvd (title, production_year)
VALUES ('Аладдин', 2019);
INSERT INTO dvd (title, production_year)
VALUES ('Король Лев', 2019);

INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Богдан', 'Смирнов', 8719637853, date('2010-01-20'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Мария', 'Степанова', 7520657886, date('2012-12-05'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Виктория', 'Яковлева', 7011845878, date('2019-05-14'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Иван', 'Павлов', 7212523821, date('2014-08-17'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Артём', 'Сорокин', 8214533613, date('2009-09-02'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Александр', 'Котов', 6522467214, date('2016-04-10'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Татьяна', 'Петрова', 8035267181, date('2017-10-20'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Кирилл', 'Алексеев', 7525268234, date('2011-06-06'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Дарья', 'Григорьева', 8256258681, date('2018-07-07'));
INSERT INTO customer (first_name, last_name, passport_code, registration_date)
VALUES ('Алиса', 'Алексеева', 8817346431, date('2015-08-08'));

INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (1, 1, date('2018-07-07'), date('2018-07-11'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (2, 2, date('2020-04-20'), NULL);
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (3, 3, date('2019-12-12'), date('2019-12-22'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (4, 4, date('2020-04-10'), NULL);
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (5, 5, date('2020-01-01'), date('2020-01-20'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (6, 6, date('2019-11-07'), date('2019-11-10'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (7, 7, date('2017-10-20'), date('2017-10-24'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (8, 8, date('2019-05-07'), date('2019-05-15'));
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (9, 9, date('2020-03-20'), NULL);
INSERT INTO offer (dvd_id, customer_id, offer_date, return_date)
VALUES (10, 10, date('2019-01-12'), date('2019-01-16'));

--task 4
SELECT * FROM dvd
WHERE dvd.production_year = 2010
ORDER BY title;

--task 5
SELECT dvd.dvd_id, dvd.title FROM offer 
JOIN dvd ON offer.dvd_id = dvd.dvd_id
WHERE offer.return_date IS NULL;

--task 6
SELECT customer.customer_id, customer.first_name, customer.last_name, dvd.dvd_id, dvd.title FROM offer 
JOIN dvd ON offer.dvd_id = dvd.dvd_id 
JOIN customer ON offer.customer_id = customer.customer_id
WHERE strftime('%Y', offer.offer_date) = '2020';