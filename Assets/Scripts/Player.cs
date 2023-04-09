using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _hp = 1;
    
    [SerializeField]
    private float _speed = 2f;

    private float horizontalInput;
    private float verticalInput;

    private SpriteRenderer _spriteRenderer;
    public Text _ghoulCount;
    private float _textDistFromGhoul = 48; // ghost is 32x32. font height is 16. So 32+16 = 48
                                           // on each 0.25f scale, we take this value + (32/4)
                                           // to reposition the text correctly


    [SerializeField]
    Text mTextOverHead;
    Transform mTransform;
    Transform mTextOverTransform;

    void LateUpdate()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        // add a tiny bit of height?
        screenPos.y += _textDistFromGhoul; // adjust as you see fit.
        mTextOverTransform.position = screenPos;
    }

    // Called once at component load time
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        mTransform = transform;
        mTextOverTransform = mTextOverHead.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-1, 0, 0);

        // set default values
        _hp = 1;
        GameManager.Instance.TotalGhouls = _hp;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        mTextOverHead.text = _hp.ToString();
    }

    void PlayerMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // flip player sprite according to facing direction
        if (horizontalInput < 0) _spriteRenderer.flipX = true;
        if (horizontalInput > 0) _spriteRenderer.flipX = false;

        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
    }

    void OnCollideWithEnemy(GameObject other)
    {
        // increase horde count
        _hp++;
        if (GameManager.Instance != null)
            GameManager.Instance.TotalGhouls = _hp;

        // decrease movement speed
        if (_speed >= 1f)
        {
            _speed = _speed - 0.1f;
        }

        // increase player object size ("horde" size)
        gameObject.transform.localScale = new Vector3(transform.localScale.x + 0.25f, transform.localScale.y + 0.25f, transform.localScale.z);
        _textDistFromGhoul = _textDistFromGhoul + (32 / 4);

        // destroy the colliding enemy
        Destroy(other);
    }

    void OnCollideWithWall()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.GameOver();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") OnCollideWithEnemy(other.gameObject);
        if (other.tag == "Wall") OnCollideWithWall();
    }

    void UpdateGhoulCount()
    {
        _ghoulCount.text = _hp.ToString();
    }
}
