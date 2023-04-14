using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectShop123
{
    public abstract class Device
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Color { get; set; }
        public Device(string manufacturer, string model, int quantity, double price, string color)
        {
            Manufacturer = manufacturer;
            Model = model;
            Quantity = quantity;
            Price = price;
            Color = color;
        }
        public abstract void PrintInfo();
    }
    public class MobilePhone : Device
    {
        public string OS { get; set; }
        public string DisplayType { get; set; }
        public MobilePhone(string manufacturer, string model, int quantity, double price, string color, string os, string displayType)
            : base(manufacturer, model, quantity, price, color)
        {
            OS = os;
            DisplayType = displayType;
        }
        public override void PrintInfo()
        {
            Console.WriteLine("Type device: mobile phone");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price} c.u.");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Operation system: {OS}");
            Console.WriteLine($"Display type: {DisplayType}");
            Console.WriteLine();
        }
    }
    public class Laptop : Device
    {
        public string Processor { get; set; }
        public int RAM { get; set; }
        public Laptop(string manufacturer, string model, int quantity, double price, string color, string processor, int ram)
            : base(manufacturer, model, quantity, price, color)
        {
            Processor = processor;
            RAM = ram;
        }
        public override void PrintInfo()
        {
            Console.WriteLine("Type device: Laptop");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price} c.u.");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Processor: {Processor}");
            Console.WriteLine($"RAM: {RAM} GB");
            Console.WriteLine();
        }
    }
    public class Tablet : Device
    {
        public string OS { get; set; }
        public string Connectivity { get; set; }
        public Tablet(string manufacturer, string model, int quantity, double price, string color, string os, string connectivity)
    : base(manufacturer, model, quantity, price, color)
        {
            OS = os;
            Connectivity = connectivity;
        }
        public override void PrintInfo()
        {
            Console.WriteLine("Type device: Tablet");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price} c.u.");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Operation system: {OS}");
            Console.WriteLine($"USB type: {Connectivity}");
            Console.WriteLine();
        }
    }
    public class Store
    {
        private List<Device> devices = new List<Device>();
        public void AddDevice(Device device)
        {
            devices.Add(device);
        }

        public void RemoveDevice(string manufacturer, string model)
        {
            Device deviceToRemove = devices.Find(d => d.Manufacturer == manufacturer && d.Model == model);
            if (deviceToRemove != null)
            {
                devices.Remove(deviceToRemove);
                Console.WriteLine("The device has been successfully removed from the list.");
            }
            else
            {
                Console.WriteLine("Device not found in the list.");
            }
        }
        public void PrintDeviceList()
        {
            Console.WriteLine("The list of devices in the store:");
            foreach (Device device in devices)
            {
                device.PrintInfo();
            }
        }
        public void SearchDevice(string manufacturer, string model)
        {
            Device deviceToSearch = devices.Find(d => d.Manufacturer == manufacturer && d.Model == model);
            if (deviceToSearch != null)
            {
                Console.WriteLine("Found device:");
                deviceToSearch.PrintInfo();
            }
            else
            {
                Console.WriteLine("No device found.");
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            MobilePhone mobilePhone1 = new MobilePhone("Samsung", "Galaxy M33", 10, 300, "Black", "Android", "AMOLED");
            Laptop laptop1 = new Laptop("Apple", "MacBook Pro", 5, 1000, "Silvery", "Intel Core i9", 32);
            Tablet tablet1 = new Tablet("Apple", "iPad Pro", 8, 500, "Gray", "iPadOS", "Lightning");
            Store store = new Store();

            store.AddDevice(mobilePhone1);
            store.AddDevice(laptop1);
            store.AddDevice(tablet1);

            store.PrintDeviceList();
            Console.WriteLine();


            Console.WriteLine("Search for a device according to a specified criterion:");
            store.SearchDevice("Samsung", "Galaxy M33");
            Console.WriteLine();


            Console.WriteLine("Removing a device from the list:");
            store.RemoveDevice("Apple", "MacBook Pro");
            Console.WriteLine();

            store.PrintDeviceList();

        }
    }
}
