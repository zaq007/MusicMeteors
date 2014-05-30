texture displacementMap; // наша карта

sampler TextureSampler : register(s0); // тут та текстура, которая отрисовалась на экран
sampler DisplacementSampler : samplerState{ // устанавливаем TextureAddress
Texture = displacementMap;
MinFilter = Point;
MagFilter = Point;
AddressU = Clamp;
AddressV = Clamp;

};

float4 main(float4 color : COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{
    
   /* PIXEL DISTORTION BY DISPLACEMENT MAP */
    float4 displacement = tex2D(DisplacementSampler, texCoord); // получаем R,G,B из карты
    
    // Offset the main texture coordinates.
    texCoord.x += displacement.a * 0.1; // меняем позицию пикселя
    texCoord.y += displacement.a * 0.1; // меняем позицию пикселя


   float4 output = tex2D(TextureSampler, texCoord); // получаем цвет для нашей текстуры

    return color * output;
}

technique DistortionPosteffect
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 main(); // компилируем шейдер
    }
}