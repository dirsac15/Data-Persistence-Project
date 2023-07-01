using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField PlayerNameInput;
    public void LoadMainScene()
    {
        GameManager.Instance.CurrentPlayerName = "anonymous";
        SceneManager.LoadScene(1);

        GameManager.Instance.CurrentPlayerName = PlayerNameInput.text;
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
