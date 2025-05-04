using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interact")]
    public float RayLength = 10f;
    public Text textUI;

    [Header("Debug")]
    public bool IsDebug = false;
    public float DebugDelay = 0.1f;
    public Color DebugColor = Color.red;

    private InteractObject hitObj;
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (IsDebug)
            Debug.DrawRay(ray.origin, ray.direction * RayLength, DebugColor, DebugDelay);

        if (Physics.Raycast(ray, out hit, RayLength) && hit.collider.tag == "interact" && hit.collider.GetComponent<InteractObject>().IsCanInteract)
        {

            hitObj = hit.collider.GetComponent<InteractObject>();
            textUI.text = "[ЛКМ] " + hitObj.TextAction;
            textUI.enabled = true;
        }
        else
        {
            hitObj = null;
            textUI.enabled = false;
        }
        Click();
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0) && hitObj != null)
        {
            hitObj.Interact();
        }
    }
}