using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class MeshMask : Mask 
{
    bool _Freeze = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        _Freeze = false;
    }

    void UnFreeze()
    {
        _Freeze = false;
    }

    public void Refresh()
    { 
        if( _Freeze )
            return;

		int width = Screen.width;
		int height = Screen.height;
		int designWidth = 640;
		int designHeight = 960;
		float s1 = (float)designWidth / (float)designHeight;
		float s2 = (float)width / (float)height;
 
		float contentScale = 1f;
		if( s1 > s2 )
        {
		    contentScale = s1 / s2;
        }
        //Vector2 pos;
        //if( RectTransformUtility.ScreenPointToLocalPointInRectangle( canvas.transform as RectTransform, transform.position,
        //    canvas.transform.FindChild( "UICamera" ).GetComponent<Camera>(), out pos ) ) 
        //{
			Renderer  [] meshes	 = transform.GetComponentsInChildren<Renderer>();
			RectTransform rectTransform = transform as RectTransform;
			float minX,minY,maxX,maxY;
			minX = rectTransform.rect.x  + transform.position.x * 100 * contentScale;
			minY = rectTransform.rect.y + transform.position.y * 100 * contentScale / 1.04f;
			maxX = minX + rectTransform.rect.width;
			maxY = minY + rectTransform.rect.height; 
 
			foreach( Renderer mesh in meshes )
			{
                if( mesh.gameObject.activeSelf == false )
                    continue;

				mesh.sharedMaterial.SetFloat( "_MinX",minX / 100 / contentScale * 1.04f );
				mesh.sharedMaterial.SetFloat( "_MinY",minY / 100 / contentScale * 1.04f );
				mesh.sharedMaterial.SetFloat( "_MaxX",maxX / 100 / contentScale * 1.04f );
				mesh.sharedMaterial.SetFloat( "_MaxY",maxY / 100 / contentScale * 1.04f );
			}
		//}

        _Freeze = true;
        Invoke( "UnFreeze", 1 );
    }
}