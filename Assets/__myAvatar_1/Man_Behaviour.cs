using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Man_Behaviour : MonoBehaviour
{
    public int num_man;
    public SkinnedMeshRenderer face;//获取脸的贴图
    public Material material_;
    public Texture[] textures;

    public GameObject Particle;
    public Texture[] Particle_;
    private int count = 0;
    Animator animator_;
    //说的话
    public Text avatartext;
    public Text remetext;
    public String[] reme_name;

    public Man_Behaviour(Text avatartext) => this.avatartext = avatartext;

    void Start()
    {
        material_ = face.material;
        avatartext.text = "wellcome " + PlayerPrefs.GetString("userName", "you!") 
            + ", start your journey by right click the avatar.";
        animator_ =gameObject.GetComponent<Animator>();
        
        //Debug.Log("start" + PlayerPrefs.GetString("userName", "you!"));
        material_.mainTexture = textures[7];
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
    }
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
            Debug.Log(reme_name[num_man]);
            num_man = SimulateAnim();
            /*if (num_man > 10)
            {
                num_man = 0;
            }*/
            remetext.text = "remediation needs:" + reme_name[num_man];
            switch (num_man)
            {
                case 0://break
                    animator_.SetInteger("super_ID", 1);
                    avatartext.text = "Hey! " + PlayerPrefs.GetString("userName", "you!") + ", take a break, stretch your body!";
                    //remetext.text = speaking[0];
                    break;
                case 1://Ask the user to do another task
                    animator_.SetInteger("super_ID", 2);
                    avatartext.text = "Hey, "+PlayerPrefs.GetString("userName", "you") + " you should try another task!";
                    break;
                case 2://Ask user to exercise
                    animator_.SetInteger("super_ID", 3);
                    avatartext.text = "Come on " + PlayerPrefs.GetString("userName", "student") + ", some exercise might help you feel better!";
                    break;
                case 3://Ask the user to change their posture
                    animator_.SetInteger("super_ID", 2);
                    avatartext.text = "You should change your posture, "+ PlayerPrefs.GetString("userName", "their");
                    break;
                case 4://Ask the user to start working
                    animator_.SetInteger("super_ID", 5);
                    avatartext.text = "Yous should start working, you've been hanging around for hours!";
                    break;
                case 5://Ask user to change their workplace
                    animator_.SetInteger("super_ID", 4);
                    avatartext.text = "You might want to change your work place to " + PlayerPrefs.GetString("prefWorkplace", "classroom");
                    break;
                case 6://Remind the user of distractions
                    animator_.SetInteger("super_ID", 4);
                    avatartext.text = PlayerPrefs.GetString("userName", "Dude") + ", I think something is distracting you.";
                    break;
                case 7://Remind the user of the need for focus
                    animator_.SetInteger("super_ID", 5);
                    avatartext.text = "Hey hey hey!! Focus";
                    break;
                case 8://Remind the user of their learning goals
                    animator_.SetInteger("super_ID",2);
                    avatartext.text = PlayerPrefs.GetString("userName", "Hey student!") + " remember the goals you set for yourself?";
                    break;
                case 9://Chat with the user
                    animator_.SetInteger("super_ID", 6);
                    avatartext.text = PlayerPrefs.GetString("userName", "student")+", nice weather, right?";
                    break;
                case 10://Encourage user, show Empathy
                    animator_.SetInteger("super_ID", 7);
                    avatartext.text = "Hey! " + PlayerPrefs.GetString("userName", "you!") + " ,carry on, you are doing great.";
                    break;
                case 11://Be happy for your users
                    animator_.SetInteger("super_ID", 6);
                    avatartext.text = "Awosome work!";
                    break;
                case 12://Remind users to put down their phones
                    animator_.SetInteger("super_ID", 6);
                    avatartext.text = "I saw you playing your smart phone! Stop it!";
                    break;

            }
            Particle.SetActive(true);
            Invoke("backidle", 1);//延迟
            
        } 
    }
   public void backidle()
    {
        animator_.SetInteger("super_ID", 0);
        Particle.SetActive(false);
    }
    public int SimulateAnim()
    {
        int randAnim;
        System.Random rd = new System.Random();//伪随机数生成
        randAnim = rd.Next(12);//显示12以内的伪随机数
        Debug.Log(Convert.ToString(randAnim));
        //Debug.Log("succesfully created rand");
        return randAnim;
    }

    /// <summary>
    /// facial animation control
    /// </summary>
    public void Idleface3()
    {
        material_.mainTexture = textures[7];
    }
    public void Idleface2()
    {
        material_.mainTexture = textures[1];
    }
    public void Idleface1()
    {
        material_.mainTexture = textures[0];
    }
    public void Idleface()
    {
        material_.mainTexture = textures[2];
    }

    public void AngryFace()
    {
        material_.mainTexture = textures[9];
    }
    public void Bigsimle()
    {
        material_.mainTexture = textures[5];
    }

    // wink loop
    public void wink()
    {
        material_.mainTexture = textures[3];
        Invoke("wink1", 0.4F);
        //Debug.Log("succesfully created ticking");
    }
    public void wink1()
    {
        material_.mainTexture = textures[8];
        
    }

    //speak loop
    public void speak()
    {
        material_.mainTexture = textures[0];
        if (count < 8)
        {
            Invoke("speak1", 0.4F);
            count += 1;
        }else
        { count = 0; }
    }
    public void speak1()
    {
        material_.mainTexture = textures[1];
        if (count < 8)
        {
            Invoke("speak", 0.4F);
            count += 1;
        }else
        { count = 0; }
    }
    //single wink
    public void winkeye()
    {
        material_.mainTexture = textures[6];
    }
    //single mouse open
    public void mouseopen()
    {
        material_.mainTexture = textures[4];
    }
}
