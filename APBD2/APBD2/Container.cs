namespace APBD2;

public abstract class Container {
    public float load { get; set; }
    public float containerMass; //kg
    public float height; //cm
    public float depth; //cm
    public float maxLoad; //kg
    public string SerialNumber { get; private set; }

    private static Dictionary<string, int> _typeCounts = new Dictionary<string, int>();

    public Container() {
        SerialNumber = GenerateSerialNumber();
    }

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
}