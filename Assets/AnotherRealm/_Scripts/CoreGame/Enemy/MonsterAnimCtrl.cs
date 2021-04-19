using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
	public class MonsterAnimCtrl : MonoBehaviour
	{

        // Start is called before the first frame update
        //void Start()
        //{
        //	AnimationClip clip;
        //	Animator anim;
        //	AnimationEvent evt;
        //	evt = new AnimationEvent();

        //	evt.intParameter = 12345;
        //	evt.time = 1.12f;
        //	evt.functionName = "DieAnimFinish";

        //	// get the animation clip and add the AnimationEvent
        //	anim = GetComponent<Animator>();
        //	for (int i = 0; i < 5; i++)
        //	{
        //		clip = anim.runtimeAnimatorController.animationClips[i];
        //		clip.AddEvent(evt);
        //	}
        //}

        //// Update is called once per frame
        //void Update()
        // 	 	{

        // 	 	}

        public void DieAnimFinish()
        {
            Debug.Log("DieAnimFinish");
            gameObject.GetComponentInParent<MonsterBase>().gameObject.SetActive(false);
           // gameObject.SetActive(false);
        }
    }
}
