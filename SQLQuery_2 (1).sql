CREATE DATABASE COFFEESHOP
GO
USE COFFEESHOP



CREATE TABLE EMPLOYEE (
    ID_EM INT PRIMARY KEY,
    NAME_EM NVARCHAR(4000),
    DAY_OF_BIRTH DATE,
    PHONE_NUM VARCHAR(15),
    ADDRESS_EM NVARCHAR(4000),
    SEX NVARCHAR(3) CHECK (SEX IN ('Nam', N'Nữ')),
	NAME_ROLE NVARCHAR(100),
	USERNAME VARCHAR(50) UNIQUE ,
    PASS VARCHAR(50)
);

CREATE TABLE MENU (
    ID INT PRIMARY KEY,
	TYPE NVARCHAR(100),
    NAME_FOOD NVARCHAR(200),
	DESCRIPTION NVARCHAR(500),
    PRICE DECIMAL(7)
);

CREATE TABLE CUSTOMER (
    ID_CUSTOMER INT PRIMARY KEY,
    NAME_CUSTOMER NVARCHAR(200)
);

CREATE TABLE BILL (
    ID_BILL INT PRIMARY KEY,
    ID_EM  INT,
    ID_CUSTOMER  INT,
    DAY_BILL DATE,
	PRICE DECIMAL(10),
    STATUS_BILL VARCHAR(20),
    FOREIGN KEY (ID_EM) REFERENCES EMPLOYEE(ID_EM),
    FOREIGN KEY (ID_CUSTOMER) REFERENCES CUSTOMER(ID_CUSTOMER)
);

CREATE TABLE BILLDETAIL (
    ID_BILL INT,
    ID INT,
    SOLUONG INT,
    PRIMARY KEY (ID_BILL, ID),
    FOREIGN KEY (ID_BILL) REFERENCES BILL(ID_BILL),
    FOREIGN KEY (ID) REFERENCES MENU(ID)
);

--TABLE CHUA HINH ANH
CREATE TABLE IMAGES (
    ID_IMAGE INT PRIMARY KEY,
    IMAGE_DATA IMAGE
);

INSERT INTO EMPLOYEE VALUES ('1', N'Đỗ Trần Tuấn Anh', '03/08/2004', '0784699510', N'41 Trần Văn Hoàng, Phường 9, Quận Tân Bình, TPHCM', 'Nam', 'Admin', 'Admin','Admin');
INSERT INTO EMPLOYEE VALUES ('2', N'Đỗ Trần Tuấn An', '03/08/2004', '0784699510', N'41 Trần Văn Hoàng, Phường 9, Quận Tân Bình, TPHCM', 'Nam', 'Staff', 'TuananhDo0308','Tuananh04');
INSERT INTO EMPLOYEE VALUES ('3', N'Lê Hồng Anh', '03/08/2004', '0784699510', N'41 Trần Văn Hoàng, Phường 9, Quận Tân Bình, TPHCM', 'Nam', 'Staff', 'Honganh','Honganh');

INSERT INTO MENU VALUES 
('1','Tea','Olong Tea','A Olong Tea', '20000'),
('5','Coffee','Coffee','A VietNamese Coffee','20000'),
('2','Coffee','Milk Coffee','A Coffee with some Milk','25000'),
('4','Tea','Milk Tea','A Tea with some Milk','20000'),
('6','Coffee, Tea','Coffee Tea','A Coffee with some Tea','25000'),
('3','Drink','Juice','A cup of Juice','18000'),
('7','Drink','Ice Blended','A cup of Coffee, Tea, Fruit or Milke with some ice','40000'),
('8','Fruit','Smoothies','A thick, cold drink made from Fruit and often Yogurt or ice cream, mixed together until smooth','35000'),
('9','Bread','Cakes','A type of Sweetened bread that is often rich or delicate made from Flour, Sugar, Eggs, Fat, and a leavening agent','55000');

INSERT INTO CUSTOMER VALUES
('1',N'Đỗ Trần Tuấn Anh'),
('2',N'Trần Quốc Ấn'),
('3',N'Lê Hồng Anh'),
('4',N'Trần Quốc Long');

INSERT INTO BILL VALUES
('1','1','2','03/08/2023','50000','Sold'),
('2','3','4','03/10/2023','20000','Waiting');

INSERT INTO BILLDETAIL VALUES
('1','2','1'),
('1','6','1'),
('2','4','1');

--CAU LENH CHEN HINH ANH *TRONG O DIA CO SAN' VAO BANG IMAGES
--TRUY VAN SELECT * FROM IMAGES (WHERE ID_IMAGE = ?)
--Sau khi thực hiện lệnh SELECT, bạn cần xử lý dữ liệu nhận được để hiển thị hình ảnh trong ứng dụng của mình
INSERT INTO IMAGES (ID_IMAGE, IMAGE_DATA)
VALUES (1,(SELECT * FROM OPENROWSET(BULK N'C:\Users\TPT\Desktop\Other\CNTT.B\Lập trình Windows\Picture2.jpg', SINGLE_BLOB) AS IMAGE_DATA));

INSERT INTO BILL VALUES
('3','3','4','10/08/2023','20000','Sold');

INSERT INTO BILLDETAIL VALUES
('1','1','1');

SELECT * FROM EMPLOYEE;