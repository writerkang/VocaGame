using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WordGame.Models;

namespace WordGame.Helpers
{
    public class GameManager : IGameManager
    {
        public List<Word> MakeAllWordList()
        {
            var result = new List<Word>();
            List<string> list = File.ReadLines(@"..\\..\\..\\Toeic.txt")
                .Where(x => x.Length >= 3 && x.Length <= 10)
                .ToList();

            list.ForEach(x => result.Add(new Word { Name = x}));

            Console.WriteLine("총 개수 " + result.Count);

            return result;
        }

        public List<Position> NewMakeRandomWordBoard()
        {
            Console.WriteLine("중간!");
            var list = new List<Position>();

            int boardSize = 3;

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; i++)
                {
                    var item = new Position
                    {
                        Row = i,
                        Columnn = j
                    };
                    list.Add(item);                       
                }
            }
            Console.WriteLine(list.Count);
            return list;            
        }

        public List<Word> MakeRandomWordList(int size)
        {
            var wordList = MakeAllWordList();
            var result = new List<Word>();

            var random = new Random();

            while (result.Count < size)
            {
                var randomNum = random.Next(wordList.Count);
                result.Add(wordList[randomNum]);
                wordList.RemoveAt(randomNum);
            }

            return result;
        }

        public char[,] MakeRandomWordBoard(int boardSize, int wordsCount)
        {
            var wordList = MakeRandomWordList(wordsCount);
            Console.Write("정답: ");
            wordList.ForEach(x => Console.Write($"{x.Name} "));
            Console.WriteLine();

            var board = new char[boardSize, boardSize];
            var random = new Random();

            // X로 모두 초기화
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    board[i, j] = 'X';
                }
            }

            // 단어 길이에 맞게 공간 확보, 가로 세로
            // 단어 채우기
            foreach (var word in wordList)
            {
                var wordLength = word.Name.Length;
                var success = false;
                while (!success)
                {
                    var rNum = random.Next(4);

                    //가로
                    if (rNum == (int) Direction.LeftToRight)
                    {
                        var randomX = random.Next(boardSize);
                        var randomY = random.Next(boardSize - wordLength);
                        var hasSpace = true;

                        for (int i = 0; i < wordLength; i++)
                        {
                            if (board[randomX, randomY + i] != 'X')
                            {
                                hasSpace = false;
                                break;
                            }
                        }

                        success = false;

                        if (hasSpace)
                        {
                            for (int i = 0; i < wordLength; i++)
                            {
                                {
                                    board[randomX, randomY + i] = word.Name[i];
                                }
                            }

                            success = true;
                        }
                    }
                    //세로
                    else if (rNum == (int) Direction.UpToDown)
                    {
                        var randomX = random.Next(boardSize - wordLength);
                        var randomY = random.Next(boardSize);
                        var hasSpace = true;

                        for (int i = 0; i < wordLength; i++)
                        {
                            if (board[randomX + i, randomY] != 'X')
                            {
                                hasSpace = false;
                                break;
                            }
                        }

                        success = false;
                        if (hasSpace)
                        {
                            for (int i = 0; i < wordLength; i++)
                            {
                                board[randomX + i, randomY] = word.Name[i];
                            }

                            success = true;
                        }
                    }
                    //대각선 우하방향
                    //else if (rNum == (int) Direction.LeftToRightDown)
                    //{
                    //    var randomX = random.Next(boardSize - wordLength);
                    //    var randomY = random.Next(boardSize - wordLength);
                    //    var hasSpace = true;

                    //    for (int i = 0; i < wordLength; i++)
                    //    {
                    //        if (board[randomX + i, randomY + i] != 'X')
                    //        {
                    //            hasSpace = false;
                    //            break;
                    //        }
                    //    }

                    //    success = false;
                    //    if (hasSpace)
                    //    {
                    //        for (int i = 0; i < wordLength; i++)
                    //        {
                    //            board[randomX + i, randomY + i] = word.Name[i];
                    //        }

                    //        success = true;
                    //    }

                    //}
                    ////대각선 좌하방향
                    //else if (rNum == (int) Direction.RightToLeftDown)
                    //{
                    //    var randomX = random.Next(boardSize - wordLength);
                    //    var randomY = random.Next(boardSize - wordLength);
                    //    var hasSpace = true;

                    //    for (int i = 0; i < wordLength; i++)
                    //    {
                    //        if (board[randomX + i, boardSize - i - 1 - randomY] != 'X')
                    //        {
                    //            hasSpace = false;
                    //            break;
                    //        }
                    //    }

                    //    success = false;
                    //    if (hasSpace)
                    //    {
                    //        for (int i = 0; i < wordLength; i++)
                    //        {
                    //            board[randomX + i, boardSize - i - 1 - randomY] = word.Name[i];
                    //        }
                    //        success = true;
                    //    }
                    //}
                }
            }
            
            // 남은 공란 랜덤 초기화
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if(board[i,j] == 'X')
                    {
                        board[i, j] = (char)random.Next(97, 123);
                    }
                }
            }
            return board;
        }
    }
}
        
