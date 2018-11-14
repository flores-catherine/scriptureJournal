CREATE TABLE [dbo].[Scripture] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Book]      NVARCHAR (MAX) NULL,
    [Chapter]   INT            NOT NULL,
    [Verse]     INT            NOT NULL,
    [Note]      NVARCHAR (MAX) NULL,
    [DateAdded] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Scripture] PRIMARY KEY CLUSTERED ([ID] ASC)
);

