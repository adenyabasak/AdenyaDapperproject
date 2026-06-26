USE AdenyaFreelanceDb
GO

CREATE PROC ReportLastJobs
AS
BEGIN
    SELECT TOP 5
        Title,
        Budget
    FROM Jobs
    ORDER BY JobId DESC
END
GO





CREATE PROC ReportLastBids
AS
BEGIN
    SELECT TOP 5
        Price,
        Message,
        BidDate
    FROM Bids
    ORDER BY BidId DESC
END
GO