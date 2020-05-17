--task 1

CREATE TABLE PC (
	id_PC	INTEGER NOT NULL,
	cpu	INTEGER NOT NULL,
	memory	INTEGER NOT NULL,
	hdd	INTEGER NOT NULL,
	PRIMARY KEY(id_PC AUTOINCREMENT)
);

INSERT INTO PC (cpu, memory, hdd)
VALUES 
	(1600, 2000, 500),
	(2400, 3000, 800),
	(3200, 3000, 1200),
	(2400, 2000, 500);

--1.1 Тактовые частоты CPU тех компьютеров, у которых объем памяти 3000 Мб

SELECT PC.id_PC, PC.cpu, PC.memory FROM PC
WHERE PC.memory = '3000';

--1.2 Минимальный объём жесткого диска, установленного в компьютере на складе

SELECT MIN(PC.hdd) AS min_hdd FROM PC;

--1.3 Количество компьютеров с минимальным объемом жесткого диска, доступного на складе

SELECT COUNT(PC.id_PC) AS count, hdd FROM PC
WHERE PC.hdd IN (SELECT MIN(PC.hdd) FROM PC);

--task 2

CREATE TABLE track_downloads (
	download_id	INTEGER NOT NULL,
	track_id	INTEGER NOT NULL,
	user_id	INTEGER NOT NULL,
	download_time	TEXT NOT NULL DEFAULT 0,
	PRIMARY KEY( download_id AUTOINCREMENT)
);

INSERT INTO track_downloads (track_id, user_id, download_time)
VALUES 
	(1, 1, date('2010-10-19')),
	(2, 1, date('2010-10-19')),
	(3, 2, date('2010-01-01')),
	(4, 3, date('2010-10-19')),
	(5, 4, date('2010-10-19')),
	(6, 4, date('2010-10-19')),
	(7, 4, date('2010-03-03'));

/*
Напишите SQL-запрос, возвращающий все пары (download_count, user_count), удовлетворяющие следующему условию: 
user_count — общее ненулевое число пользователей, сделавших ровно download_count скачиваний 19 ноября 2010 года.
*/

SELECT COUNT(track_downloads.download_id) AS download_count, track_downloads.user_id FROM track_downloads
WHERE track_downloads.download_time = '2010-10-19'
GROUP BY track_downloads.user_id;

--task 3
/*
DATETIME xранит время в виде целого числа вида YYYYMMDDHHMMSS, используя для этого 8 байтов. Это время не зависит от временной зоны. 
Оно всегда отображается при выборке точно так же, как было сохранено, независимо от того какой часовой пояс.

TIMESTAMP xранит 4-байтное целое число, равное количеству секунд, прошедших с полуночи 1 января 1970 года 
по усреднённому времени Гринвича. При получении из базы отображается с учётом часового пояса.
*/
--task 4

CREATE TABLE student (
	id_student	INTEGER NOT NULL,
	name	TEXT NOT NULL,
	PRIMARY KEY(id_student AUTOINCREMENT)
)

CREATE TABLE course (
	id_course	INTEGER NOT NULL,
	name	TEXT NOT NULL,
	PRIMARY KEY(id_course AUTOINCREMENT)
)

CREATE TABLE student_on_course (
	id_student_on_course	INTEGER NOT NULL,
	id_student	INTEGER,
	id_course	INTEGER,
	FOREIGN KEY (id_student) REFERENCES student(id_student),
	FOREIGN KEY (id_course) REFERENCES course(id_course),
	PRIMARY KEY(id_student_on_course AUTOINCREMENT)	
)

INSERT INTO student (name)
VALUES
	('Богдан Смирнов'),
	('Мария Степанова'),
	('Виктория Яковлева'),
	('Иван Павлов'),
	('Артём Сорокин'),
	('Александр Котов'),
	('Татьяна Петрова'),
	('Кирилл Алексеев');

INSERT INTO course (name)
VALUES
	('mathematics'),
	('english_language '),
	('russian_language '),
	('physics'),
	('physical_сulture');

INSERT INTO student_on_course (id_student, id_course)
VALUES
	(1, 1),
	(1, 2),
	(1, 5),
	(2, 2),
	(2, 4),
	(3, 2),
	(4, 2),
	(4, 4),
	(4, 5),
	(5, 2),
	(7, 4),
	(8, 2);

--4.1 Количество курсов, на которые ходят более 5 студентов

SELECT COUNT(1) courses_count
FROM
(
	SELECT COUNT(DISTINCT course.id_course) as "count" FROM student_on_course
    JOIN student ON student.id_student = student_on_course.id_student
    JOIN course ON course.id_course = student_on_course.id_course
	GROUP BY course.id_course
	HAVING (COUNT(course.id_course) >= 5)
)
GROUP BY count

--4.2 Все курсы, на которые записан определенный студент

--Для студента с id = 1
SELECT student.id_student, student.name, course.id_course, course.name FROM student
JOIN student_on_course ON student_on_course.id_student = student.id_student
JOIN course ON course.id_course = student_on_course.id_course
WHERE student.id_student = 1

--task 5
/*
Может ли значение в столбце(ах), на который наложено ограничение foreign key, равняться null? 
Привидите пример. 

Может, если на столбец не наложено ограничение not null
Пример: пусть есть база данных, в которой хранятся предложения по продажам. 
Для каждого предложения назначено только одно торговое лицо и один клиент. 
Таким образом, таблица предложений будет иметь два внешних ключа, один с идентификатором 
клиента и один с идентификатором торгового представителя. Однако в момент создания записи 
торговый представитель не всегда назначается, поэтому идентификатор клиента заполняется, 
но идентификатор торгового представителя может быть нулевым. 
*/

--task 6
/*
Как удалить повторяющиеся строки с использованием ключевого слова Distinct?
Приведите пример таблиц с данными и запросы. 
*/

--Пример:
CREATE TABLE letter (
	id_letter	INTEGER NOT NULL,
	letter TEXT NOT NULL,
	PRIMARY KEY(id_letter AUTOINCREMENT)
)

INSERT INTO letter (letter)
VALUES 
	('a'),
	('b'),
	('a'),
	('c');
	
--Нужно использовать DISTINCT по столбцу с повторяющимися строками
SELECT DISTINCT letter FROM letter;

--task 7

CREATE TABLE users (
	users_id	INTEGER NOT NULL,
	name	TEXT NOT NULL,
	PRIMARY KEY(users_id AUTOINCREMENT)
)

CREATE TABLE orders (
	orders_id	INTEGER NOT NULL,
	users_id	INTEGER NOT NULL,
	status	INTEGER,
	FOREIGN KEY (users_id) REFERENCES users(users_id),
	PRIMARY KEY(orders_id AUTOINCREMENT)
)

INSERT INTO users (name)
VALUES 
	('Богдан Смирнов'),
	('Мария Степанова'),
	('Виктория Яковлева'),
	('Иван Павлов'),
	('Артём Сорокин');

INSERT INTO orders (users_id, status)
VALUES 
	(1, 0),
	(1, 0),
	(2, 0),
	(3, 0),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(3, 1),
	(4, 0),
	(5, 1);

--7.1 Выбрать всех пользователей из таблицы users, у которых ВСЕ записи в таблице orders имеют status = 0

SELECT DISTINCT users.users_id, users.name FROM users
JOIN orders ON orders.users_id = users.users_id
WHERE users.users_id NOT IN 
( 
	SELECT users_id FROM orders
	WHERE status != 0
);

--7.2 Выбрать всех пользователей из таблицы users, у которых больше 5 записей в таблице orders имеют status = 1

SELECT DISTINCT users.users_id, users.name, COUNT(orders.users_id) AS count, orders.status FROM users
JOIN orders ON orders.users_id = users.users_id
WHERE orders.status = 1
GROUP BY users.users_id, users.name, orders.users_id, orders.status
HAVING count > 5;

--task 8
--В чем различие между выражениями HAVING и WHERE?

/*
WHERE используется для проверки условия на момент выборки.
Нельзя использовать с GROUP BY.

HAVING предназначен для применения фильтра по результатам агрегатных функций.
Может использоваться только с GROUP BY.

Неэффективно использовать HAVING не по результатам агрегатных функций.
*/
