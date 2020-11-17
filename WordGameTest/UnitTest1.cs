using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using WordGame.Helpers;
using WordGame.Models;

namespace WordGameTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get_Random_WordList()
        {
            var manager = new GameManager();
            
            var list = manager.MakeRandomWordList(7);

            list.ForEach(x => Console.WriteLine(x.Name));
            Assert.AreEqual(7, list.Count);
        }

        [Test]
        public void Get_Random_WordBoard()
        {
            var manager = new GameManager();
            var boardSize = 10;
            var wordCount = 7;
            
            var board = manager.MakeRandomWordBoard(boardSize, wordCount);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i,j] + " ");
                }
                Console.WriteLine();
            }

            Assert.NotNull(board[0,0]);
        }

        [Test]
        public void UserInputWork()
        {
            var manager = new GameManager();
            var user = new User();
            
            var boardSize = 10;
            var wordCount = 7;
            var board = new char[10,10];
            board[0, 0] = 'b';
            board[0, 1] = 'a';
            board[0, 2] = 'k';
            board[0, 3] = 'e';

            var userInput = new List<Tuple<int, int>>();
            userInput.Add(Tuple.Create(0, 0));
            userInput.Add(Tuple.Create(0, 1));
            userInput.Add(Tuple.Create(0, 2));
            userInput.Add(Tuple.Create(0, 3));

            var wordList = manager.MakeAllWordList();

            var sb = new StringBuilder();
            foreach (var tuple in userInput)
            {
                sb.Append(board[tuple.Item1,tuple.Item2]);
            }

            Console.WriteLine(sb);

            bool correct = wordList.Exists(x => x.Name == sb.ToString());
            
            Assert.IsTrue(correct);
            
        }
        
    }
}