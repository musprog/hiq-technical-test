using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Models;
using System.Text;

namespace RadioControlledCarSimulator.Utilities
{
    public class SimulationIO
    {
        private readonly ILogger<SimulationIO> _logger;

        public SimulationIO(ILogger<SimulationIO> logger)
        {
            _logger = logger;
        }

        public Task<Car> StartPostion()
        {
            SimulationLogger.LogInformation(_logger, "Welcome to the Radio Controlled Car Simulator!");

            // Set the console output encoding to UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            var room = CreateRoom();
            var car = CreateCar(room);

            if (car.CarStartPosition())
            {
                SimulationLogger.LogInformation(_logger, car.ToString());
                Console.WriteLine($"Car position is fine! {car}");
                car.Draw();
            }
            else
            {
                throw new SimulationException($"Car cannot be positioned, it's out of room range. {car}");
            }

            return Task.FromResult(car);
        }
        public Room CreateRoom()
        {
            int width = ReadPositiveIntegerInput("Enter room width: ");
            int height = ReadPositiveIntegerInput("Enter room height: ");

            SimulationLogger.LogInformation(_logger, $"Room dimensions: {width}x{height}");

            return new Room(width, height);
        }

        public Car CreateCar(Room room)
        {
            int startX = ReadPositiveIntegerInput("Enter starting X position: ");
            int startY = ReadPositiveIntegerInput("Enter starting Y position: ");

            Directions startDirection = ReadDirectionInput("Enter starting direction (N, E, S, W): ");

            return new Car(startX, startY, startDirection, room);
        }

        public static int ReadPositiveIntegerInput(string message)
        {
            Console.Write(message);
            int input;

            while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                Console.Write(message);
            }

            return input;
        }

        public Directions ReadDirectionInput(string message)
        {
            Console.Write(message);

            Directions direction;

            while (!Enum.TryParse(Console.ReadLine()?.ToUpper(), out direction) || !Enum.IsDefined(typeof(Directions), direction))
            {
                Console.WriteLine("Invalid input. Please enter a valid direction (N, E, S, W).");
                Console.Write(message);
            }

            SimulationLogger.LogInformation(_logger, $"Direction entered: {direction}");
            return direction;
        }

        public string[] ReadCommandsInput()
        {
            string message = "Enter commands (F, B, L, R) separated by spaces:";
            Console.WriteLine(message);

            string[] commands = Console.ReadLine().ToUpper().Split(' ');

            // Validate commands as movements enum
            if (!commands.All(command => Enum.TryParse(command, out Movements _)))
            {
                Console.WriteLine("Invalid input. Please enter valid commands (F, B, L, R).");
                return ReadCommandsInput();
            }

            SimulationLogger.LogInformation(_logger, $"Commands entered: {string.Join(" ", commands)}");
            return commands;
        }

        public static void CarMoving(bool result, string moving, int x, int y, Directions direction)
        {
            string toDirection = Mapper.ToDirections(direction);

            Console.WriteLine(result ? $"Car is moved {moving} to position: ({x}, {y}) to ward {toDirection}" :
                "Car cannot move forward as it would be out of room range, crashed!");
        }

        public static void CarTurning(string turn, int x, int y, Directions direction)
        {
            string toDirection = Mapper.ToDirections(direction);

            Console.WriteLine($"Car is turned {turn} to position: ({x}, {y}) to ward {toDirection}");
        }

        public void WriteCarPosition(Car car)
        {
            Console.WriteLine(car);
        }

        public void SimulationFinished(bool reslut)
        {
            Console.WriteLine(reslut ? "Simulation is finished!" : "Simulation failed!");
            if (!reslut) throw new SimulationException("Simulation failed!");
        }
    }
}
