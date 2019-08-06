using System;

namespace HelloWorld.Api.Randomizer
{
    public class RandomWrapper : IRandomWrapper
    {
        public int Next(int maxNum)
        {
            var rnd = new Random();
            return(rnd.Next(maxNum));
        }
    }
}
