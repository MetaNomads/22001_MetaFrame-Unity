void InstancedParticles_float (
    float3          PositionOS,
    out real3       PositionOS_o
)
{
    PositionOS_o = PositionOS;
}

////////////////////////////////

#if defined(UNITY_PROCEDURAL_INSTANCING_ENABLED)
    #define UNITY_PARTICLE_INSTANCING_ENABLED
#endif

#if defined(UNITY_PARTICLE_INSTANCING_ENABLED)

    #ifndef UNITY_PARTICLE_INSTANCE_DATA
        #define UNITY_PARTICLE_INSTANCE_DATA DefaultParticleInstanceData
    #endif

    struct DefaultParticleInstanceData
    {
        float3x4 transform;
        uint color;
        float animFrame;
    };

    StructuredBuffer<UNITY_PARTICLE_INSTANCE_DATA> unity_ParticleInstanceData;
    float4 unity_ParticleUVShiftData;
    float unity_ParticleUseMeshColors;


    #ifdef unity_ObjectToWorld
        #undef unity_ObjectToWorld
    #endif
    #ifdef unity_WorldToObject
        #undef unity_WorldToObject
    #endif


    void vertInstancingMatrices(out float4x4 objectToWorld, out float4x4 worldToObject)
    {
        UNITY_PARTICLE_INSTANCE_DATA data = unity_ParticleInstanceData[unity_InstanceID];

        // transform matrix
        objectToWorld._11_21_31_41 = float4(data.transform._11_21_31, 0.0f);
        objectToWorld._12_22_32_42 = float4(data.transform._12_22_32, 0.0f);
        objectToWorld._13_23_33_43 = float4(data.transform._13_23_33, 0.0f);
        objectToWorld._14_24_34_44 = float4(data.transform._14_24_34, 1.0f);

        // inverse transform matrix
        worldToObject = 0;
        
        // UNITY_BRANCH if(_NeedsWorldToObjectMatrix)
        // {
        //     float3x3 w2oRotation;
        //     w2oRotation[0] = objectToWorld[1].yzx * objectToWorld[2].zxy - objectToWorld[1].zxy * objectToWorld[2].yzx;
        //     w2oRotation[1] = objectToWorld[0].zxy * objectToWorld[2].yzx - objectToWorld[0].yzx * objectToWorld[2].zxy;
        //     w2oRotation[2] = objectToWorld[0].yzx * objectToWorld[1].zxy - objectToWorld[0].zxy * objectToWorld[1].yzx;

        //     float det = dot(objectToWorld[0].xyz, w2oRotation[0]);

        //     w2oRotation = transpose(w2oRotation);

        //     w2oRotation *= rcp(det);

        //     float3 w2oPosition = mul(w2oRotation, -objectToWorld._14_24_34);

        //     worldToObject._11_21_31_41 = float4(w2oRotation._11_21_31, 0.0f);
        //     worldToObject._12_22_32_42 = float4(w2oRotation._12_22_32, 0.0f);
        //     worldToObject._13_23_33_43 = float4(w2oRotation._13_23_33, 0.0f);
        //     worldToObject._14_24_34_44 = float4(w2oPosition, 1.0f);
        // }
        
    }

    void vertInstancingSetup()
    {
    //  We can't use UNITY_MATRIX_M, UNITY_MATRIX_I_M as the compiler throws errors.
    //  In order to use unity_ObjectToWorld, unity_WorldToObject we have to undef them.
        //vertInstancingMatrices(UNITY_MATRIX_M, UNITY_MATRIX_I_M);
        vertInstancingMatrices(unity_ObjectToWorld, unity_WorldToObject);
    }

    void vertInstancingColor(inout real4 color)
    {
    #ifndef UNITY_PARTICLE_INSTANCE_DATA_NO_COLOR
        UNITY_PARTICLE_INSTANCE_DATA data = unity_ParticleInstanceData[unity_InstanceID];
        color = lerp(real4(1.0f, 1.0f, 1.0f, 1.0f), color, unity_ParticleUseMeshColors);
        color *= float4(data.color & 255, (data.color >> 8) & 255, (data.color >> 16) & 255, (data.color >> 24) & 255) * (1.0f / 255);
    #endif
    }
#else
    void vertInstancingSetup(){};
    void vertInstancingColor(inout real4 color){};
#endif

// ////////////////////////////////////