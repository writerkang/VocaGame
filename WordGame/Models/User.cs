using System;
using System.Collections.Generic;

namespace WordGame.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public List<Tuple<int, int>> Guess()
        {
            var result = new List<Tuple<int, int>>();

            var input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                var splitText = input.Split(" ");
                result.Add(Tuple.Create(int.Parse(splitText[0]), int.Parse(splitText[1])));
            }
            return result;
        }
    }
}