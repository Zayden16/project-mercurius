BEGIN;

INSERT INTO "User"("User_IBAN", "User_ReferenceNumber", "User_FirstName", "User_LastName", "User_DisplayName", "User_Mail", "User_Password")  
VALUES ('CH9300762011623852957', '21000000003139471430009017', 'Thomas', 'Shelby', 'Tom', 'tom@gmail.com', 'password');

INSERT INTO "User"("User_IBAN", "User_ReferenceNumber", "User_FirstName", "User_LastName", "User_DisplayName", "User_Mail", "User_Password")  
VALUES ('CH6904205123987375128', '53200001105000312897842002', 'Arthur', 'Shelby', 'Arthur', 'arthur@gmail.com', 'password');

INSERT INTO "TaxRate"("Taxrate_Percentage", "Taxrate_Description")  
VALUES (5, 'Tax');

INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('stk');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('kg');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('g');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('m');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('m3');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('cm');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('cm3');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('l');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('dl');
INSERT INTO "ArticleUnit"("ArticleUnit_Text")  
VALUES ('cl');

INSERT INTO "Article"("Article_Title", "Article_Description", "Article_Price", "Article_TaxRate", "Article_Unit")  
VALUES ('TestArticle', 'This is a test.', 15.99, 1, 1);

INSERT INTO "DocumentType"("DocumentType_Description")  
VALUES ('Invoice');

INSERT INTO "DocumentStatus"("DocumentStatus_Description")  
VALUES ('Active');

INSERT INTO "Plz"("Plz_Number", "Plz_City")  
VALUES ('6330', 'Zug');

INSERT INTO "Customer"("Customer_FirstName", "Customer_LastName", "Customer_Address1", "Customer_Address2", "Customer_Email", "Customer_PlzId")  
VALUES ('James', 'Bond', 'secret 15', '', 'james@gmail.com', 1);

INSERT INTO "Document"("Document_Number", "Document_TypeId", "Document_CreatorId", "Document_SendeeId", "Document_StatusId")  
VALUES (100, 1, 1, 1, 1);

INSERT INTO "ArticlePosition"("Article_Id", "Document_Id", "Article_Quantity")  
VALUES (1, 1, 15);

END;
