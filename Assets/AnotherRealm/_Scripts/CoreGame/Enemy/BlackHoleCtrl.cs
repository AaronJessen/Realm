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
            transform.localPosition = new Vector3(Random.Range(-3, 3), 0, Random.Range(50, 55));
            return;
            //BlackHoleList = new List<GameObject>();
            Debug.Log("InitFactory " + BlackHoleList.Count);
            for(int i = 0; i < BlackHoleList.Count; i++)
            {
                BlackHoleList[i].SetActive(false);
            }

            for (int i = 0; i < count; i++)
            {
                if (i >= BlackHoleList.Count)
                {
                    GameObject g = Instantiate(BlackHolePre);
                    Transform t = g.transform;
                    t.SetParent(ParTrans);
                    t.localScale = Vector3.one;
                    BlackHoleList.Add(g);
                }
                BlackHoleList[i].transform.localPosition = new Vector3(Random.Range(-10, 10), 0, Random.Range(50, 55));

            }
        }
    }
}
