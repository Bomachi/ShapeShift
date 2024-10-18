using System.Collections;
using UnityEngine;

public class CubefoldScript : MonoBehaviour{
    public Transform topPlane;
    public Transform bottomPlane;
    public Transform frontPlane;
    public Transform backPlane;
    public Transform leftPlane;
    public Transform rightPlane;

    public float foldDuration = 2.0f;

    private Vector3 topOriginalPos, bottomOriginalPos, frontOriginalPos, backOriginalPos, leftOriginalPos, rightOriginalPos;
    private Quaternion topOriginalRot, bottomOriginalRot, frontOriginalRot, backOriginalRot, leftOriginalRot, rightOriginalRot;

    void Start(){

        topOriginalPos = topPlane.position;
        bottomOriginalPos = bottomPlane.position;
        frontOriginalPos = frontPlane.position;
        backOriginalPos = backPlane.position;
        leftOriginalPos = leftPlane.position;
        rightOriginalPos = rightPlane.position;

        topOriginalRot = topPlane.rotation;
        bottomOriginalRot = bottomPlane.rotation;
        frontOriginalRot = frontPlane.rotation;
        backOriginalRot = backPlane.rotation;
        leftOriginalRot = leftPlane.rotation;
        rightOriginalRot = rightPlane.rotation;
    }

    public void FoldCube(){
        StartCoroutine(FoldRoutine());
    }

    public void UnfoldCube(){
        StartCoroutine(UnfoldRoutine());
    }

    IEnumerator FoldRoutine(){
        float elapsedTime = 0f;

        while (elapsedTime < foldDuration){
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / foldDuration;

            topPlane.position = Vector3.Lerp(topOriginalPos, new Vector3(0, 10, 0), t);
            topPlane.rotation = Quaternion.Lerp(topOriginalRot, Quaternion.Euler(90, 0, 0), t);

            bottomPlane.position = Vector3.Lerp(bottomOriginalPos, new Vector3(0, -1, 0), t);
            bottomPlane.rotation = Quaternion.Lerp(bottomOriginalRot, Quaternion.Euler(-90, 0, 0), t);

            frontPlane.position = Vector3.Lerp(frontOriginalPos, new Vector3(0, 0.5f, 0.5f), t);
            frontPlane.rotation = Quaternion.Lerp(frontOriginalRot, Quaternion.Euler(0, 0, 0), t);

            backPlane.position = Vector3.Lerp(backOriginalPos, new Vector3(0, -0.5f, -0.5f), t);
            backPlane.rotation = Quaternion.Lerp(backOriginalRot, Quaternion.Euler(0, 180, 0), t);

            leftPlane.position = Vector3.Lerp(leftOriginalPos, new Vector3(-0.5f, 0, -0.5f), t);
            leftPlane.rotation = Quaternion.Lerp(leftOriginalRot, Quaternion.Euler(0, 0, 90), t);

            rightPlane.position = Vector3.Lerp(rightOriginalPos, new Vector3(0.5f, 0, 0.5f), t);
            rightPlane.rotation = Quaternion.Lerp(rightOriginalRot, Quaternion.Euler(0, 0, -90), t);

            yield return null;
        }
    }

    IEnumerator UnfoldRoutine(){
        float elapsedTime = 0f;

        while (elapsedTime < foldDuration){
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / foldDuration;

            topPlane.position = Vector3.Lerp(new Vector3(0, 1, 0), topOriginalPos, t);
            topPlane.rotation = Quaternion.Lerp(Quaternion.Euler(90, 0, 0), topOriginalRot, t);

            bottomPlane.position = Vector3.Lerp(new Vector3(0, -1, 0), bottomOriginalPos, t);
            bottomPlane.rotation = Quaternion.Lerp(Quaternion.Euler(-90, 0, 0), bottomOriginalRot, t);

            // คลี่ front Plane กลับไป
            frontPlane.position = Vector3.Lerp(new Vector3(0, 0.5f, 0.5f), frontOriginalPos, t);
            frontPlane.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 0), frontOriginalRot, t);

            backPlane.position = Vector3.Lerp(new Vector3(0, -0.5f, -0.5f), backOriginalPos, t);
            backPlane.rotation = Quaternion.Lerp(Quaternion.Euler(0, 180, 0), backOriginalRot, t);

            leftPlane.position = Vector3.Lerp(new Vector3(-0.5f, 0, -0.5f), leftOriginalPos, t);
            leftPlane.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 90), leftOriginalRot, t);

            rightPlane.position = Vector3.Lerp(new Vector3(0.5f, 0, 0.5f), rightOriginalPos, t);
            rightPlane.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, -90), rightOriginalRot, t);

            yield return null;
        }
    }
}