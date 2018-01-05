using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RosSharp;
namespace RosSharp.RosBridgeClient
{
	public class MovementManager : MonoBehaviour {

		private Vector3 lineare;
		private Vector3 angolare;

		// Use this for initialization
		void Start () {
			lineare= Vector3.zero;
			angolare=Vector3.zero;
		}
		
		// Update is called once per frame
		void Update () {
			/*
			transform.position.x = rb.transform.position.x + movement[0].x;
			transform.position.y = rb.transform.position.y + movement[0].y;
			transform.position.z = rb.transform.position.x + movement[0].z;
			transform.rotation.x = rb.transform.rotation.z + movement[1].wx;
			rb.transform.rotation.y = rb.transform.rotation.z + movement[1].wy;
			rb.transform.rotation.z = rb.transform.rotation.z + movement[1].wz;
			*/ 

			transform.Translate(lineare * Time.deltaTime);
		    transform.Rotate(Vector3.forward, angolare.x * Time.deltaTime);	
		    transform.Rotate(Vector3.up     , angolare.y * Time.deltaTime);	
		    transform.Rotate(Vector3.left   , angolare.z * Time.deltaTime);	
		
		}

		public void updateStatePosition( Vector3 _lineare, Vector3 _angolare ){
			lineare = _lineare;
	    	angolare = _angolare;
		}
	}
}