using System.Globalization;

namespace VehicleLibrary
{
    public class Vehicle
    {
        private string type;
        private string model;
        private string license_plate;
        private Vehicle vehicle;

        //Contructor
        public Vehicle()
        {
            type= "";
            model = "";
            license_plate = "";
        }

        public Vehicle(Vehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public Vehicle(string Type, string Model, string License_No)
        {
            this.type = Type;
            this.model = Model;
            this.license_plate = License_No;
        }
        public string VehicleType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string VehicleModel
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public string VehicleLicense
        {
            get
            {
                return license_plate;
            }
            set
            {
                license_plate = value;
            }
        }



    }
}