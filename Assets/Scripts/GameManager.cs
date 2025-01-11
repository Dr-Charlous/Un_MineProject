using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("2 GameManagers");
    }
    #endregion

    public PlayerComponentManager Player;
    public UiManager Ui;
}
