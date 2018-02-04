using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.IO;

public class PointsManager : MonoBehaviour {

	public GameObject mySphere;
	private string dataPath;
	private int numClasses;
	
	void Start () {
		Debug.Log("Start");
		dataPath = "/RosSharp/Scripts/PointCloudData/pointX.txt";
		numClasses = 3;
		StartCoroutine(loadP());
	}


	
	private void readClasses(){
		string pointCloudFile = System.IO.File.ReadAllText(@"C:\Users\Gioele\Desktop\Giovanna\UNITY_projects\Nao Project\Assets\RosSharp\Scripts\PointCloudData\pointX.txt");
		string[] classi = pointCloudFile.Split('!');
		for(int i=0; i<numClasses;i++){
			Debug.Log(i);
			string classe_singola = classi[i];
			if(classe_singola.Substring(classe_singola.Length-2,2) == " '" ){
				classe_singola = classe_singola.Remove(classe_singola.Length-3,3);
			}
			if(classe_singola.Substring(0,1) == "'"){
				classe_singola = classe_singola.Remove(0,3);
			}
			Debug.Log(classe_singola);
			System.IO.File.WriteAllText(@"C:\Users\Gioele\Desktop\Giovanna\UNITY_projects\Nao Project\Assets\RosSharp\Scripts\PointCloudData\prova"+i+".txt",classe_singola);
			
		}
	}


	private string[] readPoint(int i){
		string pointCloudFile = System.IO.File.ReadAllText(@"C:\Users\Gioele\Desktop\Giovanna\UNITY_projects\Nao Project\Assets\RosSharp\Scripts\PointCloudData\prova"+i+".txt");
		string[] points = pointCloudFile.Split(',');

		return points;
	}


	IEnumerator loadP(){
		Debug.Log("in IEnumerator");
		bool exist = false;
		yield return new WaitForSeconds(0.1f);

		if(File.Exists (Application.dataPath + dataPath )){
			Debug.Log("coroutineA created");
			readClasses();
			for(int i=0; i<numClasses; i++){
				string[] points = readPoint(i);

				foreach (string p in points){
					Debug.Log("inizio");
					double x;
					string xx = p.Replace(" ", string.Empty);
					if(xx.Substring(0,1)=="-"){
						x = double.Parse(xx.Remove(0,1), System.Globalization.NumberStyles.AllowTrailingSign | System.Globalization.NumberStyles.AllowDecimalPoint)* -1.0;
					}else{
						x = double.Parse(xx, System.Globalization.NumberStyles.AllowTrailingSign | System.Globalization.NumberStyles.AllowDecimalPoint);
					}
					double y=0.2;
					double z=0.5 + i;
					Instantiate(mySphere, new Vector3((float)x, (float)y, (float)z), new Quaternion(0.0f,0.0f,0.0f,0.0f));
					Debug.Log("fine");
				}
				
			}
			Debug.Log("coroutineA running again");
		}
	}

}


