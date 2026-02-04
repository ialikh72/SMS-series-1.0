using System;
class SMS
{ 
   static string[] productname=new string[100];
     static int[] productqty=new int[100];
   static double[] productprice=new double[100];
       static int count=0;
   static double totalsales = 0;
    static int lastsoldid=-1;
    static int lastsoldqty = 0;

    static void Main()
    {
        startmenu();
    }
    static void startmenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1- to add product");
            Console.WriteLine("2- to view product");
            Console.WriteLine("3- sell product");
            Console.WriteLine("4- generate bill");
            Console.WriteLine("5- view sales");
            Console.WriteLine("6- exit");
            Console.WriteLine("Enter your choice:");
            int choice = Convert.ToInt32(Console.ReadLine());
      
            switch (choice)
            {
                case 1:
                    addproduct();
                    break;
                case 2:
                    viewproduct();
                    break;
                case 3:
                    sellproduct();
                    break;
                case 4:
                    generatebill();
                    break;
                case 5:
                    viewsales();
                    break;
                case 6:
                    exit();
                    return;
                   
                default:
                    Console.WriteLine("Invalid choice");


                    break;
            }
            Console.WriteLine("enter any key");
            Console.ReadKey();
        }
     

    }
    static void addproduct()
    {  if(count>=100)
        {
            Console.WriteLine("product limit reached");
            return;
        }
        Console.WriteLine("enter product name:");
        productname[count]=Console.ReadLine();
        Console.WriteLine("enter product's quantity:");
        productqty[count]=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter price of product:");
        productprice[count]=Convert.ToDouble(Console.ReadLine());
        count++;
        Console.WriteLine("added successfully");
    }
    static void viewproduct()
    {
        for(int i=0;i<count;i++)
        {
            Console.WriteLine("---\t---\t---\t---\t---\t---");
            Console.WriteLine($"ID {i} Name {productname[i]} Quantity {productqty[i]} Price {productprice[i]}");
        }
    }
    static void sellproduct()
    {
        if (count==0)
        {
            Console.WriteLine("no product to sell");
            return;
        }
        viewproduct();
        Console.WriteLine("enter id to sell");
        int id=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("enter quantity");
        int qty=Convert.ToInt32(Console.ReadLine());
        if(qty<0|| qty>productqty[id])
        {
            Console.WriteLine("invalid quantity");
            return;
        }
        else
        {
            productqty[id]-=qty;
            double bill=qty*productprice[id];
            Console.WriteLine("bill ="+bill);
            lastsoldid=id;
            lastsoldqty=qty;
        }
    }
    static void generatebill()
    {
        if(lastsoldid==-1)
        {
            Console.WriteLine("no product sold yet");
            return;
        }
        double total=lastsoldqty*productprice[lastsoldid];
        Console.WriteLine("---- BILL ----");
        Console.WriteLine($"Product: {productname[lastsoldid]}");
        Console.WriteLine($"Quantity: {lastsoldqty}");
        Console.WriteLine($"Total Price: {total}");
        totalsales+=total;
        lastsoldid=-1;
        lastsoldqty = 0;
    }
    static void viewsales()
    {
        Console.WriteLine("Total sales: "+totalsales);
    }
    static void exit()
    {
        Console.WriteLine("thanks for using SMS");
        Console.WriteLine("developed by ALi");
    }
}
