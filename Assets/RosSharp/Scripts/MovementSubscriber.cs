using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RosSharp;
namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosSocket))]
	public class MovementSubscriber : MonoBehaviour 
	{
		private RosSocket rosSocket;
		public int UpdateTime = 1;
		public Rigidbody rb;
		public GameObject player;
		private MovementManager movementManager;

		private float[] Positions;
		// Use this for initialization
		void Start () {
			rosSocket = transform.GetComponent<RosConnector>().RosSocket;
			rosSocket.Subscribe("/movement", "/Movement", updatePosition, UpdateTime);
			//rb = GetComponent<Rigidbody>();
			movementManager = player.GetComponent<MovementManager>();		

		}
		
		private void updatePosition(Message message)
		{
			MovementPosition movementList = (MovementPosition)message ; 
			movementManager.updateStatePosition( 
								new Vector3( movement[0].x, movement[0].y, movement[0].z),
								new Vector3( movement[1].x, movement[1].y, movement[1].z));

		}
	}
}

