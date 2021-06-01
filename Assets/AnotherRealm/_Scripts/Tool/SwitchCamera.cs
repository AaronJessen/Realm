using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Vuforia;

namespace ARExplorer
{
	public class SwitchCamera : MonoBehaviour
	{
  	  	// Start is called before the first frame update
  	  	void Start()
        {
            
        }

   	 	// Update is called once per frame
		void Update()
		{
            
		}

        public void SwitchMyCamera() {


            WebCamDevice[] cameraType = WebCamTexture.devices;
            //FindObjectOfType<BackgroundPlaneBehaviour>().Material.mainTexture = CameraDevice.;
            WebCamTexture webCamTexture = new WebCamTexture(cameraType[1].name);
            // Vuforia.WebCamARController.Instance.
            //if (cameraType[0].isFrontFacing)
            //{
            //    //CameraDevice.Instance.
            //}
        }
	}
}
