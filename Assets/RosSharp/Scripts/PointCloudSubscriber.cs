
using UnityEngine;
using System;
using System.IO;
using System.Text;

namespace RosSharp.RosBridgeClient
{

	[RequireComponent(typeof(RosConnector))]
	public class PointCloudSubscriber : MonoBehaviour
	{
		
		private string topic = "/stringozza";

		private RosSocket rosSocket;
		private PointsManager pointsManager;
		public int UpdateTime = 1;
		public GameObject emptyObject;
		 

		// Use this for initialization
		void Start ()
		{	
			
			rosSocket = transform.GetComponent<RosConnector>().RosSocket;
			rosSocket.Subscribe(topic, "std_msgs/String", createMesh, UpdateTime);
			pointsManager = emptyObject.GetComponent<PointsManager>();	
			Debug.Log("hrgfedak");

			//createMesh();
		}

		private void createMesh(Message message)
		//void createMesh()
		{
			//messaggio ricevuto da ROS
			StandardString pointCloudText = (StandardString)message;

			//pointCloudManager.loadScene();
			
			
			System.IO.File.WriteAllText(@"C:\Users\Gioele\Desktop\Giovanna\UNITY_projects\Nao Project\Assets\RosSharp\Scripts\PointCloudData\pointX.txt", pointCloudText.data );
			
			//string pointCloudFile = System.IO.File.ReadAllText(@"D:\unityProjects\ROS_Unity_interaction\Assets\RosSharp\Scripts\PointCloudData\pointX.txt");
			
			//string[] points = pointCloudFile.Split(',');
			/*
			
			
			File.AppendAllText(@"D:\unityProjects\ROS_Unity_interaction\Assets\RosSharp\Scripts\PointCloudData\PuntiBuoni4.off", "OFF"+ Environment.NewLine);
			File.AppendAllText(@"D:\unityProjects\ROS_Unity_interaction\Assets\RosSharp\Scripts\PointCloudData\PuntiBuoni4.off", points.Length+" 0 0"+ Environment.NewLine);
			
			for(int i=0; i < points.Length; i++){
				Debug.Log(i);
				string lines =points[i]; 
				File.AppendAllText(@"D:\unityProjects\ROS_Unity_interaction\Assets\RosSharp\Scripts\PointCloudData\PuntiBuoni4.off", lines + Environment.NewLine);
				
			}
			*/
			Debug.Log("scritto");
			//pointsManager.loadPoint();
			//StartCoroutine(pointsManager.loadP());
		}
	}

}
