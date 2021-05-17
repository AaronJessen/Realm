using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class CameraEditorCtrl : MonoBehaviour
	{
  	  	// Start is called before the first frame update
  	  	void Start()
        {
       
        }
        float speed = 20;
   	 	// Update is called once per frame
		void Update()
		{
            if (Input.GetKey(KeyCode.A))
            {
                var currEulerAngles = transform.eulerAngles;
                currEulerAngles.y -= speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(currEulerAngles);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                var currEulerAngles = transform.eulerAngles;
                currEulerAngles.y += speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(currEulerAngles);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                var currEulerAngles = transform.eulerAngles;
                currEulerAngles.x -= speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(currEulerAngles);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                var currEulerAngles = transform.eulerAngles;
                currEulerAngles.x += speed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(currEulerAngles);
            }
        }
	}
}
