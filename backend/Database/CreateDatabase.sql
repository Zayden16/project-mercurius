BEGIN;

CREATE TABLE "Article"
(
    "Article_Id" SERIAL PRIMARY KEY,
    "Article_Title" VARCHAR,
    "Article_Description" VARCHAR,
    "Article_Price" numeric,
	"Article_TaxRate" integer,
    "Article_Unit" integer
);

CREATE TABLE "ArticlePosition"
(
    "ArticlePosition_Id" SERIAL PRIMARY KEY,
    "Article_Id" integer,
    "Article_Quantity" numeric
);

CREATE TABLE "ArticleUnit"
(
    "ArticleUnit_Id" SERIAL PRIMARY KEY,
    "ArticleUnit_Text" VARCHAR
);

CREATE TABLE "Customer"
(
    "Customer_Id" SERIAL PRIMARY KEY,
    "Customer_FirstName" VARCHAR,
    "Customer_LastName" VARCHAR,
    "Customer_Address1" VARCHAR,
    "Customer_Address2" VARCHAR,
    "Customer_Email" VARCHAR,
    "Customer_PlzId" integer
);

CREATE TABLE "Document"
(
    "Document_Id" SERIAL PRIMARY KEY,
    "Document_Number" integer NOT NULL,
    "Document_TypeId" integer,
    "Document_CreatorId" integer,
    "Document_SendeeId" integer,
    "Document_StatusId" integer,
    "Document_ArticlePositionId" integer
);

CREATE TABLE "DocumentStatus"
(
    "DocumentStatus_Id" SERIAL PRIMARY KEY,
    "DocumentStatus_Description" VARCHAR
);

CREATE TABLE "DocumentType"
(
    "DocumentType_Id" SERIAL PRIMARY KEY,
    "DocumentType_Title" VARCHAR,
    "DocumentType_Description" VARCHAR
);

CREATE TABLE "Plz"
(
    "Plz_Id" SERIAL PRIMARY KEY,
    "Plz_Number" VARCHAR,
    "Plz_City" VARCHAR
);

CREATE TABLE "TaxRate"
(
    "Taxrate_Id" SERIAL PRIMARY KEY,
    "Taxrate_Percentage" numeric,
    "Taxrate_Description" VARCHAR
);

CREATE TABLE "User"
(
    "User_Id" SERIAL PRIMARY KEY,
    "User_FirstName" VARCHAR,
    "User_LastName" VARCHAR,
    "User_DisplayName" VARCHAR,
    "User_Mail" VARCHAR,
    "User_Password" text NOT NULL
);
	
ALTER TABLE "Article"
    ADD CONSTRAINT "FK_Article_TaxRate"
    FOREIGN KEY ("Article_TaxRate") 
    REFERENCES "TaxRate" ("Taxrate_Id");

ALTER TABLE "Article"
    ADD CONSTRAINT "FK_Article_Unit"
    FOREIGN KEY ("Article_Unit") 
    REFERENCES "ArticleUnit" ("ArticleUnit_Id");

ALTER TABLE "Customer"
    ADD CONSTRAINT "FK_Customer_PlzId"
    FOREIGN KEY ("Customer_PlzId") 
    REFERENCES "Plz" ("Plz_Id");
	
ALTER TABLE "ArticlePosition"
    ADD CONSTRAINT "FK_Article_Id"
    FOREIGN KEY ("Article_Id") 
    REFERENCES "Article" ("Article_Id");
	
ALTER TABLE "Document"
    ADD CONSTRAINT "FK_Document_TypeId"
    FOREIGN KEY ("Document_TypeId") 
    REFERENCES "DocumentType" ("DocumentType_Id");

ALTER TABLE "Document"
    ADD CONSTRAINT "FK_Document_CreatorId"
    FOREIGN KEY ("Document_CreatorId") 
    REFERENCES "User" ("User_Id");
	
ALTER TABLE "Document"
    ADD CONSTRAINT "FK_Document_SendeeId"
    FOREIGN KEY ("Document_SendeeId") 
    REFERENCES "Customer" ("Customer_Id");
	
ALTER TABLE "Document"
    ADD CONSTRAINT "FK_Document_StatusId"
    FOREIGN KEY ("Document_StatusId") 
    REFERENCES "DocumentStatus" ("DocumentStatus_Id");
	
ALTER TABLE "Document"
    ADD CONSTRAINT "FK_Document_ArticlePositionId"
    FOREIGN KEY ("Document_ArticlePositionId") 
    REFERENCES "ArticlePosition" ("ArticlePosition_Id");
	
END;
