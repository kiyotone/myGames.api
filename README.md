# 🎮 myGames.api

A simple .NET API to store and display games you've played, each linked to a genre using a genre ID system.

## 🛠 Features

- Add and view your game collection.
- Use genre IDs to classify games by type (e.g., RPG, Action, Strategy).
- Fetch list of all games.
- Update or delete game entries.

## 🧩 Tech Stack

- .NET 8 Web API
- Entity Framework Core 9.0.3
- SQLite database

## 📦 API Overview

### 🎲 Games

| Method | Endpoint        | Description             |
|--------|------------------|-------------------------|
| GET    | /api/games       | Get all games           |
| GET    | /api/games/{id}  | Get a game by ID        |
| POST   | /api/games       | Add a new game          |
| PUT    | /api/games/{id}  | Update a game           |
| DELETE | /api/games/{id}  | Delete a game           |

## 🧪 Example Game JSON

```json
{
    "name": "Cyberpuasdnk 2077",
    "genreId": 3,
    "platform": "PC",
    "releaseDate": "2020-12-10"

}
```

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/kiyotone/myGames.api.git
cd myGames.api
```

### 2. Install dependencies

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.3
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 9.0.3
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.3
```

### 3. Set up the database

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

### 5. Access the API

Navigate to: `http://localhost:5066` (or the port your app uses).

## 📄 License

MIT License

---

Built with 💻 by [@kiyotone](https://github.com/kiyotone)
