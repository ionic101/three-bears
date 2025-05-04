using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public string TextAction = "взаимодействовать";
    public bool IsCanInteract = true;
    public Color NewColor;

    public void Interact()
    {
        IsCanInteract = false;
        gameObject.GetComponent<MeshRenderer>().material.color = NewColor;
    }
}
