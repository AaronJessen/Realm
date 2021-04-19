using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ARExplorer
{
    public class LookAtCamera : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
           
        }


        void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
            //var target = Camera.main.transform.position;
            //target.y = transform.position.y;
            //transform.LookAt(target);
            // transform.forward = Camera.main.transform.forward;
        }
    }
}
