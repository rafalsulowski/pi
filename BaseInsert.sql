Use TripPlanner;


insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('rmsulowski@gmail.com', 'Rafa³ Sulowski', 'Willowa 34a, Lublin 20-819', 'string', 'Lublin', '2001-08-13T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('gut22@gmail.com', 'Maria Gut', 'Skowronkowa 108C, Lublin 72-819', 'string', 'Lublin', '2002-11-02T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('krisGut@gmail.com', 'Krysia Gut', 'Skowronkowa 108C, Lublin 72-819', 'string', 'Lublin', '2002-11-02T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('bubix@gmail.com', 'Zuzia Popio³ek', 'Fabryczna 76b, Lublin 20-119', 'string', 'Lublin', '2001-12-13T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('smolkam@gmail.com', 'Kamil Smo³ecki', 'Podgórska 1b, Kraœnik 06-123', 'string', 'Kraœnik', '2000-04-13T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('mlodykuba@gmail.com', 'Jakub Szczygielski', '£uków 9b, £uków 01-549', 'string', '£uków', '2002-01-28T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('wixa@gmail.com', 'Wiktoria Kozdrój', 'Garbów 12a, Garbów 23-219', 'string', 'Garbów', '2001-05-23T11:49:30.456Z');



insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords)
Values ('S³owacja', 'Chopok', '2023-12-28T11:49:30.456Z', '2024-01-03T11:49:30.456Z', '2023-08-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi za granice', '', 'https://TripPlanner/join/asgaweADDas', 13, 'Wyjazd na narty 2024', '');

insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) 
Values ('2023-08-13T11:49:30.456Z', 1, 'Prezes', 1, 1);

insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords)
Values ('Chorwacja', 'Zadar', '2024-07-12T11:49:30.456Z', '2024-07-20T11:49:30.456Z', '2023-09-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi do Chorwacji', '', 'https://TripPlanner/join/arfw3wefcsd', 16, 'Chorwacja 2024', '');

insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) 
Values ('2023-09-13T11:49:30.456Z', 1, 'Prezes', 1, 1);

insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords)
Values ('Po³udniowy Tyrol', 'Tyrol SKI', '2025-02-14T11:49:30.456Z', '2025-02-21T11:49:30.456Z', '2023-10-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi w Alpy', '', 'https://TripPlanner/join/6k4jwnsdf3g', 12, 'Wyjazd na narty 2025', '');

insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) 
Values ('2023-10-13T11:49:30.456Z', 1, 'Prezes', 1, 1);






