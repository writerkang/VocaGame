using System.Collections.Generic;
using WordGame.Models;

namespace WordGame.Helpers
{
    public interface IGameManager
    {
        List<Word> MakeAllWordList();
        List<Word> MakeRandomWordList(int size);
        
        char[,] MakeRandomWordBoard(int boardSize, int wordsCount);
    }
}