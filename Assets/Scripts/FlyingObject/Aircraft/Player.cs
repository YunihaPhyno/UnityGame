using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Aircraft {

	protected override void Move()
	{
		return transform.position + InputManager.Instance.GetDistance () * Time.deltaTime;
	}
}
