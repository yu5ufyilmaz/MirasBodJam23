using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObjects : MonoBehaviour
{
    public bool OnRotate = false;
    public float movingSpeed = 100f;

    private void OnMouseDown()
    {
        if (OnRotate)
        {
            OnRotate = false;
            this.GetComponent<Outline>().enabled = false;
            
        }
        else
        {
            OnRotate = true;
            this.GetComponent<Outline>().enabled = true;
            Translatee();
        }
    }
    private void Translatee()
    {
        if (OnRotate)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * movingSpeed * Time.deltaTime);
            }
        }
    }
}
