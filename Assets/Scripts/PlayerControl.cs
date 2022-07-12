using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public InputAction m_inputMover;
    Vector2 m_movementValue;
    public float m_fspeed = 0.01f;

    public GameObject arrowPrefab;
    public float shotPower;

    [SerializeField]
    ZankiManager zankiManager;

    [SerializeField]
    Animator anim;

    bool spacePressBigin; // スペースキーの状態

    private void Start()
    {
        spacePressBigin = false;
        shotPower = 0f;
    }

    private void OnEnable()
    {
        m_inputMover.Enable();
    }

    private void OnDisable()
    {
        m_inputMover.Disable();
    }

    void Restrictions() // 移動範囲制限
    {
        if (transform.position.x > 2f)
        {
            transform.position = new Vector2(2f, transform.position.y);
        }
        if (transform.position.x < -2f)
        {
            transform.position = new Vector2(-2f, transform.position.y);
        }
    }

    public void Spawn() // 矢の発射
    {
        if (GameManager.Instance.gameState == GameManager.GAME_STATE.PLAYING)
        {
            if (shotPower > 100f)
            {
                GameObject arrow = GameObject.Instantiate(
                    (arrowPrefab) as GameObject,
                    transform.position,
                    transform.rotation
                );
                arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * shotPower);
                GameManager.Instance.arrowActive = true;
                AudioManager.Instance.PlaySE(SESoundData.SE.SHOT);
                //Debug.Log("arrowActive:" + GameManager.Instance.arrowActive);
                zankiManager.RadeceLifeArrow(1);
                anim.SetBool("kamae", false);
                anim.SetBool("arrowShot", false);
            }
            anim.SetBool("arrowShot", false);
            shotPower = 0;
        }
    }

    private void Update()
    {
        if (shotPower > 500)
        {
            shotPower = 500;
        }

        m_movementValue = m_inputMover.ReadValue<Vector2>(); // 入力処理
        transform.Translate(0, m_movementValue.y * m_fspeed, 0);

        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if (GameManager.Instance.arrowActive == false)
        {
            if (spaceKey.wasPressedThisFrame)
            {
                OnPressBigin();
            }
            if (spaceKey.isPressed)
            {
                OnPressed();
            }
            if (spaceKey.wasReleasedThisFrame)
            {
                OnReleased();
            }
        }
        else
        {
            shotPower = 0;
        }
    }

    public void kamaeAnimMethod(bool flag)
    {
        if (!spacePressBigin)
        {
            Debug.Log("KamaeMethod");
            anim.SetBool("kamae", flag);
            spacePressBigin = true;
        }
    }

    public void ArrowShotMethod()
    {
        if (spacePressBigin)
        {
            Debug.Log("ArrowShotMethod");
            anim.SetBool("arrowShot", true);
            Spawn();
            spacePressBigin = false;
        }
    }

    void OnPressBigin() // 押下した
    {
        if (spacePressBigin == false)
        {
            shotPower = 0;
            anim.SetBool("kamae", true);
            spacePressBigin = true;
        }
    }

    void OnPressed() // 押下中
    {
        if (spacePressBigin)
        {
            shotPower += 1.2f;
        }
    }

    void OnReleased() // 解放
    {
        if (spacePressBigin)
        {
            if (shotPower > 100f)
            {
                anim.SetBool("arrowShot", true);
                Spawn();
            }
            else
            {
                anim.SetBool("kamae", false);
            }
        }
        anim.SetBool("kamae", false);
        spacePressBigin = false;
    }

    private void FixedUpdate()
    {
        Restrictions();
    }
}
