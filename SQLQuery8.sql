insert into MainInfo (Surname,Criminal.Name, Nickname, Criminal.Status, BirthdayDate, Criminal.DangerLevel, Address, DeathDate, Grouping.Name_Grouping, Type )
select Surname, Criminal.Name, Nickname, Criminal.Status, BirthdayDate, Criminal.DangerLevel, Address, DeathDate, Grouping.Name_Grouping, Type
from (Criminal inner join Belongs on Criminal.ID_Criminal = Belongs.ID_Criminal) inner join Grouping on Belongs.ID_Grouping = Grouping.ID_Grouping
where Name = 'Polnareff'
