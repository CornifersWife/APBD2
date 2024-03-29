namespace APBD2;

public class FluidContainer : Container, IHazardNotifier {
    private bool containsDangerousLoad;

    public FluidContainer(float containerMass, float height, float depth, float maxLoad, bool containsDangerousLoad) :
        base(containerMass, height, depth, maxLoad) {
        this.containsDangerousLoad = containsDangerousLoad;
    }

    protected override string GetTypeChar() => "L";

    public void NotifyOfDanger() {
        Console.WriteLine($"A dangerous operation has been attempted on container {SerialNumber} ");
    }

    public override void AddLoad(float addedLoad) {
        var tmpMaxLoad = maxLoad * (containsDangerousLoad ? 0.5 : 0.9);
        if (Load + addedLoad > tmpMaxLoad)
            NotifyOfDanger();
        else {
            base.AddLoad(addedLoad);
        }
    }

    public override void GetInformation() {
        base.GetInformation();
        Console.WriteLine($"Contains dangerous load: {containsDangerousLoad}\n");
    }
}