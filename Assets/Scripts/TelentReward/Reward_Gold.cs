public class Reward_Gold : Telent {
    public int GoldGain;
    public override void Reward() {
        base.Reward();
        ShopManager.Instance.GainGold(GoldGain);
    }
}