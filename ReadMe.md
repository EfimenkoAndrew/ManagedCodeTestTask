1) install docker 
2) copy `transactions_2_million.csv` to `src/ManagedCodeTestTask.Api/`. Git does not support 100+MB files
3) run `docker-compose build` to build project. 
4) run `docker-compose --env-file .env -f .\docker-compose.override.yml -f .\docker-compose.yml up -d` to run the db and app
5) visit `http://localhost:4847/swagger/index.html`
6) call POST: /api/transactions with body:
`
{
  "filePath": "transactions_2_million.csv"
}
`
7) be patient 
8) call GET: /api/transactions

for file results - put true in the parameter.
Open `managedcodetesttask_output_files` volume to find and download `output_file.json` with json results

Persomal notes:
I think that JSON file report generation should be a separate controller, not a flag. I had a crazy weekend so I had to make some shortcuts.
