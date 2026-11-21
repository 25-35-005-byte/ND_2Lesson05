using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// マウスポインター
/// 
/// ・まうすの座標に合わせて動く
/// </summary>
public class MousePointer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {//まうすの座標を取得
        Vector2 mousePosition = Mouse.current.position.value;

        //スクリーン座標を作る
        Vector3 screenPosition = mousePosition;
        screenPosition.z = 10;

        //まうすの座標をワールド座標に変換する
        //ワールド座標系 = Camera.main.ScreenToWorldPoint(スクリーン座標系)
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //オブジェクトの座標をまうすの座標と合わせる
        transform.position = worldPosition;
    }
}
