select u.FirstName, u.LastName, uf.FileType, uf.FileName, uf.Score, uf.Remark from users u inner join UsersFile uf on u.email= uf.Email
