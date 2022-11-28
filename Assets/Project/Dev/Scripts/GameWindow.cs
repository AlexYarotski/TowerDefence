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

    private NumKill numKill = Tank.GetNumberKilled;
    private Text _text = null;

    private void Start()
    {
        Button btn = _button.GetComponent<Button>();
        btn.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void FixedUpdate()
    {
       _counter.text = numKill().ToString();
    }
}
