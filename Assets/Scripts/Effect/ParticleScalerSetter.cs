using UnityEngine;
using System.Collections;

// 这个只在设置一次
public class ParticleScalerSetter : MonoBehaviour
{
    public Transform targetTrans;

    void Start()
    {
        if( targetTrans == null )
            return;

        Refresh();
    }

    public void Refresh()
    {
        ParticleSystemRenderer[] renderers = GetComponentsInChildren<ParticleSystemRenderer>();
        
        foreach( ParticleSystemRenderer render in renderers )
        {
		    //render.sharedMaterial.SetVector( "_Position", fruit.uiManager.GetUICamera().worldToCameraMatrix.MultiplyPoint( transform.root.position ) );
		    render.sharedMaterial.SetVector( "_Scale", transform.localScale );
        }
    }
}