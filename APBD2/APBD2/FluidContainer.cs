using System.Text.Json.Serialization.Metadata;

namespace APBD2;

public class FluidContainer :  Container, IHazardNotifier {

    public bool containsDangerousLoad;
    
    protected override string GetTypeChar() => "L";

    public void NotifyOfDanger() {
        Console.WriteLine($"A dangerous operation has been attempted on container {SerialNumber} ");
    }

    public override void AddLoad(float addedLoad) {
        var tmpMaxLoad = maxLoad * (containsDangerousLoad ? 0.5 : 0.9);
        if(load+addedLoad>tmpMaxLoad)
            NotifyOfDanger();
        else {
            base.AddLoad(addedLoad);
        }
    }
   
}