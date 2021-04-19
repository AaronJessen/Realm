using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ARExplorer
{
    public class ZoomHelper : MonoBehaviour
    {
        public static Vector3 currentScale;

        private Touch oldTouch1;
        private Touch oldTouch2;
        RaycastHit hit;
        private void Awake()
        {
            hit = new RaycastHit();
        }
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                //MyDebug.Log(this.name);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    MyDebug.Log(hit.collider.tag);
                    if (!hit.collider.CompareTag("ARObject"))
                    {
                        return;
                    }
                    MyDebug.Log(hit.collider.name);
                }
                else
                {
                    return;
                }

                //单指滑动旋转
                if (Input.touchCount == 1)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector2 deltaPos = touch.deltaPosition;
                    transform.Rotate(Vector3.down * deltaPos.x, Space.Self);
                }

                if (Input.touchCount == 2)
                {
                    MyDebug.Log("Input.touchCount == 2 " + this.name);
                    //缩放
                    Touch newTouch1 = Input.GetTouch(0);

                    Touch newTouch2 = Input.GetTouch(1);

                    if (newTouch2.phase == TouchPhase.Began)
                    {
                        oldTouch2 = newTouch2;
                        oldTouch1 = newTouch1;

                        return;
                    }
                    float oldDistance = Vector2.Distance(oldTouch1.position, oldTouch2.position);
                    float newDistance = Vector2.Distance(newTouch1.position, newTouch2.position);

                    float offset = newDistance - oldDistance;

                    float scaleFactor = offset / 200f;

                    Vector3 localScale = transform.localScale;

                    Vector3 scale = new Vector3(localScale.x + scaleFactor, localScale.y + scaleFactor, localScale.z + scaleFactor);
                    //限制最低最高值
                    if ((scale.x >= 0.5f && scale.x <= 3) && (scale.y >= 0.5f && scale.y <= 3f) && (scale.z >= 0.5f && scale.z <= 3f))
                    {
                        transform.localScale = scale;
                        currentScale = scale;
                    }
                    oldTouch1 = newTouch1;
                    oldTouch2 = newTouch2;
                }
            }

        }
    }
}
