#include <stdafx.h>

#include "Memory/Physics.h"

static std::vector<Hash> availablePropModels;
static const Hash weaponHash = GET_HASH_KEY("weapon_specialcarbine");

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

			// Don't include models that are too small
			if (modelSize > 0.4f)
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

		LOG("Creating Prop Step 2");

		SET_OBJECT_PHYSICS_PARAMS(prop, 100.f, 1.f, 1.f, 0.f, 0.f, .5f, 0.f, 0.f, 0.f, 0.f, 0.f);
		
		// Object needs to be shot at to be dynamic, otherwise it will be frozen (thank you Last0xygen)
		Vector3 min, max;
		GET_MODEL_DIMENSIONS(choosenPropHash, &min, &max);
		SHOOT_SINGLE_BULLET_BETWEEN_COORDS(spawnPos.x, spawnPos.y, spawnPos.z + max.z - min.z, spawnPos.x, spawnPos.y,
		                                   spawnPos.z, 1, true, weaponHash, 0, false, true, 0.01);

		Memory::ApplyForceToEntityCenterOfMass(prop, 0, 50.f, 0, -10000.f, true, false, true, true);		
		
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
		.Id = "misc_proprain",
		.IsTimed = true
	}
);