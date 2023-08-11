
GO
--por 3 uno con el nombre de la porfe
INSERT INTO Usuarios (Email, Password) VALUES ('lilinana@gmail.com', '1234!!AAd');
INSERT INTO Usuarios (Email, Password) VALUES ('juanma@example.com', '1234!!AAd');
INSERT INTO Usuarios (Email, Password) VALUES ('bruno@example.com', '1234!!AAd');
GO
-- Insertar Tipos
INSERT INTO Tipos (Nombre, CostoPorHuesped, Descripcion)
VALUES ('VIP', 2500, 'Cabaña de lujo con jacuzzi y vista al lago'),
('Económico', 1000, 'Cabaña sencilla con vista al bosque'),
('Romántico', 1800, 'Cabaña para parejas con chimenea y vista al bosque'),
('Familiar', 1500, 'Cabaña amplia para familias con niños y mascotas'),
('Rústico', 1200, 'Cabaña estilo rústico con chimenea y vista al bosque');
GO
-- Insertar Cabañas
INSERT INTO Cabanias (TipoId, Nombre, Descripcion, PoseeJacuzzi, HabilitadoReservas, NumHabitacion, CapacidadMaximaPersonas)
VALUES (1, 'Cabaña VIP 1', 'Cabaña de lujo con vista al lago', 1, 1, 101, 2),
(2, 'Cabaña Económica 1', 'Cabaña sencilla con vista al bosque', 0, 0, 102, 4),
(3, 'Cabaña Romántica 1', 'Cabaña para parejas con chimenea y vista al bosque', 0, 1, 103, 2),
(4, 'Cabaña Familiar 1', 'Cabaña amplia para familias con niños y mascotas', 1, 1, 104, 6),
(5, 'Cabaña Rústica 1', 'Cabaña estilo rústico con chimenea y vista al bosque', 0, 0, 105, 4),
(1, 'Cabaña VIP 2', 'Cabaña de lujo con jacuzzi y vista al lago', 1, 1, 201, 2),
(2, 'Cabaña Económica 2', 'Cabaña sencilla con vista al bosque', 0, 1, 202, 4),
(3, 'Cabaña Romántica 2', 'Cabaña para parejas con chimenea y vista al bosque', 0, 0, 203, 2),
(4, 'Cabaña VIP 3', 'Cabaña de lujo con jacuzzi y vista al lago', 1, 1, 301, 2),
(5, 'Cabaña Rústica 2', 'Cabaña estilo rústico con chimenea y vista al bosque', 0, 1, 302, 4);
GO
--insert fotos
INSERT INTO Fotos (NombreFoto, CabaniaId)
VALUES ('Cabaña_VIP 1_001.jpg', 1),
('Cabaña_Económica 1_001.jpg', 2),
('Cabaña_Romántica 1_001.jpg', 3),
('Cabaña_Familiar 1_001.jpg', 4),
('Cabaña_Rústica 1_001.jpg', 5),
('Cabaña_VIP 2_001.jpg', 6),
('Cabaña_Económica 2_001.jpg', 7),
('Cabaña_Romántica 2_001.jpg', 8),
('Cabaña_VIP 3__001.jpg', 9),
('Cabaña_Rústica 2_001.jpg', 10)



