using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ReadJson : MonoBehaviour {


	public static JsonData LoadJsonfileFromResource(string path)
	{
		string filePath =  path.Replace(".json", "");

		TextAsset targetFile = Resources.Load<TextAsset>(filePath);
		if (!targetFile)
        {
			Debug.Log ("Loading Error: " + path);
			return null;
		}
		return JsonMapper.ToObject (targetFile.text);
	}



}
