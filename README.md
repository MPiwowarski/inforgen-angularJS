"# inforgen" 
Description of the quick configuration of the development environment

1. Creation of the database.
* Open backend project in the Visual Studio
* Open Package Manager Console 
* type command: Enable-Migrations
* then type command: Update-Database
* The database should be created automatically with tables and sample data.
If no then check if your connections string in .config file is ok.

2. Run the WebAPI
* Try to run the MyApp.WebAPI project in the debug mode.
* If the url in your web browser is different than the url in MyApp.WebAPI/Web.config -> http://localhost:59649, please change the value of appUrl node in <appSettings> section to your url.

3. Run the Web UI
* Open cmder and go to the directory of the frontend folder
* Type command: npm install
* Then type command: bower install
* To run the web ui type command: gulp serve