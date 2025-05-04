using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int CountJokes = 0;
    public Text CounterJokes;
    private void Start()
    {
        CountJokes = GameObject.FindGameObjectsWithTag("interact").Length;
    }

    private void Update()
    {
        
        CounterJokes.text = "Осталось пакостей: " + CountJokes;
    }
}
