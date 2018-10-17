using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
	namespace PlayerController
	{
		public class ControlSystem
		{
			public static Vector3 Axis
			{
				get
				{
					return new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
				}
			}

			public static bool Btn_jump
			{
				get
				{
					return Input.GetButtonDown("Jump");
				}
			}

			public static bool Btn_fire
			{
				get
				{
					return Input.GetButtonDown("Fire");
				}
			}
		}
	}	
}