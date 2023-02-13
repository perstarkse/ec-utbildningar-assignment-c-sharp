bool isRunning = true;
do
{
    Console.Clear();
    Console.WriteLine("WELCOME");
    int.TryParse(Console.ReadLine(), out int selection);

    switch (selection)
    {
        case 1:
            Console.WriteLine("did 0");
            break;
        case 2:
            Console.WriteLine("did 2");
            break;
        case 3:
            Console.WriteLine("did 3");
            break;
        case 4:
            Console.WriteLine("did 4");
            break;
        case 5:
            Console.WriteLine("did 5");
            isRunning= false;
            break;
        default:
            Console.WriteLine("press the right buttons yo");
            break;
    }
} while (isRunning);