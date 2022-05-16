#include <stdafx.h>

static const char* ms_szShaderSrc = R"SRC(
Texture2D HDRSampler : register(t5);
SamplerState g_samLinear : register(s5)
{
    Filter = MIN_MAG_MIP_LINEAR;
    AddressU = Wrap;
    AddressV = Wrap;
};

float4 main(float4 position	: SV_POSITION, float3 texcoord : TEXCOORD0, float4 color : COLOR0) : SV_Target0
{
    float4 col = HDRSampler.Sample(g_samLinear, texcoord);
    col.rgb = col.brg;

    return col;
}
)SRC";

static void OnStart()
{
    Hooks::OverrideScreenShader(ms_szShaderSrc);
}

static void OnStop()
{
    Hooks::ResetScreenShader();
}

static RegisterEffect registerEffect(EFFECT_MISC_INVERTEDCOLORS, OnStart, OnStop, EffectInfo
	{
		.Name = "Inverted Colors",
		.Id = "misc_invertedcolors",
		.IsTimed = true,
		.EffectCategory = EEffectCategory::Shader,
        .EffectGroupType = EEffectGroupType::Shader
	}
);