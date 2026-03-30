using _07_NullableEnumStruct.Enums;
using _07_NullableEnumStruct.Models;
using System;
using System.Drawing;

namespace _07_NullableEnumStruct
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DrinkOrder order1 = new DrinkOrder(
                101,
                "Ali",
                DrinkType.Coffee,
                DrinkSize.Medium
            );

            DrinkOrder order2 = new DrinkOrder(
                102,
                "Leyla",
                DrinkType.Tea,
                DrinkSize.Large
            );

            DrinkOrder order3 = new DrinkOrder(
                103, 
                "Vüqar",
                DrinkType.Juice,
                DrinkSize.Small
            );

            order1.UpdateStatus(OrderStatus.Preparing);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Ready);
            order1.DisplayOrder();
            order1.UpdateStatus(OrderStatus.Delivered);
            order1.DisplayOrder();

            order2.UpdateStatus(OrderStatus.Ready);
            order2.DisplayOrder();

            order3.DisplayOrder();

            Console.WriteLine("Bütün DrinkType deyerleri");
            foreach (DrinkType type in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine(type.ToString());
                DrinkType drinkTypeParsed = (DrinkType)Enum.Parse(typeof(DrinkType), type.ToString());
                Console.WriteLine(drinkTypeParsed);
            }
            Console.WriteLine();

            Console.WriteLine("Bütün DrinkSize deyerleri");
            foreach (DrinkSize size in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine(size.ToString());
                DrinkSize drinkSizeParsed = (DrinkSize)Enum.Parse(typeof(DrinkSize), size.ToString());
                Console.WriteLine(drinkSizeParsed);
            }
            Console.WriteLine();

            Console.WriteLine("Bütün OrderStatus deyerleri");
            foreach (OrderStatus order in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine(order);
            }
            Console.WriteLine();

            Console.WriteLine("Statistika");
            Console.WriteLine("Umumi Sifaris: 3");
            Console.WriteLine($"Birinci Sifarisin Qiymeti: {order1.CalculatePrice(order1.Type, order1.Size)} AZN");
            Console.WriteLine($"Ikinci Sifarisin Qiymeti: {order2.CalculatePrice(order2.Type, order2.Size)} AZN");
            Console.WriteLine($"Ucuncu Sifarisin Qiymeti: {order3.CalculatePrice(order3.Type, order3.Size)} AZN");
            decimal totalprice = order1.Price + order2.Price + order3.Price;
            Console.WriteLine($"Ümumi Mebleg: {totalprice} AZN");
        }
    }
}
