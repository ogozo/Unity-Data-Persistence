using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Timeline;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI scoreText;
    public static MenuUIHandler Instance;
    public string theName;
    void Start()
    {
        scoreText.text = "Best Score: " + PlayerPrefs.GetString("highestPlayer") + " : " + PlayerPrefs.GetInt("highScore");
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void StartGame()
    {
        SetName();
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
    void SetName()
    {
        theName = inputField.text;
    }
}