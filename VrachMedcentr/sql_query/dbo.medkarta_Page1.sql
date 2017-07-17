CREATE TABLE [dbo].[medkarta_Page1] (
    [Id]         INT        NOT NULL,
    [Id_pacient] INT        NOT NULL,
    [dataZap]    DATE   NOT NULL,
    [P]          NCHAR (50) NOT NULL,
    [I] NCHAR(50) NOT NULL, 
    [B] NCHAR(50) NOT NULL, 
    [sex] NCHAR(1) NOT NULL, 
    [data_Birth] DATE NOT NULL, 
    [adresa] NCHAR(50) NOT NULL, 
    [nasPunkt] NCHAR(50) NULL, 
    [robota] NCHAR(50) NULL, 
    [Dispans] BIT NOT NULL, 
    [kontyngent] NCHAR(50) NULL, 
    [nomPilg] NCHAR(12) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

