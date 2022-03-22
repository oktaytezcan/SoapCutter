using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private int currentSceneIndex;
    public int CurrentSceneIndex { get { return currentSceneIndex; } }

    private void OnEnable()
    {
        EventManager.OnTapToPlayButtonPressed.AddListener(StartGameplay);
        EventManager.OnNextLevelButtonPressed.AddListener(LoadNextLevel);
        EventManager.OnRetryButtonPressed.AddListener(LoadNextLevel);
    }

    private void OnDisable()
    {
        EventManager.OnTapToPlayButtonPressed.RemoveListener(StartGameplay);
        EventManager.OnNextLevelButtonPressed.RemoveListener(LoadNextLevel);
        EventManager.OnRetryButtonPressed.RemoveListener(LoadNextLevel);
    }

    private void Awake()
    {
        instance = this;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Start()
    {
        EventManager.OnSceneStart?.Invoke();
    }

    private void StartGameplay()
    {
        EventManager.OnLevelStart?.Invoke();
    }

    private void LoadNextLevel()
    {
        // Since there's only one level, it'll reload the same level.
        // todo refactor after new leves are added.
        SceneManager.LoadScene(currentSceneIndex);
    }
}
