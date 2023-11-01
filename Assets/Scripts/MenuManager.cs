using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Ease _motionType;
    [SerializeField] private GameObject _pausePanel;
    private bool _isPaused;
    private void Start()
    {
        _textMeshProUGUI.transform.DOScale(1.2f, 0.5f).SetLoops(10,LoopType.Yoyo).SetEase(_motionType);
        _isPaused = true;
    }
    /// <summary>
    /// Старт игровой сессии
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("PlayGameScene");
        Time.timeScale = 1f;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    /// <summary>
    /// Возврат в главное меню
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1f;
    }
    /// <summary>
    /// Выход из игры для сборки
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
    /// <summary>
    /// Пауза
    /// </summary>
    public void PauseGame()
    {
        if (_isPaused == true && Time.timeScale == 1)
        {
            Time.timeScale = 0f;
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 1f;
            _isPaused = true;
        }
    }
}
