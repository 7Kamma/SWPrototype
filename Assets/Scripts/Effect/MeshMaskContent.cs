using UnityEngine;
using System.Collections;

public class MeshMaskContent : MonoBehaviour
{
    // 创建的时候通知Mask刷新
    void Start()
    {
        MeshMask mask = GetComponentInParent<MeshMask>();
        if( mask != null )
            GetComponentInParent<MeshMask>().Refresh();
    }
}
