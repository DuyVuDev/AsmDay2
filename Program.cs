namespace AsmDay2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string make = Validator.ValidateStringInput("Enter Make: ", "Make is required");
            string model = Validator.ValidateStringInput("Enter Model: ", "Model is required");
            int year = Validator.ValidateYearInput("Enter Year: ", "Invalid year! Please enter a valid year between 1886 and the current year");

            DateTime lastMaintenanceDate;

            while (true)
            {
                lastMaintenanceDate = Validator.ValidateDateInput("Enter Last Maintenance Date (yyyy-MM-dd): ");
                if (lastMaintenanceDate.Year >= year)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Last Maintenance Date must be in the same year or later than the car's year.");
                }
            }

            string carType = Validator.ValidateCarTypeInput("Is this a Fuel car or an Electric car? (F/E): ");

            Car car;

            if (carType.Equals("F", StringComparison.OrdinalIgnoreCase))
            {
                car = new FuelCar
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    LastMaintenanceDate = lastMaintenanceDate
                };

            }
            else if (carType.Equals("E", StringComparison.OrdinalIgnoreCase))
            {
                car = new ElectricCar
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    LastMaintenanceDate = lastMaintenanceDate
                };

            }
            else
            {
                throw new ArgumentException("Invalid car type.");
            }

            car.DisplayDetails();
            car.ScheduleMaintenance();

            Console.Write("Do you want to refuel/charge? (Y/N)");
            char response = (char)Console.Read();
            if (response == 'Y')
            {
                if (carType.Equals("F", StringComparison.OrdinalIgnoreCase))
                {
                    DateTime refuelDate;

                    while (true)
                    {
                        refuelDate = Validator.ValidateDateInput("Enter Refuel Date (yyyy-MM-dd HH:mm): ");
                        if (refuelDate.Year > year)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Refuel Date must be later than the car's year.");
                        }
                    }
                    ((FuelCar)car).Refuel(refuelDate);
                }
                else
                {
                    DateTime chargeDate;

                    while (true)
                    {
                        chargeDate = Validator.ValidateDateInput("Enter Charge Date (yyyy-MM-dd HH:mm): ");
                        if (chargeDate.Year > year)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Charge Date must be later than the car's year.");
                        }
                    }
                    ((ElectricCar)car).Charge(chargeDate);
                }
            }
            else if (response != 'N')
            {
                Console.WriteLine("Invalid response. Please enter Y or N.");
            }
        }
    }
}
