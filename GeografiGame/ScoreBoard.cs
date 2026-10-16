using System;
using System.Collections.Generic;
using System.IO; // Krävs för att kunna hantera filer

namespace GeografiGame
{
    public class Scoreboard
    {
        private List<ScoreList> _scores;
        private int _maxEntries;
        private string _filePath = "scores.txt"; // Filen skapas i samma mapp som spelet körs ifrån

        public Scoreboard(int maxEntries = 5)
        {
            _maxEntries = maxEntries;
            _scores = new List<ScoreList>();

            LoadScores(); // 1. Ladda sparade poäng direkt när spelet startar!
        }

        public void AddScore(string name, int score)
        {
            _scores.Add(new ScoreList(name, score));
            _scores.Sort();

            if (_scores.Count > _maxEntries)
            {
                _scores.RemoveRange(_maxEntries, _scores.Count - _maxEntries);
            }

            SaveScores(); // 2. Spara listan till filen direkt när en ny poäng läggs till!
        }

        public void Display()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine("\n=================================");
            Console.WriteLine("       GEOGRAFI GAME - TOPPLISTA  ");
            Console.WriteLine("=================================");
            Console.WriteLine($"{"Plats",-6} {"Namn",-15} {"Poäng",-10}");
            Console.WriteLine(new string('-', 33));

            for (int i = 0; i < _scores.Count; i++)
            {
                Console.WriteLine($"{i + 1,-6} {_scores[i].PlayerName,-15} {_scores[i].HighScore,-10}");
            }
            Console.WriteLine("=================================\n");
        }

        // METOD 1: Sparar listan till textfilen
        private void SaveScores()
        {
            try
            {
                List<string> lines = new List<string>();

                // Gör om varje spelare till textraden "Namn;Poäng"
                foreach (var entry in _scores)
                {
                    lines.Add($"{entry.PlayerName};{entry.HighScore}");
                }

                // Skriver över filen med den nya uppdaterade listan
                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception)
            {
                // Om något går fel (t.ex. filen är låst) så kraschar inte spelet
                Console.WriteLine("Kunde inte spara poängen till filen.");
            }
        }

        // METOD 2: Läser poängen från textfilen
        private void LoadScores()
        {
            // Om filen inte finns än (t.ex. första gången man spelar) gör vi ingenting
            if (!File.Exists(_filePath)) return;

            try
            {
                string[] lines = File.ReadAllLines(_filePath);

                foreach (string line in lines)
                {
                    // Delar upp raden vid semikolonet
                    string[] parts = line.Split(';');

                    if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                    {
                        // Lägg till i listan igen
                        _scores.Add(new ScoreList(parts[0], score));
                    }
                }

                // Sortera listan så att den är i rätt ordning efter laddningen
                _scores.Sort();
            }
            catch (Exception)
            {
                // Om filen är trasig eller inte kan läsas, starta med en tom lista
                _scores = new List<ScoreList>();
            }
        }
    }
}

