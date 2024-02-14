# My-Ride-App
I created a Console base app Like Uber Careem using C# 
To use this project you need to set up a Microsoft SQL server on your Local host which is utilized in the Project.

# Database Schema

This document outlines the schema for the `DRIVER` table in the database.

## Table Name: DRIVER

### Columns
- `Id`: INTEGER, NOT NULL
- `Name`: VARCHAR(100)
- `Age`: INTEGER
- `Gender`: CHAR(10)
- `Address`: VARCHAR(500)
- `Latitude`: FLOAT(53)
- `Longitude`: FLOAT(53)
- `Availability`: CHAR(10)
- `Vehicle_Type`: NCHAR(10)
- `Vehicle_Model`: NCHAR(10)
- `Vehicle_License`: NCHAR(10)

### Primary Key
The primary key for this table is `Id`.

### SQL Code
```sql
CREATE TABLE [dbo].[DRIVER] (
    [Id]              INT           NOT NULL,
    [Name]            VARCHAR (100) NULL,
    [Age]             INT           NULL,
    [Gender]          CHAR (10)     NULL,
    [Address]         VARCHAR (500) NULL,
    [Latitude]        FLOAT (53)    NULL,
    [Longitude]       FLOAT (53)    NULL,
    [Availaibility]   CHAR (10)     NULL,
    [Vehicle_Type]    NCHAR (10)    NULL,
    [Vehicle_Model]   NCHAR (10)    NULL,
    [Vehicle_License] NCHAR (10)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
```




After setting up your DataBase you Have to create a Driver Table and after creating it Copy its connection string and place it in the Cloned Project of your which is in AdminLibrary.cs
