using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class EventCatcher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueManager.EventTrigger += OnCatch;
    }

    private void OnCatch(string eventName)
    {
        switch (eventName)
        {
            case "GoGameplay1":
                SceneManager.LoadScene("Choices_Politesse");
                break;
            default:
                break;
        }
    }
}
