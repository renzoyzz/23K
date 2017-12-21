namespace _23Knots.GameObjects.Dynamic.Properties
{
    public class Stats
    {
        public float Acceleration { get; set; }
        public float MaxSpeed { get; set; }

        public Stats(float acceleration = 0f, float maxSpeed = 0f)
        {
            Acceleration = acceleration;
            MaxSpeed = maxSpeed;
        }

    }
}
