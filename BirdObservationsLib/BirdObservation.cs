namespace BirdObservationsLib
{
    public class BirdObservation
    {

        public int Id { get; set; }
        public string? Species { get; set; }
        public int HowMany { get; set; }

        public void ValidateSpecies()
        {
            if (Species == null) 
            { 
                throw new ArgumentNullException("Species is null");
            }

            if(Species.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Species skal være mindst 2 tegn langt");
            }

        }


        public void ValidateHowMany()
        {
            if (HowMany < 0)
            {
                throw new ArgumentOutOfRangeException("How many skal være 0 eller over");
            }
        }

        public void Validate()
        {
            ValidateSpecies();
            ValidateHowMany();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Species: {Species}, How many: {HowMany}";
        }
    }
}
