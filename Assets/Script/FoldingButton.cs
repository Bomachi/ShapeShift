using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour{
    public CubefoldScript cubeScript;
    public Button foldButton;
    public Button unfoldButton;


    void Start(){
        foldButton.onClick.AddListener(FoldCube);
        unfoldButton.onClick.AddListener(UnfoldCube);
    }

    void FoldCube(){
        if (cubeScript != null)
        {
            cubeScript.FoldCube();
        }
    }

    void UnfoldCube(){
        if (cubeScript != null){
            cubeScript.UnfoldCube();
        }
    }
}