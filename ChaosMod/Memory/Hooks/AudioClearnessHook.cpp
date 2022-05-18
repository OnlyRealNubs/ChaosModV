#include "stdafx.h"

#include "Hook.h"

static bool ms_bEnabledHook = false;
static int ms_fValue = 0;

__int64(*_OG_rage__audRequestedSettings__SetClearness)(__int64 _this, __int64 pitch);
__int64 _HK_rage__audRequestedSettings__SetClearness(__int64 _this, __int64 pitch)
{
	return _OG_rage__audRequestedSettings__SetClearness(_this, ms_bEnabledHook ? ms_fValue : pitch);
}

static bool OnHook()
{
	Handle handle = Memory::FindPattern("E8 ? ? ? ? 83 64 24 ? ? 49 8B 8C 36 ? ? ? ? 45 33 C9");
	if (!handle.IsValid())
	{
		return false;
	}

	Memory::AddHook(handle.Into().Get<void>(), _HK_rage__audRequestedSettings__SetClearness, &_OG_rage__audRequestedSettings__SetClearness);

	return true;
}

static RegisterHook registerHook(OnHook, "rage__audRequestedSettings__SetClearness");

namespace Hooks
{
	void SetAudioClearness(int iValue)
	{
		ms_bEnabledHook = true;
		ms_fValue = iValue;
	}

	void ResetAudioClearness()
	{
		ms_bEnabledHook = false;
	}
}