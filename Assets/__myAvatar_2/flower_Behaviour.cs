using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class flower_Behaviour : MonoBehaviour
{
   
    public int num_flower;
    public SkinnedMeshRenderer face_flower;//获取脸的贴图
    public Material material_flower;
    public Texture[] textures_flower;
    Animator animator_flower;
    public Text avatar2text;
    public GameObject Particle;

    public Text remetext;
    public String[] reme_name;

    // Start is called before the first frame update
    void Start()
    {
        animator_flower = GetComponent<Animator>();
        material_flower= face_flower.material;
        avatar2text.text = "wellcome " + PlayerPrefs.GetString("userName", "you!")
            + ", start your journey by right click the avatar.";
        Debug.Log("start");
        reme_name = new string[13] {
            "Ask user to exercise",
            "Encourage user, show Empathy",
            "Be happy for your users",
            "Ask user to take a break",
            "Remind the user of the need for focus" ,
            "Learning goals",
            "Ask user to change their workplace",
            "Chat with the user",
            "Do another task",
            "Start working",
            "Remind the user of the distraction",
            "Remind the user to change their posture",
            "Remind users to put down their phones"
        };
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            num_flower = SimulateAnim();
            remetext.text = "remediation needs:" + reme_name[num_flower];
            Debug.Log("num flower"+ num_flower);
            //material_flower.mainTexture = textures_flower[3  ];
            //animator_flower.Play(num_flower.ToString());
            switch (num_flower)
            {
                case 0://EXERCISE  Ask user to exercise
                    animator_flower.SetInteger("ActionID", 10);
                    avatar2text.text = "Some exercise might be good for you!Get up and do some jogging";
                    //material_flower.mainTexture = textures_flower[3];
                    break;
                case 1://ENCOURAGE Encourage user, show Empathy
                    animator_flower.SetInteger("ActionID", 2);
                    avatar2text.text = "I know ur tired, but don't give up!";
                    break;
                case 2://CHEER Be happy for your users
                    animator_flower.SetInteger("ActionID", 3);
                    avatar2text.text = "Welldone! I feel gooooooood!";
                    break;
                case 3://STRETCH Ask user to take a break
                    animator_flower.SetInteger("ActionID", 4);
                    avatar2text.text = "You should take a break!";
                    break;
                case 4://DYING Remind the user of the need for focus
                    animator_flower.SetInteger("ActionID", 5);
                    avatar2text.text = "You really need to focus, Im dying";
                    break;
                case 5://Learning goals
                    animator_flower.SetInteger("ActionID", 6);
                    avatar2text.text ="Hey "+ PlayerPrefs.GetString("userName", "their") + ", remember the goals you set for yourself?";
                    break;
                case 6://WONDER Ask user to change their workplace
                    animator_flower.SetInteger("ActionID", 7);
                    avatar2text.text = "Maybe you can be more productive working somewhere else. I recommend " + PlayerPrefs.GetString("prefWorkplace", "classroom") + "might be better";
                    break;
                case 7://chat
                    animator_flower.SetInteger("ActionID", 3);
                    avatar2text.text = "Nice Weather isn't it~";
                    break;
                case 8://do another task
                    animator_flower.SetInteger("ActionID", 7);
                    avatar2text.text = PlayerPrefs.GetString("userName", "hey!")+ ", you should switch your mind, try another task!";
                    break;
                case 9://start working
                    animator_flower.SetInteger("ActionID", 5);
                    avatar2text.text = PlayerPrefs.GetString("userName", "hey!") + ", you should start working right now! I'm about to die!";
                    break;
                case 10://distraction
                    animator_flower.SetInteger("ActionID", 7);
                    avatar2text.text = PlayerPrefs.GetString("userName", "hey!") + ", I'm sure something is distracting you";
                    break;
                case 11://change posture
                    animator_flower.SetInteger("ActionID", 7);
                    avatar2text.text = PlayerPrefs.GetString("userName", "hey!") + ", poor posture is bad for you!";
                    break;
                case 12://smart phone
                    animator_flower.SetInteger("ActionID", 7);
                    avatar2text.text = PlayerPrefs.GetString("userName", "hey!") + ", maybe you should put down your smartphone.";
                    break;
            }
            Particle.SetActive(true);
            Invoke("backidle", 1);//延迟
        }

    }
    public void backidle()
    {
        animator_flower.SetInteger("ActionID", 0);
        Particle.SetActive(false);
        //material_flower.mainTexture = textures_flower[3];
    }
    public int SimulateAnim()
    {
        int randAnim;
        System.Random rd = new System.Random();//伪随机数生成
        randAnim = rd.Next(12);//显示10以内的伪随机数
        Debug.Log("succesfully created rand" + randAnim);
        return randAnim;
    }
    public void Hearteye()
    {
        material_flower.mainTexture = textures_flower[0];
    }

    public void Worry()
    {
        material_flower.mainTexture = textures_flower[5];
    }

    public void Feelbad()
    {
        material_flower.mainTexture = textures_flower[2];
    }

    public void NormalFace()
    {
        material_flower.mainTexture = textures_flower[8];
    }
    public void NormalidleFace()
    {
        material_flower.mainTexture = textures_flower[3];
    }

    public void Dye()
    {
        material_flower.mainTexture = textures_flower[7];
    }

    public void Cry()
    {
        material_flower.mainTexture = textures_flower[9];
    }

    public void Stareyes()
    {
        material_flower.mainTexture = textures_flower[11];
    }

    public void Cheer()
    {
        material_flower.mainTexture = textures_flower[12];
    }
    public void wink()
    {
        material_flower.mainTexture = textures_flower[3];
        Invoke("wink1", 0.4F);
        Debug.Log("succesfully created ticking");
    }
    public void wink1()
    {
        //if (num_man == 8)
        {
            material_flower.mainTexture = textures_flower[8];
        }

    }
}
