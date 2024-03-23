namespace APBD2;

public class GasContainer : Container, IHazardNotifier {
    public float pressure; //atm

    public GasContainer(float containerMass, float height, float depth, float maxLoad, float pressure) : base(
        containerMass, height, depth, maxLoad) {
        this.pressure = pressure; //should this be auto calculated?
    }

    protected override string GetTypeChar() => "G";

    public override void RemoveLoad() {
        if (load > maxLoad * 0.05f)
            load = maxLoad * 0.05f;
    }

    public void NotifyOfDanger() {
        Console.WriteLine($"A dangerous operation has been attempted on container {SerialNumber} ");
    }
    public override void GetInformation() {
        base.GetInformation();
        //TODO
    }
}