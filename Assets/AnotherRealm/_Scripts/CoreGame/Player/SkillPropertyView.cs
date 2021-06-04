using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class SkillPropertyView : MonoBehaviour
	{
        [SerializeField] Image propertyImg;
        [SerializeField] Text descriptionTxt;
        [SerializeField] Text valueTxt;
        // Start is called before the first frame update
        void Start()
        {
            
        }

   	 	// Update is called once per frame
		public void ShowSkillProperty(string des, int value)
		{
            descriptionTxt.text = des;
            valueTxt.text = value.ToString();
            gameObject.SetActive(true);
        }

        public void HideSkill()
        {
            gameObject.SetActive(false);
        }
	}
}
