namespace APBD2;

public class CoolingContainer : Container {
    public string productName;
    public float containerTemperature;
    public float minimumTemperature;

//TODO something to check minimum temperature like json? or smth
    public CoolingContainer(float containerMass, float height, float depth, float maxLoad, string productName,
        float containerTemperature) : base(containerMass, height, depth, maxLoad) {
        this.productName = productName;
        this.containerTemperature = containerTemperature;
    }

    protected override string GetTypeChar() => "C";

    public override void RemoveLoad() {
        throw new NotImplementedException();
    }

    public override void GetInformation() {
        base.GetInformation();
        //TODO
    }
}