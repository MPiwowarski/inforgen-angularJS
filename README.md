"# inforgen" 

1. Creationg of the database
Open backend project in the Visual Studio
Open Package Manager Console 
type command: Enable-Migrations
then type command: Update-Database
The database should be created automatically with tables and sample data.
If no then check if your connections string in .config file is ok.

2. Run the WebAPI
if the url in your web browser is different than the url in MyApp.WebAPI/Web.config, please change the value of appUrl node in <appSettings> section to your url.

3. Run the Web UI
Open cmder and go to the directory of the frontend folder
Type command: npm install


To run the web ui type command: gulp serve