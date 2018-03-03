using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyingObjectBase : MonoBehaviour {

	Rigidbody m_rigidbody;

	// いる？
	private Rigidbody Rigidbody
	{
		get {
			if (m_rigidbody == null) {
				m_rigidbody = GetComponent<Rigidbody>(); // まだ初期化されていなければrigidbodyをgameobjectから取得
			}
			return m_rigidbody;
		}
	}

    // Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		DoMove ();
	}

	/// <summary>
	/// 移動の実行
	/// (UPDATEの中で実行される)
	/// </summary>
	private void DoMove ()
	{
		Rigidbody.MovePosition(Move());
	}

	/// <summary>
	/// 移動に関わる内容はここで実装してください。
	/// </summary>
	protected abstract Vector3 Move();


}
