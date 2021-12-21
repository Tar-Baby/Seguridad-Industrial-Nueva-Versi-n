using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacionPanelFinalOficina : MonoBehaviour
{
    [SerializeField] private GameObject Panel_Final;
    public static int interacciones = 0; // variable global

    private void OnTriggerEnter(Collider other)
    {
        if (interacciones == 3)
        {
            Panel_Final.SetActive(true);
        }
        
    }
}
