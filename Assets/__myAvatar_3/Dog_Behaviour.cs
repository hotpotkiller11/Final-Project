 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dog_Behaviour : MonoBehaviour
{
    private int num_dog;
    public GameObject Particle;
    public Texture[] Particle_;
    Animator animator_;
    //说的话
    public Text avatartext;
    public Text remetext;
    public String[] reme_name;

    public Dog_Behaviour(Text avatartext) => this.avatartext = avatartext;

    void Start()
    {
        
        avatartext.text = "wellcome " + PlayerPrefs.GetString("userName", "you!")
            + ", start your journey by right click the avatar.";
        animator_ = gameObject.GetComponent<Animator>();
        reme_name = new string[13] {
            "ask the user to take a break",
            "Ask the user to do another task",
            "Ask user to exercise",
            "Ask the user to change their posture",
            "Ask the user to start working" ,
            "Ask user to change their workplace",
            "Remind the user of distractions",
            "Remind the user of the need for focus",
            "Remind the user of their learning goals",
            "Chat with the user",
            "Encourage user, show Empathy",
            "Be happy for your users",
            "Remind users to put down their phones"
        };

        Debug.Log("starting: user " + PlayerPrefs.GetString("userName", "you!"));

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            num_dog = SimulateAnim();
            Debug.Log("dogdog space down");
            remetext.text = "remediation needs:"+reme_name[num_dog];
            switch (num_dog)
            {
                case 0://Ask user to take a break
                    animator_.SetInteger("DogControl", 4);
                    avatartext.text = " you look tired, take a walk with me!";
                    break;
                case 1://Ask the user to do another task
                    animator_.SetInteger("DogControl", 1);
                    avatartext.text = "Try another task, " + PlayerPrefs.GetString("userName", " ");
                    break;
                case 2://Ask user to exercise
                    animator_.SetInteger("DogControl", 3);
                    avatartext.text = "Hey " + PlayerPrefs.GetString("userName", "there") + ", get up and exercise";
                    break;
                case 3://change their posture
                    animator_.SetInteger("DogControl", 1);
                    avatartext.text = "Hey " + PlayerPrefs.GetString("userName", "there") + ", bad posture warning" ;
                    break;
                case 4://Ask the user to start working
                    animator_.SetInteger("DogControl", 2);
                    avatartext.text = "Hey " + PlayerPrefs.GetString("userName", "there") + ", you said you were going to work!";
                    break;
                case 5://Ask user to change their workplace
                    animator_.SetInteger("DogControl", 1);
                    avatartext.text = "Hey " + PlayerPrefs.GetString("userName", " ")+ " you should go to the "+ PlayerPrefs.GetString("prefWorkplace", "classroom");
                    break;
                case 6://Remind the user of distractions 
                    animator_.SetInteger("DogControl", 10);
                    avatartext.text = "I think something is distracting you";
                    break;
                case 7://Remind the user of the need for focus
                    animator_.SetInteger("DogControl", 2);
                    avatartext.text = "Dude, focus!";
                    break;
                case 8://Remind the user of their learning goals
                    animator_.SetInteger("DogControl", 1);
                    avatartext.text = "You still have work to do";
                    break;
                case 9://Chat with the user
                    animator_.SetInteger("DogControl", 5 );
                    avatartext.text = "Good weather!! ";
                    break;
                case 10://Encourage user, show Empathy
                    animator_.SetInteger("DogControl", 2);
                    avatartext.text = "It's okay " + PlayerPrefs.GetString("userName", "you!") + " we can do better next time.";
                    break;
                case 11://Be happy for your users
                    animator_.SetInteger("DogControl", 6);
                    avatartext.text = "Wooho!";
                    break;
                case 12:
                    animator_.SetInteger("DogControl", 2);
                    avatartext.text = "Put down your phone! You said you can control your self!";
                    break;
            }
            Particle.SetActive(true);
            Invoke("backidle", 0.5f);//延迟

        }
    }
    public void backidle()
    {
        animator_.SetInteger("DogControl", 0);
        Debug.Log("back to idle");
        Particle.SetActive(false);
    }
    public int SimulateAnim()
    {
        int randAnim;
        System.Random rd = new System.Random();//伪随机数生成
        randAnim = rd.Next(12);//显示12以内的伪随机数
        Debug.Log(Convert.ToString(randAnim));
        return randAnim;
    }

}
