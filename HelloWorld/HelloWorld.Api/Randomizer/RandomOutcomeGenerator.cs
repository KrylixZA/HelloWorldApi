using System;

namespace HelloWorld.Api.Randomizer
{
    public class RandomOutcomeGenerator : IRandomOutcomeGenerator
    {
        public string GetHelloWorldString()
        {
            var rnd = new Random();
            int card = rnd.Next(54); //Generate a random playing card number.

            if (card == 52 || card == 53)
            {
                throw new Exception("Haha! You got jokered!");
            }

            if (card >= 0 && card < 13) //It was a Spade
            {
                return $"Hello World. Your card number was {card % 52} of Spades";
            } else if (card >= 13 && card < 26) // It was a Diamond
            {
                return $"Hello World. Your card number was {card % 52} of Diamonds";
            } else if (card >= 26 && card < 39) // It was a Club
            {
                return $"Hello World. Your card number was {card % 52} of Clubs";
            }

            // If it was none of the above, it was a Heart.
            return $"Hello World. Your card number was {card % 52} of Hearts";
        }
    }
}
