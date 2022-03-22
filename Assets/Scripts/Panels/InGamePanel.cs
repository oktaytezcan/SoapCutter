using UnityEngine;
using TMPro;

public class InGamePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    void Start()
    {
        levelText.text = "LEVEL " + (LevelManager.instance.CurrentSceneIndex + 1).ToString();
    }
}
