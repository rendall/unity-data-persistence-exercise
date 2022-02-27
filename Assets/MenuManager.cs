using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text nameInputField;

    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.SetPlayerName(nameInputField.text);
    }
}
