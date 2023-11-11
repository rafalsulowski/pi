Use TripPlanner;


insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('rmsulowski@gmail.com', 'Rafa� Sulowski', 'Willowa 34a, Lublin 20-819', 'string', 'Lublin', '2001-08-13T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('gut22@gmail.com', 'Maria Gut', 'Skowronkowa 108C, Lublin 72-819', 'string', 'Lublin', '2002-11-02T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('krisGut@gmail.com', 'Krysia Gut', 'Skowronkowa 108C, Lublin 72-819', 'string', 'Lublin', '2002-11-02T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('bubix@gmail.com', 'Zuzia Popio�ek', 'Fabryczna 76b, Lublin 20-119', 'string', 'Lublin', '2001-12-13T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('smolkam@gmail.com', 'Kamil Smo�ecki', 'Podg�rska 1b, Kra�nik 06-123', 'string', 'Kra�nik', '2000-04-13T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('mlodykuba@gmail.com', 'Jakub Szczygielski', '�uk�w 9b, �uk�w 01-549', 'string', '�uk�w', '2002-01-28T11:49:30.456Z');

insert into Users(Email, FullName, FullAddress, PasswordHash, City, DateOfBirth) Values 
('wixa@gmail.com', 'Wiktoria Kozdr�j', 'Garb�w 12a, Garb�w 23-219', 'string', 'Garb�w', '2001-05-23T11:49:30.456Z');



insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords)
Values ('S�owacja', 'Chopok', '2023-12-28T11:49:30.456Z', '2024-01-03T11:49:30.456Z', '2023-08-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi za granice', '', 'https://TripPlanner/join/asgaweADDas', 13, 'Wyjazd na narty 2024', '');

insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) 
Values ('2023-08-13T11:49:30.456Z', 1, 'Prezes', 1, 1);

insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords)
Values ('Chorwacja', 'Zadar', '2024-07-12T11:49:30.456Z', '2024-07-20T11:49:30.456Z', '2023-09-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi do Chorwacji', '', 'https://TripPlanner/join/arfw3wefcsd', 16, 'Chorwacja 2024', '');

insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) 
Values ('2023-09-13T11:49:30.456Z', 1, 'Prezes', 1, 1);

insert into Tours(TargetCountry, TargetRegion, StartDate, EndDate, CreateDate, Description, ImagePath, InviteLink, MaxParticipant, Title, WeatherCords)
Values ('Po�udniowy Tyrol', 'Tyrol SKI', '2025-02-14T11:49:30.456Z', '2025-02-21T11:49:30.456Z', '2023-10-13T11:49:30.456Z', 'Pierwszy wyjazd ze znajomymi w Alpy', '', 'https://TripPlanner/join/6k4jwnsdf3g', 12, 'Wyjazd na narty 2025', '');

insert into ParticipantTours(AccessionDate, IsOrganizer, Nickname, TourId, UserId) 
Values ('2023-10-13T11:49:30.456Z', 1, 'Prezes', 1, 1);






