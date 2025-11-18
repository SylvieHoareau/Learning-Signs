using TMPro;
using UnityEngine;

public class NPCControler : MonoBehaviour
{
    public string id;
    public int numberDialog;

    public TextMeshProUGUI tmp;

    public void Start()
    {
        EventCatcher.ChangeId += ModifyID;
        EventCatcher.ChangeString += ModifyText;
    }

    public void ModifyID(string _id)
    {
        DialogueManager.Instance.currentStep = 0;
        id = _id;
    }

    public void ModifyText(string _string)
    {
        tmp.text = _string;
    }
}
