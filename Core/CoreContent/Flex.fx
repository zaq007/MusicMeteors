texture displacementMap; // ���� �����

sampler TextureSampler : register(s0); // ��� �� ��������, ������� ������������ �� �����
sampler DisplacementSampler : samplerState{ // ������������� TextureAddress
Texture = displacementMap;
MinFilter = Point;
MagFilter = Point;
AddressU = Clamp;
AddressV = Clamp;

};

float4 main(float4 color : COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{
    
   /* PIXEL DISTORTION BY DISPLACEMENT MAP */
    float4 displacement = tex2D(DisplacementSampler, texCoord); // �������� R,G,B �� �����
    
    // Offset the main texture coordinates.
    texCoord.x += displacement.a * 0.1; // ������ ������� �������
    texCoord.y += displacement.a * 0.1; // ������ ������� �������


   float4 output = tex2D(TextureSampler, texCoord); // �������� ���� ��� ����� ��������

    return color * output;
}

technique DistortionPosteffect
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 main(); // ����������� ������
    }
}