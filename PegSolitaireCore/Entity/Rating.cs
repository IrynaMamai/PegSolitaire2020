using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Entity
{
    [Serializable]

    public class Rating
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rating_player { get; set; }

    }
}
