using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ── Singleton so other scripts can find us easily ──
    public static GameManager Instance { get; private set; }

    // ── Settings (tweak in Inspector) ──
    [Header("Hit Limit")]
    [SerializeField] int maxHits = 5;

    [Header("Timer")]
    [SerializeField] float totalTime = 120f; // seconds

    [Header("Win Condition")]
    [Tooltip("Player must have fewer than this many hits to win")]
    [SerializeField] int winHitThreshold = 5;

    // ── UI References (drag in Inspector) ──
    [Header("UI")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject winPanel;

    // ── Optional audio ──
    [Header("Audio")]
    public AudioClip gameOverSound;
    public AudioClip winSound;
    AudioSource audioSource;

    // ── Internal state ──
    float timeRemaining;
    bool gameActive = true;

    public bool IsGameActive => gameActive;
    public int MaxHits => maxHits;
    public int WinHitThreshold => winHitThreshold;

    void Awake()
    {
        // Simple singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        timeRemaining = totalTime;

        // Make sure panels are hidden at start
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);

        UpdateTimerUI();
    }

    void Update()
    {
        if (!gameActive) return;

        // Count down
        timeRemaining -= Time.deltaTime;
        timeRemaining = Mathf.Max(timeRemaining, 0f);
        UpdateTimerUI();

        // Time ran out → game over
        if (timeRemaining <= 0f)
        {
            GameOver("Time's up!");
        }
    }

    // ── Called by Scorer when hits change ──
    public void OnHitRegistered(int currentHits)
    {
        if (!gameActive) return;

        if (currentHits >= maxHits)
        {
            GameOver("Too many hits!");
        }
    }

    // ── Called by WinZone when player reaches the end ──
    public void PlayerReachedEnd(int currentHits)
    {
        if (!gameActive) return;

        if (currentHits < winHitThreshold)
        {
            Win();
        }
        else
        {
            GameOver("");
        }
    }

    // ── Game Over ──
    void GameOver(string reason)
    {
        gameActive = false;
        Debug.Log("GAME OVER: " + reason);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            // Update the reason text if there's a child TextMeshProUGUI
            TextMeshProUGUI reasonText = gameOverPanel.GetComponentInChildren<TextMeshProUGUI>();
            if (reasonText != null)
                reasonText.text = "Game Over!\n" + reason;
        }

        if (gameOverSound != null)
            audioSource.PlayOneShot(gameOverSound);

        // Freeze the game
        Time.timeScale = 0f;
    }

    // ── Win ──
    void Win()
    {
        gameActive = false;
        Debug.Log("YOU WIN!");

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            TextMeshProUGUI winText = winPanel.GetComponentInChildren<TextMeshProUGUI>();
            if (winText != null)
                winText.text = "You Win!";
        }

        if (winSound != null)
            audioSource.PlayOneShot(winSound);

        Time.timeScale = 0f;
    }

    // ── Restart (hook this up to a UI button) ──
    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    // ── Helpers ──
    void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = FormatTime(timeRemaining);
    }

    string FormatTime(float t)
    {
        int minutes = Mathf.FloorToInt(t / 60f);
        int seconds = Mathf.FloorToInt(t % 60f);
        return string.Format("{0}:{1:00}", minutes, seconds);
    }
}