using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {

#if UNITY_EDITOR
	/// <summary>
	/// キーボードから入力される方向を返します。(長さは1固定)
	/// </summary>
	/// <returns>長さ1の方向ベクトル</returns>
	public Vector3 GetDistance()
	{
		Vector3 vec = new Vector3();
		if(Input.GetKey(KeyCode.W))
		{
			vec.y = 1;
		}
		if(Input.GetKey(KeyCode.S))
		{
			vec.y = -1;
		}
		if(Input.GetKey(KeyCode.D))
		{
			vec.x = 1;
		}
		if(Input.GetKey(KeyCode.A))
		{
			vec.x = -1;
		}
		return vec.normalized;
	}
#endif

}
