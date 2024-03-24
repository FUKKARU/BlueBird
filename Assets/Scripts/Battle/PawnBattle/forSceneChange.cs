using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class forSceneChange : MonoBehaviour
{
    [SerializeField] private string thisSceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(thisSceneName);
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
