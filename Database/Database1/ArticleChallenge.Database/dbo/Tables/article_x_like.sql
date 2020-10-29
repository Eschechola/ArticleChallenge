CREATE TABLE [dbo].[article_x_like] (
    [Id]            BIGINT IDENTITY (1, 1) NOT NULL,
    [fk_article_id] BIGINT NOT NULL,
    [fk_user_id]    BIGINT NOT NULL,
    CONSTRAINT [PK_article_x_like] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_article_x_like_article_fk_article_id] FOREIGN KEY ([fk_article_id]) REFERENCES [dbo].[article] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_article_x_like_user_fk_user_id] FOREIGN KEY ([fk_user_id]) REFERENCES [dbo].[user] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_article_x_like_fk_article_id]
    ON [dbo].[article_x_like]([fk_article_id] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_article_x_like_fk_user_id]
    ON [dbo].[article_x_like]([fk_user_id] ASC);

