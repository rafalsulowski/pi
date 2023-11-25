Use TripPlanner;

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('rmsulowski@gmail.com', 'Rafa³ Sulowski', 'Willowa 34a, Lublin 20-819', 'string', 'Lublin', '2001-08-13T11:49:30.456Z'),
('gut22@gmail.com', 'Maria Gut', 'Skowronkowa 108C, Lublin 72-819', 'string', 'Lublin', '2002-11-02T11:49:30.456Z'),
('krisGut@gmail.com', 'Krysia Gut', 'Skowronkowa 108C, Lublin 72-819', 'string', 'Lublin', '2002-11-02T11:49:30.456Z'),
('bubix@gmail.com', 'Zuzia Popio³ek', 'Fabryczna 76b, Lublin 20-119', 'string', 'Lublin', '2001-12-13T11:49:30.456Z'),
('smolkam@gmail.com', 'Kamil Smo³ecki', 'Podgórska 1b, Kraœnik 06-123', 'string', 'Kraœnik', '2000-04-13T11:49:30.456Z'),
('mlodykuba@gmail.com', 'Jakub Szczygielski', '£uków 9b, £uków 01-549', 'string', '£uków', '2002-01-28T11:49:30.456Z'),
('wixa@gmail.com', 'Wiktoria Kozdrój', 'Garbów 12a, Garbów 23-219', 'string', 'Garbów', '2001-05-23T11:49:30.456Z'),
('wixa@gmail.com', 'Krzysztof W³osek', 'Lublin Mêczenników Majdanka 23/75, Lublin 22-219', 'string', 'Lublin', '2001-05-23T11:49:30.456Z'),
('Anna1nowak@gmail.com', 'Anna Nowak', 'ul. S³oneczna 1, Warszawa 00-001', 'string', 'Warszawa', '1995-03-15T11:49:30.456Z'),
('piotrgg@gmail.com', 'Piotr Kowalski', 'ul. Kwiatowa 12, Kraków 30-002', 'string', 'Kraków', '1988-08-22T11:49:30.456Z'),
('agaawis@gmail.com', 'Agnieszka Wiœniewska', 'ul. Leœna 5, Gdañsk 80-003', 'string', 'Gdañsk', '1990-11-10T11:49:30.456Z'),
('macin@gmail.com', 'Marcin D¹browski', 'ul. Ogrodowa 8, Wroc³aw 50-004', 'string', 'Wroc³aw', '1982-05-08T11:49:30.456Z'),
('karo@gmail.com', 'Karolina Jankowska', 'ul. Polna 21, £ódŸ 90-005', 'string', '£ódŸ', '1993-09-27T11:49:30.456Z'),
('adamczak@gmail.com', 'Micha³ Adamczyk', 'ul. Miodowa 3, Poznañ 60-006', 'string', 'Poznañ', '1987-04-18T11:49:30.456Z');


insert into Friends(Friend1Id, Friend2Id) Values
(1,2),
(1,3),
(1,4),
(1,5),
(1,6),
(1,7),
(1,8),
(1,9),
(1,10),
(1,11),
(1,12),
(1,13),
(1,14),
(2,1),
(2,3),
(2,4),
(2,5),
(2,6),
(2,7),
(2,8);


insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords) Values 
('S³owacja', 'Chopok', '2023-12-28T11:49:30.456Z', '2024-01-03T11:49:30.456Z', '2023-08-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi za granice', '', 'https://TripPlanner/join/asgaweADDas', 13, 'Wyjazd na narty 2024', 'Kosowo'),
('Po³udniowy Tyrol', 'Tyrol SKI', '2025-02-14T11:49:30.456Z', '2025-02-21T11:49:30.456Z', '2023-10-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi w Alpy', '', 'https://TripPlanner/join/6k4jwnsdf3g', 12, 'Wyjazd na narty 2025', 'Rzym'),
('Chorwacja', 'Zadar', '2024-07-12T11:49:30.456Z', '2024-07-20T11:49:30.456Z', '2023-09-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi do Chorwacji', '', 'https://TripPlanner/join/arfw3wefcsd', 16, 'Chorwacja 2024', 'Split');


insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) Values 
('2023-08-13T11:49:30.456Z', 1, 'Prezes', 1, 1),
('2023-08-13T11:49:30.456Z', 0, '', 1, 2),
('2023-08-13T11:49:30.456Z', 0, '', 1, 3),
('2023-08-13T11:49:30.456Z', 0, '', 1, 4),
('2023-08-13T11:49:30.456Z', 0, '', 1, 5),
('2023-08-13T11:49:30.456Z', 0, '', 1, 6),
('2023-08-13T11:49:30.456Z', 0, '', 1, 7),
('2023-08-13T11:49:30.456Z', 0, '', 1, 8),
('2023-08-13T11:49:30.456Z', 0, '', 1, 9),
('2023-08-13T11:49:30.456Z', 0, '', 1, 10),
('2023-08-13T11:49:30.456Z', 0, '', 1, 11),
('2023-08-13T11:49:30.456Z', 0, '', 1, 12),
('2023-08-13T11:49:30.456Z', 0, '', 1, 13),
('2023-08-13T11:49:30.456Z', 0, '', 1, 14),

('2023-08-13T11:49:30.456Z', 1, 'Prezes', 2, 1),
('2023-08-13T11:49:30.456Z', 0, '', 2, 2),
('2023-08-13T11:49:30.456Z', 0, '', 2, 3),
('2023-08-13T11:49:30.456Z', 0, '', 2, 4),
('2023-08-13T11:49:30.456Z', 0, '', 2, 5),
('2023-08-13T11:49:30.456Z', 0, '', 2, 6),
('2023-08-13T11:49:30.456Z', 0, '', 2, 7),
('2023-08-13T11:49:30.456Z', 0, '', 2, 8),
('2023-08-13T11:49:30.456Z', 0, '', 2, 9),
('2023-08-13T11:49:30.456Z', 0, '', 2, 10),
('2023-08-13T11:49:30.456Z', 0, '', 2, 11),
('2023-08-13T11:49:30.456Z', 0, '', 2, 12),
('2023-08-13T11:49:30.456Z', 0, '', 2, 13),
('2023-08-13T11:49:30.456Z', 0, '', 2, 14),

('2023-08-13T11:49:30.456Z', 1, 'Prezes', 3, 1),
('2023-08-13T11:49:30.456Z', 0, '', 3, 2),
('2023-08-13T11:49:30.456Z', 0, '', 3, 3),
('2023-08-13T11:49:30.456Z', 0, '', 3, 4),
('2023-08-13T11:49:30.456Z', 0, '', 3, 5),
('2023-08-13T11:49:30.456Z', 0, '', 3, 6),
('2023-08-13T11:49:30.456Z', 1, '', 3, 7),
('2023-08-13T11:49:30.456Z', 0, '', 3, 8),
('2023-08-13T11:49:30.456Z', 0, '', 3, 9);


insert into ScheduleDays(TourId, Date, Description) Values
(1, '2023-12-28T12:00:00.456Z', ''),
(1, '2023-12-29T12:00:00.456Z', ''),
(1, '2023-12-30T12:00:00.456Z', ''),
(1, '2023-12-31T12:00:00.456Z', ''),
(1, '2024-01-01T12:00:00.456Z', ''),
(1, '2024-01-02T12:00:00.456Z', ''),
(1, '2024-01-03T12:00:00.456Z', ''),

(2, '2025-02-14T12:00:00.456Z', ''),
(2, '2025-02-15T12:00:00.456Z', ''),
(2, '2025-02-16T12:00:00.456Z', ''),
(2, '2025-02-17T12:00:00.456Z', ''),
(2, '2025-02-18T12:00:00.456Z', ''),
(2, '2025-02-19T12:00:00.456Z', ''),
(2, '2025-02-20T12:00:00.456Z', ''),
(2, '2025-02-21T12:00:00.456Z', ''),

(3, '2024-07-12T12:00:00.456Z', ''),
(3, '2024-07-13T12:00:00.456Z', ''),
(3, '2024-07-14T12:00:00.456Z', ''),
(3, '2024-07-15T12:00:00.456Z', ''),
(3, '2024-07-16T12:00:00.456Z', ''),
(3, '2024-07-17T12:00:00.456Z', ''),
(3, '2024-07-18T12:00:00.456Z', ''),
(3, '2024-07-19T12:00:00.456Z', ''),
(3, '2024-07-20T12:00:00.456Z', '');