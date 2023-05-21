using System;
using System.Collections;

namespace Ind2_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MusicCatalog catalog = new MusicCatalog();
                int countMusic;


                Console.Write("Введите название диска: ");
                string discName = Console.ReadLine();
                catalog.AddDisc(discName);
                do
                {
                    Console.Write("Сколько песен хотите добавить?");
                    countMusic = int.Parse(Console.ReadLine());
                } while (countMusic <= 0);

                for (int i = 1; i <= countMusic; i++)
                {
                    Console.Write("Введите название песни: ");
                    string songName = Console.ReadLine();
                    Console.Write("Введите автора песни: ");
                    string artist = Console.ReadLine();
                    catalog.AddSong(discName, songName, artist);
                }

                catalog.AddDisc("Disc 2");
                catalog.AddSong("Disc 2", "Song 3", "Artist 1");
                catalog.AddSong("Disc 2", "Song 4", "Artist 3");

                catalog.DisplayCatalog();

                Console.Write("Введите автора, которого хочите найти: ");
                string searchArtist = Console.ReadLine();
                catalog.SearchArtist(searchArtist);

                Console.Write("Введите название диска для удаления: ");
                string removeDiscName = Console.ReadLine();
                catalog.RemoveDisc(removeDiscName);

                Console.Write("Введите название диска: ");
                string removediscName = Console.ReadLine();
                Console.Write("Введите название песни: ");
                string removeSongName = Console.ReadLine();
                Console.Write("Введите автора песни: ");
                string removeArtist = Console.ReadLine();
                catalog.RemoveSong(removediscName, removeSongName, removeArtist);

                catalog.DisplayCatalog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}