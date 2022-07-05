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
    private float shotPower;

    [SerializeField]
    ZankiManager zankiManager;

    [SerializeField]
    Animator anim;

    bool bigin;

    private void Start()
    {
        bigin = false;
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
        if (transform.position.x > 5.55f)
        {
            transform.position = new Vector2(5.55f, transform.position.y);
        }
        if (transform.position.x < -5.55f)
        {
            transform.position = new Vector2(-5.55f, transform.position.y);
        }
    }

    void Spawn() // 矢の発射
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
                Debug.Log("arrowActive:" + GameManager.Instance.arrowActive);
                zankiManager.RadeceLifeArrow(1);
            }
            shotPower = 0;
        }
        anim.SetBool("kamae", false);
    }

    private void Update()
    {
        if (shotPower > 500)
        {
            shotPower = 500;
        }

        m_movementValue = m_inputMover.ReadValue<Vector2>();
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

    void OnPressBigin()
    {
        Debug.Log("キーが押された!");
        anim.SetTrigger("Pressed");
        bigin = true;
        shotPower = 0;
    }

    void OnPressed()
    {
        if (bigin)
        {
            Debug.Log("キーが押されています");
            Debug.Log("shotPower : " + shotPower);
            //anim.SetTrigger("Pressed");
            anim.SetBool("kamae", true);
            shotPower += 1.2f;
        }
    }

    void OnReleased()
    {
        if (bigin)
        {
            Debug.Log("キーから離れました");
            bigin = false;
            anim.SetTrigger("Shot");
            //anim.SetBool("kamae", false);
            Spawn();
        }
    }

    private void FixedUpdate()
    {
        Restrictions();
    }
}
