
using System.Collections;
using UnityEngine;

public class SizeControl : MonoBehaviour
{
    private float isSize;

    [SerializeField] private GameObject Char;
    [SerializeField] private GameObject Character;
    [SerializeField] private ParticleSystem ParticleSystem_;

    [Header ("0-Normal, 1-Little, 2-Micro")]
    [SerializeField] private float[] ValuePowerSpeed;
    [SerializeField] private float[] ValuePowerJump;

    [SerializeField] private GameObject[] Buttons;

    bool isBlockSize;
    bool PrassButton;
    bool[] buttons = new bool[3];

    private void Start()
    {
        buttons[0] = true;
        isSize = 1f;
        MoveCharacter._checkRadius = 0.3f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "BlockSize")
        {
            isBlockSize = true;
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "BlockSize")
    //    {
    //        isBlockSize = false;
    //    }
    //}

    public void SizeNormal()
    {
        if (PrassButton == false)
        {
            PrassButton = true;
            ButtonPrass(0);
            ParticleSystem_.transform.localScale = new Vector2(1, 1);
            MoveCharacter._checkRadius = 0.3f;
            MoveCharacter._moveSpeed = ValuePowerSpeed[0];
            MoveCharacter._powerJump = ValuePowerJump[0];
            MoveCharacter._rigidbody2D.mass = 1.5f;
            MoveCharacter._rigidbody2D.gravityScale = 6f;
            StartCoroutine(TransformScale(1f));
            Char.tag = "NormalPlayer";
        }
    }

    public void SizeLittle()
    {
        if (PrassButton == false)
        {
            PrassButton = true;
            ButtonPrass(1);
            ParticleSystem_.transform.localScale = new Vector2(0.6f, 0.6f);
            MoveCharacter._checkRadius = 0.2f;
            MoveCharacter._moveSpeed = ValuePowerSpeed[1];
            MoveCharacter._powerJump = ValuePowerJump[1];
            MoveCharacter._rigidbody2D.mass = 1f;
            MoveCharacter._rigidbody2D.gravityScale = 4f;
            StartCoroutine(TransformScale(0.5f));
            Char.tag = "LittlePlayer";
        }
    }

    public void SizeMicro()
    {
        if (PrassButton == false)
        {
            PrassButton = true;
            ButtonPrass(2);
            ParticleSystem_.transform.localScale = new Vector2(0.3f, 0.3f);
            MoveCharacter._checkRadius = 0.1f;
            MoveCharacter._moveSpeed = ValuePowerSpeed[2];
            MoveCharacter._powerJump = ValuePowerJump[2];
            MoveCharacter._rigidbody2D.mass = 0.5f;
            MoveCharacter._rigidbody2D.gravityScale = 2f;
            StartCoroutine(TransformScale(0.2f));
            Char.tag = "MicroPlayer";
        }
    }

    private IEnumerator TransformScale(float valueSize)
    {
        isBlockSize = false;
        float SizeNow = isSize;
        if (isSize < valueSize)
        {
            while (isSize < valueSize && isBlockSize != true)
            {
                yield return new WaitForFixedUpdate();
                isSize += 0.02f;
                Character.GetComponent<Transform>().localScale = new Vector3(isSize, isSize, isSize);
            }

            if (isBlockSize == true)
            {
                if (SizeNow < 0.48f)
                {
                    PrassButton = false;
                    SizeMicro();
                }

                if (SizeNow >= 0.48f && SizeNow < 1f)
                {
                    PrassButton = false;
                    SizeLittle();
                }
            }
        }
        
        else
            while (isSize > valueSize)
            {
                yield return new WaitForFixedUpdate();
                isSize -= 0.02f;
                Character.GetComponent<Transform>().localScale = new Vector3(isSize, isSize, isSize);
            }

        PrassButton = false;
    }

    public void ButtonPrass(int button)
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (buttons[i] == true)
            {
                Buttons[i].GetComponent<Animation>().Play("Open button");
                buttons[i] = false;
            }

            if (i == button)
            {
                buttons[i] = true;
                Buttons[i].GetComponent<Animation>().Play("Close button");
            }
        }
    }
}
