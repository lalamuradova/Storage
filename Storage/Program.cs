using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AbstactMethods
{

    abstract class Storage
    {
        public string Model { get; set; }
        public string MediaName { get; set; }
        public int Capacity { get; set; }
        public int Speed { get; set; }

        public abstract void PrintDevice();

        public abstract int Copy(int size);
        public abstract int FreeMemory();

    }

    class Flash : Storage
    {        
        public int CurrentSize { get; set; } = 0;
        public override int Copy(int size)
        {
            if (base.Capacity - CurrentSize >= size) 
            {
                CurrentSize += size;
                return CurrentSize;
            }
            throw new Exception("Capacity is full . . .");

        }

        public override int FreeMemory()
        {
            var memory = base.Capacity;
            memory -= CurrentSize;
            return memory;
        }

        public override void PrintDevice()
        {
            Console.WriteLine($"\nModel: {Model} \nMedia name: {MediaName} \nCapacity: {Capacity} \nSpeed: {Speed}");
        }
    }

    class HDD : Storage
    {        
        public int CurrentSize { get; set; } = 0;
        public override int Copy(int size)
        {
            if (base.Capacity - CurrentSize >= size)
            {
                CurrentSize += size;
                return CurrentSize;
            }
            throw new Exception("Capacity is full . . .");

        }

        public override int FreeMemory()
        {
            var memory = base.Capacity;
            memory -= CurrentSize;
            return memory;
        }

        public override void PrintDevice()
        {
            Console.WriteLine($"\nModel: {Model} \nMedia name: {MediaName} \nCapacity: {Capacity} \nSpeed: {Speed}");
        }
    }

    class SSD : Storage
    {
        public int CurrentSize { get; set; } = 0;
        public override int Copy(int size)
        {
            if (base.Capacity - CurrentSize >= size)
            {
                CurrentSize += size;
                return CurrentSize;
            }
            throw new Exception("Capacity is full . . .");

        }
        public override int FreeMemory()
        {
            var memory = base.Capacity;
            memory -= CurrentSize;
            return memory;
        }
        public override void PrintDevice()
        {
            Console.WriteLine($"\nModel: {Model} \nMedia name: {MediaName} \nCapacity: {Capacity} \nSpeed: {Speed}");
        }
    }
    class Run
    {
        public void Display1()
        {
            Storage[] storages =
            {
                new Flash
                {
                   Model="SanDisk Ultra USB 3.0 Flash Drive",
                   MediaName="Flash",
                   Capacity=128,
                   Speed=100
                },
                new HDD
                {
                    Model="My Book External USB 3.0 Hard Drive",
                    MediaName="HDD",
                    Capacity=1024,
                    Speed=280
                },
                new SSD
                {
                    Model="Samsung - 870 EVO SATA 2.5",
                    MediaName="SSD",
                    Capacity=512,
                    Speed=560
                }
            };
                        
            Display2(ref storages);
        }
        public void Display2(ref Storage [] st)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Flash [1]");
            Console.WriteLine("HDD [2]");
            Console.WriteLine("SSD [3]");
            Console.WriteLine("Choose storage: ");

            string choise = Console.ReadLine();
            Console.Clear();
            if (choise == "1")
            {
                DisplayFlash(ref st);
            }
            else if (choise == "2")  {
                DisplayHDD(ref st);
            }
            else if (choise == "3")
            {
                DisplaySSD(ref st);
            }
            else
            {
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number you entered is incorrect");
                Console.ForegroundColor = ConsoleColor.White;
                Display2(ref st);
            }
        }

        public string Choise()
        {
            Console.WriteLine($"\n\nCopy [1]");
            Console.WriteLine($"Show free memory [2]");
            Console.WriteLine($"Back [0]");
            Console.WriteLine("Enter choise : ");

            string ch = Console.ReadLine();

            return ch;
        }
        public void DisplayFlash(ref Storage[] s)
        {            
            s[0].PrintDevice();
            var choise = Choise();
            Console.Clear();

            if (choise == "1")
            {
                Copy(ref s, 0);
            }
            else if (choise == "2")
            {
                var memory = s[0].FreeMemory();
                Console.WriteLine($"Free memory: {memory}");

                Console.WriteLine($"Back [0] : ");               
                string ch = Console.ReadLine();
                Console.Clear();
                if (ch == "0") { DisplayFlash(ref s); }
            }
            else if (choise == "0")
            {
                Display2(ref s);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number you entered is incorrect");
                Console.ForegroundColor = ConsoleColor.White;
                DisplayFlash(ref s);

            }
        }
        public void DisplayHDD(ref Storage[] s)
        {
            s[1].PrintDevice();
            var choise = Choise();
            Console.Clear();

            if (choise == "1")
            {
                Copy(ref s, 1);
            }
            else if (choise == "2")
            {
                var memory = s[1].FreeMemory();
                Console.WriteLine($"Free memory: {memory}");

                Console.WriteLine($"Back [0] : ");
                string ch = Console.ReadLine();
                Console.Clear();
                if (ch == "0") { DisplayHDD(ref s); }
            }
            else if (choise == "0")
            {
                Display2(ref s);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number you entered is incorrect");
                Console.ForegroundColor = ConsoleColor.White;
                DisplayHDD(ref s);

            }
        }
        public void DisplaySSD(ref Storage[] s)
        {
            s[2].PrintDevice();
            var choise = Choise();
            Console.Clear();

            if (choise == "1")
            {
                Copy(ref s, 2);
            }
            else if (choise == "2")
            {
                var memory = s[2].FreeMemory();
                Console.WriteLine($"Free memory: {memory}");

                Console.WriteLine($"Back [0] : ");
                string ch = Console.ReadLine();
                Console.Clear();
                if (ch == "0") { DisplaySSD(ref s); }
            }
            else if (choise == "0")
            {
                Display2(ref s);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The number you entered is incorrect");
                Console.ForegroundColor = ConsoleColor.White;
                DisplaySSD(ref s);

            }
        }
        public void Copy(ref Storage[] storage,int index)
        {
            Console.WriteLine("How many megabytes of data do you want to copy : ");
            string choise = Console.ReadLine();
            int size = int.Parse(choise);
            Console.Clear();
            try
            {
                var ss = storage[index];
                var currentSize = ss.Copy(size);
                PrintStorageDesign(currentSize, size, ss.Capacity, ss.Speed);
                Console.WriteLine($"\n\nCurrent size: {currentSize}");
                Console.ForegroundColor = ConsoleColor.White;              
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine($"Back [0]");
                Console.WriteLine("Enter choise : ");

                string ch = Console.ReadLine();
                if (ch == "0")
                {
                    Display2(ref storage);
                }
            }
        }

        public int CurrentSizeDisp(int currentSize)
        {
            if(currentSize > 0 && currentSize <= 50)
            {
                return 5;
            }
            else if (currentSize >= 51 && currentSize <= 100)
            {
                return 10;
            }
            else if (currentSize > 100 && currentSize <= 200)
            {
                return 15;
            }
            else if (currentSize > 200 && currentSize <= 400)
            {
                return 18;
            }
            return 20;
        }
        public void PrintStorageDesign(int currSize, int size, int capacity,int speed)
        {
            Console.Write(@"
");
            int currentSize = CurrentSizeDisp(currSize);
            if (currSize != size)
            {                
                for (int i = 0; i < currentSize; i++)
                {
                    if (currentSize + size <= capacity / 2) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write("[]");
                    Thread.Sleep(speed * 3);
                }
            }
            else
            {                
                for (int i = currentSize; i < currentSize + 5; i++) 
                {
                    if (currentSize + size <= capacity/2 )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("[]");
                    Thread.Sleep(speed * 3);
                }
            }
        }
        
    }
    
    class Program
    {
       
        static void Main(string[] args)
        {
            Run run = new Run();
            run.Display1();



        }
    }



}
