#include <stdafx.h>
#include "./Memory/Hooks/AudioPitchHook.h"
#include "./Memory/PedModels.h"
#include <map>

static Vector3 ms_vDefaultMatrix;
static float ms_fScale = 3.f;
static const Hash UnarmedWepHash = "WEAPON_UNARMED"_hash;

static Cam cam; //Without a custom cam, we would see the players butt.
static float camZOffset = 2.f;

Vector3 ConvertToRadians(Vector3 rot)
{
	return Vector3::Init(rot.x * 3.14f / 180, rot.y * 3.14f / 180, rot.z * 3.14f / 180);
}

Vector3 RotationToDirection(Vector3 rot)
{
	auto rotZ   = (rot.z);
	auto rotX   = (rot.x);
	auto multXY = abs(cos(rotX));

	return Vector3::Init(-sin(rotZ) * multXY, cos(rotZ) * multXY, sin(rotX));
}

static int Dot(Vector3 a, Vector3 b)
{
	int p = 0;
	p     = p + a.x * b.x;
	p     = p + a.z * b.z;
	p     = p + a.y * b.y;
	return p;
}

Vector3 RelativeRightVector(Vector3 rot)
{
	auto num = cos(rot.y);
	Vector3 v {};
	v.x = cos(-rot.z) * num;
	v.y = sin(rot.z) * num;
	v.z = sin(-rot.y);
	return v;
}

Vector3 GetRelativeOffsetGivenWorldCoords(Vector3 position1, Vector3 position2, Vector3 rot)
{
	Vector3 right   = RelativeRightVector(rot);
	Vector3 forward = RotationToDirection(
	    rot); // Doing rot.DirectionForRotation() crashes the game. So use this custom function instead.

	return Vector3::Init(-1 * Dot(right, (position1 - position2)), -1 * Dot(forward, (position1 - position2)),
	                     position2.z - position1.z);
}

static bool VectorEquals(Vector3 vec1, Vector3 vec2)
{
	return abs(vec1.x - vec2.x) < 0.01f && abs(vec1.y - vec2.y) < 0.01f && abs(vec1.z - vec2.z) < 0.01f;
}

static void UpdateCam()
{
	SET_FOLLOW_PED_CAM_VIEW_MODE(2);
	SET_FOLLOW_VEHICLE_CAM_VIEW_MODE(2);
	SET_FOLLOW_VEHICLE_CAM_ZOOM_LEVEL(2);
	auto coord = CAM::GET_GAMEPLAY_CAM_COORD();
	auto rot = CAM::GET_GAMEPLAY_CAM_ROT(2);
	auto fov = CAM::GET_GAMEPLAY_CAM_FOV();
	CAM::SET_CAM_PARAMS(cam, coord.x, coord.y, coord.z + camZOffset, rot.x, rot.y, rot.z, 120, 700, 0, 0, 2);
}

static void OnStart()
{
	LOG("z");
	Ped playerPed = PLAYER_PED_ID();
	LOG("A");
	cam = CREATE_CAM("DEFAULT_SCRIPTED_CAMERA", 1);
	CAM::RENDER_SCRIPT_CAMS(true, true, 700, 1, 1, 1);
	LOG("b");
	Vector3 rightVector, upVector, forwardVector, position;
	GET_ENTITY_MATRIX(playerPed, &rightVector, &forwardVector, &upVector, &position);
	ms_vDefaultMatrix = Vector3(rightVector.Length(), forwardVector.Length(), upVector.Length());
	LOG("c");
	if (IS_PED_IN_ANY_VEHICLE(playerPed, true))
	{
		Vehicle veh = GET_VEHICLE_PED_IS_IN(playerPed, false);
		BRING_VEHICLE_TO_HALT(veh, 0.1f, 10, false);
		TASK_LEAVE_VEHICLE(playerPed, veh, 16);
	}
	LOG("d");
	SET_CURRENT_PED_WEAPON(playerPed, UnarmedWepHash, true);
	_SET_CAN_PED_EQUIP_ALL_WEAPONS(playerPed, false);
	Hooks::SetAudioPitch(g_Random.GetRandomInt(-900, -300));
	LOG("e");
}

static void OnTick()
{
	SET_EXPLOSIVE_MELEE_THIS_FRAME(PLAYER_ID());
	LOG("A");
	Ped playerPed = PLAYER_PED_ID();
	LOG("b");
	SET_CAM_ACTIVE(cam, true);
	UpdateCam();
	DISABLE_CONTROL_ACTION(0, 37, true);
	DISABLE_CONTROL_ACTION(0, 23, true);
	LOG("c");
	Vector3 rightVector, upVector, forwardVector, position;
	GET_ENTITY_MATRIX(playerPed, &rightVector, &forwardVector, &upVector, &position);
	Vector3 pedSize = Vector3(rightVector.Length(), forwardVector.Length(), upVector.Length());
	LOG("d");
	if (VectorEquals(ms_vDefaultMatrix, pedSize))
	{
		Memory::SetPedScale(playerPed, ms_fScale);
	}
	LOG("e");
	Hash curPedWep;
	GET_CURRENT_PED_WEAPON(playerPed, &curPedWep, true);
	if (curPedWep != UnarmedWepHash)
	{
		SET_CURRENT_PED_WEAPON(playerPed, UnarmedWepHash, true);
	}
	LOG("f");
	SET_PED_CAN_LEG_IK(playerPed, false);
	SET_PED_LEG_IK_MODE(playerPed, 1);
	_ENABLE_CROSSHAIR_THIS_FRAME();
	LOG("g");
}

static void OnStop()
{

	SET_CAM_ACTIVE(cam, false);
	CAM::RENDER_SCRIPT_CAMS(false, true, 700, 1, 1, 1);
	CAM::DESTROY_CAM(cam, true);
	cam = 0;

	_SET_CAN_PED_EQUIP_ALL_WEAPONS(PLAYER_PED_ID(), true);
	Hooks::ResetAudioPitch();
}

// clang-format off
REGISTER_EFFECT(OnStart, OnStop, OnTick, EffectInfo
	{
		.Name = "!megamike",
		.Id = "player_giant",
		.IsTimed = true,
	}
);