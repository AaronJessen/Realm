using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
    public class MyDebug 
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public static void Log(object info)
        {
            Debug.Log("AR Explorer: " + info);
        }
    }
}
