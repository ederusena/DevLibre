namespace DevLibre.Entities
{
    public class Skills : BaseEntity
    {
        public Skills(string description) : base()
        {
            Description = description;
        }   
        public string Description { get; private set; }
    }
}
