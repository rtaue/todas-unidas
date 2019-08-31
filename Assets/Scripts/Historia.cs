using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Historia : MonoBehaviour {
    [SerializeField] string sceneToGo;

    public void SceneToGo(string scene)
    {

        sceneToGo = scene;

    }

    public void LoadScene()
    {
        MainData.NextScene = sceneToGo;
        Invoke("DelayLoad", 0.5f);

    }

    void DelayLoad()
    {
        SceneManager.LoadScene("Loading");

    }
}
