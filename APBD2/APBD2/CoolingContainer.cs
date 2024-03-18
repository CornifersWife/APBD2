namespace APBD2;

public class CoolingContainer : Container {
    protected override string GetTypeChar() => "C";
    public override void RemoveLoad() {
        throw new NotImplementedException();
    }
}