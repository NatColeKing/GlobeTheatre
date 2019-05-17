//Attach this script to a GameObject with an Animator component attached.
//For this example, create parameters in the Animator and name them “Crouch” and “Jump”
//Apply these parameters to your transitions between states

//This script allows you to trigger an Animator parameter and reset the other that could possibly still be active. Press the up and down arrow keys to do this.
namespace VRTK.Examples
{
  using UnityEngine;
  public class Gesture : MonoBehaviour
  {
      private Animator animator;

      void Start()
      {
          //Get the Animator attached to the GameObject you are intending to animate.
          animator = gameObject.GetComponent<Animator>();
      }

      public VRTK_InteractableObject linkedObject;
      // protected Transform obj;

      protected virtual void OnEnable()
      {
          linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed += InteractableObjectUsed;
              linkedObject.InteractableObjectUnused += InteractableObjectUnused;
          }

          // obj = transform.Find("Capsule");
      }

      protected virtual void OnDisable()
      {
          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
              linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
          }
      }

      protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
      {
        animator.SetTrigger("GestureTrigger");
      }

      protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
      {
      }
  }
}
