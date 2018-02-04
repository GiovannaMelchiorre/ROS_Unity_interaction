using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RosSharp.RosBridgeClient
{
	[RequireComponent(typeof(RosConnector))]
	public class CoordinatesPublisher : MonoBehaviour {

		public string topic = "/coordinates";

		private RosSocket rosSocket;
		private int publicationId;
		private GeometryVector3 message;
		private int sequenceId;
		public string frameId = "coordinates";
		
		void Start()
		{
			// The ROS part
			rosSocket = transform.GetComponent<RosConnector>().RosSocket;
			publicationId = rosSocket.Advertize(topic, "geometry_msgs/Vector3");
			message = new GeometryVector3();
			//sequenceId = 0;
			//message.x = 0;   // -y in ROS
			//message.y = 0;   // z in ROS
			//message.z = 0 ;  //x in ROS
			
			//rosSocket.Publish(publicationId, message);
		}
		
		public void Publish(Vector3 vector3)
		{
			// Build up the message and publish
			//message.header.frame_id = frameId;
			//message.header.seq = sequenceId;
			//é da capire in quale ordine va passato xyz
			/*
			message.x = 1;
			message.y = 0;   // z in ROS
			message.z = 0 ;  //x in ROS
			*/
			message.x = -vector3.y;
			message.y = vector3.z;  
			message.z = vector3.x;
			Debug.Log(message);
			rosSocket.Publish(publicationId, message);

			//++sequenceId;
		}
		
		
		
	}
}
