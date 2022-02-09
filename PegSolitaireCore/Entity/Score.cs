using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Entity
{
    [Serializable]
    public class Score
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}
