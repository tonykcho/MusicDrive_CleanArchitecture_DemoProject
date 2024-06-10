Music Drive Database Migrations

## Get migrations list
    dotnet ef migrations list -p MusicDrive.DataAccess -s MusicDrive.Api

## Add new migrations
    dotnet ef migrations add <name> -p MusicDrive.DataAccess -s MusicDrive.Api -o ./Migrations -c MusicDriveDbContext

## Remove new migrations
    dotnet ef migrations remove -p MusicDrive.DataAccess -s MusicDrive.Api -o ./Migrations -c MusicDriveDbContext

## Reset Database
    dontnet ef migrations update 0 -p MusicDrive.DataAccess -s MusicDrive.Api -o ./Migrations -c MusicDriveDbContext
