﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class Tween : MonoBehaviour
{
    public delegate void OnFinish( GameObject obj, int value );
    public OnFinish onFinish;

    public bool     isPlaying { get { if( _Tweener == null ) return false; else return _Tweener.IsPlaying(); } }

	public int 		controlID = 0;
	public Ease		ease;
	public float	duration;
	public int		loop;
	public LoopType loopType;
	public float	delay;
	public bool		playOnEnable = false;

	protected bool			_Forward = true;
	protected Tweener		_Tweener;

	protected virtual void OnEnable()
	{
		if( playOnEnable )
			Play( true );
	}

	protected virtual void OnDisable()
	{
		_Tweener.Pause();
	}

	protected virtual void Awake()
	{
	}
	
	public virtual void ToInit()
	{
		_Tweener.Kill( false );
	}
	
	public virtual void Play( bool forward )
	{		
		_Tweener.SetEase( ease );
		_Tweener.OnComplete( OnFinished );
		_Tweener.SetLoops( loop, loopType );
		_Tweener.SetDelay( delay );

		_Forward = forward;
	}

    public bool IsPlaying()
    {
        if( _Tweener == null )
            return false;

        return _Tweener.IsPlaying();
    }

	// 正向结束为0，逆向为1
	protected void OnFinished()
	{
        if( onFinish != null )
        {
            onFinish( gameObject, _Forward ? 0 : 1 );
        }
	}
}
