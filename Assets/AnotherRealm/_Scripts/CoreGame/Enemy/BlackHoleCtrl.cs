using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class BlackHoleCtrl : MonoBehaviour
	{
        public GameObject BlackHolePre;
        [HideInInspector]
        public List<GameObject> BlackHoleList = new List<GameObject>();

        public Transform ParTrans;
        // Start is called before the first frame update
        void Start()
    	{
            //InitFactory();

        }
	
        // Update is called once per frame
   		void Update()
   	 	{
   	  	   
   	 	}

        public void InitFactory(int count)
        {
            BlackHoleList = new List<GameObject>();

            for (int i = 0; i < count; i++)
            {
                GameObject g = Instantiate(BlackHolePre);
                Transform t = g.transform;
                t.SetParent(ParTrans);
                t.localScale = Vector3.one;
                t.localPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(100, 105));
                BlackHoleList.Add(g);
            }
        }
    }
}
