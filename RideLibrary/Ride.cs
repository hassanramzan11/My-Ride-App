using PassengerLibrary;
using DriverLibrary;
using LocationLibrary;
using VehicleLibrary;
using AdminLibrary;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.IO;


namespace RideLibrary
{
    public class Ride
    {
        private Location start_location;
        private Location end_location;
        private int price;
        private Driver driver;
        private Passenger passenger;

        public void assignPassenger(Passenger p)
        {
            passenger = p;
        }

        public void assignDriver(Admin currList,string type)
        {
            Console.Write("Enter 'Y' if you want to Book the ride, Enter 'N' if you Want to cancel Operation: ");
            Console.ForegroundColor = ConsoleColor.Green;
            char input = Convert.ToChar(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            if (input == 'y' || input == 'Y')
            {
                Location passengerDistance = new Location();
                passengerDistance = this.start_location;
                List<Driver> availableDrivers = new List<Driver>();
                availableDrivers = currList.AvailableDrivers();
                //Driver closestDriver = null;
                float shortestDistance = float.MaxValue;

                foreach (Driver driverIterator in availableDrivers)
                {
                    if (driverIterator.IsAvailable() && driverIterator.Vehicle.VehicleType==type)
                    {
                        Location driverDistance = driverIterator.CurrentLocation();
                        float distance = this.CalculateDistance(driverDistance, passengerDistance);
                        if (distance < shortestDistance)
                        {
                            shortestDistance = distance;
                            driver = driverIterator;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Your Driver {driver.Name} is own the way ");
                        Console.WriteLine("HAPPY TRAVEL....!");
                        this.giveRating();
                        this.StoreRideData(@"E:\\6 Semester\\Web Engineering\\HomeWork\\BCSF20M049_H02\\My Ride App\\Ride.txt");
                        return;
                    }                    
                }    
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("No driver available right now");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (input == 'n' || input == 'N')
            {
                Console.WriteLine("Operation Cancelled");                
            }
            else
            {
                Console.WriteLine("Invalid input. Availability status remains unchanged.");
            }           
        }


        public void getLocation(Location Start,Location End)
        {
            start_location = Start;
            end_location = End;
        }

        public int CalculatePrice(string VehicleType)
        {
            const double fuelPrice = 250;      //Assume the Fuel price is 200 pkr per Liter 
            double distance = CalculateDistance(start_location,end_location);
            double commission = 0;
            double fuelAverage = 0;

            switch (VehicleType.ToLower())
            {
                case "bike":
                    fuelAverage = 50;
                    commission = 0.05;
                    break;
                case "rickshaw":
                    fuelAverage = 35;
                    commission = 0.1;
                    break;
                case "car":
                    fuelAverage = 15;
                    commission = 0.2;
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

            double initialPrice = (int)((distance * fuelPrice / fuelAverage));
            commission = (initialPrice) * commission;
            price = (int)(initialPrice + commission);

            Console.WriteLine($"Price for this ride is :{price}");
            return price;
        }

        public void giveRating()
        {
            int rating;
            Console.Write("Please enter a rating from 1 to 5: ");
            while (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.Write("Invalid input. Please enter a rating from 1 to 5: ");
            }

            Console.WriteLine("\nThanks For the Rating ");
            driver.setRating(rating);
            
        }
        
        private float CalculateDistance(Location DistanceStart,Location DistanceEnd)
        {
            float dx = DistanceStart.lat - DistanceEnd.lat;
            float dy= DistanceStart.lng - DistanceEnd.lng;
            return (float)(Math.Sqrt(dx * dx + dy * dy));
        }

        public void StoreRideData(string fileName)
        {
            // Combine all the necessary data into a string
            string data = $"Passenger Name : {passenger.Name}, Location: ({start_location.lat},{start_location.lng})({end_location.lat},{end_location.lng}), Price : {price}, Driver Name: {driver.Name}";
            
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(data);
            }
        }

    }
}