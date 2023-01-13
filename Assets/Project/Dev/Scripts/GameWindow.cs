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

    private int _numberDead = 0;
    private int _numberMining = 0;
    private string _text = string.Empty;

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
        _text = string.Format("Kill {0}", ++_numberDead);
        _counter.text = _text;
    }

    private void Bitcoin_Mining(Bitcoin obj)
    {
        _text = string.Format("Mining {0}", ++_numberMining);
        _mining.text = _text;
    }
}
