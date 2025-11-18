using UnityEngine;

public class NPCControler : MonoBehaviour
{
    public string id;
    public int numberDialog;

    public void Start()
    {
        EventCatcher.ChangeId += ModifyID;
    }

    public void ModifyID(string _id)
    {
        DialogueManager.Instance.currentStep = 0;
        id = _id;
    }
}
