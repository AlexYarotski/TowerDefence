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
        Tank.Dead += SetDead;
    }
    
    private void OnDisable()
    {
        Tank.Dead += SetDead;
    }

    private void Start()
    {
        Button btn = _button.GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        SceneManager.LoadScene(currentScene);
    }

    private void FixedUpdate()
    {
       _counter.text = _nuberDead.ToString();
    }

    private void SetDead(Tank tank) => _nuberDead++;
}
