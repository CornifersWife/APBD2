namespace APBD2;

public class CoolingContainer : Container {
    private string productName;
    private float containerTemperature;
    private float minimumTemperature;

    private static readonly Dictionary<string, float> ProductMinimumTemperatures = new Dictionary<string, float> {
        { "Bananas", 13.3f },
        { "Chocolate", 18f },
        { "Fish", 2f },
        { "Meat", -15f },
        { "Ice cream", -18f },
        { "Frozen pizza", -30f },
        { "Cheese", 7.2f },
        { "Sausages", 5f },
        { "Butter", 20.5f },
        { "Eggs", 19f }
    };

    public CoolingContainer(float containerMass, float height, float depth, float maxLoad, string productName,
        float containerTemperature) : base(containerMass, height, depth, maxLoad) {
        if (!ProductMinimumTemperatures.ContainsKey(productName))
            throw new ArgumentException($"The product: {productName} is not one of the known types.");

        minimumTemperature = ProductMinimumTemperatures[productName];
        this.productName = productName;
        this.containerTemperature = containerTemperature;

        if (containerTemperature < minimumTemperature)
            throw new ArgumentException(
                $"The container temperature ({containerTemperature}) is lower then minimum ({minimumTemperature}) for {productName}");
    }

    protected override string GetTypeChar() => "C";

    public override void GetInformation() {
        base.GetInformation();
        Console.WriteLine($"Product name: {productName}\n" +
                          $"Current container temperature: {containerTemperature}\n" +
                          $"Minimum container temperature: {minimumTemperature}\n");
    }
}