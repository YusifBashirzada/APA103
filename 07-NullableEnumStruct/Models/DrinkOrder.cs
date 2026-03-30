using _07_NullableEnumStruct.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_NullableEnumStruct.Models
{
    public class DrinkOrder
    {
        public int OrderNumber;
        public string CustomerName;
        public DrinkType Type { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price;

        public DrinkOrder(int orderNumber, string customerName, DrinkType type, DrinkSize size) {
            this.OrderNumber = orderNumber;
            this.CustomerName = customerName;
            this.Type = type;
            this.Size = size;
        }

        public DrinkOrder()
        {
        }

        public decimal CalculatePrice(DrinkType type, DrinkSize size)
        {
            decimal price = 0;
            
            switch(type)
            {
                case DrinkType.Coffee:
                    switch(size)
                    {
                        case DrinkSize.Small:
                            price = 3;
                            break;
                        case DrinkSize.Medium:
                            price = 4; 
                            break;
                        case DrinkSize.Large:
                            price = 5;
                            break;
                    }
                    break;
                case DrinkType.Tea:
                    switch(size)
                    {
                        case DrinkSize.Small:
                            price = 2;
                            break;
                        case DrinkSize.Medium:
                            price = 3;
                            break;
                        case DrinkSize.Large:
                            price = 4;
                            break;
                    }
                    break;
                case DrinkType.Juice:
                    switch(size)
                    {
                        case DrinkSize.Small:
                            price = 4;
                            break;
                        case DrinkSize.Medium:
                            price = 5;
                            break;
                        case DrinkSize.Large:
                            price = 6;
                            break;
                    }
                    break;
                case DrinkType.Water:
                    switch (size)
                    {
                        case DrinkSize.Small:
                            price = 1;
                            break;
                        case DrinkSize.Medium:
                            price = 1.5m;
                            break;
                        case DrinkSize.Large:
                            price = 2;
                            break;
                    }
                    break;
            }
            this.Price = price;
            return price;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            this.Status = newStatus;
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order Number: {OrderNumber}");
            Console.WriteLine($"Customer Name: {CustomerName}");
            Console.WriteLine($"Drink: {Type}");
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Price: {CalculatePrice(Type, Size)} AZN");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine("_______________________________________");
        }
    }
}
