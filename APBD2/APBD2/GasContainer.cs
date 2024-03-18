namespace APBD2;

public class GasContainer :  Container, IHazardNotifier{
    public float pressure; //atm
    protected override string GetTypeChar() => "G";
    public override void RemoveLoad() {
        if (load > maxLoad * 0.05f)
            load = maxLoad * 0.05f;
    }

    public void NotifyOfDanger() {
        Console.WriteLine($"A dangerous operation has been attempted on container {SerialNumber} ");
    }
}