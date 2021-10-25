using UnityEngine;

namespace _Mis_Scripts.Menú_Reportar
{
    public class ÁreaDeActivación : MonoBehaviour
    {
        [SerializeField] private GameObject menúReportar;
        [SerializeField] private GameObject menúRespuestaCorrecta;
        [SerializeField] private GameObject menúRespuestaIncorrecta;
        

        private void OnTriggerExit(Collider other)
        {
            menúReportar.SetActive(false);
            menúRespuestaCorrecta.SetActive(false);
            menúRespuestaIncorrecta.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
