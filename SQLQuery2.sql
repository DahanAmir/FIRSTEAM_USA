select * from UsersToDoList
DROP table [UsersToDoList]
CREATE TABLE [dbo].[UsersToDoList] (
    [Email]   VARCHAR (100) NOT NULL,
    [Task]    VARCHAR (500) NOT NULL,
    [DueDate] DATE          NOT NULL,
    [status] VARCHAR (100)  NOT NULL,
	[taskid] int IDENTITY(1,1) PRIMARY KEY ,
    FOREIGN KEY ([Email]) REFERENCES [dbo].[Users] ([Email])
);

CREATE TABLE [dbo].[UsersToDoList] (
    [Email]   VARCHAR (100) NOT NULL,
    [Task]    VARCHAR (500) NOT NULL,
    [DueDate] DATE          NOT NULL,
	[status] VARCHAR (100) ,
	[taskid] int IDENTITY(1,1) PRIMARY KEY ,
    PRIMARY KEY CLUSTERED ([Email] ASC),
    FOREIGN KEY ([Email]) REFERENCES [dbo].[Users] ([Email])
);
