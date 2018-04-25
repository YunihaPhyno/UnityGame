using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame {
	public class RotateTable : Equipment {
		public override void InvokeFixedUpdate()
		{
			base.InvokeFixedUpdate();
			transform.rotation *= Quaternion.Euler(0,0,30 * Time.fixedDeltaTime);
		}
	}
}
