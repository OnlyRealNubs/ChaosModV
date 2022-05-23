#include <stdafx.h>

#include "Memory/Physics.h"

static std::vector<Hash> availablePropModels;

static void OnTick()
{
	static constexpr int MAX_PROPS   = 20;

	static Object props[MAX_PROPS] = {};
	static int propDespawnTime[MAX_PROPS];
	static int propAmount = 0;

	Vector3 playerPos        = GET_ENTITY_COORDS(PLAYER_PED_ID(), false);

	static DWORD64 lastTick  = 0;
	DWORD64 curTick          = GET_GAME_TIMER();

	if (lastTick < curTick - 1000 || availablePropModels.empty())
	{
		LOG("Refreshing available props");

		lastTick = curTick;

		availablePropModels.clear();

		for (Entity prop : GetAllProps())
		{
			Hash model = GET_ENTITY_MODEL(prop);
			Vector3 min, max;
			GET_MODEL_DIMENSIONS(model, &min, &max);
			float modelSize = (max - min).Length();

			// Don't include models that are either very small or very large
			if (modelSize > 0.3f && modelSize <= 6.f)
			{
				availablePropModels.push_back(model);
			}
		}
	}

	if (propAmount <= MAX_PROPS && curTick > lastTick + 200 && !availablePropModels.empty())
	{
		LOG("Creating Prop Step 1");
		lastTick = curTick;

		Vector3 spawnPos =
			Vector3::Init(playerPos.x + g_Random.GetRandomInt(-100, 100),
		                  playerPos.y + g_Random.GetRandomInt(-100, 100), playerPos.z + g_Random.GetRandomInt(25, 50));
		Hash choosenPropHash = availablePropModels.at(g_Random.GetRandomInt(0, 4));

		Object prop          = CreatePoolProp(choosenPropHash, spawnPos.x, spawnPos.y, spawnPos.z, false);
		propAmount++;

		SET_ENTITY_HAS_GRAVITY(prop, true);

		for (int i = 0; i < MAX_PROPS; i++)
		{
			Object &prop = props[i];
			if (!prop)
			{
				prop                 = prop;
				propDespawnTime[i] = 5;
				break;
			}
		}

		LOG("Creating Prop Step 2");

		SET_OBJECT_PHYSICS_PARAMS(prop, 100000.f, 1.f, 1.f, 0.f, 0.f, .5f, 0.f, 0.f, 0.f, 0.f, 0.f);
		ACTIVATE_PHYSICS(prop);
		SET_ACTIVATE_OBJECT_PHYSICS_AS_SOON_AS_IT_IS_UNFROZEN(prop, true);
		FREEZE_ENTITY_POSITION(prop, false);
		_0xCC6E963682533882(prop);
		APPLY_FORCE_TO_ENTITY_CENTER_OF_MASS(prop, 0, 50.f, 0, -10000.f, true, false, true, true);
		//Memory::ApplyForceToEntityCenterOfMass(prop, 0, 50.f, 0, -10000.f, true, false, true, true);

		SET_MODEL_AS_NO_LONGER_NEEDED(choosenPropHash);

		LOG("Creating Prop Step 4");

		LOG("Prop size: " << propAmount << " : " << availablePropModels.size());
	}

	static DWORD64 lastTick2 = 0;
	for (int i = 0; i < MAX_PROPS; i++)
	{
		Object &prop = props[i];
		if (prop)
		{
			if (DOES_ENTITY_EXIST(prop) && propDespawnTime[i] > 0)
			{
				Vector3 propPos = GET_ENTITY_COORDS(prop, false);
				if (GET_DISTANCE_BETWEEN_COORDS(playerPos.x, playerPos.y, playerPos.z, propPos.x, propPos.y, propPos.z,
				                                true)
				    < 400.f)
				{
					if (HAS_ENTITY_COLLIDED_WITH_ANYTHING(prop))
					{
						if (lastTick2 < curTick - 1000)
						{
							propDespawnTime[i]--;
						}
					}
					continue;
				}
			}

			propAmount--;

			SET_OBJECT_AS_NO_LONGER_NEEDED(&prop);

			LOG("Removing prop");

			prop = 0;
		}
	}

	if (lastTick2 < curTick - 1000)
	{
		lastTick2 = curTick;
	}
}

static void OnStop()
{
	availablePropModels.clear();
}

// clang-format off
REGISTER_EFFECT(nullptr, OnStop, OnTick, EffectInfo
	{
		.Name = "Prop Rain",
		.Id = "proprain",
		.IsTimed = true
	}
);