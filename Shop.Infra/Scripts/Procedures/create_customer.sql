CREATE PROCEDURE spCreateCustomer
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(40),
    @LastName VARCHAR(40),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @CreatedOn DATETIME,
    @UpdatedOn DATETIME
AS
    INSERT INTO [Customer] (
        [Id],
        [FirstName],
        [LastName],
        [Document],
        [Email],
        [CreatedOn],
        [UpdatedOn]
    ) VALUES (
        @Id,
        @FirstName,
        @LastName,
        @Document,
        @Email,
        @CreatedOn,
        @UpdatedOn
    )
