namespace AsmDay2
{
    internal abstract class Car
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        private int year;
        public int Year
        {
            get => year;
            set { year = value; }
        }

        private DateTime lastMaintenanceDate;
        public DateTime LastMaintenanceDate
        {
            get => lastMaintenanceDate;
            set
            { lastMaintenanceDate = value; }
        }

        public void ScheduleMaintenance()
        {
            DateTime NextMaintenanceDate = LastMaintenanceDate.AddMonths(6);
            Console.WriteLine($"Next Maintenance Date: {NextMaintenanceDate}");
            if (DateTime.Now > NextMaintenanceDate)
            {
                Console.WriteLine("Maintenance is due! Please maintain today");
            }
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Car: {Make} {Model} ({Year})\nLast Maintenance Date: {LastMaintenanceDate}");
        }
    }
}
