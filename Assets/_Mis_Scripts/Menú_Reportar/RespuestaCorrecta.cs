using System;
using UnityEngine;

namespace _Mis_Scripts.Menú_Reportar
{
    public class RespuestaCorrecta : MonoBehaviour
    {
        // Variable r = Respuesta Correcta
        [SerializeField] private int respuesta;
        [SerializeField] private GameObject menúReportar;
        [SerializeField] private GameObject menúRespuestaCorrecta;
        [SerializeField] private GameObject menúRespuestaIncorrecta;

     
        //Los objetos inician activos en Unity, pero se desactivan en el script para solucionar un error
        private void Start()
        {
            menúReportar.SetActive(false);
            menúRespuestaCorrecta.SetActive(false);
            menúRespuestaIncorrecta.SetActive(false);
        }

        /* "DevolverRespuesta" compara el valor int asignado a la variable r, con el valor int que se devuelve
         si son equivalentes, entonces la respuesta es correcta, de lo contrario es incorrecta */
        
        public void DevolverRespuesta(int respuestaCorrecta)
        {
            if (respuestaCorrecta == respuesta)
            {
                Debug.Log("Respuesta Correcta");
                menúReportar.SetActive(false);
                menúRespuestaCorrecta.SetActive(true);
                menúRespuestaIncorrecta.SetActive(false);
            }
            else
            {
                Debug.Log("Respuesta Incorrecta");
                menúReportar.SetActive(false);
                menúRespuestaIncorrecta.SetActive(true);
                menúRespuestaCorrecta.SetActive(false);
            }
        }
    }
}