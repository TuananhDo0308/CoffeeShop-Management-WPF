import pyodbc
import sqlite3
from PIL import Image
from io import BytesIO

'''
Hướng dẫn sử dụng Python chèn dữ liệu vào TABLE
- Nếu đã tạo TABLE từ trước chưa có dữ liệu (bắt buộc tạo trước) thì run bình thường
- Trong trường hợp có dữ liệu có sẵn bị trùng với dữ liệu cần insert --> bị báo lỗi
    --> Khắc phục: xóa hoặc chuyển thành comment

- Run file Python bị lỗi, kiểm tra lại xem một số dữ liệu insert đã có trong bảng
    TABLE đó chưa --> xóa dữ liệu insert bị trùng lặp trong file này

- Tùy laptop, tên kết nối CSDL sẽ khác nhau, hãy thay đổi tại SERVER = ''
    (sử dụng Windows Authentication để kết nối đến cơ sở dữ liệu)

- Chú *í*: Nên khởi tạo lại database trước khi sử dụng
'''

# Kết nối đến cơ sở dữ liệu
connection = pyodbc.connect('DRIVER={SQL Server};'
                            'SERVER=LENOVO_IDEAPAD_\SQLEXPRESS;'
                            'DATABASE=COFFEESHOP;'
                            'Trusted_Connection=yes;')

cursor = connection.cursor()

# Danh sách thông tin của nhân viên trong EMPLOYEE
employees_data = [
    (1, 'messi2.jpg', 'Nguyễn Văn Admin', '1990-01-01', '123456789', '123 Admin Street, Admin City', 'Nam', 'Admin', 'admin', 'admin@123'),
    (2, 'messi2.jpg', 'Trần Thị Staff', '1995-05-15', '987654321', '456 Staff Street, Staff City', 'Nữ', 'Staff', 'staff', 'staff@123'),
    (3, 'messi2.jpg', 'Lê Nam Cashier', '1988-08-20', '456123789', '789 Cashier Street, Cashier City', 'Nam', 'Cashier', 'cashier', 'cashier@123'),
    (4, 'messi2.jpg', 'Nguyễn Thị Staff', '1993-02-28', '555555555', '789 Staff Street, Staff City', 'Nữ', 'Staff', 'staff2', 'staff@456'),
    (5, 'messi2.jpg', 'Trần Nam Cashier', '1998-12-10', '333333333', '999 Cashier Street, Cashier City', 'Nam', 'Cashier', 'cashier2', 'cashier@456'),
]

# Chèn dữ liệu vào cơ sở dữ liệu
insert_query = '''
INSERT INTO EMPLOYEE (ID_EM, IMAGE_DATA, NAME_EM, DAY_OF_BIRTH, PHONE_NUM, ADDRESS_EM, SEX, NAME_ROLE, USERNAME, PASS)
VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
'''

for employee_data in employees_data:
    id_em, image_path, name_em, day_of_birth, phone_num, address_em, sex, name_role, username, password = employee_data

    # Đọc ảnh từ file
    image = Image.open(image_path)

    # Chuyển đổi ảnh thành dạng byte
    image_byte_array = BytesIO()
    image.save(image_byte_array, format=image.format)
    image_bytes = image_byte_array.getvalue()

    # Thực hiện chèn dữ liệu
    cursor.execute(insert_query, (id_em, pyodbc.Binary(image_bytes), name_em, day_of_birth, phone_num, address_em, sex, name_role, username, password))


# Chèn dữ liệu tương tự cho các món ăn trong MENU
menus_data = [
    (0, 'cafe den 2.png', 0, 'Black Coffee', 'A classic black coffee', 50000, 1),
    (1, 'latte coffee2.png', 0, 'Latte', 'Espresso with steamed milk', 60000, 1),
    (2, 'orange juice.png', 1, 'Orange Juice', 'Freshly squeezed orange juice', 45000, 1),
    (3, 'green tea.png', 2, 'Green Tea', 'Traditional green tea', 50000, 1),
    (4, 'mixed berry.jpg', 3, 'Mixed Berry Smoothie', 'Blended mixed berries with yogurt', 80000, 1),
    (5, 'mocha cf & chocolate.jpg', 4, 'Mocha Ice Blended', 'Chocolate and coffee blended with ice', 90000, 1),
    (6, 'cappucino coffee.png', 0, 'Cappuccino', 'Espresso with equal parts of steamed milk and milk foam', 55000, 1),
    (7, 'apple juice.jpg', 1, 'Apple Juice', 'Freshly squeezed apple juice', 48000, 1),
    (8, 'jasmine tea.png', 2, 'Jasmine Tea', 'Delicate and fragrant jasmine tea', 52000, 1),
    (9, 'banana berry.jpg', 3, 'Banana Berry Smoothie', 'Blended banana and mixed berries with yogurt', 85000, 1),
    (10,'Vanilla ice blen coffee.jpg' , 4, 'Vanilla Ice Blended', 'Vanilla-flavored blended ice coffee', 95000, 1),
    (11,'espresso coffee.png' , 0, 'Espresso', 'Strong black coffee', 45000, 1),
    (12,'Americano coffee.png' , 0, 'Americano', 'Diluted black coffee', 48000, 1),
    (13,'Grape juice.jpg' , 1, 'Grape Juice', 'Freshly squeezed grape juice', 52000, 1),
    (14,'Pineapple juice.jpg' , 1, 'Pineapple Juice', 'Freshly squeezed pineapple juice', 55000, 1),
    (15,'chai tea.jpg' , 2, 'Chai Tea', 'Spiced black tea with milk', 58000, 1),
    (16,'oolong tea.png' , 2, 'Oolong Tea', 'Traditional Chinese oolong tea', 60000, 1),
    (17,'Mango Banana Smoothie.png' , 3, 'Mango Banana Smoothie', 'Blended mango and banana with yogurt', 88000, 1),
    (18,'Strawberry Kiwi Smoothie.png' , 3, 'Strawberry Kiwi Smoothie', 'Blended strawberry and kiwi with yogurt', 92000, 1),
    (19,'Chocolate Chip Ice Blended.png' , 4, 'Chocolate Chip Ice Blended', 'Chocolate chip-flavored blended ice coffee', 98000, 1),
    (20,'Hazelnut Ice Blended.png' , 4, 'Hazelnut Ice Blended', 'Hazelnut-flavored blended ice coffee', 105000, 1),
    (21,'pg-affogato-coffee-with-vanilla-ice-cream-1629378614.jpg' , 0, 'Affogato', 'Espresso poured over vanilla ice cream', 75000, 1),
    (22,'Watermelon Juice.png' , 1, 'Watermelon Juice', 'Freshly squeezed watermelon juice', 59000, 1),
    (23,'Lemon Tea.png' , 2, 'Lemon Tea', 'Refreshing lemon-flavored tea', 53000, 1),
    (24,'Peach Mango Smoothie.png' , 3, 'Peach Mango Smoothie', 'Blended peach and mango with yogurt', 94000, 1),
    (25,'Caramel Ice Blended.png' , 4, 'Caramel Ice Blended', 'Caramel-flavored blended ice coffee', 102000, 1),
    (26,'macchiato.png' , 0, 'Macchiato', 'Espresso with a small amount of milk foam', 58000, 1),
    (27,'Carrot Juice.png' , 1, 'Carrot Juice', 'Freshly squeezed carrot juice', 56000, 1),
    (28,'Earl Grey Tea.png' , 2, 'Earl Grey Tea', 'Classic black tea with bergamot flavor', 62000, 1),
    (29,'Blueberry Banana Smoothie.png' , 3, 'Blueberry Banana Smoothie', 'Blended blueberry and banana with yogurt', 91000, 1),
    (31,'Peanut Butter Ice Blended.png' , 4, 'Peanut Butter Ice Blended', 'Peanut butter-flavored blended ice coffee', 108000, 1),
]

# Chèn dữ liệu vào cơ sở dữ liệu
insert_query = '''
INSERT INTO MENU
VALUES (?, ?, ?, ?, ?, ?, ?)
'''

for menu_data in menus_data:
    id, image_data, id_type, name_food, description, price, available = menu_data

    # Đọc ảnh từ file
    image = Image.open(image_data)

    # Chuyển đổi ảnh thành dạng byte
    image_byte_array = BytesIO()
    image.save(image_byte_array, format=image.format)
    image_bytes = image_byte_array.getvalue()

    # Thực hiện chèn dữ liệu
    cursor.execute(insert_query, (id, pyodbc.Binary(image_bytes), id_type, name_food, description, price, available))


# Lưu thay đổi và đóng kết nối
connection.commit()
connection.close()