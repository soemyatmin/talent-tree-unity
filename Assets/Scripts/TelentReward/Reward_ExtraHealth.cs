public class Reward_ExtraHealth : Telent {
    public int HealthGain;
    public override void Reward() {
        base.Reward();
        ShopManager.Instance.GainCurrentHalth(HealthGain);
    }
}
