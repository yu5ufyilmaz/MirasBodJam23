using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterType
{
    Collectable,
    Interactable
}
public class Inters : MonoBehaviour
{
    public InterType type;
    private void Start()
    {
        EvntManager.StartListening<GameObject>("CrossInteract", OnInteracted);

    }
    private void OnInteracted(GameObject obj)
    {
        Debug.Log("<<< Interacted " + obj.name + " >>>");
        if (type == InterType.Collectable)
            EvntManager.TriggerEvent("CollectedObject", obj);
        else if(type == InterType.Interactable)
            EvntManager.TriggerEvent("Interact");
    }
    
}
