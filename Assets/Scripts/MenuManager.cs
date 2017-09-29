using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    public string SceneName;


	public void StartClick()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitClick()
    {
        Application.Quit();
    }


}
