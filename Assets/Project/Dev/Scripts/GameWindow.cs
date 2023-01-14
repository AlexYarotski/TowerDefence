using System;
using Project.Dev.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _counter = null;

    [SerializeField]
    private TextMeshProUGUI _mining = null;
    
    [SerializeField]
    private Button _button = null;

    private readonly string _counterKillText = "Kill {0}";
    private readonly string _counterCoinText = "Coin {0}";
    private int _numberDead = 0;
    private int _numberMining = 0;

    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
        Bitcoin.Mining += Bitcoin_Mining;
        Tower.Dead += Tower_Dead;
    }
    
    private void OnDisable()
    {
        Tank.Dead -= Tank_Dead;
        Bitcoin.Mining -= Bitcoin_Mining;
        Tower.Dead -= Tower_Dead;
    }

    private void Start()
    {
        _button.onClick.AddListener(RestartGame);
    }
    
    private void Tower_Dead(Tower obj)
    {
        RestartGame();
    }

    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(currentScene);
    }

    private void Tank_Dead(Tank tank)
    {
        _numberDead++;
        _counter.text = String.Format(_counterKillText, _numberDead);
    }

    private void Bitcoin_Mining(Bitcoin obj)
    {
        _numberMining++;
        _mining.text = String.Format(_counterCoinText, _numberMining);
    }
}
