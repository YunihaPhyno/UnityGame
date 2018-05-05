using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame
{
	public class LookAtTable : Equipment
	{
		private LockOnUnit m_lockOnUnit = new LockOnUnit();
		public LockOnUnit GetLockOnUnit(){ return m_lockOnUnit; }

		public override void InvokeFixedUpdate()
		{
			base.InvokeFixedUpdate();
			UpdateRotation();
		}

		private void UpdateRotation()
		{
			Vector3 relativePos = GetLockOnUnit().GetTargetPosition() - transform.position;
			transform.rotation = transform.rotation * Quaternion.FromToRotation(transform.rotation.eulerAngles, relativePos);
		}
	}
}