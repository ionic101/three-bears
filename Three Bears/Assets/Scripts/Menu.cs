using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    
    public void OptionsMenu()
    {
        
        Debug.Log("Открытие меню настроек");
    }

    
    public void ExitGame()
    {
        Debug.Log("Выход из игры");
        Application.Quit();

    }
}
