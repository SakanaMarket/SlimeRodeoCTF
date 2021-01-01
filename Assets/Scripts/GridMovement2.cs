using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridMovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask whatToCollect;
    public LayerMask whatKills;

    public Animator ani;

    public bool isFacingRight;

    [SerializeField] private Management manager;
    [SerializeField] private GameObject teleport;

    private Vector3 startPos;

    private bool lockMovements;

    private List<GameObject> slimeList;

    [SerializeField] private AudioSource sfxSrc;
    [SerializeField] private AudioClip collection_sound;
    [SerializeField] private AudioClip bump;
    [SerializeField] private AudioClip wall_bump;

    [SerializeField] private bool capping;
    private void Awake()
    {
        startPos = transform.position;
        lockMovements = false;
        slimeList = new List<GameObject>();
        capping = false;
    }

    private void Start()
    {
        movePoint.parent = null;
        isFacingRight = true;
    }

    void Update()
    {
        if (lockMovements == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
            {
                float H = Input.GetAxisRaw("Horizontal");
                float V = Input.GetAxisRaw("Vertical");
                ani.SetBool("moving", false);

                if (Mathf.Abs(H) == 1f)
                {
                    Debug.Log("horizontal");
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(H, 0f, 0f), .2f, whatStopsMovement))
                    {
                        if (!isFacingRight && H > 0)
                        {
                            Flip();
                        }
                        else if (isFacingRight && H < 0)
                        {
                            Flip();
                        }
                        movePoint.position += new Vector3(H, 0f, 0f);
                    }

                }

                else if (Mathf.Abs(V) == 1f)
                {
                    Debug.Log("vertical");
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, V, 0f), .2f, whatStopsMovement))
                    {
                        movePoint.position += new Vector3(0f, V, 0f);
                    }

                }

            }
            else
            {
                ani.SetBool("moving", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bad")
        {
            lockMovements = true;
            sfxSrc.PlayOneShot(bump, 0.25f);
            this.transform.position = startPos;
            movePoint.transform.position = startPos;
            /*foreach (GameObject s in slimeList)
            {
                s.SetActive(true);
            }
            manager.ResetCount();*/
            manager.increment_death();

            StartCoroutine(Delay(.5f));
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 obj_scale = transform.localScale;
        obj_scale.x *= -1;
        transform.localScale = obj_scale;
    }

    private void SlimeCheck()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (capping == false)
        {
            if (collision.gameObject.tag == "collect")
            {
                //Destroy(collision.gameObject);
                sfxSrc.PlayOneShot(collection_sound, 0.25f);
                slimeList.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
                manager.increment_count();
            }
            else if (collision.gameObject.tag == "bad")
            {
                lockMovements = true;
                sfxSrc.PlayOneShot(bump, 0.25f);
                this.transform.position = startPos;
                movePoint.transform.position = startPos;
                foreach (GameObject s in slimeList)
                {
                    s.SetActive(true);
                }
                manager.ResetCount();
                manager.increment_death();

                StartCoroutine(Delay(.5f));

            }
        }
        else
        {
            if (collision.gameObject.tag == "bigboi")
            {
                sfxSrc.PlayOneShot(collection_sound, 0.25f);
                manager.increment_count();
                Management m = GameObject.FindGameObjectWithTag("manager").GetComponent<Management>();
                m.Flag_Cap();
            }
            else if (collision.gameObject.tag == "spoder")
            {
                lockMovements = true;
                sfxSrc.PlayOneShot(bump, 0.25f);
                this.transform.position = startPos;
                movePoint.transform.position = startPos;
                manager.ResetCount();
                manager.increment_death();
                StartCoroutine(Delay(.5f));
            }
        }
        
    }

    IEnumerator Delay(float secs)
    {
        yield return new WaitForSeconds(secs);
        lockMovements = false;
    }

    public void Set_Capping()
    {
        capping = true;
    }
}
