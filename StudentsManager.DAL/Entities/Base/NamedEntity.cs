namespace DAL.Entities
{
    public abstract class NamedEntity : Entity
    {
        public string Name { get; set; }

        public NamedEntity() : base()
        {
            Name = "";
        }
    }
}