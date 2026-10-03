using System;
using SexyFramework;
using Common = SexyFramework.Common;

namespace JeffLib
{
	public class AlphaFader
	{
		public void Update()
		{
			this.mColor.mAlpha += this.mFadeRate;
			if (global::SexyFramework.Common._geq(this.mColor.mAlpha, (float)this.mMax) && this.mFadeRate > 0f)
			{
				this.mColor.mAlpha = (float)this.mMax;
				this.mFadeRate *= -1f;
				this.mFadeCount++;
				return;
			}
			if (global::SexyFramework.Common._leq(this.mColor.mAlpha, (float)this.mMin) && this.mFadeRate < 0f)
			{
				this.mColor.mAlpha = (float)this.mMin;
				this.mFadeRate *= -1f;
				this.mFadeCount++;
			}
		}

		public FColor mColor;

		public float mFadeRate;

		public int mFadeCount;

		public int mMin;

		public int mMax = 255;
	}
}
