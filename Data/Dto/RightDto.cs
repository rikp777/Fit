using Interfaces;

namespace Data.dto
{
    public class RightDto : IRight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}