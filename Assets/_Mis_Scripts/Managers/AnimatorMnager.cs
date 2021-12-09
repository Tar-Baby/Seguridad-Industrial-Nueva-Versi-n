using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static CounterDialogo;

public class AnimatorMnager : MonoBehaviour
{
  //  [SerializeField] Animator OficinistaTutorial2; //un personaje con un animator controller 
  //  [SerializeField] Animator OficinistaTutorial3;
    public static int contador = 0; // variable global

    public void PersuadidoTrue(Animator anim)
    {
        anim.SetBool("Persuadido", true);
        Debug.Log("Persuadido");
    }

    public void PersuadidoToTrue3(Animator anim)   //Si la conversacion toma 3 presiones de boton para Success
    {                                              //Contando el EnterDialogue como 1
        if (contador == 3)
        {
            PersuadidoTrue(anim);
            Debug.Log("Persuadido");
        }
    }

    public void TriggerFail2(Animator anim)  //  Si el contador es igual a 2
    {
        if (contador == 2)
        {
            anim.SetTrigger("Fail");
            Debug.Log("Fail");
        }
        
    }



}
