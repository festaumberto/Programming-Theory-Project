using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverText;

    private bool isGameOver = false;

    private int playerScore;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            isGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int score)
    {
        Debug.Log("adding score: " + score + " to current player score: " + playerScore);
        this.playerScore += score;
        scoreText.text = "Score: " + playerScore;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }
}