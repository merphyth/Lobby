namespace WebApplication1
{
    public class Car
    {
        public int Id { get; set; }
        
        public float MaxSpeed { get; set; }
        public string Model { get; set; }

        public string Description { get; set; }

        public Car() 
        {
            Id = 0;
            MaxSpeed = 0.0F;
            Model = string.Empty;
            Description = string.Empty;
        }
    }
}
