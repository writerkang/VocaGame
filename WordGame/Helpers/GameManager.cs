using System;
using System.Collections.Generic;
using System.Text;
using WordGame.Models;

namespace WordGame.Helpers
{
    public class GameManager : IGameManager
    {
        public List<Word> MakeAllWordList()
        {
            var result = new List<Word>();

            result.Add(new Word {Name = "compute"});
            result.Add(new Word {Name = "bake"});
            result.Add(new Word {Name = "employee"});
            result.Add(new Word {Name = "store"});
            result.Add(new Word {Name = "copy"});
            result.Add(new Word {Name = "occupy"});
            result.Add(new Word {Name = "adjust"});
            result.Add(new Word {Name = "estimate"});
            result.Add(new Word {Name = "illustrate"});
            result.Add(new Word {Name = "generate"});

            return result;
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
                    else if (rNum == (int) Direction.LeftToRightDown)
                    {
                        var randomX = random.Next(boardSize - wordLength);
                        var randomY = random.Next(boardSize - wordLength);
                        var hasSpace = true;

                        for (int i = 0; i < wordLength; i++)
                        {
                            if (board[randomX + i, randomY + i] != 'X')
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
                                board[randomX + i, randomY + i] = word.Name[i];
                            }

                            success = true;
                        }

                    }
                    //대각선 좌하방향
                    else if (rNum == (int) Direction.RightToLeftDown)
                    {
                        var randomX = random.Next(boardSize - wordLength);
                        var randomY = random.Next(boardSize - wordLength);
                        var hasSpace = true;

                        for (int i = 0; i < wordLength; i++)
                        {
                            if (board[randomX + i, boardSize - i - 1 - randomY] != 'X')
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
                                board[randomX + i, boardSize - i - 1 - randomY] = word.Name[i];
                            }
                            success = true;
                        }
                    }
                }
            }
            return board;
        }
    }
}
        
