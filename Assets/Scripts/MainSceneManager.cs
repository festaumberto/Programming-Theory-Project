using TMPro;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverText;

    private int playerScore;

    public static MainSceneManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }


    public void AddScore(int score)
    {
        Debug.Log("adding score: " + score + " to current player score: " + playerScore);
        this.playerScore += score;
        scoreText.text = "Score: " + playerScore;
    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        GameManager.Instance.GameOver();
    }
}