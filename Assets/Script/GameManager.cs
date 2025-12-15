using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;
    public bool isCoOpMode = false;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    [SerializeField]
    private Animator _pauseMenuAnimation;
    private Vector3 _initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pauseMenuAnimation.updateMode = AnimatorUpdateMode.UnscaledTime;
        _initialPosition = _pauseMenuPanel.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);//1 is main menu scene
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {

            _pauseMenuAnimation.SetBool("isPauseMenu", true);
            _pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
        }


    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void ResumeGame()
    {

        _pauseMenuPanel.SetActive(false);
        _pauseMenuPanel.transform.position = _initialPosition;
        _pauseMenuPanel.SetActive(true);
        Time.timeScale = 1;
    }

}
