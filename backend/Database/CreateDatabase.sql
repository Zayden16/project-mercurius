BEGIN;

CREATE TABLE public."Article"
(
    "Article_Id" uuid NOT NULL,
    "Article_Title" character varying,
    "Aritcle_Descrption" character varying,
    "Article_Price" numeric,
    "Article_TaxRate" uuid,
    "Article_Unit" uuid,
    PRIMARY KEY ("Article_Id")
);

CREATE TABLE public."ArticlePosition"
(
    "ArticlePosition_Id" uuid NOT NULL,
	"Document_Id" uuid,
    "Article_Id" uuid,
    "Article_Quantity" double precision,
    PRIMARY KEY ("ArticlePosition_Id")
);

CREATE TABLE public."ArticleUnit"
(
    "ArticleUnit_Id" uuid NOT NULL,
    "ArticleUnit_Text" character varying,
    PRIMARY KEY ("ArticleUnit_Id")
);

CREATE TABLE public."Customer"
(
    "Customer_Id" uuid NOT NULL,
    "Customer_FirstName" character varying,
    "Customer_LastName" character varying,
    "Customer_Address1" character varying,
    "Customer_Address2" character varying,
    "Customer_Email" character varying,
    "Customer_PlzId" uuid,
    PRIMARY KEY ("Customer_Id")
);

CREATE TABLE public."Document"
(
    "Document_Id" uuid NOT NULL,
    "Document_Number" integer NOT NULL,
    "Document_TypeId" uuid,
    "Document_CreatorId" uuid,
    "Document_SendeeId" uuid,
    "Document_StatusId" uuid,
    "Document_ArticlePositionId" uuid,
    PRIMARY KEY ("Document_Id")
);

CREATE TABLE public."DocumentType"
(
    "DocumentType_Id" uuid NOT NULL,
    "DocumentType_Title" character varying,
    "DocumentType_Description" character varying,
    PRIMARY KEY ("DocumentType_Id")
);

CREATE TABLE public."Plz"
(
    "Plz_Id" uuid NOT NULL,
    "Plz_Number" integer,
    "Plz_City" character varying,
    PRIMARY KEY ("Plz_Id")
);

CREATE TABLE public."TaxRate"
(
    "Taxrate_Id" uuid NOT NULL,
    "Taxrate_Percentage" numeric,
    "Taxrate_Description" character varying,
    PRIMARY KEY ("Taxrate_Id")
);

CREATE TABLE public."User"
(
    "User_Id" uuid NOT NULL,
    "User_FirstName" character varying,
    "User_LastName" character varying,
    "User_Name" character varying,
    "User_Mail" character varying,
    "User_Salt" character varying,
    "User_Password" character varying,
    PRIMARY KEY ("User_Id")
);

CREATE TABLE public."DocumentStatus"
(
    "DocumentStatus_Id" uuid NOT NULL,
    "DocumentStatus_Description" character varying,
    PRIMARY KEY ("DocumentStatus_Id")
);

ALTER TABLE public."Article"
    ADD FOREIGN KEY ("Article_TaxRate")
    REFERENCES public."TaxRate" ("Taxrate_Id")
    NOT VALID;


ALTER TABLE public."Article"
    ADD FOREIGN KEY ("Article_Unit")
    REFERENCES public."ArticleUnit" ("ArticleUnit_Id")
    NOT VALID;


ALTER TABLE public."Customer"
    ADD FOREIGN KEY ("Customer_PlzId")
    REFERENCES public."Plz" ("Plz_Id")
    NOT VALID;

ALTER TABLE public."ArticlePosition"
    ADD FOREIGN KEY ("Document_Id")
    REFERENCES public."Document" ("Document_Id")
    NOT VALID;

ALTER TABLE public."Document"
    ADD FOREIGN KEY ("Document_ArticlePositionId")
    REFERENCES public."ArticlePosition" ("ArticlePosition_Id")
    NOT VALID;


ALTER TABLE public."Document"
    ADD FOREIGN KEY ("Document_CreatorId")
    REFERENCES public."User" ("User_Id")
    NOT VALID;


ALTER TABLE public."Document"
    ADD FOREIGN KEY ("Document_SendeeId")
    REFERENCES public."Customer" ("Customer_Id")
    NOT VALID;


ALTER TABLE public."Document"
    ADD FOREIGN KEY ("Document_StatusId")
    REFERENCES public."DocumentStatus" ("DocumentStatus_Id")
    NOT VALID;


ALTER TABLE public."Document"
    ADD FOREIGN KEY ("Document_TypeId")
    REFERENCES public."DocumentType" ("DocumentType_Id")
    NOT VALID;

END;