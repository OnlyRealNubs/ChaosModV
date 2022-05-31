/*
	Effect By OnlyRealNubs
*/

#include <stdafx.h>

static std::string handlerModel = "handler";
static std::string floydModel = "ig_floyd";

static void OnStart()
{
	LoadModel(GET_HASH_KEY(handlerModel.c_str()));
	LoadModel(GET_HASH_KEY(floydModel.c_str()));

	static Ped player = PLAYER_PED_ID();
	Vector3 pos = GET_ENTITY_COORDS(player, true);	
	
	static Hash relationshipGroup;
	ADD_RELATIONSHIP_GROUP("_TOW_TRUCK_TONYA", &relationshipGroup);
	SET_RELATIONSHIP_BETWEEN_GROUPS(0, relationshipGroup, GET_HASH_KEY("PLAYER"));

	Vehicle handler = CreatePoolVehicle(GET_HASH_KEY(handlerModel.c_str()), pos.x, pos.y, pos.z, GET_ENTITY_HEADING(player));
	SET_VEHICLE_ENGINE_ON(handler, true, true, false);
	SET_VEHICLE_FORWARD_SPEED(handler, GET_ENTITY_SPEED(player));
	SET_VEHICLE_ON_GROUND_PROPERLY(handler, 5);

	Ped floyd = CreatePoolPedInsideVehicle(handler, 4, GET_HASH_KEY(floydModel.c_str()), -1);
	SET_PED_DEFAULT_COMPONENT_VARIATION(floyd);
	SET_PED_RELATIONSHIP_GROUP_HASH(floyd, relationshipGroup);

	SET_VEHICLE_AS_NO_LONGER_NEEDED(&handler);
	SET_PED_AS_NO_LONGER_NEEDED(&floyd);

	TASK_VEHICLE_DRIVE_TO_COORD_LONGRANGE(floyd, handler, -134.f, -2415.f, 6.f, 9999.f, 262668, 0.f);
}

// clang-format off
REGISTER_EFFECT(OnStart, nullptr, nullptr, EffectInfo
	{ 
		.Name = "Scouting The Port",
		.Id = "misc_scoutingport",
		.EffectGroupType = EEffectGroupType::SpawnGeneric
	}
);