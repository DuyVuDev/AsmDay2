namespace AsmDay2;


internal class ElectricCar : Car, IChargable
{
    public void Charge(DateTime timeOfCharge)
    {
        if (timeOfCharge <= DateTime.Now)
        {
            Console.WriteLine($"Car charged on {timeOfCharge.ToString("yyyy-MM-dd HH:mm")}");
        }
        else
        {
            throw new ArgumentException("Invalid charge date.");
        }
    }
}