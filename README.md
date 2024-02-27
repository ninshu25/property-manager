# property-manager
Initially to perform the migration the following is executed `dotnet ef --startup-project ./API --project ./DataAccess migrations add InitialMigration -c CRMContext` and then continued by `dotnet ef --startup-project ./API --project ./DataAccess database update -c CRMContext`.

Once the database has been populated table structures, exectue the seeding script to add the initial data.

# Project
As a project both front-end and back-end a Monolithic structure was utilised (since it is not a big project). On the backend the Onion architecture was adopted to adhere SOLID principles.

On the frontend the angular 17 framework was used, and a modular approach to components was used to reduce duplication of code

# Help
If there is any issues with installing and running the solution please, do reach out on ciantarnathan00@gmail.com