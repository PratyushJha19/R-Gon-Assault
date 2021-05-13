using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;// it is a package provided by unity standard assets to make game for all platforms and get input without keycode by setting the input in the UnityEngine
//by using it we can set the input in the UnityEngine for all platforms like PC, Mac, Play Station, and mobile. 

public class Player : MonoBehaviour
{
    [SerializeField] GameObject[] guns;//This is an array because we have to store multiple values in it.
    //It is of type GameObject because we have to store game object in it, in the Unity Editor.

    int[] testing = {0,1,2,3,4};

    [Header("Speed")]
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 70f;
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 70f;// Tooltip is a keyword used to declare the unit of the value of that variable.
    //here we have used the m/s unit with help of the Tooltip keyword. 
    [Header("Range")]//"Header" is a keyword used to Child the member variable into a topic, which we see in the Unity Editor.
    [Tooltip("In m")] [SerializeField] float xRange = 30f;
    [Tooltip("In m")] [SerializeField] float yRange = 20f;

    [SerializeField] float positionPitchFactorX = -0.5f;
    [SerializeField] float controlPitchFactorX = -20f;

    [SerializeField] float positionYawFactor = 0f;
    [SerializeField] float controlYawFactor = 20f;

    [SerializeField] float positionRollFactor = -0.5f;

    float xThrow;
    float yThrow;
    bool Control = true;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (Control)// this means if control is true apply the methods below or if control is false dont apply.(It is not explained properly yet) 
        {
            MoveLftNdRght();
            MoveUpNdDown();
            RotateUpNdDown();
            ProcessFiring();
        }
        TestingOutput();
    }

    void MoveLftNdRght()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");//here we have used GetAxis because we want GameObject to move in the spcified axis on an input.
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;//"transform.localPosition.x" means the local position of object in X axis. We can use it in the same way with Y and Z.
        float xClamp = Mathf.Clamp(rawXPos, -xRange, xRange);//Mathf.Clamp determines the range of movement of the game object. The game object stops moving when the game object reaches the clamp range.
        //We have to use three values in it first the value we have provided the game object to move and then the both the range value in which the object should move, it can be -ve and +ve, -ve and -ve, +ve and +ve.
        transform.localPosition = new Vector3(xClamp, transform.localPosition.y, transform.localPosition.z);
        //"transform.localPosition" it is the default position of the game object and here we are giving its new value as "Vector3" because of which it will change its position according to the value given.
    }
    void MoveUpNdDown()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float yClamp = Mathf.Clamp(rawYPos, -yRange, yRange);
        transform.localPosition = new Vector3(transform.localPosition.x, yClamp, transform.localPosition.z);
    }
    void RotateUpNdDown()
    {
        float pitch = transform.localPosition.y * positionPitchFactorX + yThrow * controlPitchFactorX;// X axis
        //in the above line we are determing that the value of pitch is equal to the position of object in y axis * positionPitchFactor(which is 7)
        // and the pitch is itself equal to the rotational value of X axis as we have used "transform.localRotation".  
        float yaw = transform.localPosition.x * positionYawFactor + xThrow * controlYawFactor;// Y axis
        float roll = transform.localPosition.x * positionRollFactor;// Z axis
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        //"Quaternion" is a keyword used to represent rotation of object in the X, Y, Z axes. It is the same as "Vector3" which we use to represent position value of object in X, Y, Z axis.
    }

    // TODO Rotate the player with CrossPlatformInput. 

    void OnPlayerDeath()
    {
        Control = false; 
    }

    void ProcessFiring()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))//here we have used GetButton because we want an action on an input
        {
            SetGunsActive(true);          //here we say as long as we hold the input button till then it will keep on executing the output.
        }

        else
        {
            SetGunsActive(false);
        }
    }

    void SetGunsActive(bool isActive)
    {
        foreach (GameObject gun in guns)
        {
            var emmissionModule = gun.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isActive;
        }
    }

    void TestingOutput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (int test in testing)
            {
                print(test);
            }
        }
    }
}




// {void ActiveGuns()
    // {
    // foreach (GameObject gun in guns)//"foreach" executes a statement in each element in it. Its use is to iterate(repetition of a process) the statement on the input.
    //{//the variable above will continously call(execute) the value of the array  as the output. 
    //"GameObject" is variable type, gun is variable name and guns is the array.
    // we use a variable because foreach asks for it and SetActive should be used with a variable.
    //  gun.SetActive(true); //the gun variable will hold the guns araay in it.
    //      }
    // }