using UnityEngine;
using System.Collections;

public class ParticleMaskContent : MonoBehaviour
{
    // 创建的时候通知Mask刷新
    void Start()
    {
        ParticleMask mask = GetComponentInParent<ParticleMask>();
        if( mask != null )
            GetComponentInParent<ParticleMask>().Refresh();
    }
}
