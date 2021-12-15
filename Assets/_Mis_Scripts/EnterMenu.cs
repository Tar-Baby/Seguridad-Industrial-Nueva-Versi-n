using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Mis_Scripts
{
    public class EnterMenu : MonoBehaviour
    {
 
        private void EntrarMenu()
        {
            SceneManager.LoadScene("_Mis_Escenas/SeleccionarTutorial");
        }
    }
}
