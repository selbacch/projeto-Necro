Shader "fire"
{
    Properties
    {
        [NoScaleOffset] Texture2D_1DEA466A("_MainTex", 2D) = "white" {}
        [HDR]Color_2FFD2910("Color", Color) = (59.01769, 18.53959, 0, 0)
        Vector1_513A17E5("distorçãoamount", Float) = 0
        Vector1_5FD77B36("dissolvescalle", Float) = 1.2
        Vector1_A1231BEA("dissolveamount", Float) = 1.2
        Vector2_C646D0BC("dissolvespeed", Vector) = (-0.1, -0.5, 0, 0)
        Vector1_FA1ECC98("dissolve scale", Float) = 2
        Vector2_2A63689("distorçãospeed", Vector) = (0, -0.1, 0, 0)
        Vector1_9C91A495("distorçãoscale", Float) = 0

        _StencilComp("Stencil Comparison", Float) = 8
         _Stencil("Stencil ID", Float) = 0
         _StencilOp("Stencil Operation", Float) = 0
         _StencilWriteMask("Stencil Write Mask", Float) = 255
         _StencilReadMask("Stencil Read Mask", Float) = 255

         _ColorMask("Color Mask", Float) = 15


        Vector1_9d8cdff47a2d4d8296101a44f8b8cd90("Vector1_9d8cdff47a2d4d8296101a44f8b8cd90", Float) = 0
        [HideInInspector][NoScaleOffset]unity_Lightmaps("unity_Lightmaps", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_LightmapsInd("unity_LightmapsInd", 2DArray) = "" {}
        [HideInInspector][NoScaleOffset]unity_ShadowMasks("unity_ShadowMasks", 2DArray) = "" {}
    }
        SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType" = "Transparent"
            "UniversalMaterialType" = "Lit"
            "Queue" = "Transparent"
        }
        Pass
        {
            Name "Sprite Lit"
            Tags
            {
                "LightMode" = "Universal2D"
            }

        // Render State
        Cull Off
    Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
        Cull Back
    ZTest[unity_GUIZTestMode]
    ZWrite Off
        //ColorMask:<None>
                Stencil{
            Ref[_Stencil]
            Comp[_StencilComp]
            Pass[_StencilOp]
            ReadMask[_StencilReadMask]
            WriteMask[_StencilWriteMask]
                    }
             ColorMask[_ColorMask]
         
         
        
        // Debug
        // <None>

        // --------------------------------------------------
        // Pass

        HLSLPROGRAM

        // Pragmas
        #pragma target 2.0
    #pragma exclude_renderers d3d11_9x
    #pragma vertex vert
    #pragma fragment frag

        // DotsInstancingOptions: <None>
        // HybridV1InjectedBuiltinProperties: <None>

        // Keywords
        #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_0
    #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_1
    #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_2
    #pragma multi_compile _ USE_SHAPE_LIGHT_TYPE_3
        // GraphKeywords: <None>

        // Defines
        #define _SURFACE_TYPE_TRANSPARENT 1
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_TEXCOORD0
        #define VARYINGS_NEED_COLOR
        #define VARYINGS_NEED_SCREENPOSITION
        #define FEATURES_GRAPH_VERTEX
        /* WARNING: $splice Could not find named fragment 'PassInstancing' */
        #define SHADERPASS SHADERPASS_SPRITELIT
        /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */

        // Includes
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/LightingUtility.hlsl"

        // --------------------------------------------------
        // Structs and Packing

        struct Attributes
    {
        float3 positionOS : POSITION;
        float3 normalOS : NORMAL;
        float4 tangentOS : TANGENT;
        float4 uv0 : TEXCOORD0;
        float4 color : COLOR;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : INSTANCEID_SEMANTIC;
        #endif
    };
    struct Varyings
    {
        float4 positionCS : SV_POSITION;
        float4 texCoord0;
        float4 color;
        float4 screenPosition;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : CUSTOM_INSTANCE_ID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
        #endif
    };
    struct SurfaceDescriptionInputs
    {
        float4 uv0;
        float3 TimeParameters;
    };
    struct VertexDescriptionInputs
    {
        float3 ObjectSpaceNormal;
        float3 ObjectSpaceTangent;
        float3 ObjectSpacePosition;
    };
    struct PackedVaryings
    {
        float4 positionCS : SV_POSITION;
        float4 interp0 : TEXCOORD0;
        float4 interp1 : TEXCOORD1;
        float4 interp2 : TEXCOORD2;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : CUSTOM_INSTANCE_ID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
        #endif
    };

        PackedVaryings PackVaryings(Varyings input)
    {
        PackedVaryings output;
        output.positionCS = input.positionCS;
        output.interp0.xyzw = input.texCoord0;
        output.interp1.xyzw = input.color;
        output.interp2.xyzw = input.screenPosition;
        #if UNITY_ANY_INSTANCING_ENABLED
        output.instanceID = input.instanceID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        output.cullFace = input.cullFace;
        #endif
        return output;
    }
    Varyings UnpackVaryings(PackedVaryings input)
    {
        Varyings output;
        output.positionCS = input.positionCS;
        output.texCoord0 = input.interp0.xyzw;
        output.color = input.interp1.xyzw;
        output.screenPosition = input.interp2.xyzw;
        #if UNITY_ANY_INSTANCING_ENABLED
        output.instanceID = input.instanceID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        output.cullFace = input.cullFace;
        #endif
        return output;
    }

    // --------------------------------------------------
    // Graph

    // Graph Properties
    CBUFFER_START(UnityPerMaterial)
float4 Texture2D_1DEA466A_TexelSize;
half4 Color_2FFD2910;
half Vector1_513A17E5;
half Vector1_5FD77B36;
half Vector1_A1231BEA;
half2 Vector2_C646D0BC;
half Vector1_FA1ECC98;
half2 Vector2_2A63689;
half Vector1_9C91A495;
half Vector1_9d8cdff47a2d4d8296101a44f8b8cd90;
CBUFFER_END

// Object and Global properties
SAMPLER(SamplerState_Linear_Repeat);
TEXTURE2D(Texture2D_1DEA466A);
SAMPLER(samplerTexture2D_1DEA466A);

// Graph Functions

void Unity_Multiply_half(half2 A, half2 B, out half2 Out)
{
    Out = A * B;
}

void Unity_TilingAndOffset_half(half2 UV, half2 Tiling, half2 Offset, out half2 Out)
{
    Out = UV * Tiling + Offset;
}


half2 Unity_GradientNoise_Dir_half(half2 p)
{
    // Permutation and hashing used in webgl-nosie goo.gl/pX7HtC
    p = p % 289;
    // need full precision, otherwise half overflows when p > 1
    float x = float(34 * p.x + 1) * p.x % 289 + p.y;
    x = (34 * x + 1) * x % 289;
    x = frac(x / 41) * 2 - 1;
    return normalize(half2(x - floor(x + 0.5), abs(x) - 0.5));
}

void Unity_GradientNoise_half(half2 UV, half Scale, out half Out)
{
    half2 p = UV * Scale;
    half2 ip = floor(p);
    half2 fp = frac(p);
    half d00 = dot(Unity_GradientNoise_Dir_half(ip), fp);
    half d01 = dot(Unity_GradientNoise_Dir_half(ip + half2(0, 1)), fp - half2(0, 1));
    half d10 = dot(Unity_GradientNoise_Dir_half(ip + half2(1, 0)), fp - half2(1, 0));
    half d11 = dot(Unity_GradientNoise_Dir_half(ip + half2(1, 1)), fp - half2(1, 1));
    fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
    Out = lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x) + 0.5;
}

void Unity_Lerp_half4(half4 A, half4 B, half4 T, out half4 Out)
{
    Out = lerp(A, B, T);
}


inline half2 Unity_Voronoi_RandomVector_half(half2 UV, half offset)
{
    half2x2 m = half2x2(15.27, 47.63, 99.41, 89.98);
    UV = frac(sin(mul(UV, m)));
    return half2(sin(UV.y * +offset) * 0.5 + 0.5, cos(UV.x * offset) * 0.5 + 0.5);
}

void Unity_Voronoi_half(half2 UV, half AngleOffset, half CellDensity, out half Out, out half Cells)
{
    half2 g = floor(UV * CellDensity);
    half2 f = frac(UV * CellDensity);
    half t = 8.0;
    half3 res = half3(8.0, 0.0, 0.0);

    for (int y = -1; y <= 1; y++)
    {
        for (int x = -1; x <= 1; x++)
        {
            half2 lattice = half2(x,y);
            half2 offset = Unity_Voronoi_RandomVector_half(lattice + g, AngleOffset);
            half d = distance(lattice + offset, f);

            if (d < res.x)
            {
                res = half3(d, offset.x, offset.y);
                Out = res.x;
                Cells = res.y;
            }
        }
    }
}

void Unity_Power_half(half A, half B, out half Out)
{
    Out = pow(A, B);
}

void Unity_Multiply_half(half A, half B, out half Out)
{
    Out = A * B;
}

void Unity_Multiply_half(half4 A, half4 B, out half4 Out)
{
    Out = A * B;
}

// Graph Vertex
struct VertexDescription
{
    half3 Position;
    half3 Normal;
    half3 Tangent;
};

VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
{
    VertexDescription description = (VertexDescription)0;
    description.Position = IN.ObjectSpacePosition;
    description.Normal = IN.ObjectSpaceNormal;
    description.Tangent = IN.ObjectSpaceTangent;
    return description;
}

// Graph Pixel
struct SurfaceDescription
{
    half3 BaseColor;
    half Alpha;
    half4 SpriteMask;
};

SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
{
    SurfaceDescription surface = (SurfaceDescription)0;
    half4 _Property_81cad936ff5a8387a368e496adbd9e8d_Out_0 = IsGammaSpace() ? LinearToSRGB(Color_2FFD2910) : Color_2FFD2910;
    UnityTexture2D _Property_c75efda14cf48b8f8c473b7010b824f4_Out_0 = UnityBuildTexture2DStructNoScale(Texture2D_1DEA466A);
    half4 _UV_2d78784b1be08885a74c57a69c16f29d_Out_0 = IN.uv0;
    half2 _Property_7c312fdf0080ff80ab5def9b29e23884_Out_0 = Vector2_2A63689;
    half2 _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2;
    Unity_Multiply_half((IN.TimeParameters.x.xx), _Property_7c312fdf0080ff80ab5def9b29e23884_Out_0, _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2);
    half2 _TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3;
    Unity_TilingAndOffset_half(IN.uv0.xy, half2 (1, 1), _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2, _TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3);
    half _Property_a98ea410d15f0a83860d9771b1fc6b84_Out_0 = Vector1_9C91A495;
    half _GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2;
    Unity_GradientNoise_half(_TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3, _Property_a98ea410d15f0a83860d9771b1fc6b84_Out_0, _GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2);
    half _Property_4c77ca82f0fbe787bb473d879fdade21_Out_0 = Vector1_513A17E5;
    half4 _Lerp_278354e1b8749981959144aa87c5b3b2_Out_3;
    Unity_Lerp_half4(_UV_2d78784b1be08885a74c57a69c16f29d_Out_0, (_GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2.xxxx), (_Property_4c77ca82f0fbe787bb473d879fdade21_Out_0.xxxx), _Lerp_278354e1b8749981959144aa87c5b3b2_Out_3);
    half4 _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0 = SAMPLE_TEXTURE2D(_Property_c75efda14cf48b8f8c473b7010b824f4_Out_0.tex, _Property_c75efda14cf48b8f8c473b7010b824f4_Out_0.samplerstate, (_Lerp_278354e1b8749981959144aa87c5b3b2_Out_3.xy));
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_R_4 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.r;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_G_5 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.g;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_B_6 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.b;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_A_7 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.a;
    half2 _Property_3e5ec6e7f730f68fad4f88166b52fe2b_Out_0 = Vector2_C646D0BC;
    half2 _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2;
    Unity_Multiply_half((IN.TimeParameters.x.xx), _Property_3e5ec6e7f730f68fad4f88166b52fe2b_Out_0, _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2);
    half2 _TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3;
    Unity_TilingAndOffset_half(IN.uv0.xy, half2 (1, 1), _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2, _TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3);
    half _Property_16aca43bd4a523838b4f761bd9f4c2ca_Out_0 = Vector1_FA1ECC98;
    half _Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3;
    half _Voronoi_e10929a14a87048a9eecbfc7564c4905_Cells_4;
    Unity_Voronoi_half(_TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3, 2, _Property_16aca43bd4a523838b4f761bd9f4c2ca_Out_0, _Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3, _Voronoi_e10929a14a87048a9eecbfc7564c4905_Cells_4);
    half _Property_ed3556ffdfba828f97197527de49d22a_Out_0 = Vector1_A1231BEA;
    half _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2;
    Unity_Power_half(_Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3, _Property_ed3556ffdfba828f97197527de49d22a_Out_0, _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2);
    half _Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2;
    Unity_Multiply_half(_GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2, _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2, _Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2);
    half4 _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2;
    Unity_Multiply_half(_SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0, (_Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2.xxxx), _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2);
    half4 _Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2;
    Unity_Multiply_half(_Property_81cad936ff5a8387a368e496adbd9e8d_Out_0, _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2, _Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2);
    surface.BaseColor = (_Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2.xyz);
    surface.Alpha = (_Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2).x;
    surface.SpriteMask = IsGammaSpace() ? half4(1, 1, 1, 1) : half4 (SRGBToLinear(half3(1, 1, 1)), 1);
    return surface;
}

// --------------------------------------------------
// Build Graph Inputs

VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
{
    VertexDescriptionInputs output;
    ZERO_INITIALIZE(VertexDescriptionInputs, output);

    output.ObjectSpaceNormal = input.normalOS;
    output.ObjectSpaceTangent = input.tangentOS.xyz;
    output.ObjectSpacePosition = input.positionOS;

    return output;
}
    SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
{
    SurfaceDescriptionInputs output;
    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);





    output.uv0 = input.texCoord0;
    output.TimeParameters = _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
#if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
#define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
#else
#define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
#endif
#undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN

    return output;
}

    // --------------------------------------------------
    // Main

    #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteLitPass.hlsl"

    ENDHLSL
}
Pass
{
    Name "Sprite Normal"
    Tags
    {
        "LightMode" = "NormalsRendering"
    }

        // Render State
        Cull Off
    Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
    ZTest LEqual
    ZWrite Off

        // Debug
        // <None>

        // --------------------------------------------------
        // Pass

        HLSLPROGRAM

        // Pragmas
        #pragma target 2.0
    #pragma exclude_renderers d3d11_9x
    #pragma vertex vert
    #pragma fragment frag

        // DotsInstancingOptions: <None>
        // HybridV1InjectedBuiltinProperties: <None>

        // Keywords
        // PassKeywords: <None>
        // GraphKeywords: <None>

        // Defines
        #define _SURFACE_TYPE_TRANSPARENT 1
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define VARYINGS_NEED_NORMAL_WS
        #define VARYINGS_NEED_TANGENT_WS
        #define VARYINGS_NEED_TEXCOORD0
        #define FEATURES_GRAPH_VERTEX
        /* WARNING: $splice Could not find named fragment 'PassInstancing' */
        #define SHADERPASS SHADERPASS_SPRITENORMAL
        /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */

        // Includes
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/Shaders/2D/Include/NormalsRenderingShared.hlsl"

        // --------------------------------------------------
        // Structs and Packing

        struct Attributes
    {
        float3 positionOS : POSITION;
        float3 normalOS : NORMAL;
        float4 tangentOS : TANGENT;
        float4 uv0 : TEXCOORD0;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : INSTANCEID_SEMANTIC;
        #endif
    };
    struct Varyings
    {
        float4 positionCS : SV_POSITION;
        float3 normalWS;
        float4 tangentWS;
        float4 texCoord0;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : CUSTOM_INSTANCE_ID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
        #endif
    };
    struct SurfaceDescriptionInputs
    {
        float3 TangentSpaceNormal;
        float4 uv0;
        float3 TimeParameters;
    };
    struct VertexDescriptionInputs
    {
        float3 ObjectSpaceNormal;
        float3 ObjectSpaceTangent;
        float3 ObjectSpacePosition;
    };
    struct PackedVaryings
    {
        float4 positionCS : SV_POSITION;
        float3 interp0 : TEXCOORD0;
        float4 interp1 : TEXCOORD1;
        float4 interp2 : TEXCOORD2;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : CUSTOM_INSTANCE_ID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
        #endif
    };

        PackedVaryings PackVaryings(Varyings input)
    {
        PackedVaryings output;
        output.positionCS = input.positionCS;
        output.interp0.xyz = input.normalWS;
        output.interp1.xyzw = input.tangentWS;
        output.interp2.xyzw = input.texCoord0;
        #if UNITY_ANY_INSTANCING_ENABLED
        output.instanceID = input.instanceID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        output.cullFace = input.cullFace;
        #endif
        return output;
    }
    Varyings UnpackVaryings(PackedVaryings input)
    {
        Varyings output;
        output.positionCS = input.positionCS;
        output.normalWS = input.interp0.xyz;
        output.tangentWS = input.interp1.xyzw;
        output.texCoord0 = input.interp2.xyzw;
        #if UNITY_ANY_INSTANCING_ENABLED
        output.instanceID = input.instanceID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        output.cullFace = input.cullFace;
        #endif
        return output;
    }

    // --------------------------------------------------
    // Graph

    // Graph Properties
    CBUFFER_START(UnityPerMaterial)
float4 Texture2D_1DEA466A_TexelSize;
half4 Color_2FFD2910;
half Vector1_513A17E5;
half Vector1_5FD77B36;
half Vector1_A1231BEA;
half2 Vector2_C646D0BC;
half Vector1_FA1ECC98;
half2 Vector2_2A63689;
half Vector1_9C91A495;
half Vector1_9d8cdff47a2d4d8296101a44f8b8cd90;
CBUFFER_END

// Object and Global properties
SAMPLER(SamplerState_Linear_Repeat);
TEXTURE2D(Texture2D_1DEA466A);
SAMPLER(samplerTexture2D_1DEA466A);

// Graph Functions

void Unity_Multiply_half(half2 A, half2 B, out half2 Out)
{
    Out = A * B;
}

void Unity_TilingAndOffset_half(half2 UV, half2 Tiling, half2 Offset, out half2 Out)
{
    Out = UV * Tiling + Offset;
}


half2 Unity_GradientNoise_Dir_half(half2 p)
{
    // Permutation and hashing used in webgl-nosie goo.gl/pX7HtC
    p = p % 289;
    // need full precision, otherwise half overflows when p > 1
    float x = float(34 * p.x + 1) * p.x % 289 + p.y;
    x = (34 * x + 1) * x % 289;
    x = frac(x / 41) * 2 - 1;
    return normalize(half2(x - floor(x + 0.5), abs(x) - 0.5));
}

void Unity_GradientNoise_half(half2 UV, half Scale, out half Out)
{
    half2 p = UV * Scale;
    half2 ip = floor(p);
    half2 fp = frac(p);
    half d00 = dot(Unity_GradientNoise_Dir_half(ip), fp);
    half d01 = dot(Unity_GradientNoise_Dir_half(ip + half2(0, 1)), fp - half2(0, 1));
    half d10 = dot(Unity_GradientNoise_Dir_half(ip + half2(1, 0)), fp - half2(1, 0));
    half d11 = dot(Unity_GradientNoise_Dir_half(ip + half2(1, 1)), fp - half2(1, 1));
    fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
    Out = lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x) + 0.5;
}

void Unity_Lerp_half4(half4 A, half4 B, half4 T, out half4 Out)
{
    Out = lerp(A, B, T);
}


inline half2 Unity_Voronoi_RandomVector_half(half2 UV, half offset)
{
    half2x2 m = half2x2(15.27, 47.63, 99.41, 89.98);
    UV = frac(sin(mul(UV, m)));
    return half2(sin(UV.y * +offset) * 0.5 + 0.5, cos(UV.x * offset) * 0.5 + 0.5);
}

void Unity_Voronoi_half(half2 UV, half AngleOffset, half CellDensity, out half Out, out half Cells)
{
    half2 g = floor(UV * CellDensity);
    half2 f = frac(UV * CellDensity);
    half t = 8.0;
    half3 res = half3(8.0, 0.0, 0.0);

    for (int y = -1; y <= 1; y++)
    {
        for (int x = -1; x <= 1; x++)
        {
            half2 lattice = half2(x,y);
            half2 offset = Unity_Voronoi_RandomVector_half(lattice + g, AngleOffset);
            half d = distance(lattice + offset, f);

            if (d < res.x)
            {
                res = half3(d, offset.x, offset.y);
                Out = res.x;
                Cells = res.y;
            }
        }
    }
}

void Unity_Power_half(half A, half B, out half Out)
{
    Out = pow(A, B);
}

void Unity_Multiply_half(half A, half B, out half Out)
{
    Out = A * B;
}

void Unity_Multiply_half(half4 A, half4 B, out half4 Out)
{
    Out = A * B;
}

// Graph Vertex
struct VertexDescription
{
    half3 Position;
    half3 Normal;
    half3 Tangent;
};

VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
{
    VertexDescription description = (VertexDescription)0;
    description.Position = IN.ObjectSpacePosition;
    description.Normal = IN.ObjectSpaceNormal;
    description.Tangent = IN.ObjectSpaceTangent;
    return description;
}

// Graph Pixel
struct SurfaceDescription
{
    half3 BaseColor;
    half Alpha;
    half3 NormalTS;
};

SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
{
    SurfaceDescription surface = (SurfaceDescription)0;
    half4 _Property_81cad936ff5a8387a368e496adbd9e8d_Out_0 = IsGammaSpace() ? LinearToSRGB(Color_2FFD2910) : Color_2FFD2910;
    UnityTexture2D _Property_c75efda14cf48b8f8c473b7010b824f4_Out_0 = UnityBuildTexture2DStructNoScale(Texture2D_1DEA466A);
    half4 _UV_2d78784b1be08885a74c57a69c16f29d_Out_0 = IN.uv0;
    half2 _Property_7c312fdf0080ff80ab5def9b29e23884_Out_0 = Vector2_2A63689;
    half2 _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2;
    Unity_Multiply_half((IN.TimeParameters.x.xx), _Property_7c312fdf0080ff80ab5def9b29e23884_Out_0, _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2);
    half2 _TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3;
    Unity_TilingAndOffset_half(IN.uv0.xy, half2 (1, 1), _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2, _TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3);
    half _Property_a98ea410d15f0a83860d9771b1fc6b84_Out_0 = Vector1_9C91A495;
    half _GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2;
    Unity_GradientNoise_half(_TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3, _Property_a98ea410d15f0a83860d9771b1fc6b84_Out_0, _GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2);
    half _Property_4c77ca82f0fbe787bb473d879fdade21_Out_0 = Vector1_513A17E5;
    half4 _Lerp_278354e1b8749981959144aa87c5b3b2_Out_3;
    Unity_Lerp_half4(_UV_2d78784b1be08885a74c57a69c16f29d_Out_0, (_GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2.xxxx), (_Property_4c77ca82f0fbe787bb473d879fdade21_Out_0.xxxx), _Lerp_278354e1b8749981959144aa87c5b3b2_Out_3);
    half4 _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0 = SAMPLE_TEXTURE2D(_Property_c75efda14cf48b8f8c473b7010b824f4_Out_0.tex, _Property_c75efda14cf48b8f8c473b7010b824f4_Out_0.samplerstate, (_Lerp_278354e1b8749981959144aa87c5b3b2_Out_3.xy));
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_R_4 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.r;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_G_5 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.g;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_B_6 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.b;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_A_7 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.a;
    half2 _Property_3e5ec6e7f730f68fad4f88166b52fe2b_Out_0 = Vector2_C646D0BC;
    half2 _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2;
    Unity_Multiply_half((IN.TimeParameters.x.xx), _Property_3e5ec6e7f730f68fad4f88166b52fe2b_Out_0, _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2);
    half2 _TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3;
    Unity_TilingAndOffset_half(IN.uv0.xy, half2 (1, 1), _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2, _TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3);
    half _Property_16aca43bd4a523838b4f761bd9f4c2ca_Out_0 = Vector1_FA1ECC98;
    half _Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3;
    half _Voronoi_e10929a14a87048a9eecbfc7564c4905_Cells_4;
    Unity_Voronoi_half(_TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3, 2, _Property_16aca43bd4a523838b4f761bd9f4c2ca_Out_0, _Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3, _Voronoi_e10929a14a87048a9eecbfc7564c4905_Cells_4);
    half _Property_ed3556ffdfba828f97197527de49d22a_Out_0 = Vector1_A1231BEA;
    half _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2;
    Unity_Power_half(_Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3, _Property_ed3556ffdfba828f97197527de49d22a_Out_0, _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2);
    half _Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2;
    Unity_Multiply_half(_GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2, _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2, _Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2);
    half4 _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2;
    Unity_Multiply_half(_SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0, (_Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2.xxxx), _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2);
    half4 _Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2;
    Unity_Multiply_half(_Property_81cad936ff5a8387a368e496adbd9e8d_Out_0, _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2, _Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2);
    surface.BaseColor = (_Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2.xyz);
    surface.Alpha = (_Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2).x;
    surface.NormalTS = IN.TangentSpaceNormal;
    return surface;
}

// --------------------------------------------------
// Build Graph Inputs

VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
{
    VertexDescriptionInputs output;
    ZERO_INITIALIZE(VertexDescriptionInputs, output);

    output.ObjectSpaceNormal = input.normalOS;
    output.ObjectSpaceTangent = input.tangentOS.xyz;
    output.ObjectSpacePosition = input.positionOS;

    return output;
}
    SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
{
    SurfaceDescriptionInputs output;
    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);



    output.TangentSpaceNormal = float3(0.0f, 0.0f, 1.0f);


    output.uv0 = input.texCoord0;
    output.TimeParameters = _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
#if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
#define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
#else
#define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
#endif
#undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN

    return output;
}

    // --------------------------------------------------
    // Main

    #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteNormalPass.hlsl"

    ENDHLSL
}
Pass
{
    Name "Sprite Forward"
    Tags
    {
        "LightMode" = "UniversalForward"
    }

        // Render State
        Cull Off
    Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
    ZTest LEqual
    ZWrite Off

        // Debug
        // <None>

        // --------------------------------------------------
        // Pass

        HLSLPROGRAM

        // Pragmas
        #pragma target 2.0
    #pragma exclude_renderers d3d11_9x
    #pragma vertex vert
    #pragma fragment frag

        // DotsInstancingOptions: <None>
        // HybridV1InjectedBuiltinProperties: <None>

        // Keywords
        // PassKeywords: <None>
        // GraphKeywords: <None>

        // Defines
        #define _SURFACE_TYPE_TRANSPARENT 1
        #define ATTRIBUTES_NEED_NORMAL
        #define ATTRIBUTES_NEED_TANGENT
        #define ATTRIBUTES_NEED_TEXCOORD0
        #define ATTRIBUTES_NEED_COLOR
        #define VARYINGS_NEED_TEXCOORD0
        #define VARYINGS_NEED_COLOR
        #define FEATURES_GRAPH_VERTEX
        /* WARNING: $splice Could not find named fragment 'PassInstancing' */
        #define SHADERPASS SHADERPASS_SPRITEFORWARD
        /* WARNING: $splice Could not find named fragment 'DotsInstancingVars' */

        // Includes
        #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Texture.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/TextureStack.hlsl"
    #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

        // --------------------------------------------------
        // Structs and Packing

        struct Attributes
    {
        float3 positionOS : POSITION;
        float3 normalOS : NORMAL;
        float4 tangentOS : TANGENT;
        float4 uv0 : TEXCOORD0;
        float4 color : COLOR;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : INSTANCEID_SEMANTIC;
        #endif
    };
    struct Varyings
    {
        float4 positionCS : SV_POSITION;
        float4 texCoord0;
        float4 color;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : CUSTOM_INSTANCE_ID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
        #endif
    };
    struct SurfaceDescriptionInputs
    {
        float3 TangentSpaceNormal;
        float4 uv0;
        float3 TimeParameters;
    };
    struct VertexDescriptionInputs
    {
        float3 ObjectSpaceNormal;
        float3 ObjectSpaceTangent;
        float3 ObjectSpacePosition;
    };
    struct PackedVaryings
    {
        float4 positionCS : SV_POSITION;
        float4 interp0 : TEXCOORD0;
        float4 interp1 : TEXCOORD1;
        #if UNITY_ANY_INSTANCING_ENABLED
        uint instanceID : CUSTOM_INSTANCE_ID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        uint stereoTargetEyeIndexAsBlendIdx0 : BLENDINDICES0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        uint stereoTargetEyeIndexAsRTArrayIdx : SV_RenderTargetArrayIndex;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        FRONT_FACE_TYPE cullFace : FRONT_FACE_SEMANTIC;
        #endif
    };

        PackedVaryings PackVaryings(Varyings input)
    {
        PackedVaryings output;
        output.positionCS = input.positionCS;
        output.interp0.xyzw = input.texCoord0;
        output.interp1.xyzw = input.color;
        #if UNITY_ANY_INSTANCING_ENABLED
        output.instanceID = input.instanceID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        output.cullFace = input.cullFace;
        #endif
        return output;
    }
    Varyings UnpackVaryings(PackedVaryings input)
    {
        Varyings output;
        output.positionCS = input.positionCS;
        output.texCoord0 = input.interp0.xyzw;
        output.color = input.interp1.xyzw;
        #if UNITY_ANY_INSTANCING_ENABLED
        output.instanceID = input.instanceID;
        #endif
        #if (defined(UNITY_STEREO_MULTIVIEW_ENABLED)) || (defined(UNITY_STEREO_INSTANCING_ENABLED) && (defined(SHADER_API_GLES3) || defined(SHADER_API_GLCORE)))
        output.stereoTargetEyeIndexAsBlendIdx0 = input.stereoTargetEyeIndexAsBlendIdx0;
        #endif
        #if (defined(UNITY_STEREO_INSTANCING_ENABLED))
        output.stereoTargetEyeIndexAsRTArrayIdx = input.stereoTargetEyeIndexAsRTArrayIdx;
        #endif
        #if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
        output.cullFace = input.cullFace;
        #endif
        return output;
    }

    // --------------------------------------------------
    // Graph

    // Graph Properties
    CBUFFER_START(UnityPerMaterial)
float4 Texture2D_1DEA466A_TexelSize;
half4 Color_2FFD2910;
half Vector1_513A17E5;
half Vector1_5FD77B36;
half Vector1_A1231BEA;
half2 Vector2_C646D0BC;
half Vector1_FA1ECC98;
half2 Vector2_2A63689;
half Vector1_9C91A495;
half Vector1_9d8cdff47a2d4d8296101a44f8b8cd90;
CBUFFER_END

// Object and Global properties
SAMPLER(SamplerState_Linear_Repeat);
TEXTURE2D(Texture2D_1DEA466A);
SAMPLER(samplerTexture2D_1DEA466A);

// Graph Functions

void Unity_Multiply_half(half2 A, half2 B, out half2 Out)
{
    Out = A * B;
}

void Unity_TilingAndOffset_half(half2 UV, half2 Tiling, half2 Offset, out half2 Out)
{
    Out = UV * Tiling + Offset;
}


half2 Unity_GradientNoise_Dir_half(half2 p)
{
    // Permutation and hashing used in webgl-nosie goo.gl/pX7HtC
    p = p % 289;
    // need full precision, otherwise half overflows when p > 1
    float x = float(34 * p.x + 1) * p.x % 289 + p.y;
    x = (34 * x + 1) * x % 289;
    x = frac(x / 41) * 2 - 1;
    return normalize(half2(x - floor(x + 0.5), abs(x) - 0.5));
}

void Unity_GradientNoise_half(half2 UV, half Scale, out half Out)
{
    half2 p = UV * Scale;
    half2 ip = floor(p);
    half2 fp = frac(p);
    half d00 = dot(Unity_GradientNoise_Dir_half(ip), fp);
    half d01 = dot(Unity_GradientNoise_Dir_half(ip + half2(0, 1)), fp - half2(0, 1));
    half d10 = dot(Unity_GradientNoise_Dir_half(ip + half2(1, 0)), fp - half2(1, 0));
    half d11 = dot(Unity_GradientNoise_Dir_half(ip + half2(1, 1)), fp - half2(1, 1));
    fp = fp * fp * fp * (fp * (fp * 6 - 15) + 10);
    Out = lerp(lerp(d00, d01, fp.y), lerp(d10, d11, fp.y), fp.x) + 0.5;
}

void Unity_Lerp_half4(half4 A, half4 B, half4 T, out half4 Out)
{
    Out = lerp(A, B, T);
}


inline half2 Unity_Voronoi_RandomVector_half(half2 UV, half offset)
{
    half2x2 m = half2x2(15.27, 47.63, 99.41, 89.98);
    UV = frac(sin(mul(UV, m)));
    return half2(sin(UV.y * +offset) * 0.5 + 0.5, cos(UV.x * offset) * 0.5 + 0.5);
}

void Unity_Voronoi_half(half2 UV, half AngleOffset, half CellDensity, out half Out, out half Cells)
{
    half2 g = floor(UV * CellDensity);
    half2 f = frac(UV * CellDensity);
    half t = 8.0;
    half3 res = half3(8.0, 0.0, 0.0);

    for (int y = -1; y <= 1; y++)
    {
        for (int x = -1; x <= 1; x++)
        {
            half2 lattice = half2(x,y);
            half2 offset = Unity_Voronoi_RandomVector_half(lattice + g, AngleOffset);
            half d = distance(lattice + offset, f);

            if (d < res.x)
            {
                res = half3(d, offset.x, offset.y);
                Out = res.x;
                Cells = res.y;
            }
        }
    }
}

void Unity_Power_half(half A, half B, out half Out)
{
    Out = pow(A, B);
}

void Unity_Multiply_half(half A, half B, out half Out)
{
    Out = A * B;
}

void Unity_Multiply_half(half4 A, half4 B, out half4 Out)
{
    Out = A * B;
}

// Graph Vertex
struct VertexDescription
{
    half3 Position;
    half3 Normal;
    half3 Tangent;
};

VertexDescription VertexDescriptionFunction(VertexDescriptionInputs IN)
{
    VertexDescription description = (VertexDescription)0;
    description.Position = IN.ObjectSpacePosition;
    description.Normal = IN.ObjectSpaceNormal;
    description.Tangent = IN.ObjectSpaceTangent;
    return description;
}

// Graph Pixel
struct SurfaceDescription
{
    half3 BaseColor;
    half Alpha;
    half3 NormalTS;
};

SurfaceDescription SurfaceDescriptionFunction(SurfaceDescriptionInputs IN)
{
    SurfaceDescription surface = (SurfaceDescription)0;
    half4 _Property_81cad936ff5a8387a368e496adbd9e8d_Out_0 = IsGammaSpace() ? LinearToSRGB(Color_2FFD2910) : Color_2FFD2910;
    UnityTexture2D _Property_c75efda14cf48b8f8c473b7010b824f4_Out_0 = UnityBuildTexture2DStructNoScale(Texture2D_1DEA466A);
    half4 _UV_2d78784b1be08885a74c57a69c16f29d_Out_0 = IN.uv0;
    half2 _Property_7c312fdf0080ff80ab5def9b29e23884_Out_0 = Vector2_2A63689;
    half2 _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2;
    Unity_Multiply_half((IN.TimeParameters.x.xx), _Property_7c312fdf0080ff80ab5def9b29e23884_Out_0, _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2);
    half2 _TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3;
    Unity_TilingAndOffset_half(IN.uv0.xy, half2 (1, 1), _Multiply_d27c8a78af87d488ba000b7dd3a80f24_Out_2, _TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3);
    half _Property_a98ea410d15f0a83860d9771b1fc6b84_Out_0 = Vector1_9C91A495;
    half _GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2;
    Unity_GradientNoise_half(_TilingAndOffset_f5ff97250236ab8da2f85d8644019610_Out_3, _Property_a98ea410d15f0a83860d9771b1fc6b84_Out_0, _GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2);
    half _Property_4c77ca82f0fbe787bb473d879fdade21_Out_0 = Vector1_513A17E5;
    half4 _Lerp_278354e1b8749981959144aa87c5b3b2_Out_3;
    Unity_Lerp_half4(_UV_2d78784b1be08885a74c57a69c16f29d_Out_0, (_GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2.xxxx), (_Property_4c77ca82f0fbe787bb473d879fdade21_Out_0.xxxx), _Lerp_278354e1b8749981959144aa87c5b3b2_Out_3);
    half4 _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0 = SAMPLE_TEXTURE2D(_Property_c75efda14cf48b8f8c473b7010b824f4_Out_0.tex, _Property_c75efda14cf48b8f8c473b7010b824f4_Out_0.samplerstate, (_Lerp_278354e1b8749981959144aa87c5b3b2_Out_3.xy));
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_R_4 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.r;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_G_5 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.g;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_B_6 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.b;
    half _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_A_7 = _SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0.a;
    half2 _Property_3e5ec6e7f730f68fad4f88166b52fe2b_Out_0 = Vector2_C646D0BC;
    half2 _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2;
    Unity_Multiply_half((IN.TimeParameters.x.xx), _Property_3e5ec6e7f730f68fad4f88166b52fe2b_Out_0, _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2);
    half2 _TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3;
    Unity_TilingAndOffset_half(IN.uv0.xy, half2 (1, 1), _Multiply_04398aa47a59278b80784a185a60a6ab_Out_2, _TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3);
    half _Property_16aca43bd4a523838b4f761bd9f4c2ca_Out_0 = Vector1_FA1ECC98;
    half _Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3;
    half _Voronoi_e10929a14a87048a9eecbfc7564c4905_Cells_4;
    Unity_Voronoi_half(_TilingAndOffset_18072a7c5799ae878a59327a63c7782a_Out_3, 2, _Property_16aca43bd4a523838b4f761bd9f4c2ca_Out_0, _Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3, _Voronoi_e10929a14a87048a9eecbfc7564c4905_Cells_4);
    half _Property_ed3556ffdfba828f97197527de49d22a_Out_0 = Vector1_A1231BEA;
    half _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2;
    Unity_Power_half(_Voronoi_e10929a14a87048a9eecbfc7564c4905_Out_3, _Property_ed3556ffdfba828f97197527de49d22a_Out_0, _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2);
    half _Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2;
    Unity_Multiply_half(_GradientNoise_4c57b9c3f34ec68abe744fbbbe420fcb_Out_2, _Power_0cf6a8e372561b8e812a7fe8b73b627d_Out_2, _Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2);
    half4 _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2;
    Unity_Multiply_half(_SampleTexture2D_9a35c0d28270ad8e9116322a8e90273e_RGBA_0, (_Multiply_7ea41c04c6546c8cbe2d80d6a50daaaf_Out_2.xxxx), _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2);
    half4 _Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2;
    Unity_Multiply_half(_Property_81cad936ff5a8387a368e496adbd9e8d_Out_0, _Multiply_4979d5512c5f9d899340dc1b3f8fd060_Out_2, _Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2);
    surface.BaseColor = (_Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2.xyz);
    surface.Alpha = (_Multiply_20f24fb17414d58a9a0e799b8e27b136_Out_2).x;
    surface.NormalTS = IN.TangentSpaceNormal;
    return surface;
}

// --------------------------------------------------
// Build Graph Inputs

VertexDescriptionInputs BuildVertexDescriptionInputs(Attributes input)
{
    VertexDescriptionInputs output;
    ZERO_INITIALIZE(VertexDescriptionInputs, output);

    output.ObjectSpaceNormal = input.normalOS;
    output.ObjectSpaceTangent = input.tangentOS.xyz;
    output.ObjectSpacePosition = input.positionOS;

    return output;
}
    SurfaceDescriptionInputs BuildSurfaceDescriptionInputs(Varyings input)
{
    SurfaceDescriptionInputs output;
    ZERO_INITIALIZE(SurfaceDescriptionInputs, output);



    output.TangentSpaceNormal = float3(0.0f, 0.0f, 1.0f);


    output.uv0 = input.texCoord0;
    output.TimeParameters = _TimeParameters.xyz; // This is mainly for LW as HD overwrite this value
#if defined(SHADER_STAGE_FRAGMENT) && defined(VARYINGS_NEED_CULLFACE)
#define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN output.FaceSign =                    IS_FRONT_VFACE(input.cullFace, true, false);
#else
#define BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN
#endif
#undef BUILD_SURFACE_DESCRIPTION_INPUTS_OUTPUT_FACESIGN

    return output;
}

    // --------------------------------------------------
    // Main

    #include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/ShaderPass.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/Varyings.hlsl"
#include "Packages/com.unity.render-pipelines.universal/Editor/ShaderGraph/Includes/SpriteForwardPass.hlsl"

    ENDHLSL
}
    }
        FallBack "Hidden/Shader Graph/FallbackError"
}