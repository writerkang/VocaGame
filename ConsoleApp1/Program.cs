using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WordGame.Helpers;
using WordGame.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            NewStartGame();
            //StartGame();
        }

        public static void NewStartGame()
        {
            Console.WriteLine("시작!");
            GameManager manager = new GameManager();
            var randomList = manager.MakeRandomWordList(7);

            var list = new List<Position>();
            int boardSize = 10;

            // 좌표 초기화
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    var item = new Position
                    {
                        Row = i,
                        Columnn = j
                    };
                    list.Add(item);
                }
            }
            Random random = new Random();

            foreach (var word in randomList)
            {
                int wordLength = word.Name.Length;

                //한 지점을 일단 찍자
                int row = random.Next(boardSize);
                int column = random.Next(boardSize);

                //가로만 먼저 생각하자
                var positions = list.FindAll(x => x.Row == row && x.Columnn >= column && (boardSize - column) >= wordLength);

                if (positions.Count > 0)
                {
                    for (int i = 0; i < wordLength; i++)
                    {
                        positions[i].Selected = true;
                        positions[i].Character = word.Name[i].ToString();
                    }
                }
                else
                {   // 세로도 생각해보자
                    positions = list.FindAll(x => !x.Selected && x.Row >= row && x.Columnn == column && (boardSize - row) >= wordLength);
                    if (positions.Count > 0)
                    {
                        for (int i = 0; i < wordLength; i++)
                        {
                            positions[i].Selected = true;
                            positions[i].Character = word.Name[i].ToString();
                        }
                    }
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i].Character);
                if ((i + 1) % boardSize == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void StartGame()
        {
            GameManager manager = new GameManager();
            User user = new User();

            var wordCount = 7;
            var boardSize = 10;

            var wordList = manager.MakeAllWordList();
            var board = manager.MakeRandomWordBoard(boardSize, wordCount);

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            var count = 0;

            while (count < 10)
            {
                Console.WriteLine($"남은 횟수: {10 - count}, 남은 단어: {wordCount}");
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;
                var splitText = input?.Split(" ");
                var start = splitText[0];
                var startX = (int)Char.GetNumericValue(start[0]);
                var startY = (int)Char.GetNumericValue(start[1]);

                var end = splitText[1];
                var endX = (int)Char.GetNumericValue(end[0]);
                var endY = (int)Char.GetNumericValue(end[1]);

                var direction = int.Parse(splitText[2]);               
                var sb = new StringBuilder();
                bool correct = false;

                switch (direction)
                {
                    case (int)Direction.LeftToRight:
                        for (int i = startY; i <= endY; i++)
                        {
                            sb.Append(board[startX, i]);
                        }
                        correct = wordList.Exists(x => x.Name == sb.ToString());
                        if (correct)
                        {
                            for (int i = startY; i <= endY; i++)
                            {
                                board[startX, i] = (char)32;                                
                            }
                            wordCount--;
                        }
                        break;

                    case (int)Direction.UpToDown:
                        for (int i = startX; i <= endX; i++)
                        {
                            sb.Append(board[i, startY]);
                        }
                        correct = wordList.Exists(x => x.Name == sb.ToString());
                        if (correct)
                        {
                            for (int i = startX; i <= endX; i++)
                            {
                                board[i, startY] = (char)32;                                
                            }
                            wordCount--;
                        }
                        break;

                    case (int)Direction.LeftToRightDown:
                        for (int i = 0; i <= endX - startX; i++)
                        {
                            sb.Append(board[startX + i, startY + i]);
                        }
                        correct = wordList.Exists(x => x.Name == sb.ToString());
                        if (correct)
                        {
                            for (int i = 0; i <= endX - startX; i++)
                            {
                                board[startX + i, startY + i] = (char)32;                                
                            }
                            wordCount--;
                        }
                        break;

                    case (int)Direction.RightToLeftDown:
                        for (int i = 0; i <= endX - startX; i++)
                        {
                            sb.Append(board[startX + i, startY - i]);
                        }
                        correct = wordList.Exists(x => x.Name == sb.ToString());
                        if (correct)
                        {
                            for (int i = 0; i <= endX - startX; i++)
                            {
                                board[startX + i, startY - i] = (char)32;                                
                            }
                            wordCount--;
                        }
                        break;
                }                  
                
                Console.WriteLine();

                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        Console.Write(board[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                count++;
            }
        }
    }
}