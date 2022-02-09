using System;
using System.Collections.Generic;
using System.Text;

namespace PegSolitaire.Entity
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }
    }
}
