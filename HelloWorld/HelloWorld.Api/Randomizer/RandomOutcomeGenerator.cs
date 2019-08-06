using System;

namespace HelloWorld.Api.Randomizer
{
    public class RandomOutcomeGenerator : IRandomOutcomeGenerator
    {
        private readonly IRandomWrapper _random;

        public RandomOutcomeGenerator(IRandomWrapper random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public string GetHelloWorldString()
        {
            var card = _random.Next(54);

            if (card == 52 || card == 53)
            {
                throw new Exception("Haha! You got joker'ed!");
            }

            if (card >= 0 && card < 13) //It was a Spade
            {
                return $"Hello World. Your card number was {card} of Spades";
            } else if (card >= 13 && card < 26) // It was a Diamond
            {
                return $"Hello World. Your card number was {card % 13} of Diamonds";
            } else if (card >= 26 && card < 39) // It was a Club
            {
                return $"Hello World. Your card number was {card % 13} of Clubs";
            }

            // If it was none of the above, it was a Heart.
            return $"Hello World. Your card number was {card % 13} of Hearts";
        }
    }
}
