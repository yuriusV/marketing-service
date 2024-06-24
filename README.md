### Architecture
![Diagram](docs/arch.png)

### Run in docker

docker-compose -p marketingfull -f docker-compose.yml -f docker-compose.override.yml up -d --build

docker-compose -p marketingslim -f docker-compose.slim.yml up -d --build

### Add migrations

dotnet ef migrations add MigrationName