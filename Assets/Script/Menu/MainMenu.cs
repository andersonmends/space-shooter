using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    public void LoadSinglePlayer()
    {
        SceneManager.LoadScene("SinglePlayerMode");
    }
    public void LoadCoOp()
    {
        SceneManager.LoadScene("CoOpMode");
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
