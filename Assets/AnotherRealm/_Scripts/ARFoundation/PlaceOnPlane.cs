using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ARExplorer
{
    /// <summary>
    /// Listens for touch events and performs an AR raycast from the screen touch point.
    /// AR raycasts will only hit detected trackables like feature points and planes.
    ///
    /// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
    /// and moved to the hit position.
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Instantiates this prefab on a plane at the touch location.")]
        GameObject m_PlacedPrefab;

        /// <summary>
        /// The prefab to instantiate on touch.
        /// </summary>
        public GameObject placedPrefab
        {
            get { return m_PlacedPrefab; }
            set { m_PlacedPrefab = value; }
        }

        /// <summary>
        /// The object instantiated as a result of a successful raycast intersection with a plane.
        /// </summary>
        //[SerializeField]
        GameObject spawnedObject;// { get; set; }
        PlacementIndicator placementIndicator;

        public delegate void OnPlacePlaneEventHandler();
        public static event OnPlacePlaneEventHandler OnPlacePlaneEvent;
        void Awake()
        {
            m_RaycastManager = GetComponent<ARRaycastManager>();
            placementIndicator = FindObjectOfType<PlacementIndicator>();
#if UNITY_EDITOR
            CreateLevel();
#endif
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                var mousePosition = Input.mousePosition;
                touchPosition = new Vector2(mousePosition.x, mousePosition.y);
                return true;
            }
#else
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
#endif

            touchPosition = default;
            return false;
        }

        void Update()
        {
           // Debug.Log(GameManager.Instance.ARProgressStatus);
            if (GameManager.Instance.ARProgressStatus != ARProgress.Scaning)
            {
                return;
            }


            
            //spawnedObject.GetComponent<ArtImageCtrl>().DispalyBillboard();
            //ARSceneManager.Instance.ARProgressStatus = ARProgress.ScanSuccess;

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
            {
                CreateLevel();

                if (OnPlacePlaneEvent != null)
                {
                    OnPlacePlaneEvent();
                }
            }

        }
        private void CreateLevel()
        {
            GameManager.Instance.ARProgressStatus = ARProgress.PreScan;
            MyDebug.Log(gameObject.name);
            spawnedObject = Instantiate(m_PlacedPrefab, placementIndicator.transform.position, placementIndicator.transform.rotation);

            //spawnedObject = Instantiate(m_PlacedPrefab, new Vector3(0, 0, -1), placementIndicator.transform.rotation);
            spawnedObject.SetActive(true);
        }

        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

        ARRaycastManager m_RaycastManager;
    }
}