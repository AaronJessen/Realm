using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace ARExplorer
{
    public class LoadImageHelper 
    {
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public static Vector2 GetImageSize(Rect rect, float scaleSize)
        {
            float ratio = rect.height / rect.width;
            Vector2 result;
            if (ratio > 1)
            {
                result = new Vector2(scaleSize, scaleSize * ratio);
            }
            else
            {
                result = new Vector2(scaleSize / ratio, scaleSize);
            }
            return result;
        }

        public static IEnumerator SetImage(string url, Image image, Action<bool> Finish = null)
        {
            if (url != null && url != "")
            {
                //LoadingHelper.Instance.ShowLoadingPanel(true);
                WWW www = new WWW(url);
                Debug.Log("Start download " + url);
                yield return www;

                image.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), Vector2.zero);
                //LoadingHelper.Instance.ShowLoadingPanel(false);
                Finish(true);
            }
            else
            {
                Debug.Log(url);
                image.sprite = Resources.Load<Sprite>(url);
            }
        }
    }
}
