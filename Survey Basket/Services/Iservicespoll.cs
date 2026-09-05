namespace Survey_Basket.Services
{
    public interface Iservicespoll
    {
        public IEnumerable<Poll> GetAll();

        public Poll? GetById(int id);

        public void Add(Poll model);

        public bool remove(int id);


        public bool Update(int  id, Poll model);



    }
}
