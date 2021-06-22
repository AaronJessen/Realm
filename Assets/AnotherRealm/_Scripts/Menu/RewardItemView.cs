using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class RewardItemView : MonoBehaviour
	{
        [SerializeField] Image souceImg;
        [SerializeField] Text valueTxt;
  	  	// Start is called before the first frame update
  	  	void Start()
        {
            
        }

   	 	// Update is called once per frame
		public void Show(string key, int value)
		{
            souceImg.sprite = Resources.Load<Sprite>(PathProvider.rewardTexturePath + key.ToString());
            souceImg.SetNativeSize();
            souceImg.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);

            valueTxt.text = "X" + value.ToString();
        }
	}
}
