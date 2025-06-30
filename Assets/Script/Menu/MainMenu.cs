using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    public void LoadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
