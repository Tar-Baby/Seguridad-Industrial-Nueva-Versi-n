using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Mis_Scripts
{
    public class CambiarEscenaBoton : MonoBehaviour
    {

        public void CargarEscena(string nombreEscena)
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
