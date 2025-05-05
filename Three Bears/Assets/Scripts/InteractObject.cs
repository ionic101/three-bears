using Unity.VisualScripting;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public string TextAction = "взаимодействовать";
    public bool IsCanInteract = true;
    public Material DoneMaterial;

    public void Interact()
    {
        FindFirstObjectByType<AudioManager>().Play("hit");
        IsCanInteract = false;
        var oldMaterials = gameObject.GetComponent<MeshRenderer>().materials;

        Material[] materials = new Material[oldMaterials.Length];

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = DoneMaterial;
        }

        gameObject.GetComponent<MeshRenderer>().sharedMaterials = materials;

        GameManager.CountJokes--;
    }
}
