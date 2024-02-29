using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;


public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
{
    new Game()
    {
        Id = 1,
        Name = "Street Fighter 2",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991, 2, 1),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 2,
        Name = "Final Fnatsy 2",
        Genre = "Roleplaying",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010, 8, 1),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = 3,
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022, 10, 5),
        ImageUri = "https://placehold.co/100"
    }
};

    // public InMemGamesRepository()
    // {
    // }

    public IEnumerable<Game> GetAll()
    {
    return games;
    }

public Game? Get(int id)
{
    return games.Find(game => game.Id == id);
}

public void Create(Game game)
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);
}

public void Update(Game updateGame)
{
    var index = games.FindIndex(game => game.Id == updateGame.Id);
    games[index] = updateGame;
}

public void Delete(int id)
{
    var index = games.FindIndex(game => game.Id == id);
    games.RemoveAt(index);
}
}