READ ME

To Open The Project Is necesary to have Visual Studio comunity and SqlServer Installed in your Local computer 

DB SetUP:(Recomended)
1. Find In the Project Files in folder DB DBScript.SQL
2. Open Sql Server Create a DB with name AssetManagmet
3. create new Query And excute Script
or 
1. open a sqlserver
2. right click databases and select Atach
3. find AssetManagment  on the same folder 



Visual Studio projct runnig:
1. Open Solution projcet
2. Open solution explorer
3. In the Models Folder Open AssetManagementContext
4. in the line 32 "Server=d068;Database=AssetManagment;Trusted_Connection=True;" replace the server name with your name server
5. make sure to use windows authentication, if you are using sql server authentication make sure to add the user name and the password in the connection string 