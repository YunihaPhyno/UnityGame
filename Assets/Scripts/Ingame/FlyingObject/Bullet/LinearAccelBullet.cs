﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

namespace Ingame
{
	public class LinearAccelBullet : Bullet
	{
		private Vector3 m_constantAcceleration;
		public Vector3 ConstantAcceleration { get { return m_constantAcceleration; }}
		public void SetConstantAcceleration (Vector3 value) { m_constantAcceleration = value; }

		public override void SetParam(Vector3 velocity, LAYER layer)
		{
			base.SetParam(velocity, layer);
			m_constantAcceleration = Vector3.zero;
		}

		protected override void UpdateVelocity()
		{
			LocalVelocity = Mathv.CalculateVelocity(LocalVelocity, m_constantAcceleration);
		}
	}
}