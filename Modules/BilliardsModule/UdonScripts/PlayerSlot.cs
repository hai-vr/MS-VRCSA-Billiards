
using System;
#if !NOCHAT_ACTIVE
using UdonSharp;
#else
using UdonSharpBehaviour = NochatScript.NochatBehaviour;
using UdonBehaviourSyncMode = NochatScript.NochatBehaviourSyncMode;
using BehaviourSyncMode = NochatScript.NochatSyncMode;
using Networking = NochatScript.NochatNetworking;
using UdonSynced = NochatScript.NochatSynced;
#endif
#if !NOCHAT_ACTIVE
using VRC.SDKBase;
#endif

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class PlayerSlot : UdonSharpBehaviour
{
    [UdonSynced][NonSerialized] public byte slot = byte.MaxValue;
    [UdonSynced][NonSerialized] public bool leave = false;
    private NetworkingManager networkingManager;

    public void _Init(NetworkingManager networkingManager_)
    {
        networkingManager = networkingManager_;
    }

    public void JoinSlot(int slot_)
    {
        if (slot_ > 3) return;
        slot = (byte)slot_;
        leave = false;
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        RequestSerialization();
        OnDeserialization();
    }

    public void LeaveSlot(int slot_)
    {
        if (slot_ > 3) return;
        slot = (byte)slot_;
        leave = true;
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        RequestSerialization();
        OnDeserialization();
    }

    public override void OnDeserialization()
    {
        if (networkingManager == null) return;
        if (slot > 3) return;

        networkingManager._OnPlayerSlotChanged(this);
    }
}
