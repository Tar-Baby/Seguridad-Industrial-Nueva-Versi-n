using System;
using UnityEngine;

namespace _Mis_Scripts.Menú_Reportar
{
    public class RespuestaCorrecta : MonoBehaviour
    {
        // Variable respuesta = Respuesta Correcta
        [SerializeField] private Transform player;
        [SerializeField] private GameObject contenedorMenúReportar;
        [SerializeField] private GameObject menuReportar;
        [SerializeField] private GameObject menuRespuestaCorrecta;
        //[SerializeField] private GameObject menuRespuestaIncorrecta;
        [SerializeField] private GameObject areaDeActivacion;
        [SerializeField] private int respuesta;
        [SerializeField] private bool activarMenu;
        
        //Los objetos inician activos en Unity, pero se desactivan en el script para solucionar un error
        private void Start()
        {
            activarMenu = true;
            menuReportar.SetActive(false);
            menuRespuestaCorrecta.SetActive(false);
            //menuRespuestaIncorrecta.SetActive(false);
            areaDeActivacion.SetActive(false);
        }

        private void Update()
        {
            transform.LookAt(player);
            Debug.Log(player.position);
        }

        /* "DevolverRespuesta" compara el valor int asignado a la variable r, con el valor int que se devuelve
         si son equivalentes, entonces la respuesta es correcta, de lo contrario es incorrecta */
        public void DevolverRespuesta(int respuestaCorrecta)
        {
            if (respuestaCorrecta == respuesta)
            {
                PuntajesGlobales.correcta++;
                Debug.Log(PuntajesGlobales.correcta);
                Debug.Log("Respuesta Correcta: " + PuntajesGlobales.correcta);
                activarMenu = false;
                menuReportar.SetActive(false);
                menuRespuestaCorrecta.SetActive(true);
                //menuRespuestaIncorrecta.SetActive(false);
            }
            else
            {
                PuntajesGlobales.incorrecta++;
                Debug.Log("Respuesta Incorrecta: " + PuntajesGlobales.incorrecta);
                activarMenu = false;
                menuReportar.SetActive(false);
                menuRespuestaCorrecta.SetActive(false);
                //menuRespuestaIncorrecta.SetActive(true);
            }
        }
        public void InstanciarMenú(bool respuestaRegistrada = true)
        {
            if (activarMenu == respuestaRegistrada)
            {
                Instantiate(menuReportar, player.position, player.rotation);
                menuReportar.SetActive(true);
            }
        }
    }
}