namespace Introduction.WebAPI
{
    public class Subject
    {
        private static int _IdCounter = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeCreated { get; set; }

        public Subject (string name)
        {
            Id = _IdCounter++;
            Name = name;
            TimeCreated = DateTime.Now;
        }
    }
}
