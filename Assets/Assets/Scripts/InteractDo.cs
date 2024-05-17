using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InteractDo : MonoBehaviour
{
    public UnityEvent action;

    private void Start() {
        EvntManager.StartListening("Interact", DoAction);
    }

    public void DoAction()
    {
        action.Invoke();
    }
}
