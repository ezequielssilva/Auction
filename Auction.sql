USE master

GO

DROP DATABASE Auction

GO

CREATE DATABASE Auction

GO 

USE Auction

GO

CREATE TABLE Product(
    Id INT NOT NULL IDENTITY(1, 1),
    Name VARCHAR(60) NOT NULL,
    Value DECIMAL(12,2) NOT NULL,
    RegisteredIn DATETIME NOT NULL,

    CONSTRAINT PK_Product_Id PRIMARY KEY (Id)
)

GO 

CREATE TABLE Person(
    Id INT NOT NULL IDENTITY(1, 1),
    Name VARCHAR(60) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    DateOfBirth DATETIME NOT NULL,
    RegisteredIn DATETIME NOT NULL,

    CONSTRAINT PK_Person_Id PRIMARY KEY (Id)
)

GO 

CREATE TABLE Negotiation(
    Id INT NOT NULL IDENTITY(1, 1),
    ProductId INT NOT NULL,
    PersonId INT NOT NULL,
    Value DECIMAL(12,2) NOT NULL,
    NegotiatedOn DATETIME NOT NULL,

    CONSTRAINT PK_Negotiation_Id PRIMARY KEY (Id),
    CONSTRAINT FK_Negotiation_ProductId FOREIGN KEY (ProductId) REFERENCES Product (Id),
    CONSTRAINT FK_Negotiation_PersonId FOREIGN KEY (PersonId) REFERENCES Person (Id)
)