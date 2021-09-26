using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        /// <summary>The object that the AI should move to</summary>
        public Transform target;
        [SerializeField] GameObject mainrole2;
        IAstarAI ai;

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.

        }

        //void OnDisable()
        //{
        //   
        //}

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                mainrole2.transform.position = Input.mousePosition;
                target = mainrole2.transform;

                print(target.transform.position);
                if (ai != null) ai.onSearchPath += LateUpdate;
            }




            if (Mathf.Abs(transform.position.x - mainrole2.transform.position.x) <= 0.2f && Mathf.Abs(transform.position.y - mainrole2.transform.position.y) <= 0.2f)
            {
                print("����");
                if (ai != null) ai.onSearchPath -= LateUpdate;
            }


        }


        public void moveFun()
        {

        }

        private void LateUpdate()
        {
            print(1);
            if (target != null && ai != null) ai.destination = target.position;
            print(2);



        }


    }
}
