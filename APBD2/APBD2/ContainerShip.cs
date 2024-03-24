namespace APBD2;

public class ContainerShip {
    private List<Container?> Containers { get; set; }
    private float maxSpeed; //in knots
    private int maxContainerAmount;
    private float maxTotalContainersLoad; //in tons
    private float currentTotalContainerLoad;

    public ContainerShip(float maxSpeed, int maxContainerAmount, float maxTotalContainersLoad) {
        this.maxSpeed = maxSpeed;
        this.maxContainerAmount = maxContainerAmount;
        this.maxTotalContainersLoad = maxTotalContainersLoad;
        Containers = new List<Container?>();
    }

    public ContainerShip(float maxSpeed, int maxContainerAmount, float maxTotalContainersLoad,
        List<Container?> containers) {
        this.maxSpeed = maxSpeed;
        this.maxContainerAmount = maxContainerAmount;
        this.maxTotalContainersLoad = maxTotalContainersLoad;
        Containers = containers;
    }

    public void RemoveContainer(Container container) {
        currentTotalContainerLoad -= container.TotalMass();
        Containers.Remove(container);
    }

    public void AddContainers(List<Container> addedContainers) {
        foreach (Container addedContainer in addedContainers) {
            AddContainer(addedContainer);
        }
    }

    public void AddContainer(Container addedContainer) {
        if (Containers.Contains(addedContainer)) {
            Console.WriteLine("Container already on this ship");
            return;
        }

        if (Containers.Count >= maxContainerAmount) {
            throw new Exception("Max container amount has been exceeded on this ship");
        }

        if (addedContainer.TotalMass() + currentTotalContainerLoad > maxTotalContainersLoad) {
            throw new Exception("Max total container has been exceeded on this ship");
        }

        currentTotalContainerLoad += addedContainer.TotalMass();
        Containers.Add(addedContainer);
    }

    private Container? FindContainer(string containerSerialNumber) {
        Container? container = Containers.Find(container => container.SerialNumber == containerSerialNumber);
        return container;
    }

    public void ChangeContainer(Container newContainer, string oldContainerSerialNumber) {
        Container? oldContainer = FindContainer(oldContainerSerialNumber);

        if (oldContainer == null) {
            throw new Exception($"Container with serial number {oldContainerSerialNumber} not found on the ship.");
        }

        RemoveContainer(oldContainer);
        AddContainer(newContainer);
    }

    public static void MoveContainerBetweenShips(String containerSerialNumber, ContainerShip from, ContainerShip to) {
        Container container = from.FindContainer(containerSerialNumber) ?? throw new InvalidOperationException();
        MoveContainerBetweenShips(container, from, to);
    }

    public static void MoveContainerBetweenShips(Container container, ContainerShip from, ContainerShip to) {
        if (!from.Containers.Contains(container)) {
            throw new Exception($"{container.SerialNumber} is not on {from}");
        }

        from.RemoveContainer(container);
        to.AddContainer(container);
    }


    public void GetInformation() {
        float currentLoad = 0f;
        var serialNumbers = new List<string>();
        foreach (Container container in Containers) {
            currentLoad += container.Load;
            serialNumbers.Add(container.SerialNumber);
        }

        currentLoad /= 1000f;
        string serialNumbersString = String.Join(", ", serialNumbers);
        Console.WriteLine($"Max speed: {maxSpeed} knots\n" +
                          $"Current load: {currentLoad}/{maxTotalContainersLoad} tons\n" +
                          $"Containers: {Containers.Count}/{maxContainerAmount}\n" +
                          $"{serialNumbersString}\n");
    }
}