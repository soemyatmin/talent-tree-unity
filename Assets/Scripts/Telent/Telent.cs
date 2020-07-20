using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.EventSystems;

public abstract class Telent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject[] ChildTelent; // use this variable as gameobject instant of telent for on draw gizmos
    public int TelentID;
    public string DescriptionText;
    public int Cost;
    public bool isRootNode = false;

    [HideInInspector]
    public bool complete = false; // isClimed

    TelentController telentController;
    Button BtnTelentClaim;
    void Start() {
        Init();
    }

    public void Init() {
        telentController = transform.parent.GetComponent<TelentController>(); // manager may not needed
        BtnTelentClaim = GetComponent<Button>();
        BtnTelentClaim.onClick.AddListener(delegate { BtnBuy(); });
        BtnTelentClaim.interactable = isRootNode;
        transform.GetChild(0).gameObject.GetComponent<Text>().text = Cost.ToString(); // better do dynamic creation for text component XP

        foreach (GameObject ele in ChildTelent) {
            DrawUILineRender(new Vector2(ele.transform.position.x, ele.transform.position.y));
        }
    }

    public virtual void BtnBuy() {
        if (ShopManager.Instance.GetTelentPoint() >= Cost) {
            ShopManager.Instance.GainTelentPoint(-1 * Cost);
            Reward();
        } else {
            Debug.Log("Not Enought TelentPoint"); // UI show here
        }
    }
    public virtual void Reward() {
        BtnTelentClaim.interactable = false;
        complete = true;
        AllowChildTelentClaimed(); // database save may take action after reward
    }

    public void AllowChildTelentClaimed() {
        foreach (GameObject ele in ChildTelent) {
            if (!ele.GetComponent<Telent>().complete) {
                ele.GetComponent<Telent>().OpenChildTelent();
            }
        }
    }
    public virtual void OpenChildTelent() {
        BtnTelentClaim.interactable = true;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        MouseHoverDesception.Instance.SetText(DescriptionText);
    }
    public void OnPointerExit(PointerEventData eventData) {
        MouseHoverDesception.Instance.ClearText();
    }

    void DrawUILineRender(Vector2 childpoint) {
        GameObject lineDrawer = new GameObject();
        lineDrawer.transform.SetParent(transform);
        lineDrawer.AddComponent<UILineRenderer>();
        UILineRenderer ulr = lineDrawer.GetComponent<UILineRenderer>();
        ulr.Points = new Vector2[2];
        ulr.Points[0] = new Vector2(transform.position.x, transform.position.y);
        ulr.Points[1] = childpoint;
    }
    void OnDrawGizmos() {
        foreach (GameObject ele in ChildTelent) {
            Gizmos.DrawLine(transform.position, ele.transform.position);
        }
    }
}
