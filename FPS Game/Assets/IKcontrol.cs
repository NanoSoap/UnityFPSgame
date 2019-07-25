using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKcontrol : MonoBehaviour
{
    public Transform lookat;
    public Transform trigger,butt,chest,lhint,rhint;
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnAnimatorIK(int layerIndex)
    {
        if (anim)
        {

            //if the IK is active, set the position and rotation directly to the goal. 


            // Set the look target position, if one has been assigned
            if (lookat != null)
            {
                anim.SetLookAtWeight(1f);
                anim.SetLookAtPosition(lookat.position);
            }

            // Set the right hand target position and rotation, if one has been assigned
            if (trigger != null)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                anim.SetIKPosition(AvatarIKGoal.RightHand, trigger.position);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, butt.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, trigger.rotation);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, butt.rotation);

                anim.bodyRotation = chest.rotation;

                anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow,1);
                anim.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1);
                anim.SetIKHintPosition(AvatarIKHint.LeftElbow, lhint.position);
                anim.SetIKHintPosition(AvatarIKHint.RightElbow, rhint.position);

            }


        }
    }
}

