namespace VRTK.Examples
{
    using UnityEngine;

    public class InfoBubbles : MonoBehaviour
    {
      public VRTK_InteractableObject linkedObject;
      public GameObject title;
      public GameObject description;

      protected Transform obj;

      protected virtual void OnEnable()
      {
          description.SetActive(false);
          title.SetActive(false);
          linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed += InteractableObjectUsed;
              linkedObject.InteractableObjectUnused += InteractableObjectUnused;
          }

          obj = transform.Find("Capsule");
      }

      protected virtual void OnDisable()
      {
          if (linkedObject != null)
          {
              linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
              linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
          }
      }

      protected virtual void Update()
      {

      }

      protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
      {
          GameObject.Find("Game Manager").GetComponent<GameManager>().TurnOnTitle(title);
          GameObject.Find("Game Manager").GetComponent<GameManager>().TurnOnDescription(description);
          description.SetActive(true);
          title.SetActive(true);
      }

      protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
      {
          description.SetActive(false);
          title.SetActive(false);
      }
  }
}
