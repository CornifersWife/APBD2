namespace APBD2;

public abstract class Container {
    public float load;
    public float containerMass; //kg
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
        load = 0;
    }

    //TODO check if it works
    private static Dictionary<string, int> _typeCounts = new Dictionary<string, int>();

    private string GenerateSerialNumber() {
        string typeChar = GetTypeChar();

        if (!_typeCounts.ContainsKey(typeChar)) {
            _typeCounts[typeChar] = 1;
        }
        else {
            _typeCounts[typeChar]++;
        }

        return $"KON-{typeChar}-{_typeCounts[typeChar]}";
    }

    protected abstract string GetTypeChar();

    public virtual void RemoveLoad() {
        load = 0;
    }

    public virtual void AddLoad(float addedLoad) {
        if (load + addedLoad > maxLoad)
            throw new OverfillException($"Container {SerialNumber} has been overfilled");
        load += addedLoad;
    }

    public virtual void GetInformation() {
        Console.WriteLine($"SerialNumber {SerialNumber}" +
                          $"Load: {load}/{maxLoad} kg" +
                          $"Container mass: {containerMass} kg" +
                          $"Height: {height} cm" +
                          $"Depth: {depth} cm");
    }
}