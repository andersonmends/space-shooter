using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Image _liveImage;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _gameoverText;
    [SerializeField]
    private TextMeshProUGUI _restartText;
    [SerializeField]
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameoverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager is NULL");
        }


    }

    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLives)
    {
        _liveImage.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
        {
            _gameManager.GameOver();
            _restartText.gameObject.SetActive(true);
            _gameoverText.gameObject.SetActive(true);
            StartCoroutine(GameoverFlickerRoutine());
        }
    }

    IEnumerator GameoverFlickerRoutine()
    {
        while (true)
        {
            _gameoverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameoverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
