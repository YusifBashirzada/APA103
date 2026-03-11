namespace _01_C_IntroMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            //Mathcalculate();

            // Task 2
            //Findoddeven(14, 20, 35, 40, 57, 60, 100);

            // Task 3
            //Sumdivide(14, 20, 35, 40, 57, 60, 100);

            // Task 4
            //Findsymbol();

        }

        // Task 1 

        //static void Mathcalculate()
        //{
        //    Console.WriteLine("a ededini daxil edin:");
        //    int a = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("b ededini daxil edin:");
        //    int b = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Yerine yetirilecek emeli daxil edin:");
        //    char op = Convert.ToChar(Console.ReadLine());

        //    switch (op)
        //    {
        //        case '+':
        //            Console.WriteLine("Netice: " + (a + b));
        //            break;
        //        case '-':
        //            Console.WriteLine("Netice: " + (a - b));
        //            break;
        //        case '*':
        //            Console.WriteLine("Netice: " + (a * b));
        //            break;
        //        case '/':
        //            if (b == 0) Console.WriteLine("0 - a bolme yoxdur");
        //            else Console.WriteLine("Netice: " + (a / b));
        //            break;
        //        case '%':
        //            Console.WriteLine("Netice: " + (a % b));
        //            break;
        //    }
        //}

        // Task 2

        //int[] arr = [14, 20, 35, 40, 57, 60, 100];
        //static void Findoddeven(params int[] arr)
        //{
        //    string tekEdedler = "";
        //    string cutEdedler = "";
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i] % 2 == 1)
        //        {
        //            if (tekEdedler != "") tekEdedler += ", ";
        //            tekEdedler += arr[i];
        //        }
        //        else
        //        {
        //            if (cutEdedler != "") cutEdedler += ", ";
        //            cutEdedler += arr[i];
        //        }


        //    }
        //    Console.WriteLine("Tek ededler: " + tekEdedler);
        //    Console.WriteLine("Cut ededler: " + cutEdedler);
        //}

        // Task 3

        //int[] array = [14, 20, 35, 40, 57, 60, 100];

        //static void Sumdivide(params int[] array)
        //{
        //    int sum = 0;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] % 4 == 0 && array[i] % 5 == 0)
        //        {
        //            sum += array[i];
        //        }
        //    }
        //    Console.WriteLine("Cem: " + sum);
        //}

        // Task 4

        //static void Findsymbol()
        //{
        //    string cumle = Convert.ToString(Console.ReadLine().ToLower());  // Kicik Boyuk herf ferqi neticeye tesir edir deye .toLower() istifade etmisem
        //    char simvol = Convert.ToChar(Console.ReadLine().ToLower());

        //    int count = 0;
        //    for (int i = 0; i < cumle.Length; i++)
        //    {
        //        if (simvol == cumle[i])
        //        {
        //            count++;
        //        }
        //    }
        //    Console.WriteLine(count);
        //}
    }
}
