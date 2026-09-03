# financial_data_ingestion
A small C# / .NET WinForms proof-of-concept demonstrating REST API integration with SQLite persistence.

What it does
Downloads sample data from a public REST API (jsonplaceholder.typicode.com) using async HTTP calls
Saves the data to a local SQLite database using parameterized queries and transactions
Reads the saved data back from SQLite and displays it in a grid
Tech Stack
Language: C# / .NET
UI: WinForms
Database: SQLite (Microsoft.Data.Sqlite)
Key implementation details
Async/await used throughout for HTTP calls and database operations, keeping the UI responsive
Parameterized SQL queries (SqliteCommand.Parameters) to prevent SQL injection
Transactions used when writing batches of records to ensure consistency
Quickstart
Clone the repository:
   git clone https://github.com/nicodev1992-crypto/financial_data_ingestion.git
Open DemoWinFormsApi.slnx in Visual Studio
Run the project — click "Download and save data on db" to fetch and persist data, then "Load From DB and populate grid" to read it back
Notes

This is a small demo built to practice REST + SQLite integration in .NET, not a production-ready architecture. Next steps would include separating the data-access logic from the UI layer more cleanly.
