
select * from UserData 

IF EXISTS(SELECT * FROM[UserData] WHERE Email = 'adi@gmail.com')  DELETE FROM [UserData] WHERE Email='adi@gmail.com 'insert INTO[UserData] (Email,[National], Captain, League, Champions,[Cups], Position, Tofel, Sat, Gpa )Values('adi@gmail.com','1', '0', '0', '0', '0', '','0','0','0')