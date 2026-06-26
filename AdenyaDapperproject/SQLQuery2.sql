USE AdenyaFreelanceDb
GO

CREATE PROC BidListByUser
@UserId INT
AS
BEGIN
    SELECT 
        Bids.BidId,
        Bids.JobId,
        Bids.UserId,
        Bids.Price,
        Bids.Message,
        Bids.BidDate,
        Jobs.Title,
        Users.FullName
    FROM Bids
    INNER JOIN Jobs ON Bids.JobId = Jobs.JobId
    INNER JOIN Users ON Bids.UserId = Users.UserId
    WHERE Bids.UserId = @UserId
END
GO