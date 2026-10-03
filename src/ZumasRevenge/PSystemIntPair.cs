using System;
using SexyFramework.PIL;

namespace ZumasRevenge
{
	public class PSystemIntPair
	{
		public PSystemIntPair()
		{
		}

		public PSystemIntPair(global::SexyFramework.PIL.System f, int s)
		{
			this.first = f;
			this.second = s;
		}

		public global::SexyFramework.PIL.System first;

		public int second;
	}
}
