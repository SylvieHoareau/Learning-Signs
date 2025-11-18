using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CheckMyKnowledges_Politesses()
    {
        SceneManager.LoadScene("Choices_Politesse");
    }

     public void CheckMyKnowledges_Restaurant()
    {
        SceneManager.LoadScene("Choices_Restaurant");
    }
}
