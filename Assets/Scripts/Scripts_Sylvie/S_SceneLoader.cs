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

    public void CheckMyKnowledges()
    {
        SceneManager.LoadScene("Choices_Politesse");
    }
}
