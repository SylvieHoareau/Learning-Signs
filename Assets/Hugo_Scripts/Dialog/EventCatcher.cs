using System;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventCatcher : MonoBehaviour
{
    public static EventCatcher Instance;
    public static event Action<bool> ChangeScene;
    public static event Action<string> ChangeId;

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
        switch (eventName)
        {
            case "GoGameplay1":
                SendSignalScene(false);
                SendSignalChangeId("second_scene");
                DialogueManager.Instance.isTalking = false;
                SceneManager.LoadScene("Choices_Politesse");
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
}
