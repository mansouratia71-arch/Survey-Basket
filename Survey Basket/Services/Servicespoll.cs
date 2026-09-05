namespace Survey_Basket.Services
{
    public class Servicespoll : Iservicespoll
    {
        private readonly List<Poll> _polls = new List<Poll>
        {   new Poll { Id=1,
            title="ggg",
            description="asdfghjkl"
        }
        };

        public void Add(Poll model)
        {
            _polls.Add(model);
        }

        public IEnumerable<Poll> GetAll()
        {
            return _polls.AsReadOnly();
        }

        public Poll? GetById(int id)
        {
            return _polls.SingleOrDefault(pol => pol.Id == id);
        }

        public bool remove(int id)
        {
            Poll p = GetById(id);
            if (p is null)
            {
                return false;
            }
            return _polls.Remove(p);
        }

        public bool Update(int id, Poll model)
        {
            if (model is null)
                return false;
           
            Poll p = GetById(id);
            if (p is null)
            {
                return false;
            }
            p.Id= id;
            p.title = model.title;
            p.description = model.description;

            
            return true;
        }

    

    }
}

