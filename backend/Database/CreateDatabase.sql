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
	"Document_Id" integer,
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
    "Document_StatusId" integer
);

CREATE TABLE "DocumentStatus"
(
    "DocumentStatus_Id" SERIAL PRIMARY KEY,
    "DocumentStatus_Description" VARCHAR
);

CREATE TABLE "DocumentType"
(
    "DocumentType_Id" SERIAL PRIMARY KEY,
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
	"User_IBAN" VARCHAR(34),
	"User_ReferenceNumber" VARCHAR(27),
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
	
ALTER TABLE "ArticlePosition"
    ADD CONSTRAINT "FK_Article_Id"
    FOREIGN KEY ("Article_Id") 
    REFERENCES "Article" ("Article_Id");
	
ALTER TABLE "ArticlePosition"
    ADD CONSTRAINT "FK_Document_Id"
    FOREIGN KEY ("Document_Id") 
    REFERENCES "Document" ("Document_Id");

DROP FUNCTION GetDocumentView;

CREATE OR REPLACE FUNCTION GetDocumentView (
	documentId integer
)
	RETURNS TABLE (
		Document_Number 	INT,
		User_IBAN 			VARCHAR,
		User_RefNumber 		VARCHAR,
		User_FirstName 		VARCHAR,
		User_LastName 		VARCHAR,
		User_Mail 			VARCHAR,
		Customer_FirstName 	VARCHAR,
		Customer_LastName 	VARCHAR,
		Customer_Address1 	VARCHAR,
		Customer_PlzNumber  VARCHAR,
		Customer_PlzCity    VARCHAR,
		ArtPos_Quantity     NUMERIC,
		Art_Title			VARCHAR,
		Art_Description		VARCHAR,
		Art_Price			NUMERIC,
		TaxRate_Percentage	NUMERIC,
		ArtUnit_Text        VARCHAR
	)
	LANGUAGE PLPGSQL
	AS $$
	BEGIN 
		RETURN QUERY
				SELECT 
				"Document"."Document_Number", 
        		"User"."User_IBAN",
				"User"."User_ReferenceNumber",
				"User"."User_FirstName",
				"User"."User_LastName",
				"User"."User_Mail",
        		"Customer"."Customer_FirstName",
				"Customer"."Customer_LastName",
				"Customer"."Customer_Address1",
        		"CustomerPlz"."Plz_Number",
				"CustomerPlz"."Plz_City",
        		"ArticlePosition"."Article_Quantity",
        		"Article"."Article_Title",
				"Article"."Article_Description",
				"Article"."Article_Price",
        		"TaxRate"."Taxrate_Percentage",
        		"ArticleUnit"."ArticleUnit_Text"
				FROM "Document"
					JOIN "User" on "User"."User_Id" = "Document"."Document_CreatorId"
        			JOIN "Customer" on "Customer"."Customer_Id" = "Document"."Document_SendeeId"
        			JOIN "Plz" as "CustomerPlz" on "CustomerPlz"."Plz_Id" = "Customer"."Customer_PlzId"
        			JOIN "ArticlePosition" on "ArticlePosition"."Document_Id" = "Document"."Document_Id"
        			JOIN "Article" on "Article"."Article_Id" = "ArticlePosition"."Article_Id"
        			JOIN "TaxRate" on "TaxRate"."Taxrate_Id" = "Article"."Article_TaxRate"
        			JOIN "ArticleUnit" on "ArticleUnit"."ArticleUnit_Id" = "Article"."Article_Unit"
				WHERE "Document"."Document_Id" = documentId;
	END;$$
END;
