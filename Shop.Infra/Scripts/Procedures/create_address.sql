CREATE PROCEDURE spCreateAddress
  @Id UNIQUEIDENTIFIER,
	@CustomerId UNIQUEIDENTIFIER,
	@Number VARCHAR(10),
	@Street VARCHAR(40),
	@District VARCHAR(60),
	@City VARCHAR(60),
	@State CHAR(2),
	@Country CHAR(2),
	@ZipCode CHAR(8),
  @CreatedOn DATETIME,
  @UpdatedOn DATETIME
AS
    INSERT INTO [Address] (
        [Id],
        [CustomerId],
        [Number],
        [Street],
        [District],
        [City],
        [State],
        [Country],
        [ZipCode],
        [CreatedOn],
        [UpdatedOn]

    ) VALUES (
        @Id,
        @CustomerId,
        @Number,
        @Street,
        @District,
        @City,
        @State,
        @Country,
        @ZipCode,
        @CreatedOn,
        @UpdatedOn
    )
