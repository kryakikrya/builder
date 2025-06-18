using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2 : MonoBehaviour
{
    [SerializeField] GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
                obj.SetActive(true);
            }
    }
}
