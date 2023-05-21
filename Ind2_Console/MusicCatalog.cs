using System;
using System.Collections.Generic;

namespace Ind2_Console
{
    public class MusicCatalog
    {
        private Dictionary<string, Dictionary<string, List<string>>> catalog;

        public MusicCatalog()
        {
            catalog = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        public void AddDisc(string discName)
        {
            if (!catalog.ContainsKey(discName))
            {
                catalog[discName] = new Dictionary<string, List<string>>();
            }
        }

        public void AddSong(string discName, string songName, string artist)
        {
            if (catalog.ContainsKey(discName))
            {
                Dictionary<string, List<string>> disc = catalog[discName];
                if (!disc.ContainsKey(artist))
                {
                    disc[artist] = new List<string>();
                }

                disc[artist].Add(songName);
            }
        }

        public void RemoveDisc(string discName)
        {
            if (catalog.ContainsKey(discName))
            {
                catalog.Remove(discName);
            }
            else
            {
                Console.WriteLine("Диск не найден");
            }
        }

        public void RemoveSong(string discName, string songName, string artist)
        {
            if (catalog.ContainsKey(discName))
            {
                Dictionary<string, List<string>> disc = catalog[discName];
                if (disc.ContainsKey(artist))
                {
                    List<string> songs = disc[artist];
                    songs.Remove(songName);
                    if (songs.Count == 0)
                    {
                        disc.Remove(artist);
                    }
                }
                else
                {
                    Console.WriteLine("Автор не найден");
                }
            }
            else
            {
                Console.WriteLine("Диск не найден");
            }
        }

        public void DisplayCatalog()
        {
            foreach (KeyValuePair<string, Dictionary<string, List<string>>> discEntry in catalog)
            {
                Console.WriteLine($"Диск: {discEntry.Key}");
                foreach (KeyValuePair<string, List<string>> artistEntry in discEntry.Value)
                {
                    Console.WriteLine($"Автор: {artistEntry.Key}");
                    foreach (string song in artistEntry.Value)
                    {
                        Console.WriteLine($"Песня: {song}");
                    }
                }

                Console.WriteLine();
            }
        }

        public void SearchArtist(string artist)
        {
            bool found = false;
            foreach (Dictionary<string, List<string>> disc in catalog.Values)
            {
                foreach (KeyValuePair<string, List<string>> artistEntry in disc)
                {
                    if (artistEntry.Key == artist)
                    {
                        foreach (string song in artistEntry.Value)
                        {
                            Console.WriteLine($"Песня: {song}");
                        }

                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"Не найдено песен исполнителя: {artist}");
            }
        }
    }
}