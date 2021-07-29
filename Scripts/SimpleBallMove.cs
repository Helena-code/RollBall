using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBallMove : MonoBehaviour
{
    [Range(10f, 1000f)]
    public float speed;
    public float speedCoefPink;
    public float speedCoefStiking;
    public Material pinkMat;
    public GameObject stickyArea;

    Rigidbody rb;
    Vector3 accelPosition;
    Vector3 movePosition;
    float speedCoefPinkCurrent;
    float speedCoefStikingCurrent;
    bool sticking;
    GameObject stickingGO;

    //Vector3 accelPosStart;
    //bool firststart = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movePosition = Vector3.zero;
        movePosition.y = transform.position.y;
        SetTheType();
        speedCoefStikingCurrent = 1f;
        //StartCoroutine(SetStartAccelPosition());
    }
    private void Start()
    {
        //StartCoroutine(PhoneRotationRecorder.SetStartAccelPosition());
    }
    private void Update()
    {
        //if (!firststart)
        //{

            accelPosition = Input.acceleration;
           

            if (!sticking)
            {
                // вертикальное положение телефона
                //movePosition.x = accelPosition.x;
                // movePosition.z = - accelPosition.z;

                // горизонтальное положение телефона
                movePosition.x = accelPosition.x- PhoneRotationRecorder.accelPosStart.x;
                movePosition.z = accelPosition.y- PhoneRotationRecorder.accelPosStart.y;
                

                if (movePosition.sqrMagnitude > 1)
                {
                    movePosition.Normalize();
                }
            }
            else
            {
                movePosition = stickingGO.transform.position - transform.position;
                movePosition.Normalize();
            }

            
            // movePosition *= Time.deltaTime;
            // transform.Translate(movePosition * speed);
            //rb.velocity = movePosition * speed;

            
        //}
    }

    private void FixedUpdate()
    {
        // разные варианты с физикой
        //rb.MovePosition(transform.position+ movePosition*speed*0.5f);
        //rb.AddForce(movePosition * speed * 100f);



        movePosition *= Time.fixedDeltaTime;
        rb.velocity = movePosition * speed * speedCoefPinkCurrent * speedCoefStikingCurrent;


        //transform.Translate(movePosition * speed);

    }

    public void BecomeSticky()
    {
        //GetComponent<Renderer>().material = pinkMat;
        //GetComponent<StickyBallMove>().enabled = true;
        //GetComponent<CurrentTypeOfBall>().typeOfBall = Types.typesOfBall.Pink;
        //Destroy(this);
        GetComponent<CurrentTypeOfBall>().typeOfBall = Types.typesOfBall.Pink;
        GetComponent<Renderer>().material = pinkMat;
        SetTheType();
    }

    public void GoTo(GameObject go)
    {
        sticking = true;
        stickingGO = go;
        speedCoefStikingCurrent = speedCoefStiking;
    }
    public void DoNotGo()
    {
        sticking = false;
        stickingGO = null;
        speedCoefStikingCurrent = 1f;
    }

    private void SetTheType()
    {
        switch (GetComponent<CurrentTypeOfBall>().typeOfBall)
        {
            case Types.typesOfBall.Yellow:
                speedCoefPinkCurrent = 1f;
                stickyArea.SetActive(false);
                break;
            case Types.typesOfBall.Pink:
                speedCoefPinkCurrent = speedCoefPink;
                stickyArea.SetActive(true);
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.GetComponent<CurrentTypeOfBall>() != null)
            {
                GameLogicManager.Instance.LoseLevel();
            }
        }
    }

    //TODO убрать энумератор положения телефона, когда настрою его при запуске игры
  //private IEnumerator SetStartAccelPosition()
  //  {
  //      yield return new WaitForSeconds(2);
  //      accelPosStart = Input.acceleration;
  //      Debug.Log("accelPosStart " + accelPosStart);
  //      firststart = false;
  //  }


}
