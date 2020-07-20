using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public static ShopManager Instance; // just like singleton but not a full feature 

    public Text TxtTelentPoint;
    public Text TxtGold;
    public Text TxtCurrentHalth;
    public Text TxtFireAbality;
    public Text TxtAttackPoint;

    // these properties should be in a player data class yet I will leave here for demo
    int telentPoint = 50;
    int gold = 0;
    int currentHalth = 1;
    int fireAbality = 0;
    int attackPoint = 1;

    void Start() {
        Instance = this;
        Init();
    }

    void Init() {
        TxtTelentPoint.text = GetTelentPoint().ToString();
        TxtGold.text = GetGold().ToString();
        TxtCurrentHalth.text = GetCurrentHalth().ToString();
        TxtFireAbality.text = GetFireAbality().ToString();
        TxtAttackPoint.text = GetAttackPoint().ToString();
    }

    public int GetTelentPoint() {
        return telentPoint;
    }

    public void GainTelentPoint(int value) {
        telentPoint += value;
        TxtTelentPoint.text = GetTelentPoint().ToString();
    }

    public int GetGold() {
        return gold;
    }

    public void GainGold(int value) {
        gold += value;
        TxtGold.text = GetGold().ToString();
    }

    public int GetCurrentHalth() {
        return currentHalth;
    }

    public void GainCurrentHalth(int value) {
        currentHalth += value;
        TxtCurrentHalth.text = GetCurrentHalth().ToString();
    }

    public string GetFireAbality() {
        return ((fireAbality == 1)? "Unlocked": "Locked");
    }

    public void SetFireAbality(int value) {
        fireAbality = value;
        TxtFireAbality.text = GetFireAbality().ToString();
    }

    public int GetAttackPoint() {
        return attackPoint;
    }

    public void GainAttackPoint(int value) {
        attackPoint += value;
        TxtAttackPoint.text = GetAttackPoint().ToString();
    }

}
