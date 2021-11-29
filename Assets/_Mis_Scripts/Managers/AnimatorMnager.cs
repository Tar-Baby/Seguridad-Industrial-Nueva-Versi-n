using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorMnager : MonoBehaviour
{
    [SerializeField] Animator OficinistaTutorial2; //un personaje con un animator controller 

    public void Persuadido()
    {
        OficinistaTutorial2.SetBool("Persuadido",  true);
    }

}
