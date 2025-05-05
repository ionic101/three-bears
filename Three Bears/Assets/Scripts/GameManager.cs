using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int CountJokes = 2;
    public Text CounterJokes;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private FPSController playerController;
    private void Start()
    {
        CountJokes = GameObject.FindGameObjectsWithTag("interact").Length;
        playerController.enabled = true;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        CounterJokes.text = "Осталось пакостей: " + CountJokes;
        if (CountJokes == 0)
        {
            WinGame();
        }
    }


    public void WinGame()
    {
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        winPanel.SetActive(true);
    }

    public void LoseGame()
    {
        FindFirstObjectByType<AudioManager>().Play("bear");
        playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}
