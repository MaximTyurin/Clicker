using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _inputScreen;
    [SerializeField] GameObject _inputField;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _backGroundScreen;
    [SerializeField] private Text _currentScoreUI;
    [SerializeField] private int _loseCondition = 10;

    private string _name;
    private int _currentCondition;
    private int _scorePlayer;
    private string _bestScore = "BestScore";

    public string Name => _name;

    public delegate void Lose();
    public static event Lose OnLosedEvent;

    public int ScorePlayer => _scorePlayer;

    private void OnEnable()
    {
        SpawnerEnemys.OnSpawnedEvent += IncreaseCurrentCondition;
        TouchOnEnemy.OnDiedEvent += DecreaseCurrentCondition;
    }

    private void OnDisable()
    {
        SpawnerEnemys.OnSpawnedEvent -= IncreaseCurrentCondition;
        TouchOnEnemy.OnDiedEvent -= DecreaseCurrentCondition;
    }

    public void IncreaseCurrentCondition()
    {
        _currentCondition++;
        if(_currentCondition == _loseCondition)
        {
            OnLosedEvent?.Invoke();
            SaveNewPlayerName();
            Time.timeScale = 0;
        }
    }

    public void DecreaseCurrentCondition()
    {
        _currentCondition--;
        _scorePlayer++;
        _currentScoreUI.text = _scorePlayer.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DeleteAllKeys()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void SaveNewPlayerName()
    {
        if (PlayerPrefs.GetInt(_name, _scorePlayer) > PlayerPrefs.GetInt(_bestScore))
        {
            PlayerPrefs.SetInt(_bestScore, _scorePlayer);
            _inputScreen.SetActive(true);
            _backGroundScreen.SetActive(true);
        }
        else
        {
             _gameOverScreen.SetActive(true);
            _backGroundScreen.SetActive(true);
        }
    }

    public void Save()
    {
        _name = _inputField.GetComponent<Text>().text;
    }
}
