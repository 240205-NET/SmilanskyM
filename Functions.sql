
-- SQUARE NUMBER
CREATE FUNCTION dbo.fn_Square (@number INT)
RETURNS INT
AS
BEGIN
    RETURN @number * @number
END
GO

-- SELECT dbo.fn_Square(a.ArtistId)
--     FROM Artist AS a;

-- CONCAT TWO STRINGS WITH SPACE
ALTER FUNCTION dbo.Concat(@str1 VARCHAR(255), @str2 VARCHAR(255))
RETURNS VARCHAR(510)
AS
BEGIN
    RETURN @str1 + ' ' + @str2
END
GO

-- SELECT dbo.Concat(c.FirstName, c.LastName)
--     FROM Customer AS c;

-- CALCULATE AGE FROM BIRTHDATE
CREATE FUNCTION dbo.CalculateAge(@birthdate DATE)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(YEAR, @birthdate, GETDATE()) - CASE
        WHEN MONTH(@birthdate) > MONTH(GETDATE()) -- the month of birthdate is greater than curr month
        OR (MONTH(@birthdate) = MONTH(GETDATE()) AND DAY(@birthdate) > DAY(GETDATE()))
        THEN 1 ELSE 0
    END
END
GO

