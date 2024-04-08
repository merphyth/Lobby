namespace RestaurantClass
{
    public class Restaurant
    {
        public string Name { get; set; }
        public float Rating { get; set; }
        public string Owner { get; set; }

        public Restaurant()
        {
            this.Name = null;
            this.Owner = null;
            this.Rating = 0.0F;
        }
    }
}
