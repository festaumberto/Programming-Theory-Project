using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;

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
            StartGame();
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}