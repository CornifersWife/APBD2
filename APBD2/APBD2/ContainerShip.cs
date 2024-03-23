namespace APBD2;

public class ContainerShip {
    private List<Container> Containers { get; set; }
    private float maxSpeed; //in knots
    private int maxContainerAmount;
    private float maxTotalContainersLoad; //in tons

    public ContainerShip(float maxSpeed, int maxContainerAmount, float maxTotalContainersLoad) {
        this.maxSpeed = maxSpeed;
        this.maxContainerAmount = maxContainerAmount;
        this.maxTotalContainersLoad = maxTotalContainersLoad;
        Containers = new List<Container>();
    }

    public ContainerShip(float maxSpeed, int maxContainerAmount, float maxTotalContainersLoad,
        List<Container> containers) {
        this.maxSpeed = maxSpeed;
        this.maxContainerAmount = maxContainerAmount;
        this.maxTotalContainersLoad = maxTotalContainersLoad;
        Containers = containers;
    }

    public void RemoveContainer(Container container) {
        Containers.Remove(container);
    }

    public void AddContainers(List<Container> addedContainers) {
        //check for too many containers
        //check for maxtotalload
        foreach (Container addedContainer in addedContainers) {
            Containers.Add(addedContainer);
        }
    }

    public void AddContainers(Container addedContainer) {
        //check for maxtotalload
        //check for too many containers
        Containers.Add(addedContainer);
    }

    public Container FindContainer(string containerSerialNumber) {
        return null;
    }

    public void ChangeContainer(Container newContainer, string oldContainerSerialNumber) {
        Container oldContainer = FindContainer(oldContainerSerialNumber);
    }

    public static void MoveContainerBetweenShips(Container container, ContainerShip from, ContainerShip to) {
    }


    public void GetInformation() {
        float currentLoad = 0f;
        foreach (Container container in Containers) {
            currentLoad += container.load;
        }

        currentLoad /= 1000f;

        Console.WriteLine($"Max speed: {maxSpeed} knots" +
                          $"Containers: {Containers.Count}/{maxContainerAmount}" +
                          $"Current load: {currentLoad}/{maxTotalContainersLoad} tons");
    }
}