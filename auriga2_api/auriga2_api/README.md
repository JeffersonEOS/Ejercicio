#### Adicion migrations

dotnet ef migrations add InitialCreate -c Auriga2Context -s ../auriga2.infraestructure.api --output-dir migrations
dotnet ef migrations script -o .\Migrations\Scripts\v1.0.0.sql -s ../auriga2.infraestructure.api
dotnet ef migrations add v1.0.0 -s ../auriga2.infraestructure.api
dotnet ef migrations remove -s ../auriga2.infraestructure.api
dotnet ef database update -c Auriga2Context -s ../auriga2.infraestructure.Api

### ErrorHandler middleware

use CustomException for intercept in the middleware as controlled error