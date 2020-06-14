using System.Collections;
using UnityEngine;

static class MonoBehaviourExtensions
{
    public static void MoveObject(this MonoBehaviour behaviour, GameObject obj, Vector3 target)
    {
        const float moveSpeed = 5f;
        behaviour.StartCoroutine(MoveRoutine());

        IEnumerator MoveRoutine()
        {
            while (obj.transform.position != target)
            {
                obj.transform.position =
                    Vector3.Lerp(obj.transform.position, target, Time.deltaTime * moveSpeed);

                yield return null;
            }
        }
    }
}
