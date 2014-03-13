texture bloomMap;

sampler TextureSampler : register(s0);

sampler BloomSampler : samplerState
{
    Texture = bloomMap;
    MinFilter = Linear;
    MagFilter = Linear;
    AddressU = Clamp;
    AddressV = Clamp;
}; 

// ѕсевдо-гауусово размытие
const float2 offsets[12] = { 
 -0.126212, -0.205805, 
 -0.640144, 0.173580, 
 -0.495914,   0.257137, 
 -0.003345,   0.420716, 
  0.762340, 0.094983, 
  0.273434, -0.280026, 
  0.319456,   0.567022, 
  -0.185461, -0.693124, 
  0.307431,   0.064425, 
  0.696420,   0.212458, 
 -0.121940, -0.732615, 
 -0.591559, -0.397705, 
}; 

const float2 offsets1[12] = { 
 -0.326212, -0.405805, 
 -0.840144, -0.073580, 
 -0.695914,   0.457137, 
 -0.203345,   0.620716, 
  0.962340, -0.194983, 
  0.473434, -0.480026, 
  0.519456,   0.767022, 
  0.185461, -0.893124, 
  0.507431,   0.064425, 
  0.896420,   0.412458, 
 -0.321940, -0.932615, 
 -0.791559, -0.597705, 
}; 
float4 AdjustSaturation(float4 color, float saturation) { 
  float grey = dot(color, float3(0.3, 0.59, 0.11)); 
  
  return lerp(grey, color, saturation); 
} 

float4 main(float4 color : COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{
  float BlurPower = 0.01; // 0.01
  float BaseIntensity = 1;
  float BloomIntensity = 0.4; // 0.4
  float BaseSaturation = 1;
  float BloomSaturation = 1;

  float4 original = tex2D(TextureSampler, texCoord); 
  
  // размытие
  float4 sum = tex2D(BloomSampler, texCoord); 
  for(int i = 0; i < 12; i++){ 
    sum += tex2D(BloomSampler, texCoord + BlurPower * offsets[i]); 
  } 
  sum /= 13; 
  
  original = AdjustSaturation(original, BaseSaturation) * BaseIntensity; 
  sum = AdjustSaturation(sum, BloomSaturation) * BloomIntensity; 
  
  return sum + original; 
}

technique BloomEffect
{
    pass DefaultPass
    {
        PixelShader = compile ps_2_0 main();
    }
}