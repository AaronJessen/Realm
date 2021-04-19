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
		GameObject bulletPrefab;
		[SerializeField]

		//[SerializeField]
		GameObject SpotLight;
		public Image batteryFillImage;
		List<ProjectileBase> bulletList = new List<ProjectileBase>();
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
		}

	
		// Update is called once per frame
		void Update()
   	 	{
   	  	   
   	 	}

		public void Shot()
        {
			GameObject tem = SimplePool.Spawn(bulletPrefab, Vector3.zero, Quaternion.identity);
			MyDebug.Log("Shotting");
			//GameObject tem = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity, gunPoint);
			tem.transform.SetParent(gunPoint);
			bulletList.Add(tem.GetComponent<ProjectileBase>());
			tem.transform.localPosition = Vector3.zero;
			tem.transform.localEulerAngles = Vector3.zero;
			tem.transform.localScale = Vector3.one;
			bulletList[bulletList.Count - 1].Shoot();

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
