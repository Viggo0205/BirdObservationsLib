using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BirdObservationsLib
{
    public class BirdObservationsRepository
    {
        public int _nextId = 1;
        public List<BirdObservation> _birdObservations = new List<BirdObservation>();
        public BirdObservationsRepository() 
        {
            BirdObservation bird1 = new BirdObservation()
            {
                Species = "Solsort",
                HowMany = 2
            };

            BirdObservation bird2 = new BirdObservation()
            {
                Species = "Rødkælk",
                HowMany = 7
            };

            BirdObservation bird3 = new BirdObservation()
            {
                Species = "Måge",
                HowMany = 22
            };

            BirdObservation bird4 = new BirdObservation()
            {
                Species = "Hætte Måge",
                HowMany = 27
            };

            BirdObservation bird5 = new BirdObservation()
            {
                Species = "Fasan",
                HowMany = 3
            };

            Add(bird1);
            Add(bird2);
            Add(bird3);
            Add(bird4);
            Add(bird5);
        }

        public IEnumerable<BirdObservation> GetAll(int? minHowMany=null, string? species = null)
        {
            IEnumerable <BirdObservation> result = new List<BirdObservation>(_birdObservations);
            if (minHowMany != null)
            {
                result = result.Where(b => b.HowMany >= minHowMany).ToList();
            }
            else if (species != null)
            {
                result = result.Where(b => b.Species == species).ToList();
            }
            return result;

        }


        public BirdObservation? GetById(int id)
        {
            return _birdObservations.Find(birdobservation =>  birdobservation.Id == id);   
        }

        public BirdObservation Add(BirdObservation birdObservation) 
        {
            birdObservation.Validate();
            birdObservation.Id = _nextId++;
            _birdObservations.Add(birdObservation);
            return birdObservation;
        }

        public BirdObservation Delete(int id) 
        { 
            BirdObservation birdObservation = GetById(id);
            if (birdObservation == null)
            {
                return null;
            }

            _birdObservations.Remove(birdObservation);
            return birdObservation;

        }
    }
}
