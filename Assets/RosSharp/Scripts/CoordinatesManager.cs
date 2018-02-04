using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Linq;


namespace RosSharp.RosBridgeClient
{
    public class CoordinatesManager : MonoBehaviour
    {

        public GameObject TeleportMarker;
        public Transform Player;
        public float RayLength = 50f;
        public GameObject Nao;

        public GameObject RosObject;
        private CoordinatesPublisher coordinatesPublisher;

        // Use this for initialization
        void Start()
        {
            //  OVRInput.Create();
            //    OVRInput.TouchHandler += TouchpadHandler;
            coordinatesPublisher = RosObject.GetComponent<CoordinatesPublisher>();
            int i = 0;
            while (i < 4)
            {
                Debug.Log(Input.GetJoystickNames()[i]);
                i++;
            }
        }

        // Update is called once per frame
        void Update()
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, RayLength))
            {
                if (hit.collider.tag == "Ground")
                {
                    if (!TeleportMarker.activeSelf)
                    {
                        TeleportMarker.SetActive(true);
                    }
                    TeleportMarker.transform.position = hit.point;
                }
                else
                {
                    TeleportMarker.SetActive(false);
                }
            }
            else
            {
                TeleportMarker.SetActive(false);
            }

            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                if (TeleportMarker.activeSelf)
                {
                    Debug.Log("one");
                    Vector3 markerPosition = TeleportMarker.transform.position;
                    Player.position = new Vector3(markerPosition.x, Player.position.y, markerPosition.z);
                }
            }
            else if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                if (TeleportMarker.activeSelf)
                {
                    Debug.Log("two");
                    Debug.Log(TeleportMarker.transform.position.x);
                    Vector3 robotPosition = new Vector3(TeleportMarker.transform.position.x, 0, TeleportMarker.transform.position.z);
                    Debug.Log(robotPosition);
                    //Nao.transform.position = robotPosition;
                    float newX = Math.Abs(Nao.transform.position.x - robotPosition.x);
                    float newY = Math.Abs(Nao.transform.position.y - robotPosition.y);
                    float newZ = Math.Abs(Nao.transform.position.z - robotPosition.z);

                    Vector3 newPosition = new Vector3(newX, newY, newZ);
                    coordinatesPublisher.Publish(newPosition);
                }
            }
        }
    }
}