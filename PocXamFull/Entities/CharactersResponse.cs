using System.Collections.Generic;

namespace PocXamFull.Entities
{
    public class CharactersResponse
    {
        public class Inf
        {
            public int Count { get; set; }

            public int Pages { get; set; }

            public string Next { get; set; }

            public string Prev { get; set; }
        }

        public Inf Info { get; set; }

        public IList<Character> Results { get; set; }
    }
}
