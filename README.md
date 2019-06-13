# ForWork
This is Console Application builsd in .NetCore C#.
This application should provide work with the database (CRUD).
The database must contain two tables.

The first table named like Realtor has next structure:
Name            Type          Desctription
Id              int           key
Firstname       string(200)   Name of Realtor
Lastname        string(200)   Lastname of Realtor
Division        int           division of Realtor
CreatedDateTime datetime      Date and Time of create record

The second table named like Division is a reference book of divisions has nest structure:
Name            Type          Desctription
Id              int           key
Name            string(200)   Name of division
CreatedDateTime datetime      Date and Time of create record

The app has run from command line with attributes:
If user not a write attributes after executable file, he will see next text:

For use:
  homework [command] [parameters]
            
Commands:
  show realtors                                                 show all Realtors in base
  show divisions                                                show all Divisions in base
  add division [Name]                                           add Division to base
  del division [Name]                                           delete Division from base
  update division [Id] [Name]                                   update Division Name
  add realtor [FistName] [LastName] [Id division]               add realtor to base
  del realtor [Id]                                              del realtor from base
  update realtor [Id] [FirstName] [LastName] [Id division]      update realtor in base


To deploy a program for a specific platform is necessary use dotnet.
For example, for windows7 x64, you need enter: dnet publish -c release -r win7-x64

Special requirements for the application, such as: FluentApi, AutoFac, xUnit, JWT etc. will be added later if required.

