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
        
        Debug.Log("�������� ���� ��������");
    }

    
    public void ExitGame()
    {
        Debug.Log("����� �� ����");
        Application.Quit();

    }
}
