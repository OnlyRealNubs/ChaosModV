#include <stdafx.h>

#include "Memory/Vehicle.h"

std::vector<Vehicle> vehiclesMap;

static void OnStart()
{
	vehiclesMap.clear();
}

static void OnTick()
{
	Vehicle veh = GET_VEHICLE_PED_IS_IN(PLAYER_PED_ID(), false);
	if (DOES_ENTITY_EXIST(veh))
	{
		Memory::SetVehicleWheelSize(veh, 1.5f);
		Memory::SetVehicleWheelWidth(veh, 1.5f);
		Memory::SetVehicleSusHeight(veh, -1.5f);

		if (std::find(vehiclesMap.begin(), vehiclesMap.end(), veh) == vehiclesMap.end())
		{
			//Without custom wheels, we can't set the scale
			SET_VEHICLE_MOD(veh, 23, g_Random.GetRandomInt(1, 50), true);
			SET_VEHICLE_WHEEL_TYPE(veh, 1);
			vehiclesMap.push_back(veh);
		}
	}
}

//	clang-format off
REGISTER_EFFECT(OnStart, nullptr, OnTick, EffectInfo
	{ 
		.Name = "_DBG",
		.Id = "_DBG_",
		.IsTimed = true
	}
);