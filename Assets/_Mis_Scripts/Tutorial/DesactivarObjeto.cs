using UnityEngine;

namespace _Mis_Scripts.Tutorial
{
    public class DesactivarObjeto : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            this.gameObject.SetActive(false);
        }
    }
}
