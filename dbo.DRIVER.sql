CREATE TABLE [dbo].[DRIVER] (
    [Id]              INT           NOT NULL,
    [Name]            VARCHAR (100) NULL,
    [Age]             INT           NULL,
    [Gender]          CHAR (10)     NULL,
    [Address]         VARCHAR (500) NULL,
    [Availaibility]   CHAR (10)     NULL,
    [Vehicle_Type]    NCHAR (10)    NULL,
    [Vehicle_Model]   NCHAR (10)    NULL,
    [Vehicle_License] NCHAR (10)    NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);

