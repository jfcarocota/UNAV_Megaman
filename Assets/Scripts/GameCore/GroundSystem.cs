using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
	namespace PlayerController
	{
		public class GroundSystem 
		{
			[SerializeField]
            Color rayColor;
            [SerializeField, Range(0.1f, 10f)]
            float rayLenght;
            [SerializeField]
            LayerMask groundLayer;
            [SerializeField]
            Vector3 startPosition;

			public Vector3 StartPosition
            {
                get
                {
                    return startPosition;
                }
            }
		}	
	}
}

