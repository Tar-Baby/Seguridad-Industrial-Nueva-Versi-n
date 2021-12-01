using UnityEngine;
using UnityEngine.UI;

namespace _Mis_Scripts
{
    public class ContadorTiempo : MonoBehaviour
    {
        [SerializeField] private float temporizador;
        [SerializeField] private Text textoTiempo;
    
        // Start is called before the first frame update
        void Start()
        {
            temporizador = 180;
        }

        // Update is called once per frame
        void Update()
        {
            if (temporizador > 0)
            {
                temporizador -= Time.deltaTime;
            }
            else
            {
                temporizador = 0;
            }

            MostrarTiempo(temporizador);
        }

        private void MostrarTiempo(float tiempoEnPantalla)
        {
            if (tiempoEnPantalla < 0)
            {
                tiempoEnPantalla = 0;
            }

            float minutos = Mathf.FloorToInt(tiempoEnPantalla / 60);
            float segundos = Mathf.FloorToInt(tiempoEnPantalla % 60);
        
            textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }
}
