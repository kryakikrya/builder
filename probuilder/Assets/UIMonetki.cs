using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMonetki : MonoBehaviour
{

    public FirstPersonController player;
    public TextMeshProUGUI text;
    public GameObject door;
    void Update()
    {
        text.text = player.coins.ToString();
        if (player.coins == 3)
        {
            door.SetActive(false);
        }
    }
}
