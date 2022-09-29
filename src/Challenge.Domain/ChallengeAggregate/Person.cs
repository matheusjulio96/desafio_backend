namespace Challenge.Domain.ChallengeAggregate
{
    public sealed class Person
    {
        private Person(string name, int age, string document, int cityId)
        {
            Name = name;
            Age = age;
            Document = document;
            CityId = cityId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Document { get; set; }
        public int CityId { get; set; }

        public static Person Create(string name, int age, string document, int cityId)
        {
            if (name == null) 
                throw new ArgumentException("Invalid " + nameof(name));

            if (age == 0)
                throw new ArgumentException("Invalid " + nameof(age));

            if (document == null)
                throw new ArgumentException("Invalid " + nameof(document));
            
            if (document.Length != 11)
                throw new ArgumentException("Invalid " + nameof(document)+". Must be 11 digits");

            if (cityId == 0)
                throw new ArgumentException("Invalid " + nameof(cityId));

            return new Person(name, age, document, cityId);
        }

        public void Update(string name, int age, string document, int cityId)
        {
            if (name != null) 
                Name = name;

            if (age > 50)
                throw new InvalidAgeExceptions();

            if (age != 0)
                Age = age;

            if (document?.Length != 11)
                throw new ArgumentException("Invalid " + nameof(document) + ". Must be 11 digits");

            if (document != null)
                Document = document;

            if (cityId != 0)
                CityId = cityId;
        }
    }
}
