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
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (IsDebug)
            Debug.DrawRay(ray.origin, ray.direction * RayLength, DebugColor, DebugDelay);

        if (Physics.Raycast(ray, out hit, RayLength))
        {
            textUI.enabled = true;
            Debug.Log("Попали в: " + hit.collider.name);
            Debug.Log("Точка попадания: " + hit.point);
        }
        else
        {
            textUI.enabled = false;
        }
    }
}
