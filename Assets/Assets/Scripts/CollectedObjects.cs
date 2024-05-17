using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> collectedObjects;
    void Start() 
    {
        EvntManager.StartListening<GameObject>("CollectedObject", OnCollectedObject);
    }

    private void OnCollectedObject(GameObject obj)
    {
        collectedObjects.Add(obj);
        Debug.Log("<<<Collected " + obj.name + " >>>");
        Destroy(obj);
    }
}
