namespace APBD2;

internal class Program {
    public static void Main(string[] args) {
        var coolingContainer = new CoolingContainer(4, 5, 6, 7, "Bananas", 15);

        var gasContainer = new GasContainer(8, 18, 4, 44, 9);
        var gasContainer2 = new GasContainer(8, 18, 4, 44, 9);
        var gasContainer3 = new GasContainer(8, 18, 4, 44, 9);

        var fluidContainer = new FluidContainer(4, 77, 5, 18, false);
        var fluidContainer2 = new FluidContainer(14, 7, 5, 108, true);

        var exampleLists = new List<Container>();
        exampleLists.Add(coolingContainer);
        exampleLists.Add(gasContainer);
        exampleLists.Add(gasContainer2);
        exampleLists.Add(gasContainer3);
        exampleLists.Add(fluidContainer);
        exampleLists.Add(fluidContainer2);

        //Załadowanie ładunku do danego kontenera
        gasContainer2.AddLoad(8);
        //Wypisanie informacji o danym kontenerze
        gasContainer2.GetInformation();

        try {
            gasContainer2.AddLoad(88);
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }

        ContainerShip containerShip = new ContainerShip(18, 65, 1000);
        
        //Stworzenie kontenera danego typu
        var fc3 = new FluidContainer(50, 3, 2, 19, false);
        //Załadowanie kontenera na statek
        containerShip.AddContainer(fc3);
        //Wypisanie informacji o danym statku i jego ładunku 
        containerShip.GetInformation();

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Załadowanie listy kontenerów na statek\n");
        containerShip.GetInformation();
        containerShip.AddContainers(exampleLists);
        containerShip.GetInformation();

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Usunięcie kontenera ze statku\n");
        containerShip.RemoveContainer(gasContainer2);
        containerShip.GetInformation();

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Rozładowanie kontenera\n");
        gasContainer2.GetInformation();
        gasContainer2.RemoveLoad();
        gasContainer2.GetInformation();

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Zastąpienie kontenera na statku o danym numerze innym kontenerem\n");
        containerShip.ChangeContainer(gasContainer2,"KON-L-1");
        containerShip.GetInformation();

        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Możliwość przeniesienie kontenera między dwoma statkami\n");
        ContainerShip containerShip2 = new ContainerShip(18, 65, 1000);
        containerShip.GetInformation();
        containerShip2.GetInformation();
        ContainerShip.MoveContainerBetweenShips(coolingContainer,containerShip,containerShip2);
        containerShip.GetInformation();
        containerShip2.GetInformation();
    }
}