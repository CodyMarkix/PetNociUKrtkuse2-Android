using UnityEngine;

public class CamTabletButton : MonoBehaviour
{
    public CameraLook camLookScript;
    Vector2[] scales = { new Vector2(800f, 100f), new Vector2(447.5321f, 100f) };
    Vector2[] positions = { new Vector2(0f, -371.8669f), new Vector2(-161.234f, -371.8669f) };
    bool scalesPtr = false; // abusing truthyness/falsyness of booleans

    public void OnButtonPress() {
        camLookScript.SwitchTablet();

        gameObject.GetComponent<RectTransform>().sizeDelta = scales[System.Convert.ToInt32(!scalesPtr)];
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(!scalesPtr ? -161.234f : 0f, -371.8669f);
        scalesPtr = !scalesPtr;
    }
}
