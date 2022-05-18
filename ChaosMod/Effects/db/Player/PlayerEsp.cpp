#include "stdafx.h"

static float rgb[3];

static const float maxDistance = 100.f;
static const float lineThicknes = 0.001f;

static bool WithinDistance(Ped from, Ped to)
{
	Vector3 fc = GET_ENTITY_COORDS(from, true);
	Vector3 tc = GET_ENTITY_COORDS(to, true);

	bool x = tc.x - fc.x < maxDistance || fc.x - tc.x > -maxDistance;
	bool y = tc.y - fc.y < maxDistance || fc.y - tc.y > -maxDistance;
	return x && y;
}

static void OnTick()
{
	static Ped playerPed = PLAYER_PED_ID();
	for (Ped ped : GetAllPeds())
	{
		if (!IS_ENTITY_ON_SCREEN(ped) || IS_ENTITY_DEAD(ped, false) || !DOES_ENTITY_EXIST(ped) || ped == playerPed || !WithinDistance(playerPed, ped))
			continue;

		Vector3 coords = GET_PED_BONE_COORDS(ped, 0x796E, 0.f, 0.f, 0.f);
		SET_DRAW_ORIGIN(coords.x, coords.y, coords.z, 0);
		DRAW_RECT(-0.019f, -0.015f, lineThicknes, 0.07f, rgb[0], rgb[1], rgb[2], 255, false); //Left line
		DRAW_RECT(0.019f, -0.015f, lineThicknes, 0.07f, rgb[0], rgb[1], rgb[2], 255, false); //Right Line
		DRAW_RECT(0.f, -0.050f, 0.038f, lineThicknes, rgb[0], rgb[1], rgb[2], 255, false); //Top Line
		DRAW_RECT(0.f, 0.02f, 0.038f, lineThicknes, rgb[0], rgb[1], rgb[2], 255, false); //Bottom Line
		CLEAR_DRAW_ORIGIN();
	}
}

static void OnStart()
{
	rgb[0] = g_Random.GetRandomInt(0, 255);
	rgb[1] = g_Random.GetRandomInt(0, 255);
	rgb[2] = g_Random.GetRandomInt(0, 255);
}

static RegisterEffect registerEffect(OnStart, nullptr, OnTick, EffectInfo
	{
		.Name = "ESP",
		.Id = "player_esp",
		.IsTimed = true,
		.IsShortDuration = true,
		.EffectGroupType = EEffectGroupType::Weapons
	}
);