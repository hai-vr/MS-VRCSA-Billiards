
#if !NOCHAT_ACTIVE
using UdonSharp;
#else
using UdonSharpBehaviour = NochatScript.NochatBehaviour;
using UdonBehaviourSyncMode = NochatScript.NochatBehaviourSyncMode;
using BehaviourSyncMode = NochatScript.NochatSyncMode;
#endif
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CueRackManager : UdonSharpBehaviour
{
    void Start()
    {
        
    }
}
