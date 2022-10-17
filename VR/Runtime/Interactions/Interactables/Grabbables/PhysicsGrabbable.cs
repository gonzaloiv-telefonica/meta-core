using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.Global;

namespace Meta.VR
{

    public class PhysicsGrabbable : GrabAndHoldBehaviour
    {

        private Rigidbody rb;
        private Collider col;

        private Rigidbody Rb => rb ??= GetComponent<Rigidbody>();
        private Collider Col => col ??= GetComponentInChildren<Collider>();
        private OVRInput.Controller OVRController => currentInteractor.hand.ToOVRController();

        protected override void OnSecondaryClick(InteractorBehaviour interactor)
        {
            base.OnSecondaryClick(interactor);
            Rb.isKinematic = true;
            Col.isTrigger = true;
        }

        protected override void OnSecondaryUnclick(InteractorBehaviour interactor)
        {
            Rb.isKinematic = false;
            Col.isTrigger = false;
            rb.Apply(GetRbVelocity());
            base.OnSecondaryUnclick(interactor);
        }

        public virtual RbVelocity GetRbVelocity()
        {
            OVRPose localPose = new OVRPose { position = OVRInput.GetLocalControllerPosition(OVRController), orientation = OVRInput.GetLocalControllerRotation(OVRController) };
            OVRPose offsetPose = new OVRPose { position = Vector3.zero, orientation = Quaternion.identity };
            localPose *= offsetPose;
            OVRPose trackingSpace = transform.ToOVRPose() * localPose.Inverse();
            Vector3 linearVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerVelocity(OVRController);
            Vector3 angularVelocity = trackingSpace.orientation * OVRInput.GetLocalControllerAngularVelocity(OVRController);
            return new RbVelocity(linearVelocity, angularVelocity);
        }

    }

}