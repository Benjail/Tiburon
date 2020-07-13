IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Interviews] (
    [Id] uniqueidentifier NOT NULL,
    [SurveyId] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Interviews] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Surveys] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Surveys] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Results] (
    [Id] uniqueidentifier NOT NULL,
    [QuestionName] nvarchar(max) NULL,
    [AnswerName] nvarchar(max) NULL,
    [InterviewId] uniqueidentifier NULL,
    [InerviewId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Results] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Results_Interviews_InterviewId] FOREIGN KEY ([InterviewId]) REFERENCES [Interviews] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Qestions] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [SurveyId] uniqueidentifier NULL,
    CONSTRAINT [PK_Qestions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Qestions_Surveys_SurveyId] FOREIGN KEY ([SurveyId]) REFERENCES [Surveys] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Answers] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [QuestionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Answers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Answers_Qestions_QuestionId] FOREIGN KEY ([QuestionId]) REFERENCES [Qestions] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Answers_QuestionId] ON [Answers] ([QuestionId]);

GO

CREATE INDEX [IX_Qestions_SurveyId] ON [Qestions] ([SurveyId]);

GO

CREATE INDEX [IX_Results_InterviewId] ON [Results] ([InterviewId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200711173520_First', N'3.1.5');

GO

