namespace APBD2;

public abstract class Container {
    public float Load { get; protected set; }
    private float containerMass; //kg
    private float height; //cm
    private float depth; //cm
    protected float maxLoad; //kg
    public string SerialNumber { get; private set; }

    protected Container(float containerMass, float height, float depth, float maxLoad) {
        this.containerMass = containerMass;
        this.height = height;
        this.depth = depth;
        this.maxLoad = maxLoad;
        SerialNumber = GenerateSerialNumber();
        Load = 0;
    }

    private static Dictionary<string, int> _typeCounts = new Dictionary<string, int>();

    private string GenerateSerialNumber() {
        string typeChar = GetTypeChar();

        if (!_typeCounts.TryAdd(typeChar, 1)) {
            _typeCounts[typeChar]++;
        }

        return $"KON-{typeChar}-{_typeCounts[typeChar]}";
    }

    protected abstract string GetTypeChar();

    public virtual void RemoveLoad() {
        Load = 0;
    }

    public virtual void AddLoad(float addedLoad) {
        if (Load + addedLoad > maxLoad)
            throw new OverfillException($"Container {SerialNumber} has been overfilled");
        Load += addedLoad;
    }

    public virtual void GetInformation() {
        Console.Write($"SerialNumber {SerialNumber}\n" +
                      $"Load: {Load}/{maxLoad} kg\n" +
                      $"Container mass: {containerMass} kg\n" +
                      $"Height: {height} cm\n" +
                      $"Depth: {depth} cm\n");
    }

    public virtual float TotalMass() {
        return containerMass + Load;
    }
}