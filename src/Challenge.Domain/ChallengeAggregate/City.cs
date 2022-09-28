using Challenge.Domain.ChallengeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Domain.ChallengeAggregate
{
    public sealed class City
    {
        private City(string name, string uf)
        {
            Name = name;
            Uf = uf;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }

        public static City Create(string name, string uf)
        {
            if (name == null)
                throw new ArgumentException("Invalid " + nameof(name));

            if (uf == null)
                throw new ArgumentException("Invalid " + nameof(uf));

            return new City(name, uf);
        }

        public void Update(string name, string uf)
        {
            if (name != null)
                Name = name;

            if (uf != null)
                Uf = uf;
        }
    }
}
