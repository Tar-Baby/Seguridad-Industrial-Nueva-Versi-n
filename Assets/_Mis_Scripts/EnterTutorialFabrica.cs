using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Mis_Scripts
{
    public class EnterTutorialFabrica : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            SceneManager.LoadScene("_Mis_Escenas/InteracciónVR");
        }
    }
}
