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

    private void Start()
    {
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

    void Restrictions()
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

    void Spawn()
    {
        if (shotPower > 100f)
        {
            GameObject arrow = GameObject.Instantiate(
                (arrowPrefab) as GameObject,
                transform.position,
                transform.rotation
            );
            arrow.GetComponent<Rigidbody2D>().AddForce(transform.right * shotPower);
        }
        shotPower = 0;
    }

    private void Update()
    {
        m_movementValue = m_inputMover.ReadValue<Vector2>();
        transform.Translate(0, m_movementValue.y * m_fspeed, 0);

        var current = Keyboard.current;
        var spaceKey = current.spaceKey;

        if (spaceKey.isPressed)
        {
            Debug.Log("shotPower : " + shotPower);
            shotPower += 1.2f;
        }

        if (spaceKey.wasReleasedThisFrame)
        {
            Debug.Log("Released");
            Spawn();
        }
    }

    private void FixedUpdate()
    {
        Restrictions();
    }
}
