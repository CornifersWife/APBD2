namespace APBD2;

public class CoolingContainer : Container {
    public string productName;
    public float containerTemperature;


    public CoolingContainer(float containerMass, float height, float depth, float maxLoad, string productName, float containerTemperature) : base(containerMass, height, depth, maxLoad) {
        this.productName = productName;
        this.containerTemperature = containerTemperature;
    }

    protected override string GetTypeChar() => "C";

    public override void RemoveLoad() {
        throw new NotImplementedException();
    }

   
}