using Lab_1;

string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
string filePath = projectFolder + Path.DirectorySeparatorChar + "Videogames.csv";
List<Videogames> listOfGames = new List<Videogames>();
//Creating the file Stream
using (var sr = new StreamReader(filePath))
{
    while (!sr.EndOfStream)
    {
        string? line = sr.ReadLine();
        string[] lineElements = line.Split(',');
        Videogames game = new Videogames();
        {
            game.Name = lineElements[0];
            game.Platform = lineElements[1];
            game.Year = lineElements[2];
            game.Genre = lineElements[3];
            game.Publisher = lineElements[4];   
            game.NASales = lineElements[5];
            game.EUSales = lineElements[6];
            game.JPSales = lineElements[7];
            game.OtherSales = lineElements[8];
            game.GlobalSales = lineElements[9];
        }
        listOfGames.Add(game);
    }
}
listOfGames.Sort();

//List of Namco Bandi Games
List<Videogames> namacoBandiGames = new List<Videogames>(); 
foreach (var game in listOfGames)
{
    if (game.Publisher == "Namco Bandai Games")
        namacoBandiGames.Add(game);
}
namacoBandiGames.Sort();
foreach (var game in namacoBandiGames)
{
    Console.WriteLine(game.ToString());
}

int bandiGames = namacoBandiGames.Count();
int total = listOfGames.Count();
decimal percentBandi = Math.Round(((decimal)bandiGames / total)*100,2);
Console.WriteLine($"Out of {total} games {bandiGames} of them are from Namico Bandi Games. Which is {percentBandi}%");

//List of RPG games
List<Videogames> RPGgames = new List<Videogames>();
foreach (var game in listOfGames)
{
    if (game.Genre == "Role-Playing")
        RPGgames.Add(game);
}
RPGgames.Sort();
foreach (var game in RPGgames)
{
    Console.WriteLine(game.ToString());
}
int totalRPGgames = RPGgames.Count();
decimal percentRPG = Math.Round(((decimal)totalRPGgames / total) * 100, 2);
Console.WriteLine($"Out of {total} games {totalRPGgames} of them are Role-Playing Games. Which is {percentRPG}%");


//Publisher Data
static string PublisherData(List<Videogames> listOfGames)
{
    bool check = false;
    string userPub = null;

    while (!check)
    {
        Console.Write("Please enter the Publisher you are looking for: ");
        string userInput = Console.ReadLine();

        bool publisherExists = listOfGames.Any(game => game.Publisher == userInput);

        if (publisherExists)
        {
            check = true;
            userPub = userInput;
        }
        else
        {
            Console.WriteLine("Publisher not found in the list. Please try again.");
        }
    }

    List<Videogames> userListPub = listOfGames.Where(game => game.Publisher == userPub).ToList();

    foreach (var game in userListPub)
    {
        Console.WriteLine(game.ToString());
    }
    int total = listOfGames.Count();
    Console.WriteLine($"Out of {total} games {userListPub.Count()} of them are Published by {userPub}. Which is {Math.Round(((decimal)userListPub.Count() / total) * 100),2}%");

    return userPub;
}
//Genre Data
static string GenreData(List<Videogames> listOfGames)
{
    bool check = false;
    string userGenre = null;

    while (!check)
    {
        Console.Write("Please enter the Genre you are looking for: ");
        string userInput = Console.ReadLine();

        bool genreExists = listOfGames.Any(game => game.Genre == userInput);

        if (genreExists)
        {
            check = true;
            userGenre = userInput;
        }
        else
        {
            Console.WriteLine("Genre not found in the list. Please try again.");
        }
    }

    List<Videogames> userListGenre = listOfGames.Where(game => game.Genre == userGenre).ToList();

    foreach (var game in userListGenre)
    {
        Console.WriteLine(game.ToString());
    }
    int total = listOfGames.Count() ;
    Console.WriteLine($"Out of {total} games {userListGenre.Count()} of them are {userGenre} Games. Which is {Math.Round(((decimal)userListGenre.Count() / total) * 100),2}%");
    return userGenre;
}

PublisherData(listOfGames);

GenreData(listOfGames);







