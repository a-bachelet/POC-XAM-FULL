using System.Collections.Generic;

namespace PocXamFull.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public string Species { get; set; }

        public CharacterLocation Location { get; set; }

        public string Image { get; set; }
    }
}
