using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UI;

public class AA : MonoBehaviour
{
    public bool interactable;
    public GameObject obj;

    public void ChangeColor()
    {
        if (interactable)
        {
            gameObject.GetComponent<Image>().color = Random.ColorHSV();
            interactable = false;
            StartCoroutine(CD());
        }
    }

    public void Off()
    {
        if (interactable)
        {
            obj.SetActive(false);
            interactable = false;
            StartCoroutine(On());
            StartCoroutine(CD());
        }
    }

    public void Krutka()
    {
        if (interactable)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 30));
            interactable = false;
            StartCoroutine(CD());
        }
    }
    IEnumerator CD()
    {
        yield return new WaitForSeconds(3);
        interactable = true;
    }

    IEnumerator On()
    {
        yield return new WaitForSeconds(1);
        obj.SetActive(true);
    }
}
