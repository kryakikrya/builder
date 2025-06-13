using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public bool activator;
    public bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive)
        {
            if (other.CompareTag("Player") || other.CompareTag("Activation"))
            {
                obj.SetActive(!obj.active);
                isActive = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Activation"))
        {
            isActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (isActive)
        {
            if (other.CompareTag("Player") || other.CompareTag("Activation"))
            {
                obj.SetActive(!obj.active);
                isActive = false;
            }
        }
    }
}
