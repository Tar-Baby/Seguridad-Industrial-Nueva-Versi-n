using UnityEngine;

namespace _Mis_Scripts.Menú_Reportar
{
    public class MenúDesactivado : MonoBehaviour
    {
        // El menú está activado en la jerarquía pero se desactiva en Start, esto soluciona un error con los botones
    
        // Start is called before the first frame update
        void Start()
            
        {
            this.gameObject.SetActive(false);
        }

    }
}
