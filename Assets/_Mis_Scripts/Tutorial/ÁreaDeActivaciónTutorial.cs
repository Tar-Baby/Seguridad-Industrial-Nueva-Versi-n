using UnityEngine;

namespace _Mis_Scripts.Tutorial
{
    public class ÁreaDeActivaciónTutorial : MonoBehaviour
    {
        [SerializeField] private GameObject menúTutorial;
       
        
        private void OnTriggerEnter(Collider other)
        {
            menúTutorial.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            menúTutorial.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
