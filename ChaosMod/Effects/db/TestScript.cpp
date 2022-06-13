#include <stdafx.h>

#include "Memory/Vehicle.h"
#include "Util/Vehicle.h"

struct VehicleData
{
	float fRaise;
	float fWheelWidth;
	float fWheelSize;
};

std::map<Hash, VehicleData> vehiclesMap;

static const float fWheelScale = 1.8f;

static void OnStop()
{
	for (auto const &[model, data] : vehiclesMap)
	{
		LoadModel(model);
		Vehicle temp = CREATE_VEHICLE(model, 0.f, 0.f, 0.f, 0.f, true, false, false);

		Memory::SetVehicleRaise(temp, data.fRaise);
		Memory::SetVehicleWheelSize(temp, data.fWheelSize);
		Memory::SetVehicleWheelWidth(temp, data.fWheelWidth);

		//Need to change the wheels again for the size to take effect
		SET_VEHICLE_MOD(temp, 23, g_Random.GetRandomInt(0, 10), true);
		SET_VEHICLE_WHEEL_TYPE(temp, g_Random.GetRandomInt(0, 7));

		vehiclesMap.erase(model);
	}
	vehiclesMap.clear();
}

static void OnTick()
{
	for (Vehicle veh : GetAllVehs())
	{
		if (!vehiclesMap.contains(GET_ENTITY_MODEL(veh)))
		{
			// Without custom wheels, we can't set the scale/width
			SET_VEHICLE_MOD(veh, 23, g_Random.GetRandomInt(0, 10), true);
			SET_VEHICLE_WHEEL_TYPE(veh, g_Random.GetRandomInt(0, 7));

			float ogSize = Memory::GetVehicleWheelSize(veh), ogWidth = Memory::GetVehicleWheelWidth(veh);
			Memory::SetVehicleRaise(veh, 1.f);

			vehiclesMap.emplace(GET_ENTITY_MODEL(veh), VehicleData(0.f, ogWidth, ogSize));
		}

		Memory::SetVehicleTrackWidth(veh, 1.5f); // Has to be set every frame

		Memory::SetVehicleWheelSize(veh, fWheelScale);
		Memory::SetVehicleWheelWidth(veh, fWheelScale);
	}
}

//	clang-format off
REGISTER_EFFECT(nullptr, OnStop, OnTick, EffectInfo
	{ 
		.Name = "_MNSTR_TRUKS_",
		.Id = "vehs_monster_trucks",
		.IsTimed = true
	}
);