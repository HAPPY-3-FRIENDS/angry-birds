using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slingshot2 : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    public Vector3 currentPosition;

    public float maxLength;

    public float bottomBoundary;

    public Ani1 animationSource;

    bool isMouseDown;
    bool creatingBird;
    bool isSkilled;

    int currentBird = 0;
    int totalBird = 12;

    float realDefend;

    public Bird[] birdPrefab =  new Bird[12];
    public GameObject[] pig = new GameObject[10];
    int pigCount = 10;

    bool endWin;

    public float birdPositionOffset;

    public int result;

    Bird bird;
    Rigidbody2D birdRb;
    Rigidbody2D checkDb;
    Collider2D birdCollider;

    Bird cloneBlueTop;
    Rigidbody2D cloneBlueTopRb;
    Bird cloneBlueBot;
    Rigidbody2D cloneBlueBotRb;

    public AudioSource audioBirdFly;
    public AudioSource audioBirdCreate;

    public float force;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        creatingBird = false;
        isSkilled = false;
        result = 0;

        BGAudio.instance.gameObject.GetComponent<AudioSource>().Stop();
    }

    IEnumerator CreateBird()
    {
        creatingBird = true;
        isSkilled = false;
        bird = Instantiate(birdPrefab[currentBird]);
        Bird_Defend birdDf = bird.GetComponent("Bird_Defend") as Bird_Defend;
        Bird_Defend birdDfOriginal = birdPrefab[currentBird].GetComponent("Bird_Defend") as Bird_Defend;
        birdDf.defend = birdDfOriginal.realDefend;
        birdRb = bird.GetComponent<Rigidbody2D>();
        birdCollider = birdRb.GetComponent<Collider2D>();

        birdCollider.enabled = false;
        birdRb.isKinematic = true;

        bird.gameObject.SetActive(false);

        ResetStrips();

        yield return new WaitForSeconds(1.5f);

        Destroy(birdPrefab[currentBird].gameObject);
        Instantiate(animationSource, birdPrefab[currentBird].gameObject.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(1);

        bird.gameObject.SetActive(true);
        audioBirdCreate.Play();

        /*ResetStrips();*/
        currentBird += 1;
        creatingBird = false;
    }

    // Update is called once per frame
    void Update()
    {
        endWin = true;
        for (int i = 0; i < pigCount; i++)
        {
            if(pig[i] != null)
            {
                endWin = false;
            }
        }

        if (endWin == true && currentBird <= 5)
        {
            result = 3;
        } else

        if (endWin == true && currentBird <= 9)
        {
            result = 2;
        } else

        if (endWin == true && currentBird <= 13)
        {
            result = 1;
        }

        if (bird == null && birdPrefab[totalBird-1] == null)
        {
            result = -1;
        }

        /*if (currentBird - 1 == 2)
        {
            birdPositionOffset = -0.4f;
        } else 
        if (currentBird - 1 == 4)
        {
            birdPositionOffset = -0.7f;
        } else
        {
            birdPositionOffset = -0.25f;
        }*/

        if (bird == null && creatingBird == false && currentBird < totalBird)
        {
            StartCoroutine(CreateBird());
        }

        /*if (Input.GetMouseButtonDown(0) && bird.isFly == true && isSkilled == false)
        {
            if (currentBird - 1 == 1)
            {
                isSkilled = true;
                YellowSkill();
            }

            if (currentBird - 1 == 2)
            {
                isSkilled = true;
                GreenSkill();
            }

            if (currentBird -1 == 3)
            {
                isSkilled = true;
                BlueSkill();
            }
        }*/


        if (isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition
                - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (birdCollider)
            {
                birdCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }
    }

    public void BlueSkill()
    {
        Vector3 vector1 = new Vector3(birdRb.transform.position.x, birdRb.transform.position.y + 0.5f, birdRb.transform.position.z);
        cloneBlueTop = Instantiate(bird, vector1, Quaternion.identity);
        cloneBlueTop.isFly = true;

        Vector3 vector2 = new Vector3(birdRb.transform.position.x, birdRb.transform.position.y - 0.5f, birdRb.transform.position.z);
        cloneBlueBot = Instantiate(bird, vector2, Quaternion.identity);
        cloneBlueBot.isFly = true;

        cloneBlueTopRb = cloneBlueTop.GetComponent<Rigidbody2D>();
        cloneBlueTopRb.velocity = new Vector2(birdRb.velocity.x, birdRb.velocity.y * 1.5f);

        cloneBlueBotRb = cloneBlueBot.GetComponent<Rigidbody2D>();
        cloneBlueBotRb.velocity = new Vector2(birdRb.velocity.x, birdRb.velocity.y * 0.5f);

        Instantiate(animationSource, birdRb.transform.position, Quaternion.identity);
    }

    public void GreenSkill()
    {
        Instantiate(animationSource, birdRb.transform.position, Quaternion.identity);
        birdRb.velocity = new Vector2(-birdRb.velocity.x * 1.5f, birdRb.velocity.y * 0.5f);
    }

    public void YellowSkill()
    {
        Instantiate(animationSource, birdRb.transform.position, Quaternion.identity);
        birdRb.velocity *= 2.2f;
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        currentPosition = idlePosition.position;
    }

    void Shoot()
    {
        birdRb.isKinematic = false;

        Vector3 birdForce = (currentPosition - center.position) * force * -1;
        birdRb.velocity = birdForce;
        audioBirdFly.Play();
        bird.isFly = true;

        /*birdRb = null;
        birdCollider = null;*/
    }

    void ResetStrips()
    {
        currentPosition = idlePosition.position;
        SetStrips(idlePosition.position);
    }

    void SetStrips(Vector3 position)
    {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (birdRb && bird.isFly == false)
        {
            Vector3 dir = position - center.position;
            birdRb.transform.position = position + dir.normalized * birdPositionOffset;
            birdRb.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        return vector;
    }
}
