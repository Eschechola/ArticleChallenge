CREATE TABLE [dbo].[user] (
    [Id]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [name]     VARCHAR (80)  NOT NULL,
    [email]    VARCHAR (180) NOT NULL,
    [password] VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([Id] ASC)
);

