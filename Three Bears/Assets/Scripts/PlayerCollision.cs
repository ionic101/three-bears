using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bear"))
        {
            gameManager.LoseGame();
        }
    }
}
