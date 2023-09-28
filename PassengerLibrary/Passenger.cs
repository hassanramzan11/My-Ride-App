namespace PassengerLibrary
{
    public class Passenger
    {
        private string name;
        private string phone_number;    

        public Passenger(string Name,string Phone_no)
        {
            name = Name;
            phone_number = Phone_no;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set 
            { 
                name = value;
            }
        }

    }

}