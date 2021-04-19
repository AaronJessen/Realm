using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class ScreenShot : MonoBehaviour
	{
        private string ScreenshotName = "TestFile.jpeg";
  	  	// Start is called before the first frame update
  	  	void Start()
   		 {

   		 }

   	 	// Update is called once per frame
		void Update()
		{
     		   
		}

        public void TakeScreenShot()
        {

            string screenShotPath = Application.persistentDataPath + "/" + ScreenshotName;
            Texture2D t = ScreenCapture.CaptureScreenshotAsTexture();
           // ScreenCapture.
           // ScreenCapture.CaptureScreenshot
            Debug.Log("SaveToAlbum");
           // NativeGallery.SaveImageToGallery(t, "ARAPP", "CaiARAPP.JPEG");
        }


    }
}
