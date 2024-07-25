
#if !NOCHAT_ACTIVE
using UdonSharp;
#else
using UdonSharpBehaviour = NochatScript.NochatBehaviour;
using UdonBehaviourSyncMode = NochatScript.NochatBehaviourSyncMode;
using BehaviourSyncMode = NochatScript.NochatSyncMode;
#endif
using UnityEngine;
#if !NOCHAT_ACTIVE
using VRC.SDKBase;
using VRC.Udon;
#endif

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class InfoBoard : UdonSharpBehaviour
{
    [SerializeField] private GameObject[] modify;
    [SerializeField] private Texture2D english;
    [SerializeField] private Texture2D japanese;

    public void SwitchToJP()
    {
        foreach (GameObject obj in modify)
        {
            obj.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", japanese);
        }
    }

    public void SwitchToEN()
    {
        foreach (GameObject obj in modify)
        {
            obj.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", english);
        }
    }
}
