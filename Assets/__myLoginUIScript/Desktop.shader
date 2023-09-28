// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Desktop"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_TransparentColourKey ("Transparent Color Key", Color) = (0,0,0,1)
		_TransparencyTolerance ("Transparency Tolerance", Float) = 0.01
	}
	SubShader
	{
		Pass
		{
			Tags{ "RenderType" = "Opaque" }
			LOD 200

			CGPROGRAM
			#pragma vertex vert//定义顶点函数名
			#pragma fragment frag//定义片元函数名
			#include "UnityCG.cginc"

			struct a2v 
			{
				float4 pos : POSITION;//获取模型的顶点坐标
				float2 uv : TEXCOORD0;//用模型的第一套纹理坐标填充
			};

			struct v2f
			{
				float4 pos : SV_POSITION;//获取剪裁空间下的顶点坐标
				float2 uv : TEXCOORD0;//用模型的第一套纹理坐标填充
			};
			//顶点函数
			v2f vert(a2v input)
			{
				v2f output;
				output.pos = UnityObjectToClipPos(input.pos);//UnityObjectToClipPos等价于：mul(UNITY_MATRIX_MVP, float4(pos, 1.0)), 用来进行矩阵转换
				output.uv = input.uv;
				return output;
			}

			sampler2D _MainTex;
			float3 _TransparentColourKey;
			float _TransparencyTolerance;
			//片元函数
			float4 frag(v2f input) : SV_Target
			{
				//决定渲染什么颜色?获取屏幕上每个点的颜色
				float4 colour = tex2D(_MainTex, input.uv);

				//从选择的每个组件中计算透明颜色
				float deltaR = abs(colour.r - _TransparentColourKey.r);
				float deltaG = abs(colour.g - _TransparentColourKey.g);
				float deltaB = abs(colour.b - _TransparentColourKey.b);
				//如果颜色和透明色没有差别,就返回透明像素
				if (deltaR < _TransparencyTolerance && deltaG < _TransparencyTolerance && deltaB < _TransparencyTolerance)
				{
					return float4(0.0f, 0.0f, 0.0f, 0.0f);
				}

				return colour;
			}

			ENDCG
		}
	}
}
