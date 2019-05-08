# TestRentCarBackEnd
Rent-A-Car C# backend project.

<strong>Note: this is the backend only. For the front end please visit https://github.com/eliaquin/TestRentCarFrontEnd</strong>

In order to make this application work, please follow this instructions:

1. Download or clone.
2. Open with Visual Studio, preferably Visual Studio 2019.
3. Restore Nuget packages (this should be automatic).
4. Apply migrations to restore database.
5. Run

# Project Structure

<p><strong>Models:</strong> folder where all models are kept.</p>
<p><strong>Data folder</strong>: It contains the following:</p>
<ul>
    <li>ApplicationDbContext (data access configuration)</li>
    <li>Configuration folder (models configuration)</li>
    <li>Infrastructure (Repository configuration)</li>
</ul>
<p><strong>Services:</strong> this is the only place where access to data occurs. All services are available to the application via dependency injection</p>
<p><strong>Api:</strong> this is self-explanatory</p>


    
    
