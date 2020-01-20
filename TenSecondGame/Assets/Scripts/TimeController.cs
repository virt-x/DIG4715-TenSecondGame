using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeController : MonoBehaviour
{
    public Text textTitle;
    public Text textBody0;
    public Text textBody1;
    public Text textTimer;
    public Text textCount;
    public GameObject flower5;
    public GameObject flower6;
    public GameObject flower7;
    public GameObject flower8;
    public GameObject displayFlower5;
    public GameObject displayFlower6;
    public GameObject displayFlower7;
    public GameObject displayFlower8;
    private float flowerDelay = 2.0f;
    public AudioSource soundSource, musicSource;
    public AudioClip music, slam, win, lose;
    public int soundStage;
    public SpriteRenderer result;
    public Sprite endSprite, winSprite, loseSprite;
    // Start is called before the first frame update
    void Start()
    {
        soundSource.clip = slam;
        soundSource.Play();
        musicSource.clip = music;
        musicSource.PlayDelayed(2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= 1.0f && Time.time < 1.1f)
        {
            if (soundStage == 0)
            {
                soundSource.Play();
                soundStage++;
            }
            textBody1.text = "But <b>DON'T</b> end up with an <b>EVEN</b> number of petals!\nPay attention!";
        }
        if (Time.time >= 2.0f && Time.time < 12.0f)
        {
            if (soundStage == 1)
            {
                soundSource.Play();
                soundStage++;
            }
            textTitle.text = "";
            textBody0.text = "";
            textCount.text = "Flowers Collected: " + PlayerController.Count.ToString();
            Destroy(displayFlower5);
            Destroy(displayFlower6);
            Destroy(displayFlower7);
            Destroy(displayFlower8);
            textTimer.text = Math.Ceiling((12f - Time.time)).ToString();
            textTimer.transform.Rotate(0f, 0f, (((Time.time % 1) - 0.5f) * Math.Sign((Time.time % 2) - 1)) * 2, Space.World);
        }
        if (Time.time >= 2.5f && Time.time < 12.0f)
        {
            textBody1.text = "";
        }
        if (Time.time >= 12.0f)
        {
            if (soundStage == 2)
            {
                soundSource.clip = slam;
                soundSource.Play();
                soundStage++;
            }
            textCount.text = "";
            textTimer.text = "";
            List<GameObject> destroyFlowers = new List<GameObject>(GameObject.FindGameObjectsWithTag("Collectible"));
            foreach(GameObject target in destroyFlowers)
            {
                Destroy(target);
            }
            result.sprite = endSprite;
            textTitle.text = "He Loves Me...";
            int count = PlayerController.Count;
            int petal = PlayerController.Petal;            
            if (count > 9)
            {
                textBody0.text = "You collected " + count.ToString() + " flowers!";
            }
            else if (petal % 2 == 1)
            {
                textBody0.text = "You had a total of " + petal.ToString() + " petals!";
            }
            else
            {
                textBody0.color = new Color(1, 0.2f, 0.2f);
                if (count == 0)
                {
                    textBody0.text = "You didn't get any flowers!";
                }
                else
                {
                    textBody0.text = "You only collected <b>" + count.ToString() + "</b> flower" + (count > 1 ? "s" : "") + "...";
                }
            }
        }
        if (Time.time >= 13.0f)
        {
            
            textBody1.fontSize = 20;
            int count = PlayerController.Count;
            int petal = PlayerController.Petal;
            if (count > 9 && petal % 2 == 1)
            {
                result.sprite = winSprite;
                textTitle.text += "!";
                textBody1.text = "And you had a total of " + petal.ToString() + " petals! Good job!";
                if (soundStage == 3)
                {
                    soundSource.clip = win;
                    soundSource.Play();
                    soundStage++;
                }
            }
            else if (count > 9 && petal % 2 == 0)
            {
                result.sprite = loseSprite;
                textTitle.text += " <b>NOT!</b>";
                textBody1.color = new Color(1, 0.2f, 0.2f);
                textBody1.text = "But you had a total of <b>" + petal.ToString() + "</b> petals!";
                if (soundStage == 3)
                {
                    soundSource.clip = lose;
                    soundSource.Play();
                    soundStage++;
                }
            }
            else if (petal % 2 == 1)
            {
                result.sprite = loseSprite;
                textTitle.text += " <b>NOT!</b>";
                textBody1.color = new Color(1, 0.2f, 0.2f);
                textBody1.text = "But you only grabbed <b>" + count.ToString() + "</b> flower" + (count > 1 ? "s" : "") + "...";
                if (soundStage == 3)
                {
                    soundSource.clip = lose;
                    soundSource.Play();
                    soundStage++;
                }
            }
            else
            {
                if (soundStage == 3)
                {
                    soundSource.clip = lose;
                    soundSource.Play();
                    soundStage++;
                }
                result.sprite = loseSprite;
                textTitle.text += " <b>NOT!</b>";
                textBody1.color = new Color(1, 0.2f, 0.2f);
                if (count == 0)
                {
                    textBody1.text = "<b><i>WAKE UP!</i></b>";
                }
                else
                {
                    textBody1.text = "And you had <b>" + petal.ToString() + "</b> petals.";
                }
            }
        }
        if (Time.time >= 15.0f)
        {
            Application.Quit();
        }

        if (flowerDelay < Time.time && Time.time < 12.0f)
        {
            SpawnFlowers();
        }
    }

    void SpawnFlowers()
    {
        flowerDelay += UnityEngine.Random.value * 0.3f;
        int flowerType = UnityEngine.Random.Range(0, 4);
        GameObject flowerChoice;
        switch (flowerType)
        {
            case 0:
                flowerChoice = flower5;
                break;
            case 1:
                flowerChoice = flower6;
                break;
            case 2:
                flowerChoice = flower7;
                break;
            case 3:
                flowerChoice = flower8;
                break;
            default:
                flowerChoice = flower5;
                break;
        }
        Instantiate(flowerChoice, new Vector3(UnityEngine.Random.value * 18f - 9, 5.5f), new Quaternion());
    }
}
