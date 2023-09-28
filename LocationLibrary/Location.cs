namespace LocationLibrary
{    public class Location
    {
        // Attributes
        private float latitude;
        private float longitude;

        // Default constructor
        public Location()
        {
            // Set default values
            this.latitude = 0;
            this.longitude = 0;
        }
        public Location(Location other)
        {
            // Set latitude and longitude values from the other Location object
            this.latitude = other.latitude;
            this.longitude = other.longitude;
        }

        // Parametrized constructor
        public Location(float latitude, float longitude)
        {
            // Set latitude and longitude values
            this.latitude = latitude;
            this.longitude = longitude;
        }

        // Getter and Setter methods
        public float lat
        {
            get { return this.latitude; }
            set { this.latitude = value; }
        }

        public float lng
        {
            get { return this.longitude; }
            set { this.longitude = value; }
        }

        // Function to set location
        public void setLocation(float latitude, float longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}