using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ARExplorer
{
	public class PlayerWeaponsManager : MonoBehaviour
	{
		[SerializeField]
		Transform gunPoint;
		[SerializeField]
		Transform LeftHandPoint;

		[SerializeField]
		Transform bulletPoolPar;

		[SerializeField]
		List<GameObject> bulletPrefabList = new List<GameObject>();
		[SerializeField]

		//[SerializeField]
		GameObject SpotLight;
		//public Image batteryFillImage;
		//List<MagicProjectileScript> bulletList = new List<MagicProjectileScript>();
		//int batteryTotal;
		//public int BatteryTotal
		//{
		//	set { batteryTotal = value; }
  //          get { return batteryTotal; }

		//}

		//int curBattery;
		//public int CurBattery
		//{
		//	set { curBattery = value; }
		//	get { return curBattery; }

		//}
		// Start is called before the first frame update
		void Start()
		{
			//CurBattery = UserProfile.Instance.userData.MP;
			//BatteryTotal = 10;
			//SpotLightToggle(false);
			//SpellCtrl.ShotToggleEvent += Shot;
		}


        private void OnDestroy()
        {
			//SpellCtrl.ShotToggleEvent -= Shot;
		}

        // Update is called once per frame
        void Update()
   	 	{
   	  	   
   	 	}

		public void Shot(SkillData skillData)
        {
			GameObject tem = SimplePool.Spawn(bulletPrefabList[skillData.Index], Vector3.zero, Quaternion.identity);
			MyDebug.Log("Shotting");

			if (skillData.Skilltype[0] == "Heal" || skillData.Skilltype[0] == "Shield")
			{
				bulletPoolPar.position = LeftHandPoint.position;
				bulletPoolPar.rotation = LeftHandPoint.rotation;
			}
            else
            {
				bulletPoolPar.position = gunPoint.position;
				bulletPoolPar.rotation = gunPoint.rotation;
			}

			tem.transform.SetParent(bulletPoolPar);
			tem.transform.localPosition = Vector3.zero;
			tem.transform.localEulerAngles = Vector3.zero;
			tem.GetComponent<SpellBase>().m_SkillData = skillData;
			if (skillData.Name != "Life")
			{
				tem.GetComponent<Rigidbody>().velocity = Vector3.zero;
				tem.GetComponent<Rigidbody>().AddForce(gunPoint.forward * 1000 * skillData.Speed);
			}
			Debug.Log("tem.transform.forward " + gunPoint.forward);

		}

		//public void SpotLightToggle(bool show)
  //      {

  //          if (show)
  //          {
		//		//if (CurBattery == 0)
		//		//{
		//		//	return;
		//		//}
		//		//CurBattery--;

		//	}
		//	SpotLight.SetActive(show);

		//}

		//public void InitBatteryBar()
		//{
		//	//CurBattery = 10;
		//	//int curEnergy = playerCharacterController.playerWeaponsManagerScr.CurBattery;
		//	//batteryFillImage.fillAmount = curEnergy / playerCharacterController.playerWeaponsManagerScr.BatteryTotal;
		//}
	}
}
