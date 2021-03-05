# Record-Store
<h3>Contents</h3>
<ul><li>Controllers</li>
  -Controller files (C#)
  <li>Models</li>
  -Model files (C#)
  <li>Stored Procedures</li>
  -Stored procedures imported in MVC model (SQL)
  <li>Views</li>
  -View files (HTML)
  <li>Chinook.bak</li>
  -Record store database
  <li>Site.css</li>
  -Css file
  <li>_Layout.cshtml</li>
  -HTML file for menu bar
  <hr/></ul>
  
  <h1>Presentation</h1>
  <h3>Home Page</h3>
  <p>-Menu bar, lists of Albums, Artists, Customers, Employees, InvoiceLines, Invoices, MediaTypes, Playlists, Tracks from database.</br>
     -List of links executing stored procedures.</p>
     <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Home%20Page.png">
  <h3>Lists</h3>
  <p>-Albums' list</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Albums.png">
  <p>-Artists' list</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Artists.png">
  <i>*Similarly, all lists.</i> <br/>
  Through the web app the user can insert, update or delete from database.
  
  <h3>Executing Stored Procedures</h3>
  <p><b>1<sup>st</sup> link, Top Artists</b></p>
  <p>-User selects number of top artists and between which dates</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Form1.png">
  <p>-Results</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Sql1.png">
  <br/>
  <p><b>2<sup>nd</sup> link, Top 10 Tracks</b></p>
  <p>-User selects dates</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Form2.png">
  <p>-Results</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Sql2.png">
  <br/>
  <p><b>3<sup>rd</sup> link, Top 3 Genres</b></p>
  <p>-Results</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Sql3.png">
  <br/>
  <p><b>4<sup>th</sup> link, Top Customers</b></p>
  <p>-User selects dates</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Form4.png">
  <p>-Results</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Sql4.png">
  <br/>
  <p><b>5<sup>th</sup> link, Find Invoice</b></p>
  <p>-User selects dates, customer's and employee's name</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Form5.png">
  <p>-Results</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Sql5.png">
  <br/>
  <p><b>6<sup>th</sup> link, Track Sales per 3 Months</b></p>
  <p>-User selects year</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Form6.png">
  <p>-Results</p>
  <img src="https://github.com/MaryKroustali/Record-Store/blob/main/Screenshots/Sql6.png">
<i>User can submit form with null value(s) of date. If 'Since' is null, first date in database is used. If 'Till' is null, latest date in database is used. If both are null, results are between first and latest date in database. 
<i>*Stored procedures were imported in the MVC model.</i>
<br/>
<hr>
<h3>Technical details</h3>
<p>-Database and procedures were implemented in SQL Management Studio. <br/>
   -MVC project was implemented in Visual Studio connected to SQL server. </p>
  
  
 
