using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame {
	public class RotateTable : Equipment {
		public override void InvokeUpdate()
		{
			transform.rotation *= Quaternion.Euler(0,0,30 * Time.deltaTime);
		}
	}
}
