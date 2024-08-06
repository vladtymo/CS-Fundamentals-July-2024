namespace _11_events
{
    public class Car
    {
        public const int SPEED_LIMIT = 220;
        public const int CRASH_DETECTION_DIF = 30;

        private static Random random = new Random();
        private float speed; // 100

        // event - incapsulate delegate but [+=] [-=] operators
        public event Action<float> CrashEvent;

        public float Speed
        {
            get { return speed; }
            set
            {
                // ------------- Crash Detection Logic
                // speed - before change
                // value - after change
                if (Math.Abs(speed - value) >= CRASH_DETECTION_DIF)
                    CrashEvent?.Invoke(speed); // invoke crash event
                else
                    speed = value;
            }
        }

        public string Model { get; set; }
        public string VIN { get; set; }

        public Car(string vin, string model)
        {
            Model = model;
            VIN = vin;
            Speed = 0;
        }

        public void Gas()
        {
            float increase = random.Next(10);

            if (Speed + increase <= SPEED_LIMIT)
                Speed += increase;
            else
                Speed = SPEED_LIMIT;
        }

        public void Stop()
        {
            float decrease = random.Next(20);

            if (Speed - decrease >= 0)
                Speed -= decrease;
            else
                Speed = 0;
        }


        public override string ToString()
        {
            return $"Car: {Model} current speed: {Speed} km/h";
        }
    }

    internal class Program
    {
        static void Crash(Car car) => car.Speed = 0; // setter
        static void Main(string[] args)
        {
            Console.WriteLine("-------------- Events --------------");

            Car myCar = new("GJR787EBR", "Nissan GT-R");

            // [+=] - subscribe to the event
            myCar.CrashEvent += CrashAlert;
            myCar.CrashEvent += (speed) => CallPolice();
            myCar.CrashEvent += YourCar_CrashEvent;

            // [-=] - unsubscribe from the event
            myCar.CrashEvent -= CrashAlert;

            // event provive only [-=] [+=] operators on public
            //myCar.CrashEvent = null;
            //myCar.CrashEvent.Invoke(0);

            for (int i = 0; i < 20; i++)
            {
                myCar.Gas();

                if (i % 7 == 0) Crash(myCar); // crash event
            }
            Console.WriteLine(myCar);

            // -------------- another car
            Car yourCar = new("VXG5677KLO", "Audi A8");
            yourCar.CrashEvent += YourCar_CrashEvent;

            Crash(yourCar);
            Console.WriteLine(yourCar);
        }

        private static void YourCar_CrashEvent(float speed)
        {
            File.AppendAllText("crash_logs.txt", $"Crash Detected: {DateTime.Now} - {speed} km/h\n");
        }

        static void CrashAlert(float speed)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Crash Detected on {speed} km/h");
            Console.ResetColor();
        }
        static void CallPolice()
        {
            Console.WriteLine("Calling 911...");
        }
    }
}