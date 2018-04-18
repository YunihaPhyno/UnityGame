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

		public override void Initialize(Vector3 pos, Vector3 velocity, LAYER layer, int damage = 1, int hp = 1, float lifetime = float.MaxValue)
		{
			base.Initialize(pos, velocity, layer, damage, hp, lifetime);
			m_constantAcceleration = Vector3.zero;
		}

		protected override void UpdateVelocity()
		{
			Velocity = Mathv.CalculateVelocity(Velocity, m_constantAcceleration);
		}
	}
}