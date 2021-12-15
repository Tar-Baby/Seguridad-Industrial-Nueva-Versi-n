using UnityEngine;

namespace _Mis_Scripts.Menú_Reportar
{
    public class MenuLookAt : MonoBehaviour
    {

        [SerializeField] private Transform playerTransform;
        // Start is called before the first frame update

        // Update is called once per frame
        void Update()
        {
            transform.LookAt(playerTransform);
        }
    }
}
