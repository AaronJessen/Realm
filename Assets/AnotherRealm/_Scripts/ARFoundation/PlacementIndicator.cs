using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ARExplorer
{
    public class PlacementIndicator : MonoBehaviour
    {
        private ARRaycastManager rayManager;
        private GameObject visual;
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        Vector2 centerTarget = new Vector2(Screen.width / 2, Screen.height / 2);
        void Start()
        {
            // get the components
            rayManager = FindObjectOfType<ARRaycastManager>();
            visual = transform.GetChild(0).gameObject;

            // hide the placement indicator visual
            visual.SetActive(false);
            PlaceOnPlane.OnPlacePlaneEvent += PlaceARObject;
        }
        private void OnDestroy()
        {
            PlaceOnPlane.OnPlacePlaneEvent -= PlaceARObject;
        }
        void Update()
        {
            //visual.SetActive(false);
            if (GameManager.Instance.ARProgressStatus != ARProgress.Scaning)
            {
                return;
            }

            //visual.SetActive(true);
            // shoot a raycast from the center of the screen
            rayManager.Raycast(centerTarget, hits, TrackableType.Planes);

            // if we hit an AR plane surface, update the position and rotation
            if (hits.Count > 0)
            {
                transform.position = hits[0].pose.position;
                transform.rotation = hits[0].pose.rotation;

                // enable the visual if it's disabled
                if (!visual.activeInHierarchy)
                {
                    MyDebug.Log(gameObject.name);
                    visual.SetActive(true);
                }
            }
        }

        void PlaceARObject()
        {

            visual.SetActive(false);
        }

    }
}