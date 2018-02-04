/*
© CentraleSupelec, 2017
Author: Dr. Jeremy Fix (jeremy.fix@centralesupelec.fr)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

<http://www.apache.org/licenses/LICENSE-2.0>.

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;
using System;

namespace RosSharp.RosBridgeClient
{
    public class VelocityTransformManager : MonoBehaviour
    {
		private Vector3 linearVelocity;
		private Vector3 angularVelocity;
		private float angularVelocity_x;
		private float angularVelocity_y;
		private float angularVelocity_z;

		void Start()
		{
		    linearVelocity = Vector3.zero;
		    angularVelocity = Vector3.zero;
		}

		// Update is called once per frame
		void Update ()
		{
			transform.Translate(linearVelocity * Time.deltaTime);
			
			angularVelocity_x = rad2Deg(angularVelocity.x);
		    angularVelocity_y = rad2Deg(angularVelocity.y);
		    angularVelocity_z = rad2Deg(angularVelocity.z);
			
		    transform.Rotate(Vector3.forward, angularVelocity_x * Time.deltaTime);	
		    transform.Rotate(Vector3.up     , angularVelocity_y * Time.deltaTime);	
		    transform.Rotate(Vector3.left   , angularVelocity_z * Time.deltaTime);	
			
		}

		public void updateTransform(Vector3 _linearVelocity, Vector3 _angularVelocity)
		{
		    linearVelocity = _linearVelocity;
		    angularVelocity = _angularVelocity;
		}


		private static float rad2Deg(double values)
        {
        	values = values * (180.0 / Math.PI);
            values = Math.Round(values,2);
            return (float)values;
        }
    }
}
