CREATE DATABASE COFFEESHOP
GO
USE COFFEESHOP



CREATE TABLE EMPLOYEE (
    ID_EM INT PRIMARY KEY,
	IMAGE_DATA IMAGE,
    NAME_EM NVARCHAR(4000),
    DAY_OF_BIRTH DATE,
    PHONE_NUM VARCHAR(15),
    ADDRESS_EM NVARCHAR(4000),
    SEX NVARCHAR(3) CHECK (SEX IN ('Nam', N'Nữ')),
	NAME_ROLE NVARCHAR(100),
	USERNAME VARCHAR(50) UNIQUE ,
    PASS VARCHAR(50)
);
CREATE TABLE TYPE (
    ID INT PRIMARY KEY,
	TYPE NVARCHAR(100),
	AVAILABLE BIT
);
CREATE TABLE MENU (
    ID INT PRIMARY KEY,
	IMAGE_DATA IMAGE,
	ID_TYPE INT,
    NAME_FOOD NVARCHAR(200),
	DESCRIPTION NVARCHAR(500),
    PRICE DECIMAL(7),
	AVAILABLE BIT,
    FOREIGN KEY (ID_TYPE) REFERENCES TYPE(ID)
);

CREATE TABLE BILL (
    ID_BILL INT PRIMARY KEY,
    ID_EM  INT,
	NAME_CUSTOMER NVARCHAR(200),
    DAY_BILL DATE,
	PRICE DECIMAL(10),
    STATUS_BILL VARCHAR(20),
    FOREIGN KEY (ID_EM) REFERENCES EMPLOYEE(ID_EM)
);
CREATE TABLE BILLDETAIL (
    ID_BILL INT,
    ID INT,
    SOLUONG INT,
    PRIMARY KEY (ID_BILL, ID),
    FOREIGN KEY (ID_BILL) REFERENCES BILL(ID_BILL),
    FOREIGN KEY (ID) REFERENCES MENU(ID)
);

INSERT INTO EMPLOYEE (ID_EM, IMAGE_DATA, NAME_EM, DAY_OF_BIRTH, PHONE_NUM, ADDRESS_EM, SEX, NAME_ROLE, USERNAME, PASS)
VALUES
(1, NULL, N'Nguyễn Văn Admin', '1990-01-01', '123456789', N'123 Admin Street, Admin City', N'Nam', 'Admin', 'admin', 'admin@123'),
(2, NULL, N'Trần Thị Staff', '1995-05-15', '987654321', N'456 Staff Street, Staff City', N'Nữ', 'Staff', 'staff', 'staff@123'),
(3, NULL, N'Lê Nam Cashier', '1988-08-20', '456123789', N'789 Cashier Street, Cashier City', N'Nam', 'Cashier', 'cashier', 'cashier@123'),
(4, NULL, N'Nguyễn Thị Staff', '1993-02-28', '555555555', N'789 Staff Street, Staff City', N'Nữ', 'Staff', 'staff2', 'staff@456'),
(5, NULL, N'Trần Nam Cashier', '1998-12-10', '333333333', N'999 Cashier Street, Cashier City', N'Nam', 'Cashier', 'cashier2', 'cashier@456');


INSERT INTO TYPE VALUES 
('0','COFFEE','1'),
('1','JUICES','1'),
('2','TEA','1'),
('3','SMOOTHIES','1'),
('4','ICE BLENDED','1')

INSERT INTO MENU VALUES 
(0, NULL, 0, 'Black Coffee', 'A classic black coffee', 50000, 1),
(1, NULL, 0, 'Latte', 'Espresso with steamed milk', 60000, 1),
(2, NULL, 1, 'Orange Juice', 'Freshly squeezed orange juice', 45000, 1),
(3, NULL, 2, 'Green Tea', 'Traditional green tea', 50000, 1),
(4, NULL, 3, 'Mixed Berry Smoothie', 'Blended mixed berries with yogurt', 80000, 1),
(5, NULL, 4, 'Mocha Ice Blended', 'Chocolate and coffee blended with ice', 90000, 1),
(6, NULL, 0, 'Cappuccino', 'Espresso with equal parts of steamed milk and milk foam', 55000, 1),
(7, NULL, 1, 'Apple Juice', 'Freshly squeezed apple juice', 48000, 1),
(8, NULL, 2, 'Jasmine Tea', 'Delicate and fragrant jasmine tea', 52000, 1),
(9, NULL, 3, 'Banana Berry Smoothie', 'Blended banana and mixed berries with yogurt', 85000, 1),
(10, NULL, 4, 'Vanilla Ice Blended', 'Vanilla-flavored blended ice coffee', 95000, 1),
(11, NULL, 0, 'Espresso', 'Strong black coffee', 45000, 1),
(12, NULL, 0, 'Americano', 'Diluted black coffee', 48000, 1),
(13, NULL, 1, 'Grape Juice', 'Freshly squeezed grape juice', 52000, 1),
(14, NULL, 1, 'Pineapple Juice', 'Freshly squeezed pineapple juice', 55000, 1),
(15, NULL, 2, 'Chai Tea', 'Spiced black tea with milk', 58000, 1),
(16, NULL, 2, 'Oolong Tea', 'Traditional Chinese oolong tea', 60000, 1),
(17, NULL, 3, 'Mango Banana Smoothie', 'Blended mango and banana with yogurt', 88000, 1),
(18, NULL, 3, 'Strawberry Kiwi Smoothie', 'Blended strawberry and kiwi with yogurt', 92000, 1),
(19, NULL, 4, 'Chocolate Chip Ice Blended', 'Chocolate chip-flavored blended ice coffee', 98000, 1),
(20, NULL, 4, 'Hazelnut Ice Blended', 'Hazelnut-flavored blended ice coffee', 105000, 1),
(21, NULL, 0, 'Affogato', 'Espresso poured over vanilla ice cream', 75000, 1),
(22, NULL, 1, 'Watermelon Juice', 'Freshly squeezed watermelon juice', 59000, 1),
(23, NULL, 2, 'Lemon Tea', 'Refreshing lemon-flavored tea', 53000, 1),
(24, NULL, 3, 'Peach Mango Smoothie', 'Blended peach and mango with yogurt', 94000, 1),
(25, NULL, 4, 'Caramel Ice Blended', 'Caramel-flavored blended ice coffee', 102000, 1),
(26, NULL, 0, 'Macchiato', 'Espresso with a small amount of milk foam', 58000, 1),
(27, NULL, 1, 'Carrot Juice', 'Freshly squeezed carrot juice', 56000, 1),
(28, NULL, 2, 'Earl Grey Tea', 'Classic black tea with bergamot flavor', 62000, 1),
(29, NULL, 3, 'Blueberry Banana Smoothie', 'Blended blueberry and banana with yogurt', 91000, 1),
(30, NULL, 4, 'Peanut Butter Ice Blended', 'Peanut butter-flavored blended ice coffee', 108000, 1);


INSERT INTO BILL VALUES
(0, 1, N'Customer A', '2023-01-05', 150000, 'Paid'),
(1, 1, N'Customer B', '2023-02-10', 120000, 'Pending');

INSERT INTO BILLDETAIL VALUES
(0, 0, 2),
(0, 1, 1),
(1, 2, 3),
(1, 4, 1),
(1, 5, 2);