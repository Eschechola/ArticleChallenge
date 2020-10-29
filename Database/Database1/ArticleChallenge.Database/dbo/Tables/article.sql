CREATE TABLE [dbo].[article] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [title]       NVARCHAR (100) NOT NULL,
    [text]        NVARCHAR (MAX) NOT NULL,
    [mount_likes] BIGINT         NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_article] PRIMARY KEY CLUSTERED ([Id] ASC)
);

