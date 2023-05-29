namespace Assignment
{
    static class Program
    {
        static void Main()
        {
            
            Console.WriteLine("Hello, World!");
            TreasureChest chest = new TreasureChest();
            chest.Manipulate(TreasureChest.Action.Unlock);
            Console.WriteLine(chest.ToString());

            int end = 0;
            
            while(end == 0){
                Console.WriteLine("---------- Game ----------\n");
                Console.WriteLine("Press 1 to open \nPress 2 to close \nPress 3 to lock \nPress 4 to unlock \nPress 5 to exit\n");
                Console.WriteLine("--------------------------\n");
                string userchoice =  "1";  //Console.ReadLine();

                switch(userchoice){

                    case "1":
                        chest.Manipulate(TreasureChest.Action.Open);
                        break;

                    case "2":
                        chest.Manipulate(TreasureChest.Action.Close);
                        break;

                    case "3":
                        chest.Manipulate(TreasureChest.Action.Lock);
                        break;

                    case "4":
                        chest.Manipulate(TreasureChest.Action.Unlock);
                        break;

                    case "5":
                        end = 1;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;

                }

            }

        }
    }
}