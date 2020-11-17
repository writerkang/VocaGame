using System;
using System.Text;
using WordGame.Helpers;
using WordGame.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager manager = new GameManager();
            User user = new User();

            var wordList = manager.MakeAllWordList();
            var board = manager.MakeRandomWordBoard(10, 7);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i,j] + "");
                }
                Console.WriteLine();
            }

            var userInput = user.Guess();
            var sb = new StringBuilder();
            foreach (var tuple in userInput)
            {
                sb.Append(board[tuple.Item1,tuple.Item2]);
            }

            Console.WriteLine(sb);
            bool correct = wordList.Exists(x => x.Name == sb.ToString());
            Console.WriteLine(correct);
        }
    }
}