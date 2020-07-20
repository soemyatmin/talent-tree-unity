using UnityEngine;
using UnityEngine.UI;

public class MouseHoverDesception : MonoBehaviour {
    public static MouseHoverDesception Instance; // just like singleton but not a full feature 

    Image image;
    GameObject TextSize;

    void Start() {
        Instance = this;
        image = GetComponent<Image>();
        TextSize = transform.GetChild(0).gameObject;
        ClearText();
    }

    public void SetText(string txt) {
        TextSize.GetComponent<Text>().text = txt;
        image.enabled = true;
    }

    public void ClearText() {
        TextSize.GetComponent<Text>().text = "";
        image.enabled = false;
    }

}
