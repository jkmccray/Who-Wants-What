# Who Wants What 
### A Wish List App | NSS Back-End Capstone

<img src="./WhoWantsWhat/wwwroot/images/logo.png" alt="logo" float="center" height= 200px; />

Who Wants What is a wish list app that takes the stress out of gift-giving. Users can share wish lists with their groups, create gift ideas for others, and track which gifts have been purchased.

App was built using C#/.NET Core with Entity Framework using Identity and styled using Bootstrap 4. Relational database was managed using SQL Server.

## Instructions for Cloning and Running the Project Locally
**Note: Visual Studio and SQL Server are required to run this project.**

1. Navigate to the directory where you want to save the project, and run the following command in your terminal:
```
  git clone git@github.com:jkmccray/Who-Wants-What.git
```
2. To open the solution file in Visual Studio, run the following command: 
```
start WhoWantsWhat.sln
```
3. When Visual Studio opens, select **Tools > NuGet Package Manager > Package Manager Console** and run the following command in the Package Manager Console: 
```
Update-Database
```
This command will generate the database and seed it with sample data, including the following users:
* Admina Straytor
  * Email: admin@admin.com
  * Password: Admin8*
* Tom Cat
  * Email: tom@cat.com
  * Password: Admin8*
4. Start the program and log in as one of the above users.
