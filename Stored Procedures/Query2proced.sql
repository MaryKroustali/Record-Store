ALTER procedure query2
@StartDate DATE,
@StopDate DATE
AS 
BEGIN
SELECT TOP 10 Track.Name, Track.AlbumId, Track.Bytes, Track.Composer, track.GenreId, Track.MediaTypeId, 
Track.Milliseconds, Track.TrackId, Track.UnitPrice ,COUNT (Track.Name) AS 'Track Sales - Favorites', JanuaryMarch, AprilJune, JulySeptember, OctoberDecember, ArtistName   --πλήθος αγαπημένων κομματιών
FROM Invoice, Track, InvoiceLine, Customer 
WHERE Invoice.CustomerId = Customer.CustomerId AND
      InvoiceLine.TrackId = Track.TrackId AND
      InvoiceLine.InvoiceId = Invoice.InvoiceId AND
      Invoice.InvoiceDate > @StartDate AND  --χρονικό διάστημα με βάση τα τιμολόγια
	  Invoice.InvoiceDate < @StopDate 
      GROUP BY Track.Name, Track.AlbumId, Track.Bytes, Track.Composer, track.GenreId, Track.MediaTypeId, 
Track.Milliseconds, Track.TrackId, Track.UnitPrice, JanuaryMarch, AprilJune, JulySeptember, OctoberDecember, ArtistName   --ομαδοποίηση πωλήσεων ανά κομμάτι
	  ORDER BY [Track Sales - Favorites] DESC --φθίνουσα ταξινόμηση αγαπημένων κομματιών
END