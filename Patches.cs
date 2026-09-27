using HarmonyLib;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace SkipTOS
{
    [HarmonyPatch(typeof(LegalAgreements), "StartLegalAgreements")]
    static class Patch_LegalAgreements
    {
        static bool Prefix(LegalAgreements __instance, ref Task __result)
        {
            __result = Task.CompletedTask;
            return false;
        }
    }

    [HarmonyPatch(typeof(KIDAgeGate), "BeginAgeGate")]
    static class Patch_KIDAgeGate
    {
        static bool Prefix(KIDAgeGate __instance, ref Task __result)
        {
            __result = AutoFinish(__instance);
            return false;
        }

        static async Task AutoFinish(KIDAgeGate instance)
        {
            await Task.Yield();
            typeof(KIDAgeGate)
                .GetMethod("FinaliseAgeGateAndContinue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                ?.Invoke(instance, null);
        }
    }
}
