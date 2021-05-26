SELECT * FROM "Article";
SELECT * FROM "ArticlePosition";
SELECT * FROM "ArticleUnit";
SELECT * FROM "TaxRate";

SELECT * FROM "Document";
SELECT * FROM "DocumentStatus";
SELECT * FROM "DocumentType";

SELECT * FROM "User";
SELECT * FROM "Customer";
SELECT * FROM "Plz";

BEGIN;

INSERT INTO "User"("User_FirstName", "User_LastName", "User_DisplayName", "User_Mail", "User_Password")  
VALUES ('Thomas', 'Shelby','Tom', 'tom@gmail.com', 'password');

INSERT INTO "TaxRate"("Taxrate_Percentage", "Taxrate_Description")  
VALUES (5, 'Tax');

INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('Pieces');

INSERT INTO "Article"("Article_Title", "Article_Description", "Article_Price", "Article_TaxRate", "Article_Unit")  
VALUES ('TestArticle', 'This is a test.', 15.99, 1, 1);

INSERT INTO "ArticlePosition"("Article_Id", "Article_Quantity")  
VALUES (1, 15);

INSERT INTO "DocumentType"("DocumentType_Title", "DocumentType_Description")  
VALUES ('Invoice', 'Invoice description');

INSERT INTO "DocumentStatus"("DocumentStatus_Description")  
VALUES ('Active');

INSERT INTO "Plz"("Plz_Number", "Plz_City")  
VALUES ('6330', 'Zug');

INSERT INTO "Customer"("Customer_FirstName", "Customer_LastName", "Customer_Address1", "Customer_Address2", "Customer_Email", "Customer_PlzId")  
VALUES ('James', 'Bond', 'secret 15', '', 'james@gmail.com', 1);

INSERT INTO "Document"("Document_Number", "Document_TypeId", "Document_CreatorId", "Document_SendeeId", "Document_StatusId", "Document_ArticlePositionId")  
VALUES (100, 1, 1, 1, 1, 1);

END;
