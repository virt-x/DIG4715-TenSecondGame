using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private static int count;
    private static int petal;
    private Collider2D colliderr;
    private bool collision;
    public ParticleSystem particle;
    public AudioSource soundSource;
    public AudioClip flower5, flower6, flower7, flower8;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("State", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("State", false);
        }
        if (collision && Input.GetMouseButtonDown(0))
        {
            count++;
            int petals = System.Convert.ToInt32(colliderr.gameObject.GetComponent<SpriteRenderer>().sprite.name.Substring(6));
            petal += petals;
            switch (petals)
            {
                case 5:
                    soundSource.clip = flower5;
                    break;
                case 6:
                    soundSource.clip = flower6;
                    break;
                case 7:
                    soundSource.clip = flower7;
                    break;
                case 8:
                    soundSource.clip = flower8;
                    break;
                default:
                    break;
            }
            AudioSource flowerSound = Instantiate(soundSource);
            flowerSound.Play();
            Destroy(flowerSound, 0.5f);
            while (petals > 0)
            {
                Instantiate(particle.gameObject, colliderr.gameObject.transform.position, new Quaternion());
                petals--;
            }
            Debug.Log(petal + " " + count);
            Destroy(colliderr.gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.gameObject.transform.position = new Vector3(pos.x,pos.y);
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        colliderr = collide;
        collision = true;
    }
    void OnTriggerExit2D(Collider2D collide)
    {
        colliderr = null;
        collision = false;
    }

    public static int Count
    {
        get { return count; }
    }
    public static int Petal
    {
        get { return petal; }
    }
}
