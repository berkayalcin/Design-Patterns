using System;

namespace Protection_Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            Console.WriteLine("Car is being driven!");
        }
    }

    public class Driver
    {
        public int Age { get; set; }
    }

    public class CarProxy : ICar
    {
        private Driver _driver;
        private Car _car = new Car();

        public CarProxy(Driver driver)
        {
            _driver = driver;
        }

        public void Drive()
        {
            if (_driver.Age >= 16)
                _car.Drive();
            else
                Console.WriteLine("Too young!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ICar car = new CarProxy(new Driver()
            {
                Age = 12
            });
            car.Drive();

            ICar car2 = new CarProxy(new Driver()
            {
                Age = 16
            });
            car2.Drive();
        }
    }
}