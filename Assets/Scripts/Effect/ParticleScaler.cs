using UnityEngine;
using System.Collections;
 
public class ParticleScaler : MonoBehaviour
{
    public Transform targetTrans;

    ParticleSystemRenderer ps;

    void Start()
    {
        ps = GetComponent<ParticleSystemRenderer>();
    }
    
	void OnWillRenderObject()
    {
		ps.material.SetVector( "_Position", Camera.current.worldToCameraMatrix.MultiplyPoint( transform.position ) );
		ps.material.SetVector( "_Scale", targetTrans.localScale );
	}
}