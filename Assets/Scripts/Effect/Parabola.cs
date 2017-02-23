using UnityEngine;
using System.Collections;

public class Parabola : MonoBehaviour
{
    public float                moveSpeed = 1f;
    public bool                 playOnStart;
    public Vector3              fromPosition;
    public Vector3              targetPosition;

    [HideInInspector]
    public object                   param;      

    float                       _DistanceToTarget;
    bool                        _Play;

	void Start ()
    {
        _DistanceToTarget = Vector3.Distance( fromPosition, targetPosition );
        if( playOnStart )
            Play();
	}

    public void Play()
    {
        _Play = true;
    }
	
	void Update ()
    {
        if( _Play == false )
            return;

	    transform.LookAt( targetPosition );
        float angle = Mathf.Min( 1, Vector3.Distance( transform.position, targetPosition ) / _DistanceToTarget ) * 30;
        transform.rotation = this.transform.rotation * Quaternion.Euler( Mathf.Clamp( -angle, -42, 42 ), 0, 0 );
        float currentDist = Vector3.Distance( this.transform.position, targetPosition );
        if ( currentDist < 0.1f )
        {
            transform.position = targetPosition;

            _Play = false;
            return;
        }

        transform.Translate( Vector3.forward * Mathf.Min( moveSpeed * Time.deltaTime, currentDist ) );

        // 最后再转一下
        //transform.rotation = Quaternion.AngleAxis( 72, Vector3.right ) * transform.rotation;
	}
}
