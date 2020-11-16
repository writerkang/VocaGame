using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace VocaGameTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var vocaList = new List<string>();
            vocaList.Add("hello");
            vocaList.Add("bake");
            vocaList.Add("employee");
            vocaList.Add("store");
            vocaList.Add("copy");

            var maxX = 5;
            var maxY = 5;
            var intInit = 1;

            var gameBoard = new string[maxX,maxY];

            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    gameBoard[i,j] = intInit++.ToString();
                }
            }

            var pickNumber = 3;
            var random = new Random();
            var pickedVoca = new List<string>(); 

            for (int i = 0; i < pickNumber; i++)
            {
                var ranNumber = random.Next(0, vocaList.Count);
                pickedVoca.Add(vocaList[ranNumber]);
                vocaList.RemoveAt(ranNumber);
            }
            var vocasLength = 0;
            var vocaString = string.Empty;
            foreach (var voca in pickedVoca)
            {
                Console.WriteLine(voca);
                vocasLength += voca.Length;
                vocaString += voca;
            }
            Console.WriteLine(vocasLength);
            Console.WriteLine(vocaString);

            foreach (var ch in vocaString)
            {
                var isFound = false;
                while (!isFound)
                {
                    var position = random.Next(gameBoard.Length) + 1;
                    for (int i = 0; i < maxX; i++)
                    {
                        for (int j = 0; j < maxY; j++)
                        {
                            if (gameBoard[i, j].Equals(position.ToString()))
                            {
                                gameBoard[i, j] = ch.ToString();
                                isFound = true;
                                break;
                            }
                        }
                    }
                }

            }
            
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    Console.Write((gameBoard[i,j] + " ").PadLeft(3));
                }
                Console.WriteLine();
            }
            
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            var vocaList = new List<string>();
            vocaList.Add("hello");
            vocaList.Add("bake");
            vocaList.Add("employee");
            vocaList.Add("store");
            vocaList.Add("copy");
            vocaList.Add("occupy");
            vocaList.Add("adjust");
            vocaList.Add("estimate");
            vocaList.Add("illustrate");

            var pickNumber = 7;
            var random = new Random();
            var pickedVoca = new List<string>();

            while (pickedVoca.Count < pickNumber)
            {
                var ranNumber = random.Next(0, vocaList.Count);
                var pickVoca = vocaList[ranNumber];
                if (!pickedVoca.Contains(pickVoca))
                {
                    pickedVoca.Add(pickVoca);
                }
            }

            foreach (var voca in pickedVoca)
            {
                Console.Write(voca + " ");
            }
            Console.WriteLine();

            var maxX = 10;
            var maxY = 10;
            var yList = new List<int>();

            while (yList.Count < pickedVoca.Count)
            {
                int ranNum = random.Next(maxY);
                if (!yList.Contains(ranNum))
                {
                    yList.Add(ranNum);
                }
            }
            var initValue = 'a';
            var gameBoard = new char[maxX,maxY];

            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    var charNum = random.Next(97, 123);
                    gameBoard[i,j] = (char) charNum;
                }
            }

            for (int i = 0; i < yList.Count; i++)
            {
                var r = random.Next(0, maxX - pickedVoca[i].Length);
                for (int j = 0; j < pickedVoca[i].Length; j++)
                {
                    gameBoard[yList[i], r + j] = pickedVoca[i][j];
                }
                
            }

            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    Console.Write(gameBoard[i,j]);
                }
                Console.WriteLine();
            }
            
            
            Assert.Pass();
        }

        [Test]
        public void Test3()
        {
            var random = new Random();
            
            // 단어 리스트 불러오기
            var vocaList = new List<string>();
            vocaList.Add("hello");
            vocaList.Add("bake");
            vocaList.Add("employee");
            vocaList.Add("store");
            vocaList.Add("copy");
            vocaList.Add("occupy");
            vocaList.Add("adjust");
            vocaList.Add("estimate");
            vocaList.Add("illustrate");
            
            // 단어 랜덤 선택
            var pickNumber = 7;
            var pickedVoca = new List<string>();
            while (pickedVoca.Count < pickNumber)
            {
                var ranNumber = random.Next(0, vocaList.Count);
                var pickVoca = vocaList[ranNumber];
                if (!pickedVoca.Contains(pickVoca))
                {
                    pickedVoca.Add(pickVoca);
                }
            }

            foreach (var voca in pickedVoca)
            {
                Console.Write(voca + " ");
            }
            Console.WriteLine();
            
            // 10 * 10 게임판 설정
            var maxX = 10;
            var maxY = 10;
            var board = new char[maxX,maxY];

            // X로 모두 초기화
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    board[i, j] = 'X';
                }
            }
            
            // 단어 길이에 맞게 공간 확보, 가로 세로
            // 단어 채우기
            foreach (var voca in pickedVoca)
            {
                var vocaLength = voca.Length;
                var success = false;
                while (!success)
                {
                    var rNum = random.Next(2);

                    //가로
                    if (rNum == 0)
                    {
                        var randomX = random.Next(maxX);
                        var randomY = random.Next(maxY - vocaLength);
                        var hasSpace = true;
                    
                        for (int i = 0; i < vocaLength; i++)
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
                            for (int i = 0; i < vocaLength; i++)
                            {
                                {
                                    board[randomX, randomY + i] = voca[i];
                                }
                            }
                            success = true;
                        }
                    }
                    //세로
                    else
                    {
                        var randomX = random.Next(maxX - vocaLength);
                        var randomY = random.Next(maxY);
                        var hasSpace = true;

                        for (int i = 0; i < vocaLength; i++)
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
                            for (int i = 0; i < vocaLength; i++)
                            {
                                board[randomX + i, randomY] = voca[i];
                            }
                            success = true;
                        }
                    }
                }
            }

            // 나머지 공간 랜덤값으로 채우기
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    var charNum = random.Next(97, 123);
                    if (board[i, j].Equals('X'))
                    {
                        board[i,j] = (char) charNum;
                    }
                }
            }

            //출력
            for (int i = 0; i < maxX; i++)
            {
                for (int j = 0; j < maxY; j++)
                {
                    Console.Write(board[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        
    }
}