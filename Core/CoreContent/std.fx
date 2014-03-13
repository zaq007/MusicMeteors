float modifer; // случаное число

sampler TextureSampler : register(s0);

float4 main(float4 color : COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{	
    float4 output = tex2D(TextureSampler, texCoord);

    float greyscale = dot(output.rgb, float3(0.3, 0.59, 0.11));

    if(greyscale > 0.2)
    {
        color *= 1 + (modifer*greyscale / 1.5);
        if(greyscale > 0.8)
        { color *= 1 + (modifer*2); }
    }

    return color * output;
}

technique BackgroundShader
{
    pass DefaultPass
    {
        PixelShader = compile ps_2_0 main();
    }
}