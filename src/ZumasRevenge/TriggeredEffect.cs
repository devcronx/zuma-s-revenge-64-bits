using System;
using SexyFramework.PIL;

namespace ZumasRevenge
{
	public class TriggeredEffect
	{
		public TriggeredEffect(bool create)
		{
			if (create)
			{
				this.mRings = new global::SexyFramework.PIL.System(50, 50);
				this.mRings.mHighWatermark = Common._M(80);
				this.mRings.mLowWatermark = Common._M(60);
				this.mRings.mFPSCallback = new global::SexyFramework.PIL.System.FPSCallback(global::SexyFramework.PIL.System.FadeParticlesFPSCallback);
				this.mRings.mScale = Common._S(1f);
				this.mRings.WaitForEmitters(true);
				this.mRainbow = new global::SexyFramework.PIL.System(50, 50);
				this.mRainbow.mHighWatermark = Common._M(80);
				this.mRainbow.mLowWatermark = Common._M(60);
				this.mRainbow.mFPSCallback = new global::SexyFramework.PIL.System.FPSCallback(global::SexyFramework.PIL.System.FadeParticlesFPSCallback);
				this.mRainbow.mScale = Common._S(1f);
				this.mRainbow.WaitForEmitters(true);
				this.mGas = new global::SexyFramework.PIL.System(50, 50);
				this.mGas.mHighWatermark = Common._M(80);
				this.mGas.mLowWatermark = Common._M(60);
				this.mGas.mFPSCallback = new global::SexyFramework.PIL.System.FPSCallback(global::SexyFramework.PIL.System.FadeParticlesFPSCallback);
				this.mGas.mScale = Common._S(1f);
				this.mGas.WaitForEmitters(true);
				this.mFlare = new global::SexyFramework.PIL.System(50, 50);
				this.mFlare.mHighWatermark = Common._M(80);
				this.mFlare.mLowWatermark = Common._M(60);
				this.mFlare.mFPSCallback = new global::SexyFramework.PIL.System.FPSCallback(global::SexyFramework.PIL.System.FadeParticlesFPSCallback);
				this.mFlare.mScale = Common._S(1f);
				this.mFlare.WaitForEmitters(true);
				this.mTrail = new global::SexyFramework.PIL.System(150, 50);
				this.mTrail.mHighWatermark = Common._M(80);
				this.mTrail.mLowWatermark = Common._M(60);
				this.mTrail.mFPSCallback = new global::SexyFramework.PIL.System.FPSCallback(global::SexyFramework.PIL.System.FadeParticlesFPSCallback);
				this.mTrail.mScale = Common._S(1f);
				this.mTrail.WaitForEmitters(true);
			}
		}

		public TriggeredEffect()
			: this(true)
		{
		}

		public virtual void Dispose()
		{
			if (this.mRings != null)
			{
				this.mRings.Dispose();
				this.mRings = null;
			}
			if (this.mRainbow != null)
			{
				this.mRainbow.Dispose();
				this.mRainbow = null;
			}
			if (this.mGas != null)
			{
				this.mGas.Dispose();
				this.mGas = null;
			}
			if (this.mFlare != null)
			{
				this.mFlare.Dispose();
				this.mFlare = null;
			}
			if (this.mTrail != null)
			{
				this.mTrail.Dispose();
				this.mTrail = null;
			}
		}

		public global::SexyFramework.PIL.System mRings;

		public global::SexyFramework.PIL.System mRainbow;

		public global::SexyFramework.PIL.System mGas;

		public global::SexyFramework.PIL.System mFlare;

		public global::SexyFramework.PIL.System mTrail;
	}
}
