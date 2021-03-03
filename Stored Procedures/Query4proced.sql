ALTER PROCEDURE query4
 @StartDate DATETIME,
 @StopDate DATETIME
AS
BEGIN
SELECT Customer.FirstName, Customer.LastName,  
       Customer.Address, Customer.City, Customer.Country , Customer.Company , Customer.CustomerId,
	   Customer.PostalCode, Customer.State, Customer.SupportRepId ,
       Customer.Phone, Customer.Email, Customer.Fax, --στοιχεία επικοινωνίας
	   Turnover, Invoice.InvoiceId, EmployeeFirst, EmployeeLast  --υπολογισμός τζίρου από τιμολόγια
FROM InvoiceLine, Track, Customer, Invoice, Album, Artist, Genre
WHERE Invoice.InvoiceDate > @StartDate AND  --χρονικό διάστημα αγορών
	  Invoice.InvoiceDate < @StopDate AND    
      Invoice.InvoiceId = InvoiceLine.InvoiceId AND
	  Invoice.CustomerId = Customer.CustomerId AND
	  InvoiceLine.TrackId = Track.TrackId AND  
	  Track.AlbumId = Album.AlbumId AND
	  Album.ArtistId = Artist.ArtistId AND
	  Genre.GenreId = Track.GenreId
	  GROUP BY Customer.FirstName,  Customer.LastName, Customer.Phone, Customer.Email, Customer.Fax, 
	  Customer.Address, Customer.City, Customer.Country , Customer.Company , Customer.CustomerId,
	  Customer.PostalCode, Customer.State, Customer.SupportRepId, Turnover, EmployeeFirst, EmployeeLast, invoice.InvoiceId
	  ORDER BY Turnover DESC   --φθίνουσα ταξινόμηση τζίρων
END