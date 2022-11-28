using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _counter = null;

    [SerializeField]
    private Button _button = null;

    private Text _text = null;
    private int _nuberDead = 0;

    private void OnEnable()
    {
        Tank.Dead += Tank_Dead;
    }
    
    private void OnDisable()
    {
        Tank.Dead += Tank_Dead;
    }

    private void Start()
    {
        _button.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(currentScene);
    }

    private void Tank_Dead(Tank tank)
    {
        _nuberDead++;
        _counter.text = _nuberDead.ToString();
    } 
}
