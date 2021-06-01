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
		Transform bulletPoolPar;

		[SerializeField]
		List<GameObject> bulletPrefabList = new List<GameObject>();
		[SerializeField]

		//[SerializeField]
		GameObject SpotLight;
		//public Image batteryFillImage;
		List<MagicProjectileScript> bulletList = new List<MagicProjectileScript>();
		int batteryTotal;
		public int BatteryTotal
		{
			set { batteryTotal = value; }
            get { return batteryTotal; }

		}

		int curBattery;
		public int CurBattery
		{
			set { curBattery = value; }
			get { return curBattery; }

		}
		// Start is called before the first frame update
		void Awake()
		{
			CurBattery = 10;
			BatteryTotal = 10;
			SpotLightToggle(false);
            SpotLightCtrl.ShotToggleEvent += Shot;
		}


        private void OnDestroy()
        {
			SpotLightCtrl.ShotToggleEvent -= Shot;
		}

        // Update is called once per frame
        void Update()
   	 	{
   	  	   
   	 	}

		public void Shot(int index)
        {
			GameObject tem = SimplePool.Spawn(bulletPrefabList[index], Vector3.zero, Quaternion.identity);
			MyDebug.Log("Shotting");

			bulletPoolPar.position = gunPoint.position;
			bulletPoolPar.rotation = gunPoint.rotation;
			tem.transform.SetParent(bulletPoolPar);
			bulletList.Add(tem.GetComponent<MagicProjectileScript>());
			tem.transform.localPosition = Vector3.zero;
			tem.transform.localEulerAngles = Vector3.zero;
			tem.GetComponent<Rigidbody>().velocity = Vector3.zero;
			tem.GetComponent<Rigidbody>().AddForce(gunPoint.forward * 1000);
			Debug.Log("tem.transform.forward " + gunPoint.forward);
			//tem.GetComponent<MagicProjectileScript>().impactNormal = new Vector3(0,1,0);

			//bulletList[bulletList.Count - 1].Shoot();

		}

		public void SpotLightToggle(bool show)
        {

            if (show)
            {
				if (CurBattery == 0)
				{
					return;
				}
				CurBattery--;

			}
			SpotLight.SetActive(show);

		}

		public void InitBatteryBar()
		{
			CurBattery = 10;
			//int curEnergy = playerCharacterController.playerWeaponsManagerScr.CurBattery;
			//batteryFillImage.fillAmount = curEnergy / playerCharacterController.playerWeaponsManagerScr.BatteryTotal;
		}
	}
}
