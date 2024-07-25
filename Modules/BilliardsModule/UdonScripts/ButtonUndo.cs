
#if !NOCHAT_ACTIVE
using UdonSharp;
#else
using UdonSharpBehaviour = NochatScript.NochatBehaviour;
using UdonBehaviourSyncMode = NochatScript.NochatBehaviourSyncMode;
using BehaviourSyncMode = NochatScript.NochatSyncMode;
#endif
using UnityEngine;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class ButtonUndo : UdonSharpBehaviour
{
    [SerializeField] string methodName = "_Undo";
    [SerializeField] UdonSharpBehaviour script;

    public override void Interact()
    {
        script.SendCustomEvent(methodName);
    }
}
