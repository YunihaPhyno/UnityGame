using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : Bullet {

	private Vector3 m_direction;

	protected override Vector3 Move ()
	{
		return m_direction;
	}
}
