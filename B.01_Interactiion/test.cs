using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MetaFrame.Interaction
{
public class test : MonoBehaviour
{

    public void hover(){Debug.Log("hover");}
    public void unhover(){Debug.Log("unhover");}
    public void select(){Debug.Log("select");}
    public void unselect(){Debug.Log("unselect");}
    public void added(){Debug.Log("added");}
    public void removed(){Debug.Log("removed");}
    public void seladded(){Debug.Log("seladded");}
    public void selremoved(){Debug.Log("selremoved");}



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
}
