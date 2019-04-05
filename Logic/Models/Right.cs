using Interfaces;

namespace Logic.Models
{
    public class Right : IRight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}