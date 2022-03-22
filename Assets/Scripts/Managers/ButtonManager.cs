using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void PressTapToPlayButton()
    {
        EventManager.OnTapToPlayButtonPressed?.Invoke();
    }

    public void PressNextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }

    public void PressRetryButton()
    {
        EventManager.OnRetryButtonPressed?.Invoke();
    }
}
