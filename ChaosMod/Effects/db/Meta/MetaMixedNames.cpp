/*
	Effect By OnlyRealNubs
*/

#include <stdafx.h>

#include "Effects/MetaModifiers.h"

static void OnTick()
{
	MetaModifiers::m_bMixNames = true;
}

static void OnStop()
{
	MetaModifiers::m_bMixNames = false;
}

// clang-format off
REGISTER_EFFECT(nullptr, OnStop, OnTick, EffectInfo
	{
		.Name = "Guess Who",
		.Id = "meta_mixed_names",
		.IsTimed = true,
		.ExecutionType = EEffectExecutionType::Meta
	}
);