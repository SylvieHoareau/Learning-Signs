using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCatcher : MonoBehaviour
{
    public static EventCatcher Instance;
    public static event Action<bool> ChangeScene;
    public static event Action<string> ChangeId;
    public static event Action<string> ChangeString;

    void Start()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }

        DialogueManager.EventTrigger += OnCatch;
    }

    private void OnCatch(string eventName)
    {
        Debug.Log(eventName);
        switch (eventName)
        {
            case "GoGameplay1":
                SendSignalScene(false);
                SendSignalChangeId("second_scene");
                SendSignalChangeText("Super! Maintenant on va complexifier la chose . . .");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("Choices_Bonjour");
                break;
            case "GoGameplay2":
                SendSignalScene(false);
                SendSignalChangeId("third_scene");
                SendSignalChangeText("Super! Maintenant on va complexifier la chose . . .");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("Choices_Politesse");
                break;
            case "GoGameplay3":
                SendSignalScene(false);
                SendSignalChangeId("fourth_scene");
                SendSignalChangeText("Super! Maintenant on va complexifier la chose . . .");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("Choices_AuRevoir");
                break;
            case "GoGameplay4":
                SendSignalScene(false);
                SendSignalChangeId("fifth_scene");
                SendSignalChangeText("Super! Maintenant on va complexifier la chose . . .");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("Choices_Serveur");
                break;
            case "GoGameplay5":
                SendSignalScene(false);
                SendSignalChangeId("sixth_scene");
                SendSignalChangeText("Super! Maintenant on va complexifier la chose . . .");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("Choices_Commander");
                break;
            case "GoMenu":
                SendSignalScene(false);
                SendSignalChangeId("first_scene");
                SendSignalChangeText("Super! Maintenant on va complexifier la chose . . .");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("MainMenu");
                break;
            default:
                break;
        }
    }

    public void SendSignalScene(bool bo)
    {
        ChangeScene?.Invoke(bo);
    }

    public void SendSignalChangeId(string id)
    {
        ChangeId?.Invoke(id);
    }

    public void SendSignalChangeText(string id)
    {
        ChangeString?.Invoke(id);
    }
}
