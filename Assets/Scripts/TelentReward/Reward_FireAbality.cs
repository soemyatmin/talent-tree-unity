public class Reward_FireAbality : Telent {
    public override void Reward() {
        base.Reward();
        ShopManager.Instance.SetFireAbality(1);
    }
}
