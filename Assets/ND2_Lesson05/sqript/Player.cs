using UnityEngine;
using UnityEngine.InputSystem;

//Player
//・操作方法
//      WASD        :上下左右
//      マウス操作  :向きを変える（マウスの方向をみる）
//      左クリック   ：ショット

//・敵との接触で死ぬ      
//


public class Player : MonoBehaviour
{
    //フィールド
    //
    [Header("移動設定")]
    [SerializeField] private float _moveSpeed = 5.0f;//移動速度


    [Header("振り向き設定")]
    [SerializeField] private Transform _LookTarget;//向くターゲット

    [Header("ショット設定")]
    [SerializeField] private GameObject _bulletPrefab;//弾丸のプレハブ
    [SerializeField] private Transform _shotPoint;//出現位置
    [SerializeField] private float _shotPower;//ぱわー

    private Vector3 _moveVecter = new Vector3(0, 0, 0);//移動ベクトル




    void Start()
    {
        
    }


    void Update()
    {
        Movement();         //移動の実行
        LookAt();           //振り向きの実行
        Shot();             //攻撃の実行
    }

    //動くメソッド
    public void Movement()
    {
        //移動ベクトル
        _moveVecter = new Vector3(0, 0, 0);

        if(Keyboard.current.wKey.IsPressed())
        {
            _moveVecter = new Vector3(0, 0, 1);
        }
        if (Keyboard.current.aKey.IsPressed())
        {
            _moveVecter = new Vector3(-1, 0, 0);
        }
        if (Keyboard.current.sKey.IsPressed())
        {
            _moveVecter = new Vector3(0, 0, -1);
        }
        if (Keyboard.current.dKey.IsPressed())
        {
            _moveVecter = new Vector3(1, 0, 0);
        }

        //移動
        transform.Translate(_moveVecter * _moveSpeed * Time.deltaTime, Space.World);

        //移動ベクトルの可視化
        Debug.DrawRay(transform.position,_moveVecter,Color.green,0,false);

    }

    //方向を向くメソッド
    public void LookAt()
    {
        //振り向く
        //LOOKAT(ターゲット、軸)
        transform.LookAt(_LookTarget,Vector3.up);

        //向きの可視化
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 0, false);
    }


    public void Shot()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            //弾丸の複製
            GameObject bullet = Instantiate(_bulletPrefab, _shotPoint.position, _shotPoint.rotation);

            //射出
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.AddForce(_shotPoint.forward * _shotPower, ForceMode.Impulse);

            //数秒で消える
            Destroy(bullet, 5.0f);
        }
    
    }

}
