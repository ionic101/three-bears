using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public string TextAction = "взаимодействовать";
    public bool IsCanInteract = true;
    public Color NewColor = Color.red;

    public void Interact()
    {
        IsCanInteract = false;
        gameObject.GetComponent<MeshRenderer>().material.color = NewColor;
        GameManager.CountJokes--;
    }
}
