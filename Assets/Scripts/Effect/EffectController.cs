using UnityEngine;
using System.Collections;

// 特效控制器，控制*多个*特效播放停止等
public class EffectController : MonoBehaviour
{
    Animator[]          _Animators;
    ParticleSystem[]    _Particles;

    bool _Play = false;
    bool _Started = false;

	void Start ()
    {
        _Started = true;
	    _Animators = GetComponentsInChildren<Animator>();
        _Particles = GetComponentsInChildren<ParticleSystem>();        

        if( _Play )
            Play();
        else
            Stop();
	}
	
    public void Play()
    {
        _Play = true;
        if( _Started == false )
            return;

        // 注意动画State必须叫这个
        for( int i = 0; i < _Animators.Length; i++ )
            _Animators[i].SetBool( "Play", true );
        for( int i = 0; i < _Particles.Length; i++ )
            _Particles[i].Play();
    }

    public void Stop()
    {
        _Play = false;
        if( _Started == false )
            return;
 
        // 注意动画State必须叫这个
        for( int i = 0; i < _Animators.Length; i++ )
            _Animators[i].SetBool( "Play", false );
        for( int i = 0; i < _Particles.Length; i++ )
            _Particles[i].Stop();
    }

    void OnEnable()
    {        
        if( _Started == false )
            return;

        if( _Play )
            Play();
        else
            Stop();
    }
}
