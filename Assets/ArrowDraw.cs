using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{

    [SerializeField]private Image arrowImage;
    private Vector3 clickPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //0:左クリック
        //1:右クリック

        if(Input.GetMouseButtonDown(0))
        {
            clickPosition=Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 dist=clickPosition - Input.mousePosition;
            Debug.Log(dist);

            float size=dist.magnitude;
            float angelRad = Mathf.Atan2(dist.y, dist.x);
            arrowImage.rectTransform.position = clickPosition;
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angelRad * Mathf.Rad2Deg);
            arrowImage.rectTransform.sizeDelta=new Vector2(size, size);
        }
    }
}
