using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T> {

    private static T instance_;

	// なんかまだバグがある・・・
	public static T Instance
	{
		get
		{
			if (instance_ == null)
			{
				GameObject obj = new GameObject(typeof(T).Name);
				instance_ = obj.AddComponent<T>();
			}
			return instance_;
		}
	}

	private void Awake()
    {
        if (instance_ != null)
        {
            Object.Destroy(this);
			return;
        }
        instance_ = (T)this;
    }

    protected Singleton () {}
}
