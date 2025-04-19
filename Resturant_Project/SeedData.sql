USE Resturant
-- Remove Any Old Data & Rest Identity
DELETE FROM Reviews;
DELETE FROM Payments;
DELETE FROM OrderDetails;
DELETE FROM Orders;
DELETE FROM Reservations;
DELETE FROM TimeSlots;
DELETE FROM Dishes;
DELETE FROM Categories;
DELETE FROM Users;

DBCC CHECKIDENT ('Reviews', RESEED, 0);
DBCC CHECKIDENT ('Payments', RESEED, 0);
DBCC CHECKIDENT ('OrderDetails', RESEED, 0);
DBCC CHECKIDENT ('Orders', RESEED, 0);
DBCC CHECKIDENT ('Reservations', RESEED, 0);
DBCC CHECKIDENT ('TimeSlots', RESEED, 0);
DBCC CHECKIDENT ('Dishes', RESEED, 0);
DBCC CHECKIDENT ('Categories', RESEED, 0);
DBCC CHECKIDENT ('Users', RESEED, 0);

-- Insert Data
INSERT INTO Categories (Name)
VALUES 
('Seafood Platters'),  
('Grilled Fish'),      
('Appetizers'),        
('Drinks & Desserts'); 

-- Insert Users
INSERT INTO Users (Name, Phone, Email, Password, Address, Role, Image)
VALUES 
('Ahmed Hassan', '0100000001', 'ahmed1@example.com', '123', 'Alexandria', 0, 'user1.jpg'),
('Sara Mostafa', '0100000002', 'sara@example.com', '123', 'Cairo', 0, 'user2.jpg'),
('Mohamed Ali', '0100000003', 'mohamed@example.com', '123', 'Giza', 0, 'user3.jpg'),
('Nada Elsharkawy', '0100000004', 'nada@example.com', '123', 'Mansoura', 0, 'user4.jpg'),
('Kareem Tarek', '0100000005', 'kareem@example.com', '123', 'Port Said', 1, 'admin1.jpg'),
('Fatma Adel', '0100000006', 'fatma@example.com', '123', 'Ismailia', 0, 'user5.jpg'),
('Youssef Gamal', '0100000007', 'youssef@example.com', '123', 'Alexandria', 0, 'user6.jpg'),
('Mona Fathy', '0100000008', 'mona@example.com', '123', 'Tanta', 0, 'user7.jpg'),
('Omar Sherif', '0100000009', 'omar@example.com', '123', 'Assiut', 0, 'user8.jpg'),
('Laila Saeed', '0100000010', 'laila@example.com', '123', 'Suez', 0, 'user9.jpg');

-- Insert TimeSlots
INSERT INTO TimeSlots (DateTime, Capacity, Available)
VALUES 
('2025-04-20 12:00', 20, 20),
('2025-04-20 14:00', 20, 20),
('2025-04-20 16:00', 20, 20),
('2025-04-20 18:00', 20, 20),
('2025-04-21 12:00', 20, 20),
('2025-04-21 14:00', 20, 20),
('2025-04-21 16:00', 20, 20),
('2025-04-21 18:00', 20, 20),
('2025-04-22 12:00', 20, 20),
('2025-04-22 14:00', 20, 20);

-- Insert Dishes
INSERT INTO Dishes (Name, Description, Image, AverageRate, Price, InStock, CategoryId)
VALUES
('Grilled Sea Bass', 'Deliciously seasoned and grilled', 'dish3.png', 4.5, 150, 1, 2),
('Fried Shrimp', 'Golden and crispy shrimp', 'dish5.png', 4.7, 120, 1, 3),
('Lobster Thermidor', 'Classic French lobster dish', 'dish6.png', 4.9, 300, 1, 1),
('Crab Curry', 'Spicy crab curry with rice', 'dish7.png', 4.2, 180, 1, 1),
('Seafood Soup', 'Mixed seafood in creamy soup', 'dish1.png', 4.6, 90, 1, 3),
('Calamari Rings', 'Fried calamari with dip', 'dish3.png', 4.1, 85, 1, 3),
('Seafood Pasta', 'Pasta with shrimp and mussels', 'dish1.png', 4.8, 160, 1, 1),
('Lemonade', 'Freshly squeezed lemon drink', 'dish5.png', 4.3, 25, 1, 4),
('Tiramisu', 'Italian layered dessert', 'dish7.png', 4.9, 70, 1, 4),
('Grilled Tilapia', 'Grilled fish with herbs', 'dish6.png', 4.4, 130, 1, 2);

-- Insert Reservations
INSERT INTO Reservations (Descreption, UserId, TimeSlotId, TableCount)
VALUES
('Dinner with family', 1, 1, 3),
('Birthday celebration', 2, 2, 2),
('Business lunch', 3, 3, 1),
('Friends gathering', 4, 4, 4),
('Anniversary dinner', 5, 5, 2),
('Quick lunch', 6, 6, 1),
('Casual dinner', 7, 7, 2),
('Romantic dinner', 8, 8, 1),
('Group outing', 9, 9, 3),
('Lunch break', 10, 10, 2);

-- Insert Orders
INSERT INTO Orders (Amount, Status, Date, UserId)
VALUES
(2, 1, GETDATE(), 1),
(1, 0, GETDATE(), 2),
(3, 1, GETDATE(), 3),
(2, 1, GETDATE(), 4),
(1, 0, GETDATE(), 5),
(4, 1, GETDATE(), 6),
(2, 1, GETDATE(), 7),
(1, 1, GETDATE(), 8),
(3, 1, GETDATE(), 9),
(2, 0, GETDATE(), 10);

-- Insert OrderDetails
INSERT INTO OrderDetails (Descreption, OrderId, DishId)
VALUES
('Grilled fish with salad', 1, 1),
('Fried shrimp with rice', 2, 2),
('Lobster with butter sauce', 3, 3),
('Crab curry extra spicy', 4, 4),
('Soup and pasta combo', 5, 5),
('Tilapia and fries', 6, 10),
('Shrimp pasta', 7, 7),
('Seafood platter', 8, 1),
('Lemonade and cake', 9, 8),
('Tiramisu only', 10, 9);

-- Insert Payments
INSERT INTO Payments (TotalPayment, PaymentMethod, Status, OrderId)
VALUES
(300, 1, 1, 1),
(120, 0, 0, 2),
(450, 1, 1, 3),
(360, 1, 1, 4),
(150, 0, 0, 5),
(500, 1, 1, 6),
(340, 1, 1, 7),
(220, 0, 1, 8),
(270, 1, 1, 9),
(130, 0, 0, 10);

-- Insert Reviews
INSERT INTO Reviews (Rate, DishId, UserId)
VALUES
(5, 1, 1),
(4, 2, 2),
(5, 3, 3),
(3, 4, 4),
(5, 5, 5),
(4, 6, 6),
(5, 7, 7),
(3, 8, 8),
(5, 9, 9),
(4, 10, 10);


