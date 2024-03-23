namespace APBD2;

public class ContainerShip {
    private List<Container?> Containers { get; set; }
    private float maxSpeed; //in knots
    private int maxContainerAmount;
    private float maxTotalContainersLoad; //in tons
    private float currentTotalContainerLoad = 0f;

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

    public void RemoveContainer(Container? container) {
        //TOOD remove load
        Containers.Remove(container);
    }

    public void AddContainers(List<Container> addedContainers) {
        foreach (Container addedContainer in addedContainers) {
            AddContainer(addedContainer);
        }
    }

    public void AddContainer(Container addedContainer) {
        if (Containers.Count >= maxContainerAmount) {
            throw new Exception("Max container amount has been exceeded on this ship");
        }

        float totalContainerMass = addedContainer.containerMass + addedContainer.load;
        if (totalContainerMass + currentTotalContainerLoad > maxTotalContainersLoad) {
            throw new Exception("Max total container has been exceeded on this ship");
        }

        Containers.Add(addedContainer);
    }

    public Container? FindContainer(string containerSerialNumber) {
        Container? container = Containers.Find(container => container.SerialNumber == containerSerialNumber);
        return container;
    }

    public void ChangeContainer(Container newContainer, string oldContainerSerialNumber) {
        Container? oldContainer = FindContainer(oldContainerSerialNumber);
        //TODO finish implementing
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
        foreach (Container? container in Containers) {
            currentLoad += container.load;
        }

        currentLoad /= 1000f;

        Console.WriteLine($"Max speed: {maxSpeed} knots" +
                          $"Containers: {Containers.Count}/{maxContainerAmount}" +
                          $"Current load: {currentLoad}/{maxTotalContainersLoad} tons");
    }
    //TODO check for total weight of containers whenever load is added to any container
}