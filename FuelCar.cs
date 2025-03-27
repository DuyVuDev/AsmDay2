namespace AsmDay2;

internal class FuelCar : Car, IFuelable
{
    public void Refuel(DateTime timeOfRefuel)
    {
        if (timeOfRefuel <= DateTime.Now)
        {
            Console.WriteLine($"Car refueled on {timeOfRefuel}");
        }
        else
        {
            throw new ArgumentException("Invalid refuel date.");
        }
    }
}
